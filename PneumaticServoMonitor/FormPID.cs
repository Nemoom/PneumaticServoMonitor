using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PneumaticServoMonitor
{
    public partial class FormPID : Form
    {
        public FormPID(string mProjectName)
        {
            InitializeComponent();
            ProjectName = mProjectName;
        }
        string ProjectName;
        private void FormPID_Load(object sender, EventArgs e)
        {
            txt_Kp_Static.Text = FormMain.Kp_Static_W.ToString();
            txt_Kp_Dynamic.Text = FormMain.Kp_Dynamic_W.ToString();
            txt_Kp_Follow.Text = FormMain.Kp_Follow_W.ToString();
            txt_Ki_Static.Text = FormMain.Ki_Static_W.ToString();
            txt_Ki_Dynamic.Text = FormMain.Ki_Dynamic_W.ToString();
            txt_Ki_Follow.Text = FormMain.Ki_Follow_W.ToString();
            txt_Kd_Static.Text = FormMain.Kd_Static_W.ToString();
            txt_Kd_Dynamic.Text = FormMain.Kd_Dynamic_W.ToString();
            txt_Kd_Follow.Text = FormMain.Kd_Follow_W.ToString();
        }

        private void Txt_Kp_Static_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Static, Convert.ToSingle(txt_Kp_Static.Text));
                }
            }
        }

        private void Txt_Kp_Dynamic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Dynamic, Convert.ToSingle(txt_Kp_Dynamic.Text));
                }
            }
        }

        private void Txt_Kp_Follow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Follow, Convert.ToSingle(txt_Kp_Follow.Text));
                }
            }
        }

        private void Txt_Ki_Static_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Static, Convert.ToSingle(txt_Ki_Static.Text));
                }
            }
        }

        private void Txt_Ki_Dynamic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Dynamic, Convert.ToSingle(txt_Ki_Dynamic.Text));
                }
            }
        }

        private void Txt_Ki_Follow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Follow, Convert.ToSingle(txt_Ki_Follow.Text));
                }
            }
        }

        private void Txt_Kd_Static_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Static, Convert.ToSingle(txt_Kd_Static.Text));
                }
            }
        }

        private void Txt_Kd_Dynamic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Dynamic, Convert.ToSingle(txt_Kd_Dynamic.Text));
                }
            }
        }

        private void Txt_Kd_Follow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Follow, Convert.ToSingle(txt_Kd_Follow.Text));
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormMain.Kp_Static_W = Convert.ToSingle(txt_Kp_Static.Text);
            FormMain.Kp_Dynamic_W = Convert.ToSingle(txt_Kp_Dynamic.Text);
            FormMain.Kp_Follow_W = Convert.ToSingle(txt_Kp_Follow.Text);
            FormMain.Ki_Static_W = Convert.ToSingle(txt_Ki_Static.Text);
            FormMain.Ki_Dynamic_W = Convert.ToSingle(txt_Ki_Dynamic.Text);
            FormMain.Ki_Follow_W = Convert.ToSingle(txt_Ki_Follow.Text);
            FormMain.Kd_Static_W = Convert.ToSingle(txt_Kd_Static.Text);
            FormMain.Kd_Dynamic_W = Convert.ToSingle(txt_Kd_Dynamic.Text);
            FormMain.Kd_Follow_W = Convert.ToSingle(txt_Kd_Follow.Text);
            if (ProjectName == "")
            {
                MessageBox.Show("配方名未知，无法保存！");
            }
            else
            {
                string RecipeFilePath = Path.Combine(System.Environment.CurrentDirectory + "\\Recipe\\" + ProjectName + ".recipe");
                string[] strRecipe;
                using (StreamReader RecipeFile = new StreamReader(RecipeFilePath, Encoding.UTF8))
                {
                    strRecipe = RecipeFile.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
                using (StreamWriter RecipeFile = new StreamWriter(RecipeFilePath, false, Encoding.UTF8))
                {
                    for (int i = 0; i < strRecipe.Length; i++)
                    {
                        if (strRecipe[i].Split(':')[0]== "Kp_Static")
                        {
                            RecipeFile.WriteLine("Kp_Static:" + txt_Kp_Static.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Ki_Static")
                        {
                            RecipeFile.WriteLine("Ki_Static:" + txt_Ki_Static.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Kd_Static")
                        {
                            RecipeFile.WriteLine("Kd_Static:" + txt_Kd_Static.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Kp_Dynamic")
                        {
                            RecipeFile.WriteLine("Kp_Dynamic:" + txt_Kp_Dynamic.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Ki_Dynamic")
                        {
                            RecipeFile.WriteLine("Ki_Dynamic:" + txt_Ki_Dynamic.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Kd_Dynamic")
                        {
                            RecipeFile.WriteLine("Kd_Dynamic:" + txt_Kd_Dynamic.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Kp_Follow")
                        {
                            RecipeFile.WriteLine("Kp_Follow:" + txt_Kp_Follow.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Ki_Follow")
                        {
                            RecipeFile.WriteLine("Ki_Follow:" + txt_Ki_Follow.Text);
                            
                        }
                        else if (strRecipe[i].Split(':')[0] == "Kd_Follow")
                        {
                            RecipeFile.WriteLine("Kd_Follow:" + txt_Kd_Follow.Text);
                        }
                        else
                        {
                            RecipeFile.WriteLine(strRecipe[i]);
                        }
                    }
                }
                if (FormMain.m_OpcUaClient.Connected)
                {
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Static, Convert.ToSingle(txt_Kp_Static.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Dynamic, Convert.ToSingle(txt_Kp_Dynamic.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kp_Follow, Convert.ToSingle(txt_Kp_Follow.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Static, Convert.ToSingle(txt_Ki_Static.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Dynamic, Convert.ToSingle(txt_Ki_Dynamic.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Ki_Follow, Convert.ToSingle(txt_Ki_Follow.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Static, Convert.ToSingle(txt_Kd_Static.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Dynamic, Convert.ToSingle(txt_Kd_Dynamic.Text));
                    FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_Kd_Follow, Convert.ToSingle(txt_Kd_Follow.Text));
                }
                MessageBox.Show("PID数值保存成功");
            }
        }
    }
}
