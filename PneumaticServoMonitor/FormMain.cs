using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Opc.Ua;
using OpcUaHelper;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.IO;
using Gecko;
using System.Linq;

namespace PneumaticServoMonitor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //var progressBar = new MyProgressBar()
            //{
            //    Location = new Point(20, Bottom - 150),
            //    Size = new Size(Width - 60, 50),
            //    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            //};
            progressBar = new MyProgressBar();
            progressBar.Dock = DockStyle.Fill;
            panel_ProgressBar.Controls.Add(progressBar);

            //var timer = new System.Windows.Forms.Timer { Interval = 150 };
            //timer.Tick += (s, e) => progressBar.Value = progressBar.Value % 100 + 1;
            //timer.Start();
        }

        MyProgressBar progressBar;
        public FormSetting mFormSetting;
        public static OpcUaClient m_OpcUaClient;
        public static OpcUaClient m_OpcUaClient2;
        public static string ProjectName;
        public static string ProjectNumber;
        public static string SampleNumber;
        public static string strRecipe;
        private static string iniPath = "config.ini";
        IniFile ini_errorlist = new IniFile(iniPath);
        public int periodIndex = 0;
        public int startTimes = 0;//同一样品编号启动了几次
        System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();

        class chartPoints
        {
            public chartPoints(DateTime mx, double my)
            {

                //x = (mx.DayOfYear - 1 == 0 ? "" : (mx.DayOfYear - 1).ToString() + "d")
                //    + (mx.Hour == 0 ? "" : mx.Hour.ToString() + "h")
                //    + (mx.Minute == 0 ? "" : mx.Minute.ToString() + "m")
                //    + (mx.Second == 0 ? "" : mx.Second.ToString() + "s")
                //    + mx.Millisecond.ToString() + "ms";
                x = (mx.DayOfYear - 1 == 0 ? "" : (mx.DayOfYear - 1).ToString() + ":")
                   + (mx.Hour == 0 ? "" : mx.Hour.ToString() + ":")
                   + (mx.Minute == 0 ? "" : mx.Minute.ToString() + ":")
                   + (mx.Second == 0 ? "" : mx.Second.ToString() + ".")
                   + mx.Millisecond.ToString("000");
                y = my;
            }
            public string x { get; set; }
            public double y { get; set; }
        }
        Queue<chartPoints> Queue_Chart = new Queue<chartPoints>();
        Queue<chartPoints> Queue_Chart_Show = new Queue<chartPoints>();
        Queue<chartPoints> Queue_Chart2 = new Queue<chartPoints>();
        Queue<chartPoints> Queue_Chart_Show2 = new Queue<chartPoints>();
        private static readonly object SequenceLock = new object();
        private static readonly object SequenceLock2 = new object();
        int SamplingCount_Cycle = 10;        
        long n_Index = 0;
        long n_Index2 = 0;
        DateTime timestamp = new DateTime();
        double Peak_AVE, Peak_MAX, Peak_MIN;
        double Valley_AVE, Valley_MAX, Valley_MIN;
        double Peak_AVE1, Peak_MAX1, Peak_MIN1;
        double Valley_AVE1, Valley_MAX1, Valley_MIN1;
        double A_Max, A_Min, B_Max, B_Min;
        #region ini文件中的参数&对应变量
        public static string plcIP
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("plcIP", "network"))
                    {
                        return null;
                    }
                    string mIP = ini.Read("plcIP", "network");
                    try
                    {
                        return mIP;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("plcIP", value, "network");
                }
            }
        }
        public static string plcWebSite
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("plcWebSite", "network"))
                    {
                        return null;
                    }
                    string mIP = ini.Read("plcWebSite", "network");
                    try
                    {
                        return mIP;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("plcWebSite", value, "network");
                }
            }
        }
        public static string plcName
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("plcName", "network"))
                    {
                        return "";
                    }
                    string mIP = ini.Read("plcName", "network");
                    try
                    {
                        return mIP;
                    }
                    catch (Exception)
                    {
                        return "";
                    }

                }
                return "";
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("plcName", value, "network");
                }
            }
        }

        #region 保存数据相关参数
        public static string saveFile_path
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("path", "saveFile"))
                    {
                        return "";
                    }
                    string mIP = ini.Read("path", "saveFile");
                    try
                    {
                        return mIP;
                    }
                    catch (Exception)
                    {
                        return "";
                    }

                }
                return "";
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("path", value, "saveFile");
                }
            }
        }
        public string folderNmae;
        public static int saveFile_type
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("type", "saveFile"))
                    {
                        return 0;
                    }
                    string mIP = ini.Read("type", "saveFile");
                    try
                    {
                        return Convert.ToInt32(mIP);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("type", value.ToString(), "saveFile");
                }
            }
        }

        public static int saveFile_Frequency
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Frequency", "saveFile"))
                    {
                        return 0;
                    }
                    string mIP = ini.Read("Frequency", "saveFile");
                    try
                    {
                        return Convert.ToInt32(mIP);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Frequency", value.ToString(), "saveFile");
                }
            }
        }

        public static int saveFile_DataMemory
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DataMemory", "saveFile"))
                    {
                        return 0;
                    }
                    string mIP = ini.Read("DataMemory", "saveFile");
                    try
                    {
                        return Convert.ToInt32(mIP);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DataMemory", value.ToString(), "saveFile");
                }
            }
        }
        #endregion
        public static string sysPrefixNodeID
        {
            get
            {
                if (plcName == "VTEM")
                {
                    return sysPrefixNodeID_VTEM;
                }
                else
                {
                    return sysPrefixNodeID_MPYE;
                }
                //if (File.Exists(iniPath))
                //{
                //    IniFile ini = new IniFile(iniPath);
                //    if (!ini.KeyExists("PrefixNodeID", "system"))
                //    {
                //        return "";
                //    }
                //    string mStr = ini.Read("PrefixNodeID", "system");
                //    try
                //    {
                //        return mStr;
                //    }
                //    catch (Exception)
                //    {
                //        return "";
                //    }

                //}
                //return "";
            }
          
        }

        #region 系统参数
        public static float sysPositionOffset
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PositionOffset", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("PositionOffset", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("PositionOffset", value.ToString(), "system");
                }
            }
        }
        public static string sysPrefixNodeID_VTEM
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PrefixNodeID_VTEM", "system"))
                    {
                        return "";
                    }
                    string mStr = ini.Read("PrefixNodeID_VTEM", "system");
                    try
                    {
                        return mStr;
                    }
                    catch (Exception)
                    {
                        return "";
                    }

                }
                return "";
            }
           
        }
        public static string sysPrefixNodeID_MPYE
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PrefixNodeID_MPYE", "system"))
                    {
                        return "";
                    }
                    string mStr = ini.Read("PrefixNodeID_MPYE", "system");
                    try
                    {
                        return mStr;
                    }
                    catch (Exception)
                    {
                        return "";
                    }

                }
                return "";
            }
           
        }
        public static float sysCalForce1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalForce1", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("CalForce1", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalForce1", value.ToString(), "system");
                }
            }
        }
        public static float sysCalForce2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalForce2", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("CalForce2", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalForce2", value.ToString(), "system");
                }
            }
        }
        public static float sysCalVoltage1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalVoltage1", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("CalVoltage1", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalVoltage1", value.ToString(), "system");
                }
            }
        }
        public static float sysCalVoltage2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalVoltage2", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("CalVoltage2", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalVoltage2", value.ToString(), "system");
                }
            }
        }
        public static float sysDefCalForce1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalForce1", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("DefCalForce1", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalForce1", value.ToString(), "system");
                }
            }
        }
        public static float sysDefCalForce2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalForce2", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("DefCalForce2", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalForce2", value.ToString(), "system");
                }
            }
        }
        public static float sysDefCalVoltage1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalVoltage1", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("DefCalVoltage1", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalVoltage1", value.ToString(), "system");
                }
            }
        }
        public static float sysDefCalVoltage2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalVoltage2", "system"))
                    {
                        return 0;
                    }
                    string mStr = ini.Read("DefCalVoltage2", "system");
                    try
                    {
                        return Convert.ToSingle(mStr);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalVoltage2", value.ToString(), "system");
                }
            }
        }

        public static string NodeID_sysPositionOffset
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PositionOffset", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("PositionOffset", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("PositionOffset", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysCalForce1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalForce1", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CalForce1", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalForce1", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysCalForce2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalForce2", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CalForce2", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalForce2", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysCalVoltage1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalVoltage1", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CalVoltage1", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalVoltage1", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysCalVoltage2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CalVoltage2", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CalVoltage2", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CalVoltage2", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysDefCalForce1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalForce1", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DefCalForce1", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalForce1", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysDefCalForce2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalForce2", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DefCalForce2", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalForce2", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysDefCalVoltage1
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalVoltage1", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DefCalVoltage1", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalVoltage1", value.ToString(), "NodeID");
                }
            }
        }
        public static string NodeID_sysDefCalVoltage2
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DefCalVoltage2", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DefCalVoltage2", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DefCalVoltage2", value.ToString(), "NodeID");
                }
            }
        }

        #endregion

        #region 系统状态
        #region RunningFlag_R
        public static bool RunningFlag_R;
        public static string NodeID_RunningFlag
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("RunningFlag", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("RunningFlag", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("RunningFlag", value, "NodeID");
                }
            }
        }
        #endregion
        #region StopFlag_R
        public static bool StopFlag_R;
        public static string NodeID_StopFlag
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("StopFlag", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("StopFlag", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("StopFlag", value, "NodeID");
                }
            }
        }
        #endregion
        #region SystemError_R
        public static bool SystemError_R;
        public static string NodeID_SystemError
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("SystemError", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("SystemError", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("SystemError", value, "NodeID");
                }
            }
        }
        #endregion
        #region ErrorID_R
        public static int ErrorID_R;
        public static string NodeID_ErrorID
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ErrorID", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ErrorID", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ErrorID", value, "NodeID");
                }
            }
        }
        #endregion
        #endregion

        #region 控制
        #region ForceClear_W
        public static bool ForceClear_W;
        public static string NodeID_ForceClear
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ForceClear", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ForceClear", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ForceClear", value, "NodeID");
                }
            }
        }
        #endregion
        #region PositionClear_W
        public static bool PositionClear_W;
        public static string NodeID_PositionClear
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PositionClear", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("PositionClear", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("PositionClear", value, "NodeID");
                }
            }
        }
        #endregion
        #region TestStart_W
        public static bool TestStart_W;
        public static string NodeID_TestStart
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("TestStart", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("TestStart", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("TestStart", value, "NodeID");
                }
            }
        }
        #endregion
        #region TestStop_W
        public static bool TestStop_W;
        public static string NodeID_TestStop
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("TestStop", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("TestStop", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("TestStop", value, "NodeID");
                }
            }
        }
        #endregion
        #region TestEnable_W
        public static bool TestEnable_W;
        public static string NodeID_TestEnable
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("TestEnable", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("TestEnable", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("TestEnable", value, "NodeID");
                }
            }
        }
        #endregion
        #region EMG_W
        public static bool EMG_W;
        public static string NodeID_EMG
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("EMG", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("EMG", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("EMG", value, "NodeID");
                }
            }
        }
        #endregion
        #region FaultAck_W
        public static bool FaultAck_W;
        public static string NodeID_FaultAck
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("FaultAck", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("FaultAck", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("FaultAck", value, "NodeID");
                }
            }
        }
        #endregion
        #region HeartBit_W
        public static bool HeartBit_W;
        public static string NodeID_HeartBit
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("HeartBit", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("HeartBit", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("HeartBit", value, "NodeID");
                }
            }
        }
        #endregion
        #region CylinderUp_W
        public static bool CylinderUp_W;
        public static string NodeID_CylinderUp
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CylinderUp", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CylinderUp", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CylinderUp", value, "NodeID");
                }
            }
        }
        #endregion
        #region CylinderDown_W
        public static bool CylinderDown_W;
        public static string NodeID_CylinderDown
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CylinderDown", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CylinderDown", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CylinderDown", value, "NodeID");
                }
            }
        }
        #endregion
        #region CylinderSpeed_W
        public static int CylinderSpeed_W;
        public static string NodeID_CylinderSpeed
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CylinderSpeed", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CylinderSpeed", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CylinderSpeed", value, "NodeID");
                }
            }
        }
        #endregion
        #region MotorMoveUp_W
        public static bool MotorMoveUp_W;
        public static string NodeID_MotorMoveUp
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("MotorMoveUp", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("MotorMoveUp", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("MotorMoveUp", value, "NodeID");
                }
            }
        }
        #endregion
        #region MotorMoveDown_W
        public static bool MotorMoveDown_W;
        public static string NodeID_MotorMoveDown
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("MotorMoveDown", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("MotorMoveDown", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("MotorMoveDown", value, "NodeID");
                }
            }
        }
        #endregion
        #endregion

        #region 配置按钮
        #region ResetDefault_W
        public static bool ResetDefault_W;
        public static string NodeID_ResetDefault
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ResetDefault", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ResetDefault", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ResetDefault", value, "NodeID");
                }
            }
        }
        #endregion
        #region ReCalibrate_W
        public static bool ReCalibrate_W;
        public static string NodeID_ReCalibrate
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ReCalibrate", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ReCalibrate", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ReCalibrate", value, "NodeID");
                }
            }
        }
        #endregion
        #region ExcuteDone_W
        public static bool ExcuteDone_W;
        public static string NodeID_ExcuteDone
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ExcuteDone", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ExcuteDone", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ExcuteDone", value, "NodeID");
                }
            }
        }
        #endregion
        #endregion

        #region 实时显示
        #region ActualVoltage_R
        public static float ActualVoltage_R;
        public static string NodeID_ActualVoltage
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ActualVoltage", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ActualVoltage", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ActualVoltage", value, "NodeID");
                }
            }
        }
        #endregion
        #region ActualForce_R
        public static float ActualForce_R;
        public static string NodeID_ActualForce
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ActualForce", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ActualForce", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ActualForce", value, "NodeID");
                }
            }
        }
        #endregion
        #region ActualPosition_R
        public static float ActualPosition_R;
        public static string NodeID_ActualPosition
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ActualPosition", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ActualPosition", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ActualPosition", value, "NodeID");
                }
            }
        }
        #endregion
        #region CycleCount_R
        public static int CycleCount_R;
        public static string NodeID_CycleCount
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("CycleCount", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("CycleCount", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("CycleCount", value, "NodeID");
                }
            }
        }
        #endregion
        #endregion

        #region DataPoolReady_R
        public static bool DataPoolReady_R;
        public static string NodeID_DataPoolReady
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DataPoolReady", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DataPoolReady", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DataPoolReady", value, "NodeID");
                }
            }
        }
        #endregion
        #region ArrayPeak_R[]
        public static float[] ArrayPeak_R;
        public static string NodeID_ArrayPeak
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ArrayPeak", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ArrayPeak", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ArrayPeak", value, "NodeID");
                }
            }
        }
        #endregion
        #region ArrayLow_R[]
        public static float[] ArrayLow_R;
        public static string NodeID_ArrayLow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ArrayLow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ArrayLow", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ArrayLow", value, "NodeID");
                }
            }
        }
        #endregion
        #region ArrayPeakP_R[]
        public static float[] ArrayPeakP_R;
        public static string NodeID_ArrayPeakP
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ArrayPeakP", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ArrayPeakP", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ArrayPeakP", value, "NodeID");
                }
            }
        }
        #endregion
        #region ArrayLowP_R[]
        public static float[] ArrayLowP_R;
        public static string NodeID_ArrayLowP
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ArrayLowP", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ArrayLowP", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ArrayLowP", value, "NodeID");
                }
            }
        }
        #endregion

        #region DataReceived_W
        public static bool DataReceived_W;
        public static string NodeID_DataReceived
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DataReceived", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DataReceived", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DataReceived", value, "NodeID");
                }
            }
        }
        #endregion

        #region Recipe NodeID
        #region Peak_W
        public static int Peak_W;
        public static string NodeID_Peak
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Peak", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Peak", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Peak", value, "NodeID");
                }
            }
        }
        #endregion
        #region Low_W
        public static int Low_W;
        public static string NodeID_Low
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Low", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Low", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Low", value, "NodeID");
                }
            }
        }
        #endregion
        #region Frequence_W
        public static int Frequence_W;
        public static string NodeID_Frequence
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Frequence", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Frequence", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Frequence", value, "NodeID");
                }
            }
        }
        #endregion
        #region Times_W
        public static int Times_W;
        public static string NodeID_Times
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Times", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Times", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Times", value, "NodeID");
                }
            }
        }
        #endregion
        #region ForceMax_W
        public static float ForceMax_W;
        public static string NodeID_ForceMax
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ForceMax", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ForceMax", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ForceMax", value, "NodeID");
                }
            }
        }
        #endregion
        #region ForceMin_W
        public static float ForceMin_W;
        public static string NodeID_ForceMin
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ForceMin", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ForceMin", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ForceMin", value, "NodeID");
                }
            }
        }
        #endregion
        #region PositionMax_W
        public static float PositionMax_W;
        public static string NodeID_PositionMax
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PositionMax", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("PositionMax", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("PositionMax", value, "NodeID");
                }
            }
        }
        #endregion
        #region PositionMin_W
        public static float PositionMin_W;
        public static string NodeID_PositionMin
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("PositionMin", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("PositionMin", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("PositionMin", value, "NodeID");
                }
            }
        }
        #endregion
        #region BrokenTest_Force_W
        public static bool BrokenTest_Force_W;
        public static string NodeID_BrokenTest_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("BrokenTest_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("BrokenTest_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("BrokenTest_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region Threshold_Force_W
        public static float Threshold_Force_W;
        public static string NodeID_Threshold_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Threshold_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Threshold_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Threshold_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region UpPeak_Force_W
        public static float UpPeak_Force_W;
        public static string NodeID_UpPeak_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("UpPeak_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("UpPeak_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("UpPeak_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region DownPeak_Force_W
        public static float DownPeak_Force_W;
        public static string NodeID_DownPeak_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DownPeak_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DownPeak_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DownPeak_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region UpValley_Force_W
        public static float UpValley_Force_W;
        public static string NodeID_UpValley_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("UpValley_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("UpValley_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("UpValley_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region DownValley_Force_W
        public static float DownValley_Force_W;
        public static string NodeID_DownValley_Force
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DownValley_Force", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DownValley_Force", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DownValley_Force", value, "NodeID");
                }
            }
        }
        #endregion
        #region BrokenTest_Position_W
        public static bool BrokenTest_Position_W;
        public static string NodeID_BrokenTest_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("BrokenTest_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("BrokenTest_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("BrokenTest_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region Threshold_Position_W
        public static float Threshold_Position_W;
        public static string NodeID_Threshold_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Threshold_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Threshold_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Threshold_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region UpPeak_Position_W
        public static float UpPeak_Position_W;
        public static string NodeID_UpPeak_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("UpPeak_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("UpPeak_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("UpPeak_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region DownPeak_Position_W
        public static float DownPeak_Position_W;
        public static string NodeID_DownPeak_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DownPeak_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DownPeak_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DownPeak_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region UpValley_Position_W
        public static float UpValley_Position_W;
        public static string NodeID_UpValley_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("UpValley_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("UpValley_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("UpValley_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region DownValley_Position_W
        public static float DownValley_Position_W;
        public static string NodeID_DownValley_Position
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DownValley_Position", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DownValley_Position", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DownValley_Position", value, "NodeID");
                }
            }
        }
        #endregion
        #region ActivationTime_W
        public static float ActivationTime_W;
        public static string NodeID_ActivationTime
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("ActivationTime", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("ActivationTime", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("ActivationTime", value, "NodeID");
                }
            }
        }
        #endregion
        #region DelayTime_W
        public static float DelayTime_W;
        public static string NodeID_DelayTime
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("DelayTime", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("DelayTime", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("DelayTime", value, "NodeID");
                }
            }
        }
        #endregion
        #region StartIndex_W
        public static int StartIndex_W;
        public static string NodeID_StartIndex
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("StartIndex", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("StartIndex", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("StartIndex", value, "NodeID");
                }
            }
        }
        #endregion
        #region PID
        #region Kp_Static_W
        public static float Kp_Static_W;
        public static string NodeID_Kp_Static
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kp_Static", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kp_Static", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kp_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Ki_Static_W
        public static float Ki_Static_W;
        public static string NodeID_Ki_Static
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Ki_Static", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Ki_Static", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Ki_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Static_W
        public static float Kd_Static_W;
        public static string NodeID_Kd_Static
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kd_Static", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kd_Static", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kd_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kp_Dynamic_W
        public static float Kp_Dynamic_W;
        public static string NodeID_Kp_Dynamic
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kp_Dynamic", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kp_Dynamic", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kp_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Ki_Dynamic_W
        public static float Ki_Dynamic_W;
        public static string NodeID_Ki_Dynamic
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Ki_Dynamic", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Ki_Dynamic", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Ki_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Dynamic_W
        public static float Kd_Dynamic_W;
        public static string NodeID_Kd_Dynamic
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kd_Dynamic", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kd_Dynamic", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kd_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kp_Follow_W
        public static float Kp_Follow_W;
        public static string NodeID_Kp_Follow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kp_Follow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kp_Follow", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kp_Follow", value, "NodeID");
                }
            }
        }
        #endregion
        #region Ki_Follow_W
        public static float Ki_Follow_W;
        public static string NodeID_Ki_Follow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Ki_Follow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Ki_Follow", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Ki_Follow", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Follow_W
        public static float Kd_Follow_W;
        public static string NodeID_Kd_Follow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Kd_Follow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Kd_Follow", "NodeID");
                    try
                    {
                        return sysPrefixNodeID + mStr;
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                return null;
            }
            set
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    ini.Write("Kd_Follow", value, "NodeID");
                }
            }
        }
        #endregion 
        #endregion
        #endregion
        #endregion
        public string GetNewName(string fileName)
        {
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)//GetInvalidPathChars()
            {
                string invalid = new string(Path.GetInvalidFileNameChars());
                foreach (char c in invalid)
                {
                    fileName = fileName.Replace(c.ToString(), "_");
                }
            }
            return fileName;
        }
        public void RecipeChanged(string mProjectName)
        {
            try
            {
                ProjectName = mProjectName;
                string RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + ProjectName + ".recipe");
                using (StreamReader RecipeFile = new StreamReader(RecipeFilePath, Encoding.UTF8))
                {
                    RecipeFile.ReadLine();
                    RecipeFile.ReadLine();
                    RecipeFile.ReadLine();
                    strRecipe = RecipeFile.ReadToEnd();
                }
                using (StreamReader RecipeFile = new StreamReader(RecipeFilePath, Encoding.UTF8))
                {
                    try
                    {
                        RecipeFile.ReadLine();
                        ProjectNumber = RecipeFile.ReadLine().Split(':')[1];
                        SampleNumber = RecipeFile.ReadLine().Split(':')[1];
                        string controlType = RecipeFile.ReadLine().Split(':')[1];
                        Peak_W = Convert.ToInt32(RecipeFile.ReadLine().Split(':')[1]);
                        Low_W = Convert.ToInt32(RecipeFile.ReadLine().Split(':')[1]);
                        Frequence_W = Convert.ToInt32(RecipeFile.ReadLine().Split(':')[1]);
                        Times_W = Convert.ToInt32(RecipeFile.ReadLine().Split(':')[1]);
                        StartIndex_W = Convert.ToInt32(RecipeFile.ReadLine().Split(':')[1]);
                        ForceMax_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        ForceMin_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        PositionMax_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        PositionMin_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        BrokenTest_Force_W = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        if (BrokenTest_Force_W)
                        {
                            UpPeak_Force_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            DownPeak_Force_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            UpValley_Force_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            DownValley_Force_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        }
                        else
                        {
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                        }
                        BrokenTest_Position_W = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        if (BrokenTest_Position_W)
                        {
                            UpPeak_Position_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            DownPeak_Position_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            UpValley_Position_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                            DownValley_Position_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        }
                        else
                        {
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                            RecipeFile.ReadLine();
                        }
                        ActivationTime_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        DelayTime_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kp_Static_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Ki_Static_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kd_Static_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kp_Dynamic_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Ki_Dynamic_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kd_Dynamic_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kp_Follow_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Ki_Follow_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                        Kd_Follow_W = Convert.ToSingle(RecipeFile.ReadLine().Split(':')[1]);
                    }
                    catch (Exception ex)
                    {
                        writeLog(ex.ToString(), logFormat.File);
                    }
                }
                folderNmae = GetNewName(SampleNumber);
                if (saveFile_path != "")
                {
                    if (!Directory.Exists(saveFile_path + "\\" + folderNmae))
                    {
                        Directory.CreateDirectory(saveFile_path + "\\" + folderNmae);
                    }                   
                }
                else
                {
                    saveFile_path = System.Environment.CurrentDirectory + "\\Log" + "\\";
                    if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Log" + "\\" + folderNmae))
                    {
                        Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Log" + "\\" + folderNmae);
                    }
                }
                DirectoryInfo d = new DirectoryInfo(saveFile_path + "\\" + folderNmae);
                FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.csv");//指定文件夹下相关文件个数
                //文件名命名规则：n-20210107-m.csv
                //n：第几次启动
                //m：当个文件存储记录个数有限，本次启动生成的第几份日志
                if (fsinfos.Length == 0)
                {
                    startTimes = 0;
                }
                else
                {
                    int[] nArray = new int[fsinfos.Length];
                    for (int i = 0; i < fsinfos.Length; i++)
                    {
                        if (fsinfos[i].Name.Split('-').Length == 3)
                        {
                            nArray[i] = Convert.ToInt32(fsinfos[i].Name.Split('-')[0]);
                        }
                    }
                    startTimes = nArray.Max() + 1;
                }
                periodIndex = 0;
                try
                {
                    if (m_OpcUaClient.Connected)
                    {
                        m_OpcUaClient.WriteNode(NodeID_Peak, (short)Peak_W);
                        m_OpcUaClient.WriteNode(NodeID_Low, (short)Low_W);
                        m_OpcUaClient.WriteNode(NodeID_Frequence, (short)Frequence_W);
                        m_OpcUaClient.WriteNode(NodeID_ForceMax, (float)ForceMax_W);
                        m_OpcUaClient.WriteNode(NodeID_ForceMin, (float)ForceMin_W);
                        m_OpcUaClient.WriteNode(NodeID_PositionMax, (float)PositionMax_W);
                        m_OpcUaClient.WriteNode(NodeID_PositionMin, (float)PositionMin_W);
                        m_OpcUaClient.WriteNode(NodeID_Times, (int)Times_W);
                        m_OpcUaClient.WriteNode(NodeID_StartIndex, (int)StartIndex_W);
                        m_OpcUaClient.WriteNode(NodeID_BrokenTest_Force, BrokenTest_Force_W);
                        if (BrokenTest_Force_W)
                        {
                            m_OpcUaClient.WriteNode(NodeID_UpPeak_Force, UpPeak_Force_W);
                            m_OpcUaClient.WriteNode(NodeID_DownPeak_Force, DownPeak_Force_W);
                            m_OpcUaClient.WriteNode(NodeID_UpValley_Force, UpValley_Force_W);
                            m_OpcUaClient.WriteNode(NodeID_DownValley_Force, DownValley_Force_W);
                        }
                        m_OpcUaClient.WriteNode(NodeID_BrokenTest_Position, BrokenTest_Position_W);
                        if (BrokenTest_Position_W)
                        {
                            m_OpcUaClient.WriteNode(NodeID_UpPeak_Position, UpPeak_Position_W);
                            m_OpcUaClient.WriteNode(NodeID_DownPeak_Position, DownPeak_Position_W);
                            m_OpcUaClient.WriteNode(NodeID_UpValley_Position, UpValley_Position_W);
                            m_OpcUaClient.WriteNode(NodeID_DownValley_Position, DownValley_Position_W);
                        }
                        m_OpcUaClient.WriteNode(NodeID_ActivationTime, ActivationTime_W);
                        m_OpcUaClient.WriteNode(NodeID_DelayTime, DelayTime_W);
                        m_OpcUaClient.WriteNode(NodeID_Kp_Static, Kp_Static_W);
                        m_OpcUaClient.WriteNode(NodeID_Ki_Static, Ki_Static_W);
                        m_OpcUaClient.WriteNode(NodeID_Kd_Static, Kd_Static_W);
                        m_OpcUaClient.WriteNode(NodeID_Kp_Dynamic, Kp_Dynamic_W);
                        m_OpcUaClient.WriteNode(NodeID_Ki_Dynamic, Ki_Dynamic_W);
                        m_OpcUaClient.WriteNode(NodeID_Kd_Dynamic, Kd_Dynamic_W);
                        m_OpcUaClient.WriteNode(NodeID_Kp_Follow, Kp_Follow_W);
                        m_OpcUaClient.WriteNode(NodeID_Ki_Follow, Ki_Follow_W);
                        m_OpcUaClient.WriteNode(NodeID_Kd_Follow, Kd_Follow_W);
                        m_OpcUaClient.WriteNode(NodeID_CycleCount, 0);
                    }
                    updateForm();
                    m_OpcUaClient.WriteNode(NodeID_DataPoolReady, false);
                    m_OpcUaClient.WriteNode(NodeID_ArrayLow, new float[51]);
                    m_OpcUaClient.WriteNode(NodeID_ArrayPeak, new float[51]);
                    m_OpcUaClient.WriteNode(NodeID_ArrayLowP, new float[51]);
                    m_OpcUaClient.WriteNode(NodeID_ArrayPeakP, new float[51]);
                    m_OpcUaClient2.WriteNode(NodeID_DataReceived, false);
                    n_Index = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                    n_Index2 = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                    //timer2.Interval = 1 / Frequence_W * 1000;
                    lock (SequenceLock)
                    {
                        Queue_Chart = new Queue<chartPoints>(); 
                    }
                    lock (SequenceLock2)
                    {
                        Queue_Chart2 = new Queue<chartPoints>(); 
                    }
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY2.Minimum = 0;
                    mLastTime = DateTime.Now;
                }
                catch (Exception ex)
                {
                    writeLog(ex.ToString(), logFormat.File);
                }

            }
            catch (Exception ex2)
            {
                writeLog(ex2.ToString(), logFormat.File);
            }       
        }
        public void updateForm()
        {
            lbl_StartIndex.Text  = StartIndex_W.ToString();
            lbl_TImes_Set.Text  = Times_W.ToString();
            txt_CurParams.Text = strRecipe;
            txt_ProjectName.Text = ProjectName;
            txt_ProjectNumber.Text = ProjectNumber;
            txt_SampleNumber.Text = SampleNumber;
            txt_Path.Text = saveFile_path;
            cmb_SaveFrequency.Text = saveFile_Frequency.ToString();
        }
        //Gecko.GeckoWebBrowser geckoWebBrowser1;
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "PST-" + System.Environment.CurrentDirectory.Split('\\')[System.Environment.CurrentDirectory.Split('\\').Length - 1];
            if (plcIP!=""&&plcWebSite!=""&& plcName != "")
            {
                m_OpcUaClient = new OpcUaClient();
                //设置匿名连接
                m_OpcUaClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
                //设置用户名连接
                //m_OpcUaClient.UserIdentity = new UserIdentity( "user", "password" );

                //使用证书连接
                //X509Certificate2 certificate = new X509Certificate2("[证书的路径]", "[密钥]", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                //m_OpcUaClient.UserIdentity = new UserIdentity(certificate);

                m_OpcUaClient.ConnectComplete += M_OpcUaClient_ConnectComplete;
                m_OpcUaClient.OpcStatusChange += M_OpcUaClient_OpcStatusChange;

                m_OpcUaClient2 = new OpcUaClient();
                //设置匿名连接
                m_OpcUaClient2.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
                
                m_OpcUaClient2.ConnectComplete += M_OpcUaClient_ConnectComplete2;
                m_OpcUaClient2.OpcStatusChange += M_OpcUaClient_OpcStatusChange2;

                clock.Interval = 1000;
                clock.Tick += new EventHandler(clock_Tick);
                clock.Start();
                ////geckoWebBrowser1 = new GeckoWebBrowser();
                ////geckoWebBrowser1.Dock = DockStyle.Fill;
                ////panel1.Controls.Add(geckoWebBrowser1);
                //geckoWebBrowser1.Navigate(plcWebSite);

                ////////WebKit.WebKitBrowser browser = new WebKit.WebKitBrowser();
                ////////browser.Dock = DockStyle.Fill;
                ////////panel1.Controls.Add(browser);
                ////////browser.Navigate("http://192.168.2.10:8080/webvisu.htm");
                mFormSetting = new FormSetting(this);
                tableLayoutPanel1.Enabled = false;      
            }
            else
            {
                new FormCommSetting().ShowDialog();
            }
        }
        public async void TrytoConnect()
        {
            try
            {
                await m_OpcUaClient.ConnectServer("opc.tcp://" + plcIP + ":4840");
                await m_OpcUaClient2.ConnectServer("opc.tcp://" + plcIP + ":4840");
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException("Connected Failed", ex);
            }
        }
        private void M_OpcUaClient_OpcStatusChange(object sender, OpcUaStatusEventArgs e)
        {
            if (m_OpcUaClient.Connected)
            {

                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, true);
                //timer1.Enabled = true;
            }
            else
            {
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                timer1.Enabled = false;
                timer2.Enabled = false;

            }
            //throw new NotImplementedException();
        }
        private void M_OpcUaClient_OpcStatusChange2(object sender, OpcUaStatusEventArgs e)
        {
            if (m_OpcUaClient2.Connected)
            {

                //tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, true);
                //timer1.Enabled = true;
            }
            else
            {
                //tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                //timer1.Enabled = false;

            }
            //throw new NotImplementedException();
        }
        protected delegate void ChangeStatusHandler(Control Ctrl, bool b_Status);
        void ChangeStatus(Control Ctrl, bool b_Status)
        {
            Ctrl.Enabled = b_Status;
        }
        Thread tStart;
        private void M_OpcUaClient_ConnectComplete(object sender, EventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected && FormMain.m_OpcUaClient2.Connected)
            {
                m_OpcUaClient.WriteNode(NodeID_TestStart, false);
                m_OpcUaClient.WriteNode(NodeID_TestStop, true);
                Thread.Sleep(100);
                m_OpcUaClient.WriteNode(NodeID_TestStop, false);

                firstUpdateForm();
                //通信建立完成，可以开始read&Write
                ThreadStart start = delegate
                {
                    _GetData();
                };
                tStart = new Thread(start);
                tStart.IsBackground = true;
                tStart.Start();
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, true);
                timer1.Enabled = true;
                //timer2.Enabled = true;
                btn_Connect.Text = "Online";
                btn_Connect.BackColor = Color.Green;
            }
            else
            {
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                timer1.Enabled = false;
                timer2.Enabled = false;
                btn_Connect.Text = "Offline";
                btn_Connect.BackColor = Color.Red;
            }
            //throw new NotImplementedException();
        }
        private void M_OpcUaClient_ConnectComplete2(object sender, EventArgs e)
        {
            if (FormMain.m_OpcUaClient2.Connected && FormMain.m_OpcUaClient.Connected)
            {
                m_OpcUaClient.WriteNode(NodeID_TestStart, false);
                m_OpcUaClient.WriteNode(NodeID_TestStop, true);
                Thread.Sleep(100);
                m_OpcUaClient.WriteNode(NodeID_TestStop, false);

                firstUpdateForm();
                //通信建立完成，可以开始read&Write
                ThreadStart start = delegate
                {
                    _GetData();
                };
                tStart = new Thread(start);
                tStart.IsBackground = true;
                tStart.Start();
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, true);
                timer1.Enabled = true;
                //timer2.Enabled = true;
                btn_Connect.Text = "Online";
                btn_Connect.BackColor = Color.Green;
            }
            else
            {
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                timer1.Enabled = false;
                timer2.Enabled = false;
                btn_Connect.Text = "Offline";
                btn_Connect.BackColor = Color.Red;
            }
            //throw new NotImplementedException();
        }
        public void firstUpdateForm()
        {
            while (m_OpcUaClient == null)
            {
                Thread.Sleep(50);
            }
            if (m_OpcUaClient!=null)
            {
                if (m_OpcUaClient.ReadNode<bool>(NodeID_TestEnable))
                {
                    btn_Enable.BackColor = Color.Green;
                }
                else
                {
                    btn_Enable.BackColor = Color.Transparent;
                }
            }
            
            //try
            //{
            //    string curProjectName = m_OpcUaClient.ReadNode<bool>().ToString();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        //bool logOpened = false;
        public void _GetData()
        {
            while (true)
            {
                try
                {
                    //plc数据未就绪 或 设备未启动：循环等待
                    while (!m_OpcUaClient2.ReadNode<bool>(NodeID_DataPoolReady) || btn_Start.BackColor != Color.Green)
                    {
                        Thread.Sleep(50);
                    }
                   
                    DataValue DataValuePeak = m_OpcUaClient2.ReadNode(NodeID_ArrayPeak);
                    DataValue DataValueLow = m_OpcUaClient2.ReadNode(NodeID_ArrayLow);
                    DataValue DataValuePeakP = m_OpcUaClient2.ReadNode(NodeID_ArrayPeakP);
                    DataValue DataValueLowP = m_OpcUaClient2.ReadNode(NodeID_ArrayLowP);
                    ArrayPeak_R = (float[])DataValuePeak.Value;
                    ArrayLow_R = (float[])DataValueLow.Value;
                    ArrayPeakP_R = (float[])DataValuePeakP.Value;
                    ArrayLowP_R = (float[])DataValueLowP.Value;
                    Array.Resize(ref ArrayPeak_R, 10);
                    Array.Resize(ref ArrayLow_R, 10);
                    Array.Resize(ref ArrayPeakP_R, 10);
                    Array.Resize(ref ArrayLowP_R, 10);
                    Peak_MIN = ArrayPeak_R.Min();
                    Peak_MAX = ArrayPeak_R.Max();
                    Peak_AVE = ArrayPeak_R.Average();
                    Valley_MIN = ArrayLow_R.Min();
                    Valley_MAX = ArrayLow_R.Max();
                    Valley_AVE = ArrayLow_R.Average();

                    Peak_MIN1 = ArrayPeakP_R.Min();
                    Peak_MAX1 = ArrayPeakP_R.Max();
                    Peak_AVE1 = ArrayPeakP_R.Average();
                    Valley_MIN1 = ArrayLowP_R.Min();
                    Valley_MAX1 = ArrayLowP_R.Max();
                    Valley_AVE1 = ArrayLowP_R.Average();

                    #region write csv
                    //string csvFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Log\\" + folderNmae + "\\0-"
                    //               + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//默认路径
                    //if (saveFile_path != "")
                    //{
                    //    if (!Directory.Exists(saveFile_path + "\\" + folderNmae))
                    //    {
                    //        Directory.CreateDirectory(saveFile_path + "\\" + folderNmae);
                    //    }
                    //    csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + "0-"
                    //        + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//更新为设置的路径
                    //}
                    //else
                    //{
                    //    saveFile_path = System.Environment.CurrentDirectory + "\\Log" + "\\";
                    //    if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Log" + "\\" + folderNmae))
                    //    {
                    //        Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Log" + "\\" + folderNmae);
                    //    }
                    //    csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + "0-"
                    //        + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//更新为设置的路径
                    //}

                    //DirectoryInfo d = new DirectoryInfo(saveFile_path + "\\" + folderNmae);
                    //FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.csv");//指定文件夹下相关文件个数
                    ////文件名命名规则：n-20210107-m.csv
                    ////n：第几次启动
                    ////m：当个文件存储记录个数有限，本次启动生成的第几份日志
                    //if (fsinfos.Length==0)
                    //{
                    //    startTimes = 0;
                    //}
                    //else
                    //{
                    //    int[] nArray = new int[fsinfos.Length];
                    //    for (int i = 0; i < fsinfos.Length; i++)
                    //    {
                    //        if (fsinfos[i].Name.Split('-').Length == 3)
                    //        {
                    //            nArray[i] = Convert.ToInt32(fsinfos[i].Name.Split('-')[0]);
                    //        }
                    //    }
                    //    startTimes = nArray.Max() + 1;
                    //}


                    //if (!File.Exists(csvFilePath) && !logOpened)
                    //{
                    //    //不存在-1的文件
                    //    periodIndex = 0; logOpened = true;
                    //}
                    //else if (fsinfos.Length == 0 && !logOpened)
                    //{
                    //    //不存在yyyyMMdd-n.csv类型的文件
                    //    periodIndex = 0; logOpened = true;
                    //}
                    //else
                    //{
                    //    //更新periodIndex
                    //    if (!logOpened)
                    //    {
                    //        periodIndex = (fsinfos.Length - 1) * saveFile_Frequency;//起始次数
                    //        csvFilePath = Path.Combine(saveFile_path + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "-" + fsinfos.Length.ToString() + ".csv");

                    //        //重新计算periodIndex
                    //        using (StreamReader sr = new StreamReader(csvFilePath))
                    //        {
                    //            string sline;
                    //            while ((sline = sr.ReadLine()) != null)
                    //            {
                    //                if (sline.Replace(" ", "") != "")
                    //                {
                    //                    periodIndex++;
                    //                }
                    //            }
                    //        }
                    //        if (fsinfos.Length == 1)
                    //        {
                    //            periodIndex = periodIndex - 1;
                    //        }

                    //        logOpened = true;
                    //    }
                    //}

                    if (!Directory.Exists(saveFile_path + "\\" + folderNmae))
                    {
                        Directory.CreateDirectory(saveFile_path + "\\" + folderNmae);
                    }
                    string csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + startTimes.ToString() + "-"
                            + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//更新为设置的路径
                    csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + startTimes.ToString() + "-" 
                        + DateTime.Now.ToString("yyyyMMdd") + "-" + (Math.Floor((double)periodIndex / (double)saveFile_Frequency) + 1).ToString() + ".csv");
                    if (periodIndex == 0 && File.Exists(csvFilePath))
                    {
                        int logIndex = 1;
                        //文件中计数为0，可是已存在相关记录的CSV
                        while (File.Exists(csvFilePath))
                        {
                            logIndex = logIndex + 1;
                            csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + startTimes.ToString() + "-"
                       + DateTime.Now.ToString("yyyyMMdd") + "-" + logIndex.ToString() + ".csv");
                        }
                        csvFilePath = Path.Combine(saveFile_path + "\\" + folderNmae + "\\" + startTimes.ToString() + "-"
                       + DateTime.Now.ToString("yyyyMMdd") + "-" + (logIndex - 1).ToString() + ".csv");

                        //重新计算periodIndex
                        using (StreamReader sr = new StreamReader(csvFilePath))
                        {
                            string sline;
                            while ((sline = sr.ReadLine()) != null)
                            {
                                if (sline.Replace(" ", "") != "")
                                {
                                    periodIndex++;
                                }
                            }
                        }
                        if (logIndex == 2) //只存在-1.csv文件，计数减去表头那一行
                        {
                            periodIndex = periodIndex - 1;
                        }
                    }
                    string line = string.Empty;
                    using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                    {
                        if (periodIndex == 0)
                        {
                            line = "Index,ForcePeak,ForceValley,DisplacementPeak,DisplacementValley";
                            //line = "Index,Peak,Valley";
                            csvFile.WriteLine(line);
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            periodIndex++;
                            line = periodIndex + "," + ArrayPeak_R[i] + "," + ArrayLow_R[i] + "," + ArrayPeakP_R[i] + "," + ArrayLowP_R[i];
                            //line = periodIndex + "," + ArrayPeak_R[i] + "," + ArrayLow_R[i];
                            A_Max = ArrayPeak_R[i];
                            A_Min = ArrayLow_R[i];
                            B_Max = ArrayPeakP_R[i];
                            B_Min = ArrayLowP_R[i];
                           
                            if (btn_Start.BackColor == Color.Green)
                            {
                                #region 添加chart队列
                                for (int mm = 0; mm < SamplingCount_Cycle; mm++)
                                {
                                    lock (SequenceLock)
                                    {
                                        Queue_Chart.Enqueue(new chartPoints(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index++),
                                   (A_Max - A_Min) / 2 * Math.Sin(Math.PI * 2 * (double)mm / (double)SamplingCount_Cycle) + (A_Max + A_Min) / 2));
                                    }
                                    lock (SequenceLock2)
                                    {
                                        Queue_Chart2.Enqueue(new chartPoints(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index2++),
                                            (B_Max - B_Min) / 2 * Math.Sin(Math.PI * 2 * (double)mm / (double)SamplingCount_Cycle) + (B_Max + B_Min) / 2));
                                    }
                                } 
                                #endregion
                            }
                            csvFile.WriteLine(line);
                        }
                    } 
                    #endregion

                    m_OpcUaClient2.WriteNode(NodeID_DataReceived, true);
                    while (m_OpcUaClient2.ReadNode<bool>(NodeID_DataPoolReady))
                    {
                        Thread.Sleep(50);
                    }
                    m_OpcUaClient2.WriteNode(NodeID_DataReceived, false);
                }
                catch (Exception ex)
                {

                    writeLog(ex.ToString(), logFormat.File);
                }
            }
        }



        #region InvokeChangeButtonText
        protected delegate void ChangeButtonTextHandler(Button buttonCtrl, string Txt);
        void InvokeChangeButtonText(Button buttonCtrl, string Txt)
        {
            buttonCtrl.Invoke((ChangeButtonTextHandler)ChangeButtonCtrlText, buttonCtrl, Txt);
        }
        void ChangeButtonCtrlText(Button buttonCtrl, string Txt)
        {
            buttonCtrl.Text = Txt;
        }
        #endregion
        #region InvokeChangeButtonColor
        protected delegate void ChangeButtonColorHandler(Button buttonCtrl, Color Col);
        void InvokeChangeButtonColor(Button buttonCtrl, Color Col)
        {
            buttonCtrl.Invoke((ChangeButtonColorHandler)ChangeButtonCtrlColor, buttonCtrl, Col);
        }
        void ChangeButtonCtrlColor(Button buttonCtrl, Color Col)
        {
            buttonCtrl.BackColor = Col;
        }
        #endregion

        void clock_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd\r\nddd\r\nHH:mm:ss");
            //string time = DateTime.Now.ToString("yyyy-MM-dd\r\nHH:mm:ss");
            this.Invoke(
                new Action(
                    delegate
                    {
                        this.label_clock.Text = time;
                    }
                    )
                );
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            //mFormSetting.ShowDialog();
            new FormChooseRecipe(this).ShowDialog();
        }

        private void DDBtn_Calibration_Click(object sender, EventArgs e)
        {
            new FormCalibrate().ShowDialog();
        }

        private void DDBtn_File_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (txt_ProjectNumber.Text == "")
            {
                MessageBox.Show("请先选择配方！");
                btn_Setting.Focus();
            }
            else
            {
                if (MessageBox.Show("请确认横梁位置", "确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //////chart1.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
                    //////chart1.Series[0].ChartArea = "ChartArea1";
                    //////chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    //////chart1.Series[0].Color = System.Drawing.Color.White;
                    //////chart1.Series[0].Legend = "Legend1";
                    //////chart1.Series[0].MarkerColor = System.Drawing.Color.Black;
                    //////chart1.Series[0].Name = "Force";
                    ////chart1.Series[0].Points.Clear();
                    ////chart1.Series[1].Points.Clear();
                    //////chart1.Series[1] = new System.Windows.Forms.DataVisualization.Charting.Series();
                    //////chart1.Series[1].ChartArea = "ChartArea1";
                    //////chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    //////chart1.Series[1].Color = System.Drawing.Color.Red;
                    //////chart1.Series[1].Legend = "Legend1";
                    //////chart1.Series[1].Name = "Position";
                    //////chart1.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    if (!Directory.Exists(saveFile_path + "\\" + folderNmae))
                    {
                        Directory.CreateDirectory(saveFile_path + "\\" + folderNmae);
                    }
                    DirectoryInfo d = new DirectoryInfo(saveFile_path + "\\" + folderNmae);
                    FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.csv");//指定文件夹下相关文件个数
                    //////文件名命名规则：n-20210107-m.csv
                    //////n：第几次启动
                    //////m：当个文件存储记录个数有限，本次启动生成的第几份日志
                    ////if (fsinfos.Length == 0)
                    ////{
                    ////    startTimes = 0;
                    ////}
                    ////else
                    ////{
                    ////    int[] nArray = new int[fsinfos.Length];
                    ////    for (int i = 0; i < fsinfos.Length; i++)
                    ////    {
                    ////        if (fsinfos[i].Name.Split('-').Length == 3)
                    ////        {
                    ////            nArray[i] = Convert.ToInt32(fsinfos[i].Name.Split('-')[0]);
                    ////        }
                    ////    }
                    ////    startTimes = nArray.Max() + 1;
                    ////}
                    ////periodIndex = 0;
                    n_Index = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                    n_Index2 = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                    lock (SequenceLock)
                    {
                        Queue_Chart = new Queue<chartPoints>();
                    }
                    lock (SequenceLock2)
                    {
                        Queue_Chart2 = new Queue<chartPoints>();
                    }

                    m_OpcUaClient.WriteNode(NodeID_TestStop, false);
                    m_OpcUaClient.WriteNode(NodeID_TestStart, true);
                    Thread.Sleep(100);
                    m_OpcUaClient.WriteNode(NodeID_TestStart, false);
                    mLastTime = DateTime.Now;
                    //logOpened = false;

                    timer2.Enabled = true;
                    btn_Setting.Enabled = false;
                    btn_Calibrate.Enabled = false;
                    btn_ChangePath.Enabled = false;
                    btn_CommSetting.Enabled = false;
                    btn_RecipeManagement.Enabled = false;
                    btn_Adjust.Enabled = false;
                    cmb_SaveFrequency.Enabled = false;
                    btn_ForceClear.Enabled = false;
                    btn_PositionClear.Enabled = false;
                }
                else
                {
                  
                }                
            }
        }

        private void btn_EMG_Click(object sender, EventArgs e)
        {
            if (btn_EMG.BackColor == Color.Red)
            {
                m_OpcUaClient.WriteNode(NodeID_EMG, false);
                btn_EMG.BackColor = Color.Transparent;
            }
            else
            {
                m_OpcUaClient.WriteNode(NodeID_EMG, true);
                btn_EMG.BackColor = Color.Red;
            }
        }

        private void btn_Enable_Click(object sender, EventArgs e)
        {
            if (btn_Enable.BackColor == Color.Green)
            {
                m_OpcUaClient.WriteNode(NodeID_TestEnable, false);
                //btn_Enable.BackColor = Color.Transparent;
            }
            else
            {
                m_OpcUaClient.WriteNode(NodeID_TestEnable, true);
                //btn_Enable.BackColor = Color.Green;
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_TestStart, false);
            m_OpcUaClient.WriteNode(NodeID_TestStop, true);
            Thread.Sleep(100);
            m_OpcUaClient.WriteNode(NodeID_TestStop, false);
            m_OpcUaClient2.WriteNode(NodeID_DataReceived, false);
            timer2.Enabled = false;
            btn_Setting.Enabled = true;
            btn_Calibrate.Enabled = true;
            btn_ChangePath.Enabled = true;
            btn_CommSetting.Enabled = true;
            btn_RecipeManagement.Enabled = true;
            btn_Adjust.Enabled = true;
            cmb_SaveFrequency.Enabled = true;
            btn_ForceClear.Enabled = true;
            btn_PositionClear.Enabled = true;
        }
        int i_ErrorID_Last = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                m_OpcUaClient.WriteNode(NodeID_HeartBit, !m_OpcUaClient.ReadNode<bool>(NodeID_HeartBit));
                if (m_OpcUaClient.ReadNode<bool>(NodeID_TestEnable))
                {
                    btn_Enable.BackColor = Color.Green;
                }
                else
                {
                    btn_Enable.BackColor = Color.Transparent;
                    btn_Setting.Enabled = true;
                    btn_Calibrate.Enabled = true;
                    btn_ChangePath.Enabled = true;
                    btn_CommSetting.Enabled = true;
                    btn_RecipeManagement.Enabled = true;
                    btn_Adjust.Enabled = true;
                    cmb_SaveFrequency.Enabled = true;
                    btn_ForceClear.Enabled = true;
                    btn_PositionClear.Enabled = true;
                }
                if (m_OpcUaClient.ReadNode<bool>(NodeID_RunningFlag))
                {
                    btn_Start.BackColor = Color.Green;
                    pic_Running.Image = imageList_Status.Images[1];
                    if (txt_ProjectNumber.Text != "")//已选择型号
                    {
                        //上次退出程序PLC没有停止运行，重新打开程序并完成选型后
                        if (!Directory.Exists(saveFile_path + "\\" + folderNmae))
                        {
                            Directory.CreateDirectory(saveFile_path + "\\" + folderNmae);
                        }
                        //DirectoryInfo d = new DirectoryInfo(saveFile_path + "\\" + folderNmae);
                        //FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.csv");
                        ////指定文件夹下相关文件个数
                        ////文件名命名规则：n-20210107-m.csv
                        ////n：第几次启动
                        ////m：当个文件存储记录个数有限，本次启动生成的第几份日志
                        //if (fsinfos.Length == 0)
                        //{
                        //    startTimes = 0;
                        //}
                        //else
                        //{
                        //    int[] nArray = new int[fsinfos.Length];
                        //    for (int i = 0; i < fsinfos.Length; i++)
                        //    {
                        //        if (fsinfos[i].Name.Split('-').Length == 3)
                        //        {
                        //            nArray[i] = Convert.ToInt32(fsinfos[i].Name.Split('-')[0]);
                        //        }
                        //    }
                        //    startTimes = nArray.Max() + 1;
                        //}
                        //periodIndex = 0;
                        //n_Index = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                        //n_Index2 = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount) * SamplingCount_Cycle;
                        //lock (SequenceLock)
                        //{
                        //    Queue_Chart = new Queue<chartPoints>();
                        //}
                        //lock (SequenceLock2)
                        //{
                        //    Queue_Chart2 = new Queue<chartPoints>();
                        //}

                        //m_OpcUaClient.WriteNode(NodeID_TestStop, false);
                        //m_OpcUaClient.WriteNode(NodeID_TestStart, true);
                        //Thread.Sleep(100);
                        //m_OpcUaClient.WriteNode(NodeID_TestStart, false);

                        ////logOpened = false;
                        if (!timer2.Enabled)
                        {
                            timer2.Enabled = true;
                        }
                        
                        btn_Setting.Enabled = false;
                        btn_Calibrate.Enabled = false;
                        btn_ChangePath.Enabled = false;
                        btn_CommSetting.Enabled = false;
                        btn_RecipeManagement.Enabled = false;
                        btn_Adjust.Enabled = false;
                        cmb_SaveFrequency.Enabled = false;
                        btn_ForceClear.Enabled = false;
                        btn_PositionClear.Enabled = false;

                    }
                }
                else
                {
                    btn_Start.BackColor = Color.Transparent;
                    pic_Running.Image = imageList_Status.Images[0];
                    timer2.Enabled = false;
                    btn_Setting.Enabled = true;
                    btn_Calibrate.Enabled = true;
                    btn_ChangePath.Enabled = true;
                    btn_CommSetting.Enabled = true;
                    btn_RecipeManagement.Enabled = true;
                    btn_Adjust.Enabled = true;
                    cmb_SaveFrequency.Enabled = true;
                    btn_ForceClear.Enabled = true;
                    btn_PositionClear.Enabled = true;
                }
                if (m_OpcUaClient.ReadNode<bool>(NodeID_StopFlag))
                {
                    btn_Stop.BackColor = Color.Green;
                    //pic_Running.Image = imageList_Status.Images[1];
                }
                else
                {
                    btn_Stop.BackColor = Color.Transparent;
                    //pic_Running.Image = imageList_Status.Images[0];
                }
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString(), logFormat.File);
            }
            try
            {
                if (m_OpcUaClient.ReadNode<bool>(NodeID_SystemError))
                {
                    btn_Reset.BackColor = Color.Yellow;
                    pic_Error.Image = imageList_Status.Images[2];
                }
                else
                {
                    btn_Reset.BackColor = Color.Transparent;
                    pic_Error.Image = imageList_Status.Images[0];
                }
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString(), logFormat.File);
            }

            try
            {
                int i_ErrorID = m_OpcUaClient.ReadNode<short>(NodeID_ErrorID);

                if (i_ErrorID != 0)
                {
                    if (i_ErrorID_Last != i_ErrorID)
                    {

                        string msg = "";
                        try
                        {
                            msg = ini_errorlist.Read(i_ErrorID.ToString(), "ErrorList");
                        }
                        catch (Exception)
                        {

                        }
                        writeLog(msg == "" ? i_ErrorID.ToString() : msg, logFormat.Both);
                    }
                    i_ErrorID_Last = i_ErrorID;
                }
                else
                {
                    //txt_Log_Cur.Clear();
                }
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString(), logFormat.File);
            }

            try
            {
                if (Times_W != 0)
                {
                    int plc_Count = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount);
                    lbl_Times_Cur.Text = (plc_Count + StartIndex_W).ToString();
                    //lbl_TImes_Set.Text = Times_W.ToString();
                    double d_numerator = Convert.ToDouble(plc_Count) + Convert.ToDouble(StartIndex_W);
                    progressBar.Value = Convert.ToInt32((d_numerator < Convert.ToDouble(Times_W) ? d_numerator : Convert.ToDouble(Times_W)) / Convert.ToDouble(Times_W) * 100);
                }
                lbl_ActualForce.Text = m_OpcUaClient.ReadNode<float>(NodeID_ActualForce).ToString();
                lbl_ActualPosition.Text = m_OpcUaClient.ReadNode<float>(NodeID_ActualPosition).ToString();
                lbl_Peak_AVE.Text = (int)Peak_AVE == 0 ? "" : Peak_AVE.ToString("0.00");
                lbl_Peak_MAX.Text = (int)Peak_MAX == 0 ? "" : Peak_MAX.ToString("0.00");
                lbl_Peak_MIN.Text = (int)Peak_MIN == 0 ? "" : Peak_MIN.ToString("0.00");
                lbl_Valley_AVE.Text = (int)Valley_AVE == 0 ? "" : Valley_AVE.ToString("0.00");
                lbl_Valley_MAX.Text = (int)Valley_MAX == 0 ? "" : Valley_MAX.ToString("0.00");
                lbl_Valley_MIN.Text = (int)Valley_MIN == 0 ? "" : Valley_MIN.ToString("0.00");

                lbl_Peak_AVE1.Text = (int)Peak_AVE1 == 0 ? "" : Peak_AVE1.ToString("0.00");
                lbl_Peak_MAX1.Text = (int)Peak_MAX1 == 0 ? "" : Peak_MAX1.ToString("0.00");
                lbl_Peak_MIN1.Text = (int)Peak_MIN1 == 0 ? "" : Peak_MIN1.ToString("0.00");
                lbl_Valley_AVE1.Text = (int)Valley_AVE1 == 0 ? "" : Valley_AVE1.ToString("0.00");
                lbl_Valley_MAX1.Text = (int)Valley_MAX1 == 0 ? "" : Valley_MAX1.ToString("0.00");
                lbl_Valley_MIN1.Text = (int)Valley_MIN1 == 0 ? "" : Valley_MIN1.ToString("0.00");
                //progressBar.Value % 100 + 1;
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString(), logFormat.File);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_FaultAck, true);
            Thread.Sleep(100);
            m_OpcUaClient.WriteNode(NodeID_FaultAck, false);
        }        

        private void Btn_2Zero_Click(object sender, EventArgs e)
        {

        }

       

        private void DDBtn_Adjust_Click(object sender, EventArgs e)
        {
            FormPID mformPID = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType()==typeof (FormPID))
                {
                    (mformPID = (FormPID)item).Show();
                    mformPID.Activate();
                    break;
                }
            }
            if (mformPID==null)
            {
                new FormPID(ProjectName).Show();
            }            
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Calibrate_Click(object sender, EventArgs e)
        {
            new FormCalibrate().ShowDialog();
        }

        private void Btn_PIDadjust_Click(object sender, EventArgs e)
        {
            FormPID mformPID = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(FormPID))
                {
                    (mformPID = (FormPID)item).Show();
                    mformPID.Activate();
                    break;
                }
            }
            if (mformPID == null)
            {
                new FormPID(ProjectName).Show();
            }
        }

        private void Btn_RecipeManagement_Click(object sender, EventArgs e)
        {
            mFormSetting.ShowDialog();
        }

        private void btn_CommSetting_Click(object sender, EventArgs e)
        {
            new FormCommSetting().ShowDialog();
        }

        private void btn_ForceClear_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_ForceClear.Checked)
            {
                m_OpcUaClient.WriteNode(NodeID_ForceClear, true);
            }
            else
            {
                m_OpcUaClient.WriteNode(NodeID_ForceClear, false);
            }
        }

        private void btn_PositionClear_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_PositionClear.Checked)
            {
                m_OpcUaClient.WriteNode(NodeID_PositionClear, true);
            }
            else
            {
                m_OpcUaClient.WriteNode(NodeID_PositionClear, false);
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text=="Offline")
            {               
                Ping ping = new Ping();
                if (ping.Send(plcIP, 100).Status == IPStatus.Success)
                {
                    TrytoConnect();//建立OPC-UA连接
                    ////geckoWebBrowser1.Navigate(plcWebSite);
                }
                
            }
            else
            {
                tStart.Abort();
                m_OpcUaClient.Disconnect();
                m_OpcUaClient2.Disconnect();
                ////geckoWebBrowser1.Navigate("");
                btn_Connect.Text = "Offline";
                btn_Connect.BackColor = Color.Red;
            }
        }

        private void btn_ChangePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = folderBrowserDialog1.SelectedPath;
                saveFile_path = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cmb_SaveFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFile_Frequency = Convert.ToInt32(cmb_SaveFrequency.Text);
            DirectoryInfo d = new DirectoryInfo(saveFile_path + "\\" + folderNmae);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.csv");
            //指定文件夹下相关文件个数
            //文件名命名规则：n-20210107-m.csv
            //n：第几次启动
            //m：当个文件存储记录个数有限，本次启动生成的第几份日志
            if (fsinfos.Length == 0)
            {
                startTimes = 0;
            }
            else
            {
                int[] nArray = new int[fsinfos.Length];
                for (int i = 0; i < fsinfos.Length; i++)
                {
                    if (fsinfos[i].Name.Split('-').Length == 3)
                    {
                        nArray[i] = Convert.ToInt32(fsinfos[i].Name.Split('-')[0]);
                    }
                }
                startTimes = nArray.Max() + 1;
            }
            periodIndex = 0;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_Start.BackColor==Color.Green)
            {
                if (MessageBox.Show("您确认退出吗？", "确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    m_OpcUaClient.WriteNode(NodeID_TestStart, false);
                    m_OpcUaClient.WriteNode(NodeID_TestStop, true);
                    Thread.Sleep(100);
                    m_OpcUaClient.WriteNode(NodeID_TestStop, false);
                    Dispose();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {

            }
        }

        object logLock = new object();
        void writeLog(string content, logFormat format)
        {
            string line = string.Empty;

            lock (logLock)
            {
                // show in screen
                if (format != logFormat.File)
                {
                    line = string.IsNullOrWhiteSpace(content) ? "\r\n" : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + content.TrimEnd() + "\r\n";
                    this.Invoke(
                    (EventHandler)delegate
                    { txt_Log.AppendText(line); txt_Log_Cur.AppendText(line); }
                    );
                }
                // store in log file
                if (format != logFormat.Screen)
                {
                    const string LOG_DIR = "logs";
                    string logFilePath = Path.Combine(LOG_DIR, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                    if (!Directory.Exists(LOG_DIR)) Directory.CreateDirectory(LOG_DIR);
                    line = string.IsNullOrWhiteSpace(content) ? "\r\n" : DateTime.Now.ToString("HH:mm:ss") + ": " + content.TrimEnd() + "\r\n";
                    StreamWriter logFile = new StreamWriter(logFilePath, true, Encoding.UTF8);
                    logFile.Write(line);
                    logFile.Close();
                    logFile.Dispose();
                }
            }
        }

        void moveLogs()
        {
            const string LOG_DIR = "Logs";
            const string OLD_DIR = "Logs\\Old";
            if (!Directory.Exists(LOG_DIR)) return;
            if (!Directory.Exists(OLD_DIR)) Directory.CreateDirectory(OLD_DIR);

            string[] logs = Directory.GetFiles(LOG_DIR, "*.log", SearchOption.TopDirectoryOnly);
            if (logs.Length < 3) return;
            else
            {
                Array.Sort<string>(logs);
                for (int i = 0; i < logs.Length - 2; i++)
                {
                    try
                    {
                        File.Move(logs[i], Path.Combine(OLD_DIR, Path.GetFileName(logs[i])));
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }
            }
        }

        enum logFormat
        {
            Screen = 3,
            File,
            Both
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Log_Cur.Clear();
            i_ErrorID_Last = 0;
        }
        int n_Empty = 0;
        DateTime mLastTime;
        long getTotalMillisecond(chartPoints mchartPoints)
        {
            long mMillisecond = 0;
            switch (mchartPoints.x.Split(':').Length)
            {
                case 1:
                    mMillisecond = (long)(Convert.ToDouble(mchartPoints.x.Split(':')[0]) * (double)1000);
                    break;
                case 2:
                    mMillisecond = (long)(Convert.ToDouble(mchartPoints.x.Split(':')[1]) * (double)1000) + Convert.ToInt32(mchartPoints.x.Split(':')[0]) * 60;
                    break;
                case 3:
                    mMillisecond = (long)(Convert.ToDouble(mchartPoints.x.Split(':')[2]) * (double)1000) + Convert.ToInt32(mchartPoints.x.Split(':')[1]) * 60
                        + Convert.ToInt32(mchartPoints.x.Split(':')[0]) * 60 * 60;
                    break;
                case 4:
                    mMillisecond = (long)(Convert.ToDouble(mchartPoints.x.Split(':')[3]) * (double)1000) + Convert.ToInt32(mchartPoints.x.Split(':')[2]) * 60
                        + Convert.ToInt32(mchartPoints.x.Split(':')[1]) * 60 * 60 + Convert.ToInt32(mchartPoints.x.Split(':')[0]) * 24 * 60 * 60;
                    break;
                default:
                    break;
            }
            return mMillisecond;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            ////if (A_Max != 0 && A_Min != 0)
            ////{
            ////    if (Queue_Chart_Show.Count > 120)
            ////    {
            ////        Queue_Chart_Show.Dequeue();
            ////    }
            ////    if (Queue_Chart.Count > 0)
            ////    {
            ////        Queue_Chart_Show.Enqueue(Queue_Chart.Dequeue());
            ////    }
            ////    else
            ////    {
            ////        //*********依据最近的波峰波谷值获取波形图，待有数值后继续显示实际波形【需要一个周期显示完整后切换显示】**********
            ////        //Queue_Chart_Show.Enqueue(new chartPoints(n_Index++, (A_Max - A_Min) / 2 * Math.Sin(Math.PI * 2 * (double)n_Empty++ / (double)SamplingCount_Cycle) + (A_Max + A_Min) / 2));
            ////        //if (n_Empty >= SamplingCount_Cycle)
            ////        //{
            ////        //    n_Empty = 0;
            ////        //}
            ////        //***************************************************************************************************************

            ////        if (btn_Stop.BackColor == Color.Green)
            ////        {
            ////            //队列中无数据，且运行已停止
            ////        }
            ////        else
            ////        {
            ////            //中途数据刷新没跟上，补零
            ////            Queue_Chart_Show.Enqueue(new chartPoints(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index++), 0));
            ////        }
            ////    }

            ////    chart1.DataSource = Queue_Chart_Show.ToArray(); //将listp绑定给chart1

            ////    chart1.Series[0].XValueMember = "x";//将listp中所有Name元素作为X轴

            ////    chart1.Series[0].YValueMembers = "y";//将listp中所有Value元素作为Y轴

            ////    chart1.DataBind(); //绑定数据
            ////}
            int fortimes = (int)(DateTime.Now - mLastTime).TotalMilliseconds / (1000 / Frequence_W / SamplingCount_Cycle);
            if (fortimes<0)
            {
                fortimes = 6;
            }
            if (A_Max != 0 && A_Min != 0)
            {
                try
                {
                    //if (chart1.ChartAreas[0].AxisY.Minimum > Math.Round(A_Min - (A_Max - A_Min) * 0.01, 2) || chart1.ChartAreas[0].AxisY.Minimum == 0)
                    //{
                    //    chart1.ChartAreas[0].AxisY.Minimum = Math.Round(A_Min - (A_Max - A_Min) * 0.01, 2);
                    //}
                    //if (chart1.ChartAreas[0].AxisY.Maximum < Math.Round(A_Max + (A_Max - A_Min) * 0.01, 2))
                    //{
                    //    chart1.ChartAreas[0].AxisY.Maximum = Math.Round(A_Max + (A_Max - A_Min) * 0.01, 2);
                    //}
                }
                catch (Exception)
                {

                }

                for (int m = 0; m < fortimes; m++)
                {
                    //if (chart1.Series[0].Points.Count > Frequence_W * 8)
                    if (chart1.Series[0].Points.Count > 60)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }
                    if (Queue_Chart.Count > 0)
                    {
                        //try
                        //{
                        //    chartPoints mP;
                        //    lock (SequenceLock)
                        //    {
                        //        mP = Queue_Chart.Dequeue(); 
                        //    }
                        //    if (mP !=null)
                        //    {
                        //        chart1.Series[0].Points.AddXY(mP.x, mP.y);
                        //    }

                        //}
                        //catch (Exception)
                        //{

                        //}               
                    }
                    else
                    {

                        if (btn_Start.BackColor != Color.Green)
                        {
                            //队列中无数据，且运行已停止
                            timer2.Enabled = false;
                        }
                        else
                        {
                            //中途数据刷新没跟上，补零
                            //chart1.Series[0].Points.AddXY(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index++), 0);
                            for (int mm = 0; mm < SamplingCount_Cycle; mm++)
                            {
                                lock (SequenceLock)
                                {
                                    Queue_Chart.Enqueue(new chartPoints(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index++),
                               (A_Max - A_Min) / 2 * Math.Sin(Math.PI * 2 * (double)mm / (double)SamplingCount_Cycle) + (A_Max + A_Min) / 2));
                                }                                
                            }
                        }
                    }
                    if (Queue_Chart.Count > 0)
                    {
                        try
                        {
                            //if (Queue_Chart.Peek().x )
                            //{
                                
                            //}

                            chartPoints mP;
                            lock (SequenceLock)
                            {
                                mP = Queue_Chart.Dequeue();
                            }
                            if (mP != null)
                            {
                                chart1.Series[0].Points.AddXY(mP.x, mP.y);
                            }

                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                try
                {
                    //chart1.ChartAreas[0].AxisY.Minimum = Math.Round(chart1.Series[0].Points.FindMinByValue().YValues[0] - (chart1.Series[0].Points.FindMaxByValue().YValues[0] - chart1.Series[0].Points.FindMinByValue().YValues[0]) * 0.03, 3);
                    //chart1.ChartAreas[0].AxisY.Maximum = Math.Round(chart1.Series[0].Points.FindMaxByValue().YValues[0] + (chart1.Series[0].Points.FindMaxByValue().YValues[0] - chart1.Series[0].Points.FindMinByValue().YValues[0]) * 0.03, 3);
                    double mmMin = Math.Round(chart1.Series[0].Points.FindMinByValue().YValues[0] - (chart1.Series[0].Points.FindMaxByValue().YValues[0] - chart1.Series[0].Points.FindMinByValue().YValues[0]) * 0.03, 3);
                    double mmMax = Math.Round(chart1.Series[0].Points.FindMaxByValue().YValues[0] + (chart1.Series[0].Points.FindMaxByValue().YValues[0] - chart1.Series[0].Points.FindMinByValue().YValues[0]) * 0.03, 3);
                    if (mmMin >= mmMax)
                    {
                        mmMax = mmMin + 1;
                    }
                    chart1.ChartAreas[0].AxisY.Minimum = mmMin;
                    chart1.ChartAreas[0].AxisY.Maximum = mmMax;
                }
                catch (Exception)
                {

                }
                //if (chart1.Series[1].Points.Count > 120)
                //{
                //    chart1.Series[1].Points.RemoveAt(0);
                //}
            }
            for (int m = 0; m < fortimes; m++)
            {
                if (B_Max != 0 && B_Min != 0)
                {
                    //try
                    //{
                    //    if (chart1.ChartAreas[0].AxisY2.Minimum > Math.Round(B_Min - (B_Max - B_Min) * 0.04, 3) || chart1.ChartAreas[0].AxisY2.Minimum == 0)
                    //    {
                    //        chart1.ChartAreas[0].AxisY2.Minimum = Math.Round(B_Min - (B_Max - B_Min) * 0.04, 3);
                    //    }
                    //    if (chart1.ChartAreas[0].AxisY2.Maximum < Math.Round(B_Max + (B_Max - B_Min) * 0.04, 3))
                    //    {
                    //        chart1.ChartAreas[0].AxisY2.Maximum = Math.Round(B_Max + (B_Max - B_Min) * 0.04, 3);
                    //    }
                    //}
                    //catch (Exception)
                    //{


                    //}
                    //if (chart1.Series[1].Points.Count > Frequence_W * 8)
                    if (chart1.Series[1].Points.Count > 60)
                    {
                        chart1.Series[1].Points.RemoveAt(0);
                    }
                    if (Queue_Chart2.Count > 0)
                    {
                        //try
                        //{
                        //    chartPoints mP;
                        //    lock (SequenceLock2)
                        //    {
                        //        mP = Queue_Chart2.Dequeue(); 
                        //    }
                        //    if (mP != null)
                        //    {
                        //        chart1.Series[1].Points.AddXY(mP.x, mP.y);
                        //    }
                        //}
                        //catch (Exception)
                        //{

                        //}                 
                    }
                    else
                    {

                        if (btn_Start.BackColor != Color.Green)
                        {
                            //队列中无数据，且运行已停止
                            timer2.Enabled = false;
                        }
                        else
                        {
                            //中途数据刷新没跟上，补零
                            //chart1.Series[1].Points.AddXY(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index2++), 0);
                            for (int mm = 0; mm < SamplingCount_Cycle; mm++)
                            {                               
                                lock (SequenceLock2)
                                {
                                    Queue_Chart2.Enqueue(new chartPoints(timestamp.AddMilliseconds(1000 / Frequence_W / SamplingCount_Cycle * n_Index2++),
                                        (B_Max - B_Min) / 2 * Math.Sin(Math.PI * 2 * (double)mm / (double)SamplingCount_Cycle) + (B_Max + B_Min) / 2));
                                }
                            }
                        }
                    }
                    if (Queue_Chart2.Count > 0)
                    {
                        try
                        {
                            chartPoints mP;
                            lock (SequenceLock2)
                            {
                                mP = Queue_Chart2.Dequeue();
                            }
                            if (mP != null)
                            {
                                chart1.Series[1].Points.AddXY(mP.x, mP.y);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    try
                    {
                        double mmMin1 = Math.Round(chart1.Series[1].Points.FindMinByValue().YValues[0]
                                     - (chart1.Series[1].Points.FindMaxByValue().YValues[0] - chart1.Series[1].Points.FindMinByValue().YValues[0]) * 0.06, 3);
                        double mmMax1 = Math.Round(chart1.Series[1].Points.FindMaxByValue().YValues[0]
                                    + (chart1.Series[1].Points.FindMaxByValue().YValues[0] - chart1.Series[1].Points.FindMinByValue().YValues[0]) * 0.06, 3);
                        if (mmMin1 >= mmMax1)
                        {
                            mmMax1 = mmMin1 + 1;
                        }
                        chart1.ChartAreas[0].AxisY2.Minimum = mmMin1;
                        chart1.ChartAreas[0].AxisY2.Maximum = mmMax1;
                    }
                    catch (Exception)
                    {

                    }
                }

            }
            if (fortimes>0)
            {
                mLastTime = DateTime.Now;
            }
        }

        private void btn_Adjust_Click(object sender, EventArgs e)
        {
            new FormAdjust().ShowDialog();
        }
    }

    public class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);
            if (Value > 0)
            {
                var clip = new Rectangle(rect.X, rect.Y, (int)((float)Value / Maximum * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }

            string text = string.Format("{0}%", Value * 100 / Maximum); ;
            using (var font = new Font(FontFamily.GenericSerif, 20))
            {
                SizeF sz = g.MeasureString(text, font);
                var location = new PointF(rect.Width / 2 - sz.Width / 2, rect.Height / 2 - sz.Height / 2 + 2);
                g.DrawString(text, font, Brushes.Black, location);
            }
        }
    }
}
