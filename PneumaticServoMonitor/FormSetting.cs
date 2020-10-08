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
                    RecipeFile.WriteLine("ForceMax:" + txt_ForceMax.Text);
                    RecipeFile.WriteLine("ForceMin:" + txt_ForceMin.Text);
                    RecipeFile.WriteLine("PositionMax:" + txt_PositionMax.Text);
                    RecipeFile.WriteLine("PositionMin:" + txt_PositionMin.Text);
                    RecipeFile.WriteLine("BrokenTest_Force:" + chk_BrokenTest_Force.Checked.ToString());
                    RecipeFile.WriteLine("Threshold_Force:" + txt_Threshold_Force.Text);
                    RecipeFile.WriteLine("BrokenTest_Position:" + chk_BrokenTest_Position.Checked.ToString());
                    RecipeFile.WriteLine("Threshold_Position:" + txt_Threshold_Position.Text);
                    RecipeFile.WriteLine("StartIndex:" + txt_StartIndex.Text);
                    RecipeFile.WriteLine("Kp_Static:" + txt_Kp_Static.Text);
                    RecipeFile.WriteLine("Tn_Static:" + txt_Tn_Static.Text);
                    RecipeFile.WriteLine("Tv_Static:" + txt_Tv_Static.Text);
                    RecipeFile.WriteLine("Kp_Dynamic:" + txt_Kp_Dynamic.Text);
                    RecipeFile.WriteLine("Tn_Dynamic:" + txt_Tn_Dynamic.Text);
                    RecipeFile.WriteLine("Tv_Dynamic:" + txt_Tv_Dynamic.Text);
                    RecipeFile.WriteLine("Kp_Follow:" + txt_Kp_Follow.Text);
                    RecipeFile.WriteLine("Tn_Follow:" + txt_Tn_Follow.Text);
                    RecipeFile.WriteLine("Tv_Follow:" + txt_Tv_Follow.Text);
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
                        if (RecipeFile.ReadLine().Split(':')[1] == "Force")
                        {
                            rdo_ForceControl.Checked = true;
                        }
                        else if (RecipeFile.ReadLine().Split(':')[1] == "Positon")
                        {
                            rdo_PositionControl.Checked = true;
                        }
                        txt_Peak.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Low.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Frequence.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Times.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_ForceMax.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_ForceMin.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_PositionMax.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_PositionMin.Text = RecipeFile.ReadLine().Split(':')[1];
                        chk_BrokenTest_Force.Checked = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        txt_Threshold_Force.Text = RecipeFile.ReadLine().Split(':')[1];
                        chk_BrokenTest_Position.Checked = Convert.ToBoolean(RecipeFile.ReadLine().Split(':')[1]);
                        txt_Threshold_Position.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_StartIndex.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tn_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tv_Static.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tn_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tv_Dynamic.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Kp_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tn_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                        txt_Tv_Follow.Text = RecipeFile.ReadLine().Split(':')[1];
                    }
                    catch (Exception)
                    {

                    }    
                }
            }
        }

        private void btn_SaveParams_Click(object sender, EventArgs e)
        {

        }

        private void FormSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            mFormMain.mFormSetting = this;
        }
    }
}
