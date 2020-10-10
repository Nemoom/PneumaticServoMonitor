using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PneumaticServoMonitor
{
    public partial class FormPID : Form
    {
        public FormPID()
        {
            InitializeComponent();
        }

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
        }
    }
}
