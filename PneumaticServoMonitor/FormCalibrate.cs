using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PneumaticServoMonitor
{
    public partial class FormCalibrate : Form
    {
        public FormCalibrate()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new FormSensorReset().Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    txt_ActualForce.Text = FormMain.m_OpcUaClient.ReadNode(FormMain.NodeID_ActualForce).ToString();
                    txt_ActualVoltage.Text= FormMain.m_OpcUaClient.ReadNode(FormMain.NodeID_ActualVoltage).ToString();
                    if (FormMain.m_OpcUaClient.ReadNode<bool>(FormMain.NodeID_ExcuteDone))
                    {
                        button1.BackColor = Color.Green;
                    }
                    else
                    {
                        button1.BackColor = SystemColors.Control;
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void FormCalibrate_Load(object sender, EventArgs e)
        {
            txt_CalVoltage1.Text = FormMain.sysCalVoltage1.ToString();
            txt_CalVoltage2.Text = FormMain.sysCalVoltage2.ToString();
            txt_CalForce1.Text = FormMain.sysCalForce1.ToString();
            txt_CalForce2.Text = FormMain.sysCalForce2.ToString();
            timer1.Enabled = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            //更新至ini文件
            FormMain.sysCalVoltage1 = Convert.ToSingle(txt_CalVoltage1.Text);
            FormMain.sysCalVoltage2 = Convert.ToSingle(txt_CalVoltage2.Text);
            FormMain.sysCalForce1 = Convert.ToSingle(txt_CalForce1.Text);
            FormMain.sysCalForce2 = Convert.ToSingle(txt_CalForce2.Text);
            //将界面的值写给PLC
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysCalVoltage1, FormMain.sysCalVoltage1);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysCalVoltage2, FormMain.sysCalVoltage2);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysCalForce1, FormMain.sysCalForce1);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysCalForce2, FormMain.sysCalForce2);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_ReCalibrate, true);
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {                
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_ReCalibrate, false);
            }
        }
    }
}
