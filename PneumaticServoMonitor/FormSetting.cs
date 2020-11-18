using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PneumaticServoMonitor
{
    public partial class FormSetting : Form
    {
        public FormSetting(FormMain m)
        {
            InitializeComponent();
            mFormMain = m;
        }
        FormMain mFormMain;
        string RecipeFilePath;
        private void btn_RecipeSave_Click(object sender, EventArgs e)
        {
            if (cmb_ProjectName.Text == "")
            {
                MessageBox.Show("请输入测试方案名称");
                cmb_ProjectName.Focus();
            }
            else
            {
                if (cmb_ProjectName.Text == "")
                {
                    MessageBox.Show("测试方案名不可以为空");
                    cmb_ProjectName.Focus();
                }
                else if (txt_ProjectNumber.Text == "")
                {
                    MessageBox.Show("项目号不可以为空");
                    txt_ProjectNumber.Focus();
                }
                else if (txt_SampleNumber.Text == "")
                {
                    MessageBox.Show("样品编号不可以为空");
                    txt_SampleNumber.Focus();
                }
                else if (txt_Peak.Text == "")
                {
                    MessageBox.Show("波峰不可以为空");
                    txt_Peak.Focus();
                }
                else if (txt_Low.Text == "")
                {
                    MessageBox.Show("波谷不可以为空");
                    txt_Low.Focus();
                }
                else if (txt_Frequence.Text == "")
                {
                    MessageBox.Show("频率不可以为空");
                    txt_Frequence.Focus();
                }
                else if (txt_Times.Text == "")
                {
                    MessageBox.Show("循环次数不可以为空");
                    txt_Times.Focus();
                }
                else if (txt_ForceMax.Text == "")
                {
                    MessageBox.Show("载荷上限不可以为空");
                    txt_ForceMax.Focus();
                }
                else if (txt_ForceMin.Text == "")
                {
                    MessageBox.Show("载荷下限不可以为空");
                    txt_ForceMin.Focus();
                }
                else if (txt_PositionMax.Text == "")
                {
                    MessageBox.Show("位置上限不可以为空");
                    txt_PositionMax.Focus();
                }
                else if (txt_PositionMin.Text == "")
                {
                    MessageBox.Show("位置下限不可以为空");
                    txt_PositionMin.Focus();
                }
                else if (txt_StartIndex.Text == "")
                {
                    MessageBox.Show("初始次数不可以为空");
                    txt_StartIndex.Focus();
                }
                else if (txt_Kp_Static.Text == "")
                {
                    MessageBox.Show("Kp_Static不可以为空");
                    txt_Kp_Static.Focus();
                }
                else if (txt_Ki_Static.Text == "")
                {
                    MessageBox.Show("Ki_Static不可以为空");
                    txt_Ki_Static.Focus();
                }
                else if (txt_Kd_Static.Text == "")
                {
                    MessageBox.Show("Kd_Static不可以为空");
                    txt_Kd_Static.Focus();
                }
                else if (txt_Kp_Dynamic.Text == "")
                {
                    MessageBox.Show("Kp_Dynamic不可以为空");
                    txt_Kp_Dynamic.Focus();
                }
                else if (txt_Ki_Dynamic.Text == "")
                {
                    MessageBox.Show("Ki_Dynamic不可以为空");
                    txt_Ki_Dynamic.Focus();
                }
                else if (txt_Kd_Dynamic.Text == "")
                {
                    MessageBox.Show("Kd_Dynamic不可以为空");
                    txt_Kd_Dynamic.Focus();
                }
                else if (txt_Kp_Follow.Text == "")
                {
                    MessageBox.Show("Kp_Follow不可以为空");
                    txt_Kp_Follow.Focus();
                }
                else if (txt_Ki_Follow.Text == "")
                {
                    MessageBox.Show("Ki_Follow不可以为空");
                    txt_Ki_Follow.Focus();
                }
                else if (txt_Kd_Follow.Text == "")
                {
                    MessageBox.Show("Kd_Follow不可以为空");
                    txt_Kd_Follow.Focus();
                }
                else if (txt_ActivationTime.Text == "")
                {
                    MessageBox.Show("ActivationTime不可以为空");
                    txt_ActivationTime.Focus();
                }
                else if (txt_DelayTime.Text == "")
                {
                    MessageBox.Show("DelayTime不可以为空");
                    txt_DelayTime.Focus();
                }
                else if (chk_BrokenTest_Force.Checked)
                {
                    if (txt_UpPeak_Force.Text == "")
                    {
                        MessageBox.Show("UpPeak_Force不可以为空");
                        txt_UpPeak_Force.Focus();
                    }
                    else if (txt_DownPeak_Force.Text == "")
                    {
                        MessageBox.Show("DownPeak_Force不可以为空");
                        txt_DownPeak_Force.Focus();
                    }
                    else if (txt_UpValley_Force.Text == "")
                    {
                        MessageBox.Show("UpValley_Force不可以为空");
                        txt_UpValley_Force.Focus();
                    }
                    else if (txt_DownValley_Force.Text == "")
                    {
                        MessageBox.Show("DownValley_Force不可以为空");
                        txt_DownValley_Force.Focus();
                    }
                }
                else if (chk_BrokenTest_Position.Checked)
                {
                    if (txt_UpPeak_Position.Text == "")
                    {
                        MessageBox.Show("UpPeak_Position不可以为空");
                        txt_UpPeak_Position.Focus();
                    }
                    else if (txt_DownPeak_Position.Text == "")
                    {
                        MessageBox.Show("DownPeak_Position不可以为空");
                        txt_DownPeak_Position.Focus();
                    }
                    else if (txt_UpValley_Position.Text == "")
                    {
                        MessageBox.Show("UpValley_Position不可以为空");
                        txt_UpValley_Position.Focus();
                    }
                    else if (txt_DownValley_Position.Text == "")
                    {
                        MessageBox.Show("DownValley_Position不可以为空");
                        txt_DownValley_Position.Focus();
                    }
                }
                else
                {
                    if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Recipe"))
                    {
                        Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Recipe");
                    }
                    RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + cmb_ProjectName.Text + ".recipe");
                    if (File.Exists(RecipeFilePath))
                    { File.Delete(RecipeFilePath); }
                    string line = string.Empty;
                    using (StreamWriter RecipeFile = new StreamWriter(RecipeFilePath, true, Encoding.UTF8))
                    {
                        RecipeFile.WriteLine("ProjectName:" + cmb_ProjectName.Text);
                        RecipeFile.WriteLine("ProjectNumber:" + txt_ProjectNumber.Text);
                        RecipeFile.WriteLine("SampleNumber:" + txt_SampleNumber.Text);
                        if (rdo_ForceControl.Checked)
                        {
                            RecipeFile.WriteLine("ControlMode:Force");
                        }
                        else if (rdo_PositionControl.Checked)
                        {
                            RecipeFile.WriteLine("ControlMode:Position");
                        }
                        RecipeFile.WriteLine("Peak:" + txt_Peak.Text);
                        RecipeFile.WriteLine("Low:" + txt_Low.Text);
                        RecipeFile.WriteLine("Frequence:" + txt_Frequence.Text);
                        RecipeFile.WriteLine("Times:" + txt_Times.Text);
                        RecipeFile.WriteLine("StartIndex:" + txt_StartIndex.Text);
                        RecipeFile.WriteLine("ForceMax:" + txt_ForceMax.Text);
                        RecipeFile.WriteLine("ForceMin:" + txt_ForceMin.Text);
                        RecipeFile.WriteLine("PositionMax:" + txt_PositionMax.Text);
                        RecipeFile.WriteLine("PositionMin:" + txt_PositionMin.Text);
                        RecipeFile.WriteLine("BrokenTest_Force:" + chk_BrokenTest_Force.Checked.ToString());
                        RecipeFile.WriteLine("UpPeak_Force:" + txt_UpPeak_Force.Text);
                        RecipeFile.WriteLine("DownPeak_Force:" + txt_DownPeak_Force.Text);
                        RecipeFile.WriteLine("UpValley_Force:" + txt_UpValley_Force.Text);
                        RecipeFile.WriteLine("DownValley_Force:" + txt_DownValley_Force.Text);
                        RecipeFile.WriteLine("BrokenTest_Position:" + chk_BrokenTest_Position.Checked.ToString());
                        RecipeFile.WriteLine("UpPeak_Position:" + txt_UpPeak_Position.Text);
                        RecipeFile.WriteLine("DownPeak_Position:" + txt_DownPeak_Position.Text);
                        RecipeFile.WriteLine("UpValley_Position:" + txt_UpValley_Position.Text);
                        RecipeFile.WriteLine("DownValley_Position:" + txt_DownValley_Position.Text);
                        RecipeFile.WriteLine("ActivationTime:" + txt_ActivationTime.Text);
                        RecipeFile.WriteLine("DelayTime:" + txt_DelayTime.Text);
                        RecipeFile.WriteLine("Kp_Static:" + txt_Kp_Static.Text);
                        RecipeFile.WriteLine("Ki_Static:" + txt_Ki_Static.Text);
                        RecipeFile.WriteLine("Kd_Static:" + txt_Kd_Static.Text);
                        RecipeFile.WriteLine("Kp_Dynamic:" + txt_Kp_Dynamic.Text);
                        RecipeFile.WriteLine("Ki_Dynamic:" + txt_Ki_Dynamic.Text);
                        RecipeFile.WriteLine("Kd_Dynamic:" + txt_Kd_Dynamic.Text);
                        RecipeFile.WriteLine("Kp_Follow:" + txt_Kp_Follow.Text);
                        RecipeFile.WriteLine("Ki_Follow:" + txt_Ki_Follow.Text);
                        RecipeFile.WriteLine("Kd_Follow:" + txt_Kd_Follow.Text);
                    }
                    MessageBox.Show("配方" + cmb_ProjectName.Text + "保存成功");
                }
               
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Recipe"))
            {
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Recipe");
            }
            DirectoryInfo d = new DirectoryInfo(System.Environment.CurrentDirectory+"\\Recipe");
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.recipe");
            cmb_ProjectName.Items.Clear();
            for (int i = 0; i < fsinfos.Length; i++)
            {
                cmb_ProjectName.Items.Add(fsinfos[i].Name.Split('.')[0]);
            }
            
        }

        private void cmb_ProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ProjectName.SelectedItem!=null)
            {
                RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + cmb_ProjectName.Text + ".recipe");
                using (StreamReader RecipeFile = new StreamReader(RecipeFilePath, Encoding.UTF8))
                {
                    try
                    {
                        RecipeFile.ReadLine();
                        txt_ProjectNumber.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_SampleNumber.Text = RecipeFile.ReadLine().Split(':')[1];
                        string controlType = RecipeFile.ReadLine().Split(':')[1];
                        if (controlType == "Force")
                        {
                            rdo_ForceControl.Checked = true;
                        }
                        else if (controlType == "Positon")
                        {
                            rdo_PositionControl.Checked = true;
                        }
                        txt_Peak.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Low.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Frequence.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Times.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_StartIndex.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_ForceMax.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_ForceMin.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_PositionMax.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_PositionMin.Text = RecipeFile.ReadLine().Split(':')[1];
                        chk_BrokenTest_Force.Checked = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        txt_UpPeak_Force.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_DownPeak_Force.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_UpValley_Force.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_DownValley_Force.Text = RecipeFile.ReadLine().Split(':')[1];
                        chk_BrokenTest_Position.Checked = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        txt_UpPeak_Position.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_DownPeak_Position.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_UpValley_Position.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_DownValley_Position.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_ActivationTime.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_DelayTime.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Ki_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kd_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Ki_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kd_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Ki_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kd_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                        if (txt_ProjectNumber.Text == "")
                        {
                            MessageBox.Show("项目号为空");
                            txt_ProjectNumber.Focus();
                        }
                        else if (txt_SampleNumber.Text == "")
                        {
                            MessageBox.Show("样品编号为空");
                            txt_SampleNumber.Focus();
                        }
                        else if (txt_Peak.Text == "")
                        {
                            MessageBox.Show("波峰值为空");
                            txt_Peak.Focus();
                        }
                        else if (txt_Low.Text == "")
                        {
                            MessageBox.Show("波谷值为空");
                            txt_Low.Focus();
                        }
                        else if (txt_Frequence.Text == "")
                        {
                            MessageBox.Show("频率值为空");
                            txt_Frequence.Focus();
                        }
                        else if (txt_Times.Text == "")
                        {
                            MessageBox.Show("循环次数为空");
                            txt_Times.Focus();
                        }
                        else if (txt_ForceMax.Text == "")
                        {
                            MessageBox.Show("载荷上限为空");
                            txt_ForceMax.Focus();
                        }
                        else if (txt_ForceMin.Text == "")
                        {
                            MessageBox.Show("载荷下限为空");
                            txt_ForceMin.Focus();
                        }
                        else if (txt_PositionMax.Text == "")
                        {
                            MessageBox.Show("位置上限为空");
                            txt_PositionMax.Focus();
                        }
                        else if (txt_PositionMin.Text == "")
                        {
                            MessageBox.Show("位置下限为空");
                            txt_PositionMin.Focus();
                        }
                        else if (txt_StartIndex.Text == "")
                        {
                            MessageBox.Show("初始次数为空");
                            txt_StartIndex.Focus();
                        }
                        else if (txt_Kp_Static.Text == "")
                        {
                            MessageBox.Show("Kp_Static为空");
                            txt_Kp_Static.Focus();
                        }
                        else if (txt_Ki_Static.Text == "")
                        {
                            MessageBox.Show("Ki_Static为空");
                            txt_Ki_Static.Focus();
                        }
                        else if (txt_Kd_Static.Text == "")
                        {
                            MessageBox.Show("Kd_Static为空");
                            txt_Kd_Static.Focus();
                        }
                        else if (txt_Kp_Dynamic.Text == "")
                        {
                            MessageBox.Show("Kp_Dynamic为空");
                            txt_Kp_Dynamic.Focus();
                        }
                        else if (txt_Ki_Dynamic.Text == "")
                        {
                            MessageBox.Show("Ki_Dynamic为空");
                            txt_Ki_Dynamic.Focus();
                        }
                        else if (txt_Kd_Dynamic.Text == "")
                        {
                            MessageBox.Show("Kd_Dynamic为空");
                            txt_Kd_Dynamic.Focus();
                        }
                        else if (txt_Kp_Follow.Text == "")
                        {
                            MessageBox.Show("Kp_Follow为空");
                            txt_Kp_Follow.Focus();
                        }
                        else if (txt_Ki_Follow.Text == "")
                        {
                            MessageBox.Show("Ki_Follow为空");
                            txt_Ki_Follow.Focus();
                        }
                        else if (txt_Kd_Follow.Text == "")
                        {
                            MessageBox.Show("Kd_Follow为空");
                            txt_Kd_Follow.Focus();
                        }
                        else if (txt_ActivationTime.Text == "")
                        {
                            MessageBox.Show("ActivationTime不可以为空");
                            txt_ActivationTime.Focus();
                        }
                        else if (txt_DelayTime.Text == "")
                        {
                            MessageBox.Show("DelayTime不可以为空");
                            txt_DelayTime.Focus();
                        }
                        else if (chk_BrokenTest_Force.Checked)
                        {
                            if (txt_UpPeak_Force.Text == "")
                            {
                                MessageBox.Show("UpPeak_Force不可以为空");
                                txt_UpPeak_Force.Focus();
                            }
                            else if (txt_DownPeak_Force.Text == "")
                            {
                                MessageBox.Show("DownPeak_Force不可以为空");
                                txt_DownPeak_Force.Focus();
                            }
                            else if (txt_UpValley_Force.Text == "")
                            {
                                MessageBox.Show("UpValley_Force不可以为空");
                                txt_UpValley_Force.Focus();
                            }
                            else if (txt_DownValley_Force.Text == "")
                            {
                                MessageBox.Show("DownValley_Force不可以为空");
                                txt_DownValley_Force.Focus();
                            }
                        }
                        else if (chk_BrokenTest_Position.Checked)
                        {
                            if (txt_UpPeak_Position.Text == "")
                            {
                                MessageBox.Show("UpPeak_Position不可以为空");
                                txt_UpPeak_Position.Focus();
                            }
                            else if (txt_DownPeak_Position.Text == "")
                            {
                                MessageBox.Show("DownPeak_Position不可以为空");
                                txt_DownPeak_Position.Focus();
                            }
                            else if (txt_UpValley_Position.Text == "")
                            {
                                MessageBox.Show("UpValley_Position不可以为空");
                                txt_UpValley_Position.Focus();
                            }
                            else if (txt_DownValley_Position.Text == "")
                            {
                                MessageBox.Show("DownValley_Position不可以为空");
                                txt_DownValley_Position.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }    
                }
            }
        }

        private void btn_SaveParams_Click(object sender, EventArgs e)
        {

        }

        private void FormSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            mFormMain.mFormSetting = new FormSetting(mFormMain);
        }

        private void btn_Rename_Click(object sender, EventArgs e)
        {
            if (btn_Rename.Text=="重命名")
            {
                RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + cmb_ProjectName.Text + ".recipe");
                if (File.Exists(RecipeFilePath))
                {
                    cmb_ProjectName.Focus();
                    panel5.Enabled = false;
                    panel6.Enabled = false;
                    panel7.Enabled = false;
                    panel8.Enabled = false;
                    panel9.Enabled = false;
                    panel10.Enabled = false;
                    panel11.Enabled = false;
                    panel12.Enabled = false;
                    panel13.Enabled = false;
                    panel14.Enabled = false;
                    panel19.Enabled = false;
                    panel20.Enabled = false;
                    panel22.Enabled = false;
                    panel16.Enabled = false;
                    label14.Enabled = false;
                    label36.Enabled = false;
                    tableLayoutPanel9.Enabled = false;
                    tableLayoutPanel5.Enabled = false;
                    btn_Delete.Enabled = false;
                    btn_RecipeSave.Enabled = false;
                    rdo_ForceControl.Enabled = false;
                    rdo_PositionControl.Enabled = false;
                    chk_BrokenTest_Force.Enabled = false;
                    chk_BrokenTest_Position.Enabled = false;
                    btn_Rename.Text = "确定";
                }
                else
                {
                    MessageBox.Show("无此配方信息");
                }
            }
            else
            {
                string targetFilePath= Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + cmb_ProjectName.Text + ".recipe");
                if (RecipeFilePath!= targetFilePath)
                {
                    if (File.Exists(targetFilePath))
                    {
                        if (MessageBox.Show("您确定覆盖吗？", "确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            // 改名方法
                            //FileInfo fi = new FileInfo("旧路径"); //xx/xx/aa.rar
                            //fi.MoveTo(targetFilePath);
                            File.Copy(RecipeFilePath, targetFilePath, true);
                            File.Delete(RecipeFilePath);
                        }
                    }
                    else
                    {
                        // 改名方法
                        //FileInfo fi = new FileInfo("旧路径"); //xx/xx/aa.rar
                        //fi.MoveTo(targetFilePath);
                        File.Copy(RecipeFilePath, targetFilePath);
                        File.Delete(RecipeFilePath);
                    }
                }
          
                if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Recipe"))
                {
                    Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Recipe");
                }
                DirectoryInfo d = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Recipe");
                FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.recipe");
                cmb_ProjectName.Items.Clear();
                for (int i = 0; i < fsinfos.Length; i++)
                {
                    cmb_ProjectName.Items.Add(fsinfos[i].Name.Split('.')[0]);
                }
                panel5.Enabled = true;
                panel6.Enabled = true;
                panel7.Enabled = true;
                panel8.Enabled = true;
                panel9.Enabled = true;
                panel10.Enabled = true;
                panel11.Enabled = true;
                panel12.Enabled = true;
                panel13.Enabled = true;
                panel14.Enabled = true;
                panel19.Enabled = true;
                panel20.Enabled = false;
                panel22.Enabled = false;
                panel16.Enabled = true;
                label14.Enabled = true;
                label36.Enabled = true;
                tableLayoutPanel9.Enabled = true;
                tableLayoutPanel5.Enabled = true;
                btn_Delete.Enabled = true;
                btn_RecipeSave.Enabled = true;
                rdo_ForceControl.Enabled = true;
                rdo_PositionControl.Enabled = true;
                chk_BrokenTest_Force.Enabled = true;
                chk_BrokenTest_Position.Enabled = true;
                btn_Rename.Text = "重命名";
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + cmb_ProjectName.Text + ".recipe");
            if (File.Exists(RecipeFilePath))
            { File.Delete(RecipeFilePath); }
            if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Recipe"))
            {
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Recipe");
            }
            DirectoryInfo d = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Recipe");
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.recipe");
            cmb_ProjectName.Items.Clear();
            for (int i = 0; i < fsinfos.Length; i++)
            {
                cmb_ProjectName.Items.Add(fsinfos[i].Name.Split('.')[0]);
            }

        }
    }
}
