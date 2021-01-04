namespace PneumaticServoMonitor
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DDBtn_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DDBtn_Beam = new System.Windows.Forms.ToolStripDropDownButton();
            this.DDBtn_Adjust = new System.Windows.Forms.ToolStripDropDownButton();
            this.DDBtn_Calibration = new System.Windows.Forms.ToolStripDropDownButton();
            this.DDBtn_Setting = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn_Calibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Adjust = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_PIDadjust = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_RecipeManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CommSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Connect = new System.Windows.Forms.ToolStripButton();
            this.DDBtn_Help = new System.Windows.Forms.ToolStripDropDownButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_clock = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_Peak_MAX = new System.Windows.Forms.Label();
            this.lbl_Peak_AVE = new System.Windows.Forms.Label();
            this.lbl_Peak_MIN = new System.Windows.Forms.Label();
            this.lbl_Valley_MAX = new System.Windows.Forms.Label();
            this.lbl_Valley_AVE = new System.Windows.Forms.Label();
            this.lbl_Valley_MIN = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_SampleNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_ProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_ProjectNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.btn_ChangePath = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txt_CurParams = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Enable = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btn_2Zero = new System.Windows.Forms.Button();
            this.panel_ProgressBar = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl_StartIndex = new System.Windows.Forms.Label();
            this.lbl_Times_Cur = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_TImes_Set = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbl_ActualPosition = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_PositionClear = new System.Windows.Forms.CheckBox();
            this.lbl_placeholder = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lbl_ActualForce = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ForceClear = new System.Windows.Forms.CheckBox();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txt_Log_Cur = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.cmb_SaveFrequency = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.pic_Error = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.pic_Running = new System.Windows.Forms.PictureBox();
            this.btn_EMG = new System.Windows.Forms.Button();
            this.imageList_Status = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel19.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel_Right.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Error)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Running)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DDBtn_File,
            this.DDBtn_Beam,
            this.DDBtn_Adjust,
            this.DDBtn_Calibration,
            this.DDBtn_Setting,
            this.btn_Connect,
            this.DDBtn_Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1065, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DDBtn_File
            // 
            this.DDBtn_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.DDBtn_File.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_File.Image")));
            this.DDBtn_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_File.Name = "DDBtn_File";
            this.DDBtn_File.Size = new System.Drawing.Size(53, 28);
            this.DDBtn_File.Text = "文件";
            this.DDBtn_File.Click += new System.EventHandler(this.DDBtn_File_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 26);
            this.toolStripMenuItem1.Text = "退出";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // DDBtn_Beam
            // 
            this.DDBtn_Beam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Beam.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Beam.Image")));
            this.DDBtn_Beam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Beam.Name = "DDBtn_Beam";
            this.DDBtn_Beam.Size = new System.Drawing.Size(53, 24);
            this.DDBtn_Beam.Text = "横梁";
            this.DDBtn_Beam.Visible = false;
            // 
            // DDBtn_Adjust
            // 
            this.DDBtn_Adjust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Adjust.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Adjust.Image")));
            this.DDBtn_Adjust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Adjust.Name = "DDBtn_Adjust";
            this.DDBtn_Adjust.Size = new System.Drawing.Size(53, 24);
            this.DDBtn_Adjust.Text = "修正";
            this.DDBtn_Adjust.Visible = false;
            this.DDBtn_Adjust.Click += new System.EventHandler(this.DDBtn_Adjust_Click);
            // 
            // DDBtn_Calibration
            // 
            this.DDBtn_Calibration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Calibration.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Calibration.Image")));
            this.DDBtn_Calibration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Calibration.Name = "DDBtn_Calibration";
            this.DDBtn_Calibration.Size = new System.Drawing.Size(53, 24);
            this.DDBtn_Calibration.Text = "校准";
            this.DDBtn_Calibration.Visible = false;
            this.DDBtn_Calibration.Click += new System.EventHandler(this.DDBtn_Calibration_Click);
            // 
            // DDBtn_Setting
            // 
            this.DDBtn_Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Calibrate,
            this.btn_Adjust,
            this.btn_PIDadjust,
            this.btn_RecipeManagement,
            this.btn_CommSetting});
            this.DDBtn_Setting.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Setting.Image")));
            this.DDBtn_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Setting.Name = "DDBtn_Setting";
            this.DDBtn_Setting.Size = new System.Drawing.Size(53, 28);
            this.DDBtn_Setting.Text = "设置";
            // 
            // btn_Calibrate
            // 
            this.btn_Calibrate.Name = "btn_Calibrate";
            this.btn_Calibrate.Size = new System.Drawing.Size(167, 26);
            this.btn_Calibrate.Text = "传感器校准";
            this.btn_Calibrate.Click += new System.EventHandler(this.Btn_Calibrate_Click);
            // 
            // btn_Adjust
            // 
            this.btn_Adjust.Name = "btn_Adjust";
            this.btn_Adjust.Size = new System.Drawing.Size(167, 26);
            this.btn_Adjust.Text = "横梁调整";
            this.btn_Adjust.Click += new System.EventHandler(this.btn_Adjust_Click);
            // 
            // btn_PIDadjust
            // 
            this.btn_PIDadjust.Name = "btn_PIDadjust";
            this.btn_PIDadjust.Size = new System.Drawing.Size(167, 26);
            this.btn_PIDadjust.Text = "PID修正";
            this.btn_PIDadjust.Click += new System.EventHandler(this.Btn_PIDadjust_Click);
            // 
            // btn_RecipeManagement
            // 
            this.btn_RecipeManagement.Name = "btn_RecipeManagement";
            this.btn_RecipeManagement.Size = new System.Drawing.Size(167, 26);
            this.btn_RecipeManagement.Text = "配方管理";
            this.btn_RecipeManagement.Click += new System.EventHandler(this.Btn_RecipeManagement_Click);
            // 
            // btn_CommSetting
            // 
            this.btn_CommSetting.Name = "btn_CommSetting";
            this.btn_CommSetting.Size = new System.Drawing.Size(167, 26);
            this.btn_CommSetting.Text = "通信配置";
            this.btn_CommSetting.Click += new System.EventHandler(this.btn_CommSetting_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Connect.BackColor = System.Drawing.Color.Red;
            this.btn_Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Connect.Image = ((System.Drawing.Image)(resources.GetObject("btn_Connect.Image")));
            this.btn_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(61, 28);
            this.btn_Connect.Text = "Offline";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // DDBtn_Help
            // 
            this.DDBtn_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Help.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Help.Image")));
            this.DDBtn_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Help.Name = "DDBtn_Help";
            this.DDBtn_Help.Size = new System.Drawing.Size(53, 28);
            this.DDBtn_Help.Text = "帮助";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Controls.Add(this.label_clock, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel_Right, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1065, 586);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_clock
            // 
            this.label_clock.AutoSize = true;
            this.label_clock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_clock.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_clock.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_clock.Location = new System.Drawing.Point(865, 19);
            this.label_clock.Margin = new System.Windows.Forms.Padding(0);
            this.label_clock.Name = "label_clock";
            this.label_clock.Size = new System.Drawing.Size(178, 94);
            this.label_clock.TabIndex = 8;
            this.label_clock.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::PneumaticServoMonitor.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(23, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.panel19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(333, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 439);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisX.Title = "Time[hh:mm:ss]";
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY.Title = "Force[N]";
            chartArea1.AxisY2.IsStartedFromZero = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Lime;
            chartArea1.AxisY2.Title = "Displ.[mm]";
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 96);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Force";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Position";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(529, 343);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.tableLayoutPanel3);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(529, 96);
            this.panel19.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.323186F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7096F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label15, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label16, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label17, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label18, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.label20, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Peak_MAX, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Peak_AVE, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Peak_MIN, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Valley_MAX, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Valley_AVE, 7, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Valley_MIN, 8, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(15, 11, 15, 11);
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(529, 96);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "Peak";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(281, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 37);
            this.label8.TabIndex = 1;
            this.label8.Text = "Valley";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(76, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 37);
            this.label11.TabIndex = 2;
            this.label11.Text = "MAX";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(134, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 37);
            this.label15.TabIndex = 3;
            this.label15.Text = "AVE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(192, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 37);
            this.label16.TabIndex = 4;
            this.label16.Text = "MIN";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(339, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 37);
            this.label17.TabIndex = 5;
            this.label17.Text = "MAX";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(397, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 37);
            this.label18.TabIndex = 6;
            this.label18.Text = "AVE";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(455, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 37);
            this.label20.TabIndex = 7;
            this.label20.Text = "MIN";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Peak_MAX
            // 
            this.lbl_Peak_MAX.BackColor = System.Drawing.Color.Yellow;
            this.lbl_Peak_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Peak_MAX.Location = new System.Drawing.Point(73, 48);
            this.lbl_Peak_MAX.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Peak_MAX.Name = "lbl_Peak_MAX";
            this.lbl_Peak_MAX.Size = new System.Drawing.Size(58, 37);
            this.lbl_Peak_MAX.TabIndex = 8;
            // 
            // lbl_Peak_AVE
            // 
            this.lbl_Peak_AVE.BackColor = System.Drawing.Color.Lime;
            this.lbl_Peak_AVE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Peak_AVE.Location = new System.Drawing.Point(131, 48);
            this.lbl_Peak_AVE.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Peak_AVE.Name = "lbl_Peak_AVE";
            this.lbl_Peak_AVE.Size = new System.Drawing.Size(58, 37);
            this.lbl_Peak_AVE.TabIndex = 9;
            // 
            // lbl_Peak_MIN
            // 
            this.lbl_Peak_MIN.BackColor = System.Drawing.Color.Yellow;
            this.lbl_Peak_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Peak_MIN.Location = new System.Drawing.Point(189, 48);
            this.lbl_Peak_MIN.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Peak_MIN.Name = "lbl_Peak_MIN";
            this.lbl_Peak_MIN.Size = new System.Drawing.Size(58, 37);
            this.lbl_Peak_MIN.TabIndex = 10;
            // 
            // lbl_Valley_MAX
            // 
            this.lbl_Valley_MAX.BackColor = System.Drawing.Color.Yellow;
            this.lbl_Valley_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Valley_MAX.Location = new System.Drawing.Point(336, 48);
            this.lbl_Valley_MAX.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Valley_MAX.Name = "lbl_Valley_MAX";
            this.lbl_Valley_MAX.Size = new System.Drawing.Size(58, 37);
            this.lbl_Valley_MAX.TabIndex = 11;
            // 
            // lbl_Valley_AVE
            // 
            this.lbl_Valley_AVE.BackColor = System.Drawing.Color.Lime;
            this.lbl_Valley_AVE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Valley_AVE.Location = new System.Drawing.Point(394, 48);
            this.lbl_Valley_AVE.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Valley_AVE.Name = "lbl_Valley_AVE";
            this.lbl_Valley_AVE.Size = new System.Drawing.Size(58, 37);
            this.lbl_Valley_AVE.TabIndex = 12;
            // 
            // lbl_Valley_MIN
            // 
            this.lbl_Valley_MIN.BackColor = System.Drawing.Color.Yellow;
            this.lbl_Valley_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Valley_MIN.Location = new System.Drawing.Point(452, 48);
            this.lbl_Valley_MIN.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Valley_MIN.Name = "lbl_Valley_MIN";
            this.lbl_Valley_MIN.Size = new System.Drawing.Size(62, 37);
            this.lbl_Valley_MIN.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Setting, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_ChangePath, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(332, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(533, 94);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.txt_SampleNumber);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 47);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel4.Size = new System.Drawing.Size(198, 47);
            this.panel4.TabIndex = 2;
            // 
            // txt_SampleNumber
            // 
            this.txt_SampleNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_SampleNumber.Enabled = false;
            this.txt_SampleNumber.Location = new System.Drawing.Point(0, 23);
            this.txt_SampleNumber.Name = "txt_SampleNumber";
            this.txt_SampleNumber.Size = new System.Drawing.Size(198, 28);
            this.txt_SampleNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(0, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "样品编号";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.txt_ProjectName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(211, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel3.Size = new System.Drawing.Size(198, 47);
            this.panel3.TabIndex = 1;
            // 
            // txt_ProjectName
            // 
            this.txt_ProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ProjectName.Enabled = false;
            this.txt_ProjectName.Location = new System.Drawing.Point(0, 23);
            this.txt_ProjectName.Name = "txt_ProjectName";
            this.txt_ProjectName.Size = new System.Drawing.Size(198, 28);
            this.txt_ProjectName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "方案名称";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txt_ProjectNumber);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel2.Size = new System.Drawing.Size(198, 47);
            this.panel2.TabIndex = 0;
            // 
            // txt_ProjectNumber
            // 
            this.txt_ProjectNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ProjectNumber.Enabled = false;
            this.txt_ProjectNumber.Location = new System.Drawing.Point(0, 23);
            this.txt_ProjectNumber.Name = "txt_ProjectNumber";
            this.txt_ProjectNumber.Size = new System.Drawing.Size(198, 28);
            this.txt_ProjectNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目编号";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.txt_Path);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(211, 47);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel5.Size = new System.Drawing.Size(198, 47);
            this.panel5.TabIndex = 3;
            // 
            // txt_Path
            // 
            this.txt_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Path.Location = new System.Drawing.Point(0, 23);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(198, 28);
            this.txt_Path.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "路径";
            // 
            // btn_Setting
            // 
            this.btn_Setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Setting.Location = new System.Drawing.Point(422, 10);
            this.btn_Setting.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(108, 32);
            this.btn_Setting.TabIndex = 4;
            this.btn_Setting.Text = "选择配方";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // btn_ChangePath
            // 
            this.btn_ChangePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ChangePath.Location = new System.Drawing.Point(422, 57);
            this.btn_ChangePath.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.btn_ChangePath.Name = "btn_ChangePath";
            this.btn_ChangePath.Size = new System.Drawing.Size(108, 32);
            this.btn_ChangePath.TabIndex = 5;
            this.btn_ChangePath.Text = "修改路径";
            this.btn_ChangePath.UseVisualStyleBackColor = true;
            this.btn_ChangePath.Click += new System.EventHandler(this.btn_ChangePath_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.tableLayoutPanel4);
            this.panel7.Controls.Add(this.panel12);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.lbl_placeholder);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(23, 125);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel7.Size = new System.Drawing.Size(304, 439);
            this.panel7.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txt_CurParams);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 140);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 30, 0, 3);
            this.panel10.Size = new System.Drawing.Size(304, 119);
            this.panel10.TabIndex = 1;
            // 
            // txt_CurParams
            // 
            this.txt_CurParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_CurParams.Location = new System.Drawing.Point(0, 50);
            this.txt_CurParams.Multiline = true;
            this.txt_CurParams.Name = "txt_CurParams";
            this.txt_CurParams.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_CurParams.Size = new System.Drawing.Size(304, 66);
            this.txt_CurParams.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label7.Location = new System.Drawing.Point(0, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "当前参数";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_Reset, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.btn_Enable, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn_Start, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.btn_Stop, 2, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 259);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(304, 107);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Reset.Location = new System.Drawing.Point(3, 58);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(144, 44);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "复位";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Enable
            // 
            this.btn_Enable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Enable.Location = new System.Drawing.Point(3, 5);
            this.btn_Enable.Name = "btn_Enable";
            this.btn_Enable.Size = new System.Drawing.Size(144, 44);
            this.btn_Enable.TabIndex = 5;
            this.btn_Enable.Text = "使能";
            this.btn_Enable.UseVisualStyleBackColor = true;
            this.btn_Enable.Click += new System.EventHandler(this.btn_Enable_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start.Location = new System.Drawing.Point(156, 5);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(145, 44);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "开始测试";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Stop.Location = new System.Drawing.Point(156, 58);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(145, 44);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "停止测试";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.panel9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 366);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel12.Size = new System.Drawing.Size(304, 64);
            this.panel12.TabIndex = 14;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.btn_2Zero);
            this.panel18.Controls.Add(this.panel_ProgressBar);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(3, 18);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(298, 46);
            this.panel18.TabIndex = 3;
            // 
            // btn_2Zero
            // 
            this.btn_2Zero.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_2Zero.Location = new System.Drawing.Point(223, 0);
            this.btn_2Zero.Name = "btn_2Zero";
            this.btn_2Zero.Size = new System.Drawing.Size(75, 46);
            this.btn_2Zero.TabIndex = 1;
            this.btn_2Zero.Text = "清零";
            this.btn_2Zero.UseVisualStyleBackColor = true;
            this.btn_2Zero.Visible = false;
            this.btn_2Zero.Click += new System.EventHandler(this.Btn_2Zero_Click);
            // 
            // panel_ProgressBar
            // 
            this.panel_ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.panel_ProgressBar.Name = "panel_ProgressBar";
            this.panel_ProgressBar.Size = new System.Drawing.Size(298, 46);
            this.panel_ProgressBar.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lbl_StartIndex);
            this.panel9.Controls.Add(this.lbl_Times_Cur);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.lbl_TImes_Set);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(298, 18);
            this.panel9.TabIndex = 0;
            // 
            // lbl_StartIndex
            // 
            this.lbl_StartIndex.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_StartIndex.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_StartIndex.Location = new System.Drawing.Point(91, 0);
            this.lbl_StartIndex.Name = "lbl_StartIndex";
            this.lbl_StartIndex.Size = new System.Drawing.Size(69, 18);
            this.lbl_StartIndex.TabIndex = 2;
            this.lbl_StartIndex.Text = "0";
            this.lbl_StartIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Times_Cur
            // 
            this.lbl_Times_Cur.BackColor = System.Drawing.SystemColors.Menu;
            this.lbl_Times_Cur.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Times_Cur.Location = new System.Drawing.Point(160, 0);
            this.lbl_Times_Cur.Name = "lbl_Times_Cur";
            this.lbl_Times_Cur.Size = new System.Drawing.Size(69, 18);
            this.lbl_Times_Cur.TabIndex = 1;
            this.lbl_Times_Cur.Text = "0";
            this.lbl_Times_Cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "循环次数";
            // 
            // lbl_TImes_Set
            // 
            this.lbl_TImes_Set.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_TImes_Set.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_TImes_Set.Location = new System.Drawing.Point(229, 0);
            this.lbl_TImes_Set.Name = "lbl_TImes_Set";
            this.lbl_TImes_Set.Size = new System.Drawing.Size(69, 18);
            this.lbl_TImes_Set.TabIndex = 0;
            this.lbl_TImes_Set.Text = "0";
            this.lbl_TImes_Set.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Font = new System.Drawing.Font("Calibri", 4F);
            this.label10.Location = new System.Drawing.Point(0, 430);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 9);
            this.label10.TabIndex = 13;
            this.label10.Text = "                               ";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 76);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel8.Size = new System.Drawing.Size(304, 64);
            this.panel8.TabIndex = 11;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lbl_ActualPosition);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Controls.Add(this.btn_PositionClear);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(3, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(296, 64);
            this.panel11.TabIndex = 3;
            // 
            // lbl_ActualPosition
            // 
            this.lbl_ActualPosition.BackColor = System.Drawing.Color.LightGray;
            this.lbl_ActualPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ActualPosition.Font = new System.Drawing.Font("Calibri", 20F);
            this.lbl_ActualPosition.Location = new System.Drawing.Point(0, 20);
            this.lbl_ActualPosition.Margin = new System.Windows.Forms.Padding(3, 0, 13, 0);
            this.lbl_ActualPosition.Name = "lbl_ActualPosition";
            this.lbl_ActualPosition.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbl_ActualPosition.Size = new System.Drawing.Size(219, 44);
            this.lbl_ActualPosition.TabIndex = 5;
            this.lbl_ActualPosition.Text = "0.000";
            this.lbl_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "实时位移";
            // 
            // btn_PositionClear
            // 
            this.btn_PositionClear.AutoSize = true;
            this.btn_PositionClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PositionClear.Location = new System.Drawing.Point(219, 0);
            this.btn_PositionClear.Name = "btn_PositionClear";
            this.btn_PositionClear.Padding = new System.Windows.Forms.Padding(9, 15, 0, 0);
            this.btn_PositionClear.Size = new System.Drawing.Size(77, 64);
            this.btn_PositionClear.TabIndex = 0;
            this.btn_PositionClear.Text = "清零";
            this.btn_PositionClear.UseVisualStyleBackColor = true;
            this.btn_PositionClear.CheckedChanged += new System.EventHandler(this.btn_PositionClear_CheckedChanged);
            // 
            // lbl_placeholder
            // 
            this.lbl_placeholder.AutoSize = true;
            this.lbl_placeholder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_placeholder.Font = new System.Drawing.Font("Calibri", 4F);
            this.lbl_placeholder.Location = new System.Drawing.Point(0, 67);
            this.lbl_placeholder.Name = "lbl_placeholder";
            this.lbl_placeholder.Size = new System.Drawing.Size(67, 9);
            this.lbl_placeholder.TabIndex = 10;
            this.lbl_placeholder.Text = "                               ";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 3);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel6.Size = new System.Drawing.Size(304, 64);
            this.panel6.TabIndex = 9;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.lbl_ActualForce);
            this.panel13.Controls.Add(this.label6);
            this.panel13.Controls.Add(this.btn_ForceClear);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(3, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(296, 64);
            this.panel13.TabIndex = 4;
            // 
            // lbl_ActualForce
            // 
            this.lbl_ActualForce.BackColor = System.Drawing.Color.LightGray;
            this.lbl_ActualForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ActualForce.Font = new System.Drawing.Font("Calibri", 20F);
            this.lbl_ActualForce.Location = new System.Drawing.Point(0, 20);
            this.lbl_ActualForce.Margin = new System.Windows.Forms.Padding(3, 0, 13, 0);
            this.lbl_ActualForce.Name = "lbl_ActualForce";
            this.lbl_ActualForce.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lbl_ActualForce.Size = new System.Drawing.Size(219, 44);
            this.lbl_ActualForce.TabIndex = 5;
            this.lbl_ActualForce.Text = "0.000";
            this.lbl_ActualForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "实时载荷";
            // 
            // btn_ForceClear
            // 
            this.btn_ForceClear.AutoSize = true;
            this.btn_ForceClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ForceClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ForceClear.FlatAppearance.BorderSize = 2;
            this.btn_ForceClear.Location = new System.Drawing.Point(219, 0);
            this.btn_ForceClear.Name = "btn_ForceClear";
            this.btn_ForceClear.Padding = new System.Windows.Forms.Padding(9, 15, 0, 0);
            this.btn_ForceClear.Size = new System.Drawing.Size(77, 64);
            this.btn_ForceClear.TabIndex = 6;
            this.btn_ForceClear.Text = "清零";
            this.btn_ForceClear.UseVisualStyleBackColor = true;
            this.btn_ForceClear.CheckedChanged += new System.EventHandler(this.btn_ForceClear_CheckedChanged);
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.panel15);
            this.panel_Right.Controls.Add(this.panel23);
            this.panel_Right.Controls.Add(this.panel14);
            this.panel_Right.Controls.Add(this.btn_EMG);
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(868, 125);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(172, 439);
            this.panel_Right.TabIndex = 11;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tabControl1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 67);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(172, 279);
            this.panel15.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(1, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(172, 279);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_Clear);
            this.tabPage1.Controls.Add(this.txt_Log_Cur);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(164, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前报警";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Location = new System.Drawing.Point(101, 219);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(65, 25);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // txt_Log_Cur
            // 
            this.txt_Log_Cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Log_Cur.Enabled = false;
            this.txt_Log_Cur.Location = new System.Drawing.Point(0, 0);
            this.txt_Log_Cur.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Log_Cur.Multiline = true;
            this.txt_Log_Cur.Name = "txt_Log_Cur";
            this.txt_Log_Cur.Size = new System.Drawing.Size(164, 245);
            this.txt_Log_Cur.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Log);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(164, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史报警";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_Log
            // 
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Log.Enabled = false;
            this.txt_Log.Location = new System.Drawing.Point(0, 0);
            this.txt_Log.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Size = new System.Drawing.Size(164, 249);
            this.txt_Log.TabIndex = 1;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.cmb_SaveFrequency);
            this.panel23.Controls.Add(this.label19);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Margin = new System.Windows.Forms.Padding(0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel23.Size = new System.Drawing.Size(172, 67);
            this.panel23.TabIndex = 4;
            // 
            // cmb_SaveFrequency
            // 
            this.cmb_SaveFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_SaveFrequency.FormattingEnabled = true;
            this.cmb_SaveFrequency.Items.AddRange(new object[] {
            "1000",
            "10000",
            "100000",
            "1000000"});
            this.cmb_SaveFrequency.Location = new System.Drawing.Point(0, 22);
            this.cmb_SaveFrequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_SaveFrequency.Name = "cmb_SaveFrequency";
            this.cmb_SaveFrequency.Size = new System.Drawing.Size(172, 29);
            this.cmb_SaveFrequency.TabIndex = 2;
            this.cmb_SaveFrequency.SelectedIndexChanged += new System.EventHandler(this.cmb_SaveFrequency_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label19.Location = new System.Drawing.Point(0, 4);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label19.Size = new System.Drawing.Size(134, 18);
            this.label19.TabIndex = 0;
            this.label19.Text = "单个日志保存记录数";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label14);
            this.panel14.Controls.Add(this.panel17);
            this.panel14.Controls.Add(this.label13);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 346);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel14.Size = new System.Drawing.Size(172, 35);
            this.panel14.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(116, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.label14.Size = new System.Drawing.Size(67, 26);
            this.label14.TabIndex = 18;
            this.label14.Text = "故障中";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.pic_Error);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(94, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(22, 35);
            this.panel17.TabIndex = 17;
            // 
            // pic_Error
            // 
            this.pic_Error.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_Error.Image = global::PneumaticServoMonitor.Properties.Resources.status_busy;
            this.pic_Error.Location = new System.Drawing.Point(0, 0);
            this.pic_Error.Name = "pic_Error";
            this.pic_Error.Size = new System.Drawing.Size(22, 24);
            this.pic_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Error.TabIndex = 14;
            this.pic_Error.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(27, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.label13.Size = new System.Drawing.Size(67, 26);
            this.label13.TabIndex = 16;
            this.label13.Text = "运行中";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.pic_Running);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(5, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(22, 35);
            this.panel16.TabIndex = 15;
            // 
            // pic_Running
            // 
            this.pic_Running.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_Running.Image = global::PneumaticServoMonitor.Properties.Resources.status;
            this.pic_Running.Location = new System.Drawing.Point(0, 0);
            this.pic_Running.Name = "pic_Running";
            this.pic_Running.Size = new System.Drawing.Size(22, 24);
            this.pic_Running.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Running.TabIndex = 14;
            this.pic_Running.TabStop = false;
            // 
            // btn_EMG
            // 
            this.btn_EMG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_EMG.Location = new System.Drawing.Point(0, 381);
            this.btn_EMG.Name = "btn_EMG";
            this.btn_EMG.Size = new System.Drawing.Size(172, 58);
            this.btn_EMG.TabIndex = 11;
            this.btn_EMG.Text = "急停";
            this.btn_EMG.UseVisualStyleBackColor = true;
            this.btn_EMG.Click += new System.EventHandler(this.btn_EMG_Click);
            // 
            // imageList_Status
            // 
            this.imageList_Status.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Status.ImageStream")));
            this.imageList_Status.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Status.Images.SetKeyName(0, "status-offline.png");
            this.imageList_Status.Images.SetKeyName(1, "status.png");
            this.imageList_Status.Images.SetKeyName(2, "status-busy.png");
            this.imageList_Status.Images.SetKeyName(3, "status-away.png");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PST";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel19.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel_Right.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Error)).EndInit();
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Running)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_File;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_Beam;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_Calibration;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_clock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_SampleNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_ProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_ProjectNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.Button btn_ChangePath;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btn_2Zero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txt_CurParams;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbl_placeholder;
        private System.Windows.Forms.Panel panel_ProgressBar;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbl_ActualPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lbl_ActualForce;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btn_EMG;
        private System.Windows.Forms.ImageList imageList_Status;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.PictureBox pic_Running;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.PictureBox pic_Error;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Enable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_Adjust;
        private System.Windows.Forms.ToolStripDropDownButton DDBtn_Setting;
        private System.Windows.Forms.ToolStripMenuItem btn_Calibrate;
        private System.Windows.Forms.ToolStripMenuItem btn_PIDadjust;
        private System.Windows.Forms.ToolStripMenuItem btn_RecipeManagement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripMenuItem btn_CommSetting;
        private System.Windows.Forms.CheckBox btn_ForceClear;
        private System.Windows.Forms.CheckBox btn_PositionClear;
        private System.Windows.Forms.ToolStripButton btn_Connect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel23;
        public System.Windows.Forms.ComboBox cmb_SaveFrequency;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbl_Times_Cur;
        private System.Windows.Forms.Label lbl_TImes_Set;
        private System.Windows.Forms.TextBox txt_Log_Cur;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl_StartIndex;
        private System.Windows.Forms.ToolStripMenuItem btn_Adjust;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_Peak_MAX;
        private System.Windows.Forms.Label lbl_Peak_AVE;
        private System.Windows.Forms.Label lbl_Peak_MIN;
        private System.Windows.Forms.Label lbl_Valley_MAX;
        private System.Windows.Forms.Label lbl_Valley_AVE;
        private System.Windows.Forms.Label lbl_Valley_MIN;
    }
}

