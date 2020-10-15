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
    public partial class FormCommSetting : Form
    {
        public FormCommSetting()
        {
            InitializeComponent();
        }

        private void FormCommSetting_Load(object sender, EventArgs e)
        {
            txt_IP.Text = FormMain.plcIP;
            txt_Website.Text = FormMain.plcWebSite;
            cmb_Name.Text = FormMain.plcName;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {            
            FormMain.plcIP = txt_IP.Text;
            FormMain.plcWebSite = txt_Website.Text;
            FormMain.plcName = cmb_Name.Text;
            this.Close();
        }
    }
}
