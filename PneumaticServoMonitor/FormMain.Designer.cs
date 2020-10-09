﻿namespace PneumaticServoMonitor
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_clock = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel_ProgressBar = new System.Windows.Forms.Panel();
            this.btn_2Zero = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txt_CurParams = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbl_ActualPosition = new System.Windows.Forms.Label();
            this.btn_PositionClear = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_placeholder = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lbl_ActualForce = new System.Windows.Forms.Label();
            this.btn_ForceClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btn_EMG = new System.Windows.Forms.Button();
            this.imageList_Status = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_Error = new System.Windows.Forms.PictureBox();
            this.pic_Running = new System.Windows.Forms.PictureBox();
            this.DDBtn_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DDBtn_Beam = new System.Windows.Forms.ToolStripDropDownButton();
            this.DDBtn_Calibration = new System.Windows.Forms.ToolStripDropDownButton();
            this.DDBtn_Help = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.帮助文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Enable = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel_Right.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Running)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DDBtn_File,
            this.DDBtn_Beam,
            this.DDBtn_Calibration,
            this.DDBtn_Help,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1065, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(333, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 439);
            this.panel1.TabIndex = 0;
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
            this.tableLayoutPanel2.Controls.Add(this.button2, 2, 1);
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
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 47);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel4.Size = new System.Drawing.Size(198, 47);
            this.panel4.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 23);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(198, 28);
            this.textBox3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("MetaPlusLF", 8F);
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
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(211, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel3.Size = new System.Drawing.Size(198, 47);
            this.panel3.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 28);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("MetaPlusLF", 8F);
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
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel2.Size = new System.Drawing.Size(198, 47);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 28);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MetaPlusLF", 8F);
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
            this.panel5.Controls.Add(this.textBox4);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(211, 47);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel5.Size = new System.Drawing.Size(198, 47);
            this.panel5.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(0, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(198, 28);
            this.textBox4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("MetaPlusLF", 8F);
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
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(422, 57);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "锁定操作面板";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel12);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.panel_bottom);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.lbl_placeholder);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(23, 125);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel7.Size = new System.Drawing.Size(304, 439);
            this.panel7.TabIndex = 10;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel_ProgressBar);
            this.panel12.Controls.Add(this.btn_2Zero);
            this.panel12.Controls.Add(this.label12);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 163);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel12.Size = new System.Drawing.Size(304, 64);
            this.panel12.TabIndex = 14;
            // 
            // panel_ProgressBar
            // 
            this.panel_ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ProgressBar.Location = new System.Drawing.Point(3, 20);
            this.panel_ProgressBar.Name = "panel_ProgressBar";
            this.panel_ProgressBar.Size = new System.Drawing.Size(223, 44);
            this.panel_ProgressBar.TabIndex = 2;
            // 
            // btn_2Zero
            // 
            this.btn_2Zero.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_2Zero.Location = new System.Drawing.Point(226, 20);
            this.btn_2Zero.Name = "btn_2Zero";
            this.btn_2Zero.Size = new System.Drawing.Size(75, 44);
            this.btn_2Zero.TabIndex = 1;
            this.btn_2Zero.Text = "清零";
            this.btn_2Zero.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("MetaPlusLF", 8F);
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "循环次数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Font = new System.Drawing.Font("Calibri", 4F);
            this.label10.Location = new System.Drawing.Point(0, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 9);
            this.label10.TabIndex = 13;
            this.label10.Text = "                               ";
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.tableLayoutPanel3);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 236);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(304, 200);
            this.panel_bottom.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.65676F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.34324F));
            this.tableLayoutPanel3.Controls.Add(this.btn_Reset, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel10, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Start, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_Stop, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_Enable, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(304, 200);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Reset.Location = new System.Drawing.Point(208, 163);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(93, 34);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "复位";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.txt_CurParams);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Location = new System.Drawing.Point(3, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel3.SetRowSpan(this.panel10, 4);
            this.panel10.Size = new System.Drawing.Size(202, 200);
            this.panel10.TabIndex = 1;
            // 
            // txt_CurParams
            // 
            this.txt_CurParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_CurParams.Location = new System.Drawing.Point(0, 23);
            this.txt_CurParams.Multiline = true;
            this.txt_CurParams.Name = "txt_CurParams";
            this.txt_CurParams.Size = new System.Drawing.Size(202, 174);
            this.txt_CurParams.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("MetaPlusLF", 8F);
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "当前参数";
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Start.Location = new System.Drawing.Point(208, 83);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(93, 34);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "开始测试";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Stop.Location = new System.Drawing.Point(208, 123);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(93, 34);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "停止测试";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
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
            this.panel11.Controls.Add(this.btn_PositionClear);
            this.panel11.Controls.Add(this.label9);
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
            this.lbl_ActualPosition.Size = new System.Drawing.Size(221, 44);
            this.lbl_ActualPosition.TabIndex = 5;
            this.lbl_ActualPosition.Text = "0.000";
            this.lbl_ActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PositionClear
            // 
            this.btn_PositionClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PositionClear.Location = new System.Drawing.Point(221, 20);
            this.btn_PositionClear.Name = "btn_PositionClear";
            this.btn_PositionClear.Size = new System.Drawing.Size(75, 44);
            this.btn_PositionClear.TabIndex = 4;
            this.btn_PositionClear.Text = "清零";
            this.btn_PositionClear.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("MetaPlusLF", 8F);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "实时位移";
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
            this.panel13.Controls.Add(this.btn_ForceClear);
            this.panel13.Controls.Add(this.label6);
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
            this.lbl_ActualForce.Size = new System.Drawing.Size(221, 44);
            this.lbl_ActualForce.TabIndex = 5;
            this.lbl_ActualForce.Text = "0.000";
            this.lbl_ActualForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ForceClear
            // 
            this.btn_ForceClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ForceClear.Location = new System.Drawing.Point(221, 20);
            this.btn_ForceClear.Name = "btn_ForceClear";
            this.btn_ForceClear.Size = new System.Drawing.Size(75, 44);
            this.btn_ForceClear.TabIndex = 4;
            this.btn_ForceClear.Text = "清零";
            this.btn_ForceClear.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("MetaPlusLF", 8F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "实时载荷";
            // 
            // panel_Right
            // 
            this.panel_Right.Controls.Add(this.panel15);
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
            this.panel15.Controls.Add(this.textBox6);
            this.panel15.Controls.Add(this.label11);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel15.Size = new System.Drawing.Size(172, 346);
            this.panel15.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(0, 23);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(172, 320);
            this.textBox6.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("MetaPlusLF", 8F);
            this.label11.Location = new System.Drawing.Point(0, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "报警信息";
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pic_Error
            // 
            this.pic_Error.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic_Error.Image = global::PneumaticServoMonitor.Properties.Resources.status;
            this.pic_Error.Location = new System.Drawing.Point(0, 0);
            this.pic_Error.Name = "pic_Error";
            this.pic_Error.Size = new System.Drawing.Size(22, 24);
            this.pic_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Error.TabIndex = 14;
            this.pic_Error.TabStop = false;
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
            // 
            // DDBtn_Beam
            // 
            this.DDBtn_Beam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Beam.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Beam.Image")));
            this.DDBtn_Beam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Beam.Name = "DDBtn_Beam";
            this.DDBtn_Beam.Size = new System.Drawing.Size(53, 28);
            this.DDBtn_Beam.Text = "横梁";
            // 
            // DDBtn_Calibration
            // 
            this.DDBtn_Calibration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DDBtn_Calibration.Image = ((System.Drawing.Image)(resources.GetObject("DDBtn_Calibration.Image")));
            this.DDBtn_Calibration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DDBtn_Calibration.Name = "DDBtn_Calibration";
            this.DDBtn_Calibration.Size = new System.Drawing.Size(53, 28);
            this.DDBtn_Calibration.Text = "校准";
            this.DDBtn_Calibration.Click += new System.EventHandler(this.DDBtn_Calibration_Click);
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
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助文件ToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(58, 28);
            this.toolStripSplitButton1.Text = "帮助";
            // 
            // 帮助文件ToolStripMenuItem
            // 
            this.帮助文件ToolStripMenuItem.Name = "帮助文件ToolStripMenuItem";
            this.帮助文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.帮助文件ToolStripMenuItem.Text = "帮助文件";
            // 
            // btn_Enable
            // 
            this.btn_Enable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Enable.Location = new System.Drawing.Point(208, 43);
            this.btn_Enable.Name = "btn_Enable";
            this.btn_Enable.Size = new System.Drawing.Size(93, 34);
            this.btn_Enable.TabIndex = 5;
            this.btn_Enable.Text = "使能";
            this.btn_Enable.UseVisualStyleBackColor = true;
            this.btn_Enable.Click += new System.EventHandler(this.btn_Enable_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel_bottom.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel_Right.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Error)).EndInit();
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
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助文件ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_clock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btn_2Zero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txt_CurParams;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbl_placeholder;
        private System.Windows.Forms.Panel panel_ProgressBar;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbl_ActualPosition;
        private System.Windows.Forms.Button btn_PositionClear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lbl_ActualForce;
        private System.Windows.Forms.Button btn_ForceClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btn_EMG;
        private System.Windows.Forms.ImageList imageList_Status;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
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
    }
}

