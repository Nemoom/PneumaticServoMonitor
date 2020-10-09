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
        #endregion
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
                    ini.Write("HeartBit", value, "NodeID");
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
                    ini.Write("ActualPosition", value, "NodeID");
                }
            }
        }
        #endregion
        #region CycleCount_R
        public static float CycleCount_R;
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
        #region Ki_Static_W
        public static double Ki_Static_W;
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
                    ini.Write("Ki_Static", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Static_W
        public static double Kd_Static_W;
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
                    ini.Write("Kd_Static", value, "NodeID");
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
        #region Ki_Dynamic_W
        public static double Ki_Dynamic_W;
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
                    ini.Write("Ki_Dynamic", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Dynamic_W
        public static double Kd_Dynamic_W;
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
                    ini.Write("Kd_Dynamic", value, "NodeID");
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
        #region Ki_Follow_W
        public static double Ki_Follow_W;
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
                    ini.Write("Ki_Follow", value, "NodeID");
                }
            }
        }
        #endregion
        #region Kd_Follow_W
        public static double Kd_Follow_W;
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
                    ini.Write("Kd_Follow", value, "NodeID");
                }
            }
        }
        #endregion 
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
                TrytoConnect();//建立OPC-UA连接
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
            
            //NodeID_sysCalForce1 = "";
            //NodeID_sysCalForce2 = "";
            //NodeID_sysCalVoltage1 = "";
            //NodeID_sysCalVoltage2 = "";
            //NodeID_sysDefCalForce1 = "";
            //NodeID_sysDefCalForce2 = "";
            //NodeID_sysDefCalVoltage1 = "";
            //NodeID_sysDefCalVoltage2 = "";
            //NodeID_sysPositionOffset = "";

            //NodeID_ActualForce = "";
            //NodeID_ActualPosition = "";
            //NodeID_ActualVoltage = "";
            //NodeID_ArrayLow = "";
            //NodeID_ArrayPeak = "";

            //NodeID_CycleCount = "";
            //NodeID_DataPoolReady = "";
            //NodeID_DataReceived = "";
            //NodeID_EMG = "";
            //NodeID_ErrorID = "";
            //NodeID_ExcuteDone = "";
            //NodeID_FaultAck = "";
            //NodeID_ForceClear = "";
            //NodeID_ForceMax = "";
            //NodeID_ForceMin = "";
            //NodeID_Frequence = "";
            //NodeID_Kp_Dynamic = "";
            //NodeID_Kp_Follow = "";
            //NodeID_Kp_Static = "";
            //NodeID_Tn_Dynamic = "";
            //NodeID_Tn_Follow = "";
            //NodeID_Tn_Static = "";
            //NodeID_Tv_Dynamic = "";
            //NodeID_Tv_Follow = "";
            //NodeID_Tv_Static = "";
            //NodeID_Low = "";
            //NodeID_Peak = "";
            //NodeID_PositionClear = "";
            //NodeID_PositionMax = "";
            //NodeID_PositionMin = "";
            //NodeID_ReCalibrate = "";
            //NodeID_ResetDefault = "";
            //NodeID_RunningFlag = "";
            //NodeID_StartIndex = "";
            //NodeID_StopFlag = "";

            //NodeID_SystemError = "";
            //NodeID_TestEnable = "";
            //NodeID_TestStart = "";
            //NodeID_TestStop = "";

            //NodeID_BrokenTest_Force = "";
            //NodeID_BrokenTest_Position = "";
            //NodeID_Threshold_Force = "";
            //NodeID_Threshold_Position = "";
            //NodeID_Times = "";

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
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, true);
                timer1.Enabled = true;
            }
            else
            {
                tableLayoutPanel1.Invoke((ChangeStatusHandler)ChangeStatus, tableLayoutPanel1, false);
                timer1.Enabled = false;
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
            //mFormSetting.Show();
            new FormChooseRecipe().Show();
        }

        private void DDBtn_Calibration_Click(object sender, EventArgs e)
        {
            new FormCalibrate().Show();
        }

        private void DDBtn_File_Click(object sender, EventArgs e)
        {
            _GetData();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_TestStop, false);
            m_OpcUaClient.WriteNode(NodeID_TestStart, true);
            Thread.Sleep(100);
            m_OpcUaClient.WriteNode(NodeID_TestStart, false);
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
                btn_Enable.BackColor = Color.Transparent;
            }
            else
            {
                m_OpcUaClient.WriteNode(NodeID_TestEnable, true);
                btn_Enable.BackColor = Color.Green;
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_TestStart, false);
            m_OpcUaClient.WriteNode(NodeID_TestStop, true);
            Thread.Sleep(100);
            m_OpcUaClient.WriteNode(NodeID_TestStop, false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_HeartBit, !m_OpcUaClient.ReadNode<bool>(NodeID_HeartBit));
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
               
                pic_Error.Image = imageList_Status.Images[2];
            }
            else
            {
                pic_Error.Image = imageList_Status.Images[0];
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            m_OpcUaClient.WriteNode(NodeID_FaultAck, true);
            Thread.Sleep(100);
            m_OpcUaClient.WriteNode(NodeID_FaultAck, false);
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
