namespace PneumaticServoMonitor
{
    partial class FormCalibrate
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ActualVoltage = new System.Windows.Forms.TextBox();
            this.txt_ActualForce = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_CalForce1 = new System.Windows.Forms.NumericUpDown();
            this.txt_CalVoltage1 = new System.Windows.Forms.NumericUpDown();
            this.txt_CalVoltage2 = new System.Windows.Forms.NumericUpDown();
            this.txt_CalForce2 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalForce1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalVoltage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalVoltage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalForce2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_ActualVoltage, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_ActualForce, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_CalVoltage1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_CalVoltage2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_CalForce1, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_CalForce2, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 179);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前电压";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前压力";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "电压值1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "压力值1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "电压值2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "压力值2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(611, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 25);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Tare";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Calibrate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_ActualVoltage
            // 
            this.txt_ActualVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ActualVoltage.Location = new System.Drawing.Point(118, 29);
            this.txt_ActualVoltage.Name = "txt_ActualVoltage";
            this.txt_ActualVoltage.Size = new System.Drawing.Size(178, 28);
            this.txt_ActualVoltage.TabIndex = 8;
            // 
            // txt_ActualForce
            // 
            this.txt_ActualForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ActualForce.Location = new System.Drawing.Point(412, 29);
            this.txt_ActualForce.Name = "txt_ActualForce";
            this.txt_ActualForce.Size = new System.Drawing.Size(178, 28);
            this.txt_ActualForce.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // txt_CalForce1
            // 
            this.txt_CalForce1.Location = new System.Drawing.Point(412, 71);
            this.txt_CalForce1.Name = "txt_CalForce1";
            this.txt_CalForce1.Size = new System.Drawing.Size(120, 28);
            this.txt_CalForce1.TabIndex = 16;
            // 
            // txt_CalVoltage1
            // 
            this.txt_CalVoltage1.Location = new System.Drawing.Point(118, 71);
            this.txt_CalVoltage1.Name = "txt_CalVoltage1";
            this.txt_CalVoltage1.Size = new System.Drawing.Size(120, 28);
            this.txt_CalVoltage1.TabIndex = 17;
            // 
            // txt_CalVoltage2
            // 
            this.txt_CalVoltage2.Location = new System.Drawing.Point(118, 113);
            this.txt_CalVoltage2.Name = "txt_CalVoltage2";
            this.txt_CalVoltage2.Size = new System.Drawing.Size(120, 28);
            this.txt_CalVoltage2.TabIndex = 18;
            // 
            // txt_CalForce2
            // 
            this.txt_CalForce2.Location = new System.Drawing.Point(412, 113);
            this.txt_CalForce2.Name = "txt_CalForce2";
            this.txt_CalForce2.Size = new System.Drawing.Size(120, 28);
            this.txt_CalForce2.TabIndex = 19;
            // 
            // FormCalibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 179);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalibrate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "校准";
            this.Load += new System.EventHandler(this.FormCalibrate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalForce1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalVoltage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalVoltage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CalForce2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ActualVoltage;
        private System.Windows.Forms.TextBox txt_ActualForce;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown txt_CalForce1;
        private System.Windows.Forms.NumericUpDown txt_CalVoltage1;
        private System.Windows.Forms.NumericUpDown txt_CalVoltage2;
        private System.Windows.Forms.NumericUpDown txt_CalForce2;
    }
}