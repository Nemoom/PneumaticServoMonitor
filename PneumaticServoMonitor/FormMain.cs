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
            MyProgressBar progressBar = new MyProgressBar();
            progressBar.Dock = DockStyle.Fill;
            panel_ProgressBar.Controls.Add(progressBar);

            var timer = new System.Windows.Forms.Timer { Interval = 150 };
            timer.Tick += (s, e) => progressBar.Value = progressBar.Value % 100 + 1;
            timer.Start();
        }
        public FormSetting mFormSetting;
        public static OpcUaClient m_OpcUaClient;
        private static string iniPath = "config.ini";
        public int periodIndex = 0;
        System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
        #region ini文件中的参数
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
        public static string saveFile_path
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("path", "saveFile"))
                    {
                        return null;
                    }
                    string mIP = ini.Read("path", "saveFile");
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
                    ini.Write("path", value, "saveFile");
                }
            }
        }

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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
                        return mStr;
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
        public static double ForceMax_W;
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
                        return mStr;
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
        public static double ForceMin_W;
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
                        return mStr;
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
        public static double PositionMax_W;
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
                        return mStr;
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
        public static double PositionMin_W;
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
                        return mStr;
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
                        return mStr;
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
        public static double Threshold_Force_W;
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
                        return mStr;
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
                        return mStr;
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
        public static double Threshold_Position_W;
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
                        return mStr;
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
                        return mStr;
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
        public static double Kp_Static_W;
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
                        return mStr;
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
        #region Tn_Static_W
        public static double Tn_Static_W;
        public static string NodeID_Tn_Static
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tn_Static", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tn_Static", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tn_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Tv_Static_W
        public static double Tv_Static_W;
        public static string NodeID_Tv_Static
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tv_Static", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tv_Static", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tv_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kp_Dynamic_W
        public static double Kp_Dynamic_W;
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
                        return mStr;
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
        #region Tn_Dynamic_W
        public static double Tn_Dynamic_W;
        public static string NodeID_Tn_Dynamic
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tn_Dynamic", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tn_Dynamic", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tn_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Tv_Dynamic_W
        public static double Tv_Dynamic_W;
        public static string NodeID_Tv_Dynamic
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tv_Dynamic", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tv_Dynamic", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tv_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kp_Follow_W
        public static double Kp_Follow_W;
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
                        return mStr;
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
        #region Tn_Follow_W
        public static double Tn_Follow_W;
        public static string NodeID_Tn_Follow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tn_Follow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tn_Follow", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tn_Follow", value, "NodeID");
                }
            }
        }
        #endregion
        #region Tv_Follow_W
        public static double Tv_Follow_W;
        public static string NodeID_Tv_Follow
        {
            get
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    if (!ini.KeyExists("Tv_Follow", "NodeID"))
                    {
                        return null;
                    }
                    string mStr = ini.Read("Tv_Follow", "NodeID");
                    try
                    {
                        return mStr;
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
                    ini.Write("Tv_Follow", value, "NodeID");
                }
            }
        }
        #endregion
        #endregion   
        #endregion

        private void FormMain_Load(object sender, EventArgs e)
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
            Ping ping = new Ping();
            if (ping.Send(plcIP, 100).Status == IPStatus.Success)
            {
                //TrytoConnect();//建立OPC-UA连接
            }
            clock.Interval = 1000;
            clock.Tick += new EventHandler(clock_Tick);
            clock.Start();
            WebKit.WebKitBrowser browser = new WebKit.WebKitBrowser();
            browser.Dock = DockStyle.Fill;
            panel1.Controls.Add(browser);
            browser.Navigate("http://www.baidu.com");
            mFormSetting = new FormSetting(this);
            /////////////tableLayoutPanel1.Enabled = false;
        }
        public async void TrytoConnect()
        {
            try
            {
                await m_OpcUaClient.ConnectServer("opc.tcp://" + plcIP + ":4840");

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
                tableLayoutPanel1.Enabled = true;
                //InvokeChangeButtonText(button4, "Disconnect");
                

            }
            else
            {
                tableLayoutPanel1.Enabled = false;
                //InvokeChangeButtonText(button4, "Connect");
                
            }
            //throw new NotImplementedException();
        }

        private void M_OpcUaClient_ConnectComplete(object sender, EventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                //通信建立完成，可以开始read&Write
                ThreadStart start = delegate
                {
                    _GetData();
                };
                Thread tStart = new Thread(start);
                tStart.IsBackground = true;
                tStart.Start();
            }
            //throw new NotImplementedException();
        }
        public void _GetData()
        {
            while (true)
            {
                try
                {
                    //while (!m_OpcUaClient.ReadNode<bool>(NodeID_DataPoolReady))
                    //{
                    //    Thread.Sleep(50);
                    //}
                    //ArrayPeak_R = m_OpcUaClient.ReadNode(NodeID_ArrayPeak);
                    //ArrayLow_R = m_OpcUaClient.ReadNode(NodeID_ArrayLow);
                    ArrayPeak_R = new float[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 };
                    ArrayLow_R  = new float[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 };
                    //write csv
                    string csvFilePath = Path.Combine(DateTime.Now.ToString("yyyyMMdd") + ".csv");
                    if (!File.Exists(csvFilePath))
                    { periodIndex = 0; }
                    else
                    {
                        //重新计算periodIndex
                    }
                    string line = string.Empty;
                    using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                    {
                        if (periodIndex == 0)
                        {
                            line = "Index,Peak,Low";
                            csvFile.WriteLine(line);
                        }
                        
                        for (int i = 0; i < ArrayPeak_R.Length; i++)
                        {
                            periodIndex++;
                            line = periodIndex + "," + ArrayPeak_R[i] + "," + ArrayLow_R[i];
                            csvFile.WriteLine(line);
                        }
                    }
                    //m_OpcUaClient.WriteNode(NodeID_DataReceived, true);
                    //while (m_OpcUaClient.ReadNode<bool>(NodeID_DataPoolReady))
                    //{
                    //    Thread.Sleep(50);
                    //}
                    //m_OpcUaClient.WriteNode(NodeID_DataReceived, false);
                }
                catch (Exception)
                {

                    throw;
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
            mFormSetting.Show();
        }

        private void DDBtn_Calibration_Click(object sender, EventArgs e)
        {
            new FormCalibrate().Show();
        }

        private void DDBtn_File_Click(object sender, EventArgs e)
        {
            _GetData();
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
