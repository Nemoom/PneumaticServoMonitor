namespace PneumaticServoMonitor
{
    partial class FormAdjust
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_CylinderUp = new System.Windows.Forms.Button();
            this.btn_CylinderDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CylinderSpeed = new System.Windows.Forms.Label();
            this.trackBar_CylinderSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_MotorMoveDown = new System.Windows.Forms.Button();
            this.btn_MotorMoveUp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CylinderSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.73214F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.26786F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 265);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(23, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "气缸";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_CylinderUp, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_CylinderDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_CylinderUp
            // 
            this.btn_CylinderUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CylinderUp.Font = new System.Drawing.Font("Calibri", 13F);
            this.btn_CylinderUp.Location = new System.Drawing.Point(30, 3);
            this.btn_CylinderUp.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btn_CylinderUp.Name = "btn_CylinderUp";
            this.btn_CylinderUp.Size = new System.Drawing.Size(133, 41);
            this.btn_CylinderUp.TabIndex = 2;
            this.btn_CylinderUp.Text = "▲";
            this.btn_CylinderUp.UseVisualStyleBackColor = true;
            this.btn_CylinderUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_CylinderUp_MouseDown);
            this.btn_CylinderUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CylinderUp_MouseUp);
            // 
            // btn_CylinderDown
            // 
            this.btn_CylinderDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CylinderDown.Font = new System.Drawing.Font("Calibri", 13F);
            this.btn_CylinderDown.Location = new System.Drawing.Point(223, 3);
            this.btn_CylinderDown.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btn_CylinderDown.Name = "btn_CylinderDown";
            this.btn_CylinderDown.Size = new System.Drawing.Size(133, 41);
            this.btn_CylinderDown.TabIndex = 4;
            this.btn_CylinderDown.Text = "▼";
            this.btn_CylinderDown.UseVisualStyleBackColor = true;
            this.btn_CylinderDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_CylinderDown_MouseDown);
            this.btn_CylinderDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CylinderDown_MouseUp);
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.lbl_CylinderSpeed);
            this.panel1.Controls.Add(this.trackBar_CylinderSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 59);
            this.panel1.TabIndex = 5;
            // 
            // lbl_CylinderSpeed
            // 
            this.lbl_CylinderSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_CylinderSpeed.Location = new System.Drawing.Point(0, 36);
            this.lbl_CylinderSpeed.Name = "lbl_CylinderSpeed";
            this.lbl_CylinderSpeed.Size = new System.Drawing.Size(380, 23);
            this.lbl_CylinderSpeed.TabIndex = 2;
            this.lbl_CylinderSpeed.Text = "50%";
            this.lbl_CylinderSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBar_CylinderSpeed
            // 
            this.trackBar_CylinderSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_CylinderSpeed.Location = new System.Drawing.Point(0, 0);
            this.trackBar_CylinderSpeed.Maximum = 100;
            this.trackBar_CylinderSpeed.Name = "trackBar_CylinderSpeed";
            this.trackBar_CylinderSpeed.Size = new System.Drawing.Size(380, 59);
            this.trackBar_CylinderSpeed.TabIndex = 1;
            this.trackBar_CylinderSpeed.Value = 50;
            this.trackBar_CylinderSpeed.Scroll += new System.EventHandler(this.trackBar_CylinderSpeed_Scroll);
            this.trackBar_CylinderSpeed.ValueChanged += new System.EventHandler(this.trackBar_CylinderSpeed_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(23, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 73);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "横梁";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_MotorMoveDown, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_MotorMoveUp, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 46);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_MotorMoveDown
            // 
            this.btn_MotorMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MotorMoveDown.Font = new System.Drawing.Font("Calibri", 13F);
            this.btn_MotorMoveDown.Location = new System.Drawing.Point(223, 3);
            this.btn_MotorMoveDown.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btn_MotorMoveDown.Name = "btn_MotorMoveDown";
            this.btn_MotorMoveDown.Size = new System.Drawing.Size(133, 40);
            this.btn_MotorMoveDown.TabIndex = 6;
            this.btn_MotorMoveDown.Text = "▼";
            this.btn_MotorMoveDown.UseVisualStyleBackColor = true;
            this.btn_MotorMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MotorMoveDown_MouseDown);
            this.btn_MotorMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MotorMoveDown_MouseUp);
            // 
            // btn_MotorMoveUp
            // 
            this.btn_MotorMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MotorMoveUp.Font = new System.Drawing.Font("Calibri", 13F);
            this.btn_MotorMoveUp.Location = new System.Drawing.Point(30, 3);
            this.btn_MotorMoveUp.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btn_MotorMoveUp.Name = "btn_MotorMoveUp";
            this.btn_MotorMoveUp.Size = new System.Drawing.Size(133, 40);
            this.btn_MotorMoveUp.TabIndex = 5;
            this.btn_MotorMoveUp.Text = "▲";
            this.btn_MotorMoveUp.UseVisualStyleBackColor = true;
            this.btn_MotorMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MotorMoveUp_MouseDown);
            this.btn_MotorMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MotorMoveUp_MouseUp);
            // 
            // FormAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdjust";
            this.Text = "横梁调整";
            this.Load += new System.EventHandler(this.FormAdjust_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_CylinderSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_CylinderUp;
        private System.Windows.Forms.Button btn_CylinderDown;
        private System.Windows.Forms.Button btn_MotorMoveDown;
        private System.Windows.Forms.Button btn_MotorMoveUp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CylinderSpeed;
        private System.Windows.Forms.TrackBar trackBar_CylinderSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}