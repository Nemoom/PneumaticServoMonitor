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
    public partial class FormAdjust : Form
    {
        public FormAdjust()
        {
            InitializeComponent();
        }

        private void btn_CylinderUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderUp, true);
            }
        }

        private void btn_CylinderUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderUp, false);
            }
        }

        private void btn_CylinderDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderSpeed, (short)trackBar_CylinderSpeed.Value);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderDown, true);
            }
        }

        private void btn_CylinderDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderDown, false);
            }
        }

        private void btn_MotorMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderSpeed, (short)trackBar_CylinderSpeed.Value);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_MotorMoveUp, true);
            }
        }

        private void btn_MotorMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_MotorMoveUp, false);
            }
        }

        private void btn_MotorMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_MotorMoveDown, true);
            }
        }

        private void btn_MotorMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_MotorMoveDown, false);
            }
        }

        private void trackBar_CylinderSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar_CylinderSpeed_ValueChanged(object sender, EventArgs e)
        {
            lbl_CylinderSpeed.Text = trackBar_CylinderSpeed.Value.ToString() + "%";
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderSpeed, (short)trackBar_CylinderSpeed.Value);
            }
        }

        private void FormAdjust_Load(object sender, EventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_CylinderSpeed, (short)trackBar_CylinderSpeed.Value);
            }
            else
            {
                MessageBox.Show("请先切至online状态");
            }
        }
    }
}
