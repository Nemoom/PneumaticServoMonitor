﻿using System;
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
        public static string ProjectName;
        public static string ProjectNumber;
        public static string SampleNumber;
        public static string strRecipe;
        private static string iniPath = "config.ini";
        IniFile ini_errorlist = new IniFile(iniPath);
        public int periodIndex = 0;
        System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
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
        public void RecipeChanged(string mProjectName)
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

                }
            }

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
                    m_OpcUaClient.WriteNode(NodeID_Kp_Static ,Kp_Static_W );
                    m_OpcUaClient.WriteNode(NodeID_Ki_Static ,Ki_Static_W );
                    m_OpcUaClient.WriteNode(NodeID_Kd_Static ,Kd_Static_W );
                    m_OpcUaClient.WriteNode(NodeID_Kp_Dynamic,Kp_Dynamic_W);
                    m_OpcUaClient.WriteNode(NodeID_Ki_Dynamic,Ki_Dynamic_W);
                    m_OpcUaClient.WriteNode(NodeID_Kd_Dynamic,Kd_Dynamic_W);
                    m_OpcUaClient.WriteNode(NodeID_Kp_Follow ,Kp_Follow_W );
                    m_OpcUaClient.WriteNode(NodeID_Ki_Follow ,Ki_Follow_W );
                    m_OpcUaClient.WriteNode(NodeID_Kd_Follow, Kd_Follow_W );
                    m_OpcUaClient.WriteNode(NodeID_CycleCount, 0);
                }
                updateForm();
                

            }
            catch (Exception ex)
            {

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
        Gecko.GeckoWebBrowser geckoWebBrowser1;
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
               
                clock.Interval = 1000;
                clock.Tick += new EventHandler(clock_Tick);
                clock.Start();
                geckoWebBrowser1 = new GeckoWebBrowser();
                geckoWebBrowser1.Dock = DockStyle.Fill;
                panel1.Controls.Add(geckoWebBrowser1);
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
            if (FormMain.m_OpcUaClient.Connected)
            {
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
                btn_Connect.Text = "Online";
                btn_Connect.BackColor = Color.Green;
            }
            else
            {
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                timer1.Enabled = false;
                btn_Connect.Text = "Offline";
                btn_Connect.BackColor = Color.Red;
            }
            //throw new NotImplementedException();
        }
        public void firstUpdateForm()
        {
            if (m_OpcUaClient.ReadNode<bool>(NodeID_TestEnable))
            {
                btn_Enable.BackColor = Color.Green;
            }
            else
            {
                btn_Enable.BackColor = Color.Transparent;
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

        bool logOpened = false;
        public void _GetData()
        {
            while (true)
            {
                try
                {
                    while (!m_OpcUaClient.ReadNode<bool>(NodeID_DataPoolReady))
                    {
                        Thread.Sleep(50);
                    }
                   
                    DataValue DataValuePeak = m_OpcUaClient.ReadNode(NodeID_ArrayPeak);
                    DataValue DataValueLow = m_OpcUaClient.ReadNode(NodeID_ArrayLow);
                    ArrayPeak_R = (float[])DataValuePeak.Value;
                    ArrayLow_R= (float[])DataValueLow.Value;
                    //write csv
                    string csvFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Log\\" + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//默认路径
                    if (saveFile_path != "")
                    {
                        if (!Directory.Exists(saveFile_path))
                        {
                            Directory.CreateDirectory(saveFile_path);
                        }
                        csvFilePath = Path.Combine(saveFile_path + "\\" + DateTime.Now.ToString("yyyyMMdd") + "-1.csv");//更新为设置的路径
                    }
                    else
                    {
                        saveFile_path = System.Environment.CurrentDirectory + "\\Log";
                        if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Log"))
                        {
                            Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Log");
                        }
                    }
                    DirectoryInfo d = new DirectoryInfo(saveFile_path);
                    FileSystemInfo[] fsinfos = d.GetFileSystemInfos(DateTime.Now.ToString("yyyyMMdd") + "-*.csv");//指定文件夹下相关文件个数
                    if (!File.Exists(csvFilePath))
                    {
                        //不存在-1的文件
                        periodIndex = 0; logOpened = true;
                    }
                    else if (fsinfos.Length == 0)
                    {
                        //不存在yyyyMMdd-n.csv类型的文件
                        periodIndex = 0; logOpened = true;
                    }
                    else
                    {
                        if (!logOpened)
                        {
                            periodIndex = (fsinfos.Length - 1) * saveFile_Frequency;//起始次数
                            csvFilePath = Path.Combine(saveFile_path + "\\" + DateTime.Now.ToString("yyyyMMdd") + "-" + fsinfos.Length.ToString() + ".csv");

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
                            if (fsinfos.Length==1)
                            {
                                periodIndex = periodIndex - 1;
                            }
                            
                            logOpened = true;
                        }
                    }
                    csvFilePath = Path.Combine(saveFile_path + "\\" + DateTime.Now.ToString("yyyyMMdd") + "-" + (Math.Floor((double)periodIndex / (double)saveFile_Frequency) + 1).ToString() + ".csv");
                    string line = string.Empty;
                    using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                    {
                        if (periodIndex == 0)
                        {
                            line = "Index,Peak,Low";
                            csvFile.WriteLine(line);
                        }
                        
                        for (int i = 0; i < 10; i++)
                        {
                            periodIndex++;
                            line = periodIndex + "," + ArrayPeak_R[i] + "," + ArrayLow_R[i];
                            csvFile.WriteLine(line);
                        }
                    }
                    m_OpcUaClient.WriteNode(NodeID_DataReceived, true);
                    while (m_OpcUaClient.ReadNode<bool>(NodeID_DataPoolReady))
                    {
                        Thread.Sleep(50);
                    }
                    m_OpcUaClient.WriteNode(NodeID_DataReceived, false);
                }
                catch (Exception)
                {

                    
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
                m_OpcUaClient.WriteNode(NodeID_TestStop, false);
                m_OpcUaClient.WriteNode(NodeID_TestStart, true);
                Thread.Sleep(100);
                m_OpcUaClient.WriteNode(NodeID_TestStart, false);
                btn_Setting.Enabled = false;
                btn_Calibrate.Enabled = false;
                btn_ChangePath.Enabled = false;
                btn_CommSetting.Enabled = false;
                btn_RecipeManagement.Enabled = false;
                cmb_SaveFrequency.Enabled = false;
                btn_ForceClear.Enabled = false;
                btn_PositionClear.Enabled = false;
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
            btn_Setting.Enabled = true;
            btn_Calibrate.Enabled = true;
            btn_ChangePath.Enabled = true;
            btn_CommSetting.Enabled = true;
            btn_RecipeManagement.Enabled = true;
            cmb_SaveFrequency.Enabled = true;
            btn_ForceClear.Enabled = true;
            btn_PositionClear.Enabled = true;
        }
        int i_ErrorID_Last = 0;
        private void timer1_Tick(object sender, EventArgs e)
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
                cmb_SaveFrequency.Enabled = true;
                btn_ForceClear.Enabled = true;
                btn_PositionClear.Enabled = true;
            }
            if (m_OpcUaClient.ReadNode<bool>(NodeID_RunningFlag))
            {
                btn_Start.BackColor = Color.Green;
                pic_Running.Image = imageList_Status.Images[1];
            }
            else
            {
                btn_Start.BackColor = Color.Transparent;
                pic_Running.Image = imageList_Status.Images[0];
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
                txt_Log_Cur.Clear();
            }
            if (Times_W != 0)
            {
                lbl_Times_Cur.Text = m_OpcUaClient.ReadNode<int>(NodeID_CycleCount).ToString();
                //lbl_TImes_Set.Text = Times_W.ToString();
                double d_numerator = Convert.ToDouble(lbl_Times_Cur.Text) + Convert.ToDouble(StartIndex_W);
                progressBar.Value = Convert.ToInt32((d_numerator < Convert.ToDouble(Times_W) ? d_numerator : Convert.ToDouble(Times_W)) / Convert.ToDouble(Times_W) * 100);
            }
            lbl_ActualForce.Text= m_OpcUaClient.ReadNode<float>(NodeID_ActualForce).ToString();
            lbl_ActualPosition.Text = m_OpcUaClient.ReadNode<float>(NodeID_ActualPosition).ToString();
            //progressBar.Value % 100 + 1;
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
                    geckoWebBrowser1.Navigate(plcWebSite);
                }
                
            }
            else
            {
                tStart.Abort();
                m_OpcUaClient.Disconnect();
                geckoWebBrowser1.Navigate("");
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
