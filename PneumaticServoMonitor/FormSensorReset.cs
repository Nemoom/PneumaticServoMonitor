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
    public partial class FormSensorReset : Form
    {
        public FormSensorReset()
        {
            InitializeComponent();
        }

        private void Tbn_Reset_Click(object sender, EventArgs e)
        {

        }

        private void FormSensorReset_Load(object sender, EventArgs e)
        {
            if (FormMain.sysDefCalVoltage1 == 0 && FormMain.sysDefCalVoltage2 == 0)
            {
                //FormMain.sysDefCalVoltage1=
                //FormMain.sysDefCalVoltage2=
                //FormMain.sysDefCalForce1=
                //FormMain.sysDefCalForce2=
            }
            else
            {

            }
            txt_DefCalVoltage1.Text = FormMain.sysDefCalVoltage1.ToString();
            txt_DefCalVoltage2.Text = FormMain.sysDefCalVoltage2.ToString();
            txt_DefCalForce1.Text = FormMain.sysDefCalForce1.ToString();
            txt_DefCalForce2.Text = FormMain.sysDefCalForce2.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (FormMain.m_OpcUaClient.Connected)
                {
                    if (FormMain.m_OpcUaClient.ReadNode<bool>(FormMain.NodeID_ExcuteDone))
                    {
                        tbn_Reset.BackColor = Color.Green;
                    }
                    else
                    {
                        tbn_Reset.BackColor = SystemColors.Control;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void tbn_Reset_MouseDown(object sender, MouseEventArgs e)
        {
            //更新至ini文件
            FormMain.sysDefCalVoltage1 = Convert.ToSingle(txt_DefCalVoltage1.Text);
            FormMain.sysDefCalVoltage2 = Convert.ToSingle(txt_DefCalVoltage2.Text);
            FormMain.sysDefCalForce1 = Convert.ToSingle(txt_DefCalForce1.Text);
            FormMain.sysDefCalForce2 = Convert.ToSingle(txt_DefCalForce2.Text);
            //将界面的值写给PLC
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysDefCalVoltage1, FormMain.sysDefCalVoltage1);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysDefCalVoltage2, FormMain.sysDefCalVoltage2);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysDefCalForce1, FormMain.sysDefCalForce1);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_sysDefCalForce2, FormMain.sysDefCalForce2);
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_ResetDefault, true);
            }
        }

        private void tbn_Reset_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMain.m_OpcUaClient.Connected)
            {
                FormMain.m_OpcUaClient.WriteNode(FormMain.NodeID_ResetDefault, false);
            }
        }
    }
}
