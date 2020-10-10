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
    public partial class FormChooseRecipe : Form
    {
        public FormChooseRecipe(FormMain mFormMain)
        {
            InitializeComponent();
            _FormMain = mFormMain;
        }
        FormMain _FormMain;
        System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private void FormChooseRecipe_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Recipe"))
            {
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Recipe");
            }
            DirectoryInfo d = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Recipe");
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos("*.recipe");
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 0; i < fsinfos.Length; i++)
            {
                System.Windows.Forms.RadioButton rdo_Control = new System.Windows.Forms.RadioButton();
                rdo_Control.AutoSize = true;
                //rdo_Control.Checked = true;
                rdo_Control.Location = new System.Drawing.Point(25, 248);
                rdo_Control.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
                rdo_Control.Name = "rdo_Recipe" + i.ToString();
                rdo_Control.Size = new System.Drawing.Size(103, 25);
                rdo_Control.TabIndex = i + 1;
                rdo_Control.TabStop = true;
                rdo_Control.Text = fsinfos[i].Name.Split('.')[0];
                rdo_Control.UseVisualStyleBackColor = true;
                tableLayoutPanel1.Controls.Add(rdo_Control);
            }
            
            panel1.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.SuspendLayout();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (var item in tableLayoutPanel1.Controls)
            {
                if (item.GetType().Name == "RadioButton")
                {
                    RadioButton mRadioButton = (RadioButton)item;
                    if (mRadioButton.Checked)
                    {
                        _FormMain.RecipeChanged(mRadioButton.Text);
                        this.Close();
                    }
                }
            }
        }
    }
}
