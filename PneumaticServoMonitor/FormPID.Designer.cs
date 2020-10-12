namespace PneumaticServoMonitor
{
    partial class FormPID
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
            this.label14 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_Kp_Static = new System.Windows.Forms.NumericUpDown();
            this.txt_Kp_Dynamic = new System.Windows.Forms.NumericUpDown();
            this.txt_Kp_Follow = new System.Windows.Forms.NumericUpDown();
            this.txt_Ki_Static = new System.Windows.Forms.NumericUpDown();
            this.txt_Ki_Dynamic = new System.Windows.Forms.NumericUpDown();
            this.txt_Ki_Follow = new System.Windows.Forms.NumericUpDown();
            this.txt_Kd_Static = new System.Windows.Forms.NumericUpDown();
            this.txt_Kd_Dynamic = new System.Windows.Forms.NumericUpDown();
            this.txt_Kd_Follow = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.panel17.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Static)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Follow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Static)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Follow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Static)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Dynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Follow)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(0, 4);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label14.Size = new System.Drawing.Size(118, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "补偿速率 PID";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.tableLayoutPanel5);
            this.panel17.Controls.Add(this.button1);
            this.panel17.Controls.Add(this.label14);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(10, 5);
            this.panel17.Margin = new System.Windows.Forms.Padding(0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel17.Size = new System.Drawing.Size(437, 256);
            this.panel17.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label22, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label24, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label25, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label26, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kp_Static, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kp_Dynamic, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kp_Follow, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.txt_Ki_Static, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.txt_Ki_Dynamic, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.txt_Ki_Follow, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kd_Static, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kd_Dynamic, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.txt_Kd_Follow, 3, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(437, 191);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "Kp";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 21);
            this.label15.TabIndex = 10;
            this.label15.Text = "Ki";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 133);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 21);
            this.label22.TabIndex = 11;
            this.label22.Text = "Kd";
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(37, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(128, 20);
            this.label24.TabIndex = 12;
            this.label24.Text = "Static";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Location = new System.Drawing.Point(171, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 20);
            this.label25.TabIndex = 13;
            this.label25.Text = "Dynamic";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Location = new System.Drawing.Point(305, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(129, 20);
            this.label26.TabIndex = 14;
            this.label26.Text = "Follow";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_Kp_Static
            // 
            this.txt_Kp_Static.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kp_Static.Location = new System.Drawing.Point(37, 23);
            this.txt_Kp_Static.Name = "txt_Kp_Static";
            this.txt_Kp_Static.Size = new System.Drawing.Size(128, 28);
            this.txt_Kp_Static.TabIndex = 15;
            this.txt_Kp_Static.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kp_Static_KeyPress);
            // 
            // txt_Kp_Dynamic
            // 
            this.txt_Kp_Dynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kp_Dynamic.Location = new System.Drawing.Point(171, 23);
            this.txt_Kp_Dynamic.Name = "txt_Kp_Dynamic";
            this.txt_Kp_Dynamic.Size = new System.Drawing.Size(128, 28);
            this.txt_Kp_Dynamic.TabIndex = 16;
            this.txt_Kp_Dynamic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kp_Dynamic_KeyPress);
            // 
            // txt_Kp_Follow
            // 
            this.txt_Kp_Follow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kp_Follow.Location = new System.Drawing.Point(305, 23);
            this.txt_Kp_Follow.Name = "txt_Kp_Follow";
            this.txt_Kp_Follow.Size = new System.Drawing.Size(129, 28);
            this.txt_Kp_Follow.TabIndex = 17;
            this.txt_Kp_Follow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kp_Follow_KeyPress);
            // 
            // txt_Ki_Static
            // 
            this.txt_Ki_Static.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Ki_Static.Location = new System.Drawing.Point(37, 79);
            this.txt_Ki_Static.Name = "txt_Ki_Static";
            this.txt_Ki_Static.Size = new System.Drawing.Size(128, 28);
            this.txt_Ki_Static.TabIndex = 18;
            this.txt_Ki_Static.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Ki_Static_KeyPress);
            // 
            // txt_Ki_Dynamic
            // 
            this.txt_Ki_Dynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Ki_Dynamic.Location = new System.Drawing.Point(171, 79);
            this.txt_Ki_Dynamic.Name = "txt_Ki_Dynamic";
            this.txt_Ki_Dynamic.Size = new System.Drawing.Size(128, 28);
            this.txt_Ki_Dynamic.TabIndex = 19;
            this.txt_Ki_Dynamic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Ki_Dynamic_KeyPress);
            // 
            // txt_Ki_Follow
            // 
            this.txt_Ki_Follow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Ki_Follow.Location = new System.Drawing.Point(305, 79);
            this.txt_Ki_Follow.Name = "txt_Ki_Follow";
            this.txt_Ki_Follow.Size = new System.Drawing.Size(129, 28);
            this.txt_Ki_Follow.TabIndex = 20;
            this.txt_Ki_Follow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Ki_Follow_KeyPress);
            // 
            // txt_Kd_Static
            // 
            this.txt_Kd_Static.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kd_Static.Location = new System.Drawing.Point(37, 136);
            this.txt_Kd_Static.Name = "txt_Kd_Static";
            this.txt_Kd_Static.Size = new System.Drawing.Size(128, 28);
            this.txt_Kd_Static.TabIndex = 21;
            this.txt_Kd_Static.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kd_Static_KeyPress);
            // 
            // txt_Kd_Dynamic
            // 
            this.txt_Kd_Dynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kd_Dynamic.Location = new System.Drawing.Point(171, 136);
            this.txt_Kd_Dynamic.Name = "txt_Kd_Dynamic";
            this.txt_Kd_Dynamic.Size = new System.Drawing.Size(128, 28);
            this.txt_Kd_Dynamic.TabIndex = 22;
            this.txt_Kd_Dynamic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kd_Dynamic_KeyPress);
            // 
            // txt_Kd_Follow
            // 
            this.txt_Kd_Follow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Kd_Follow.Location = new System.Drawing.Point(305, 136);
            this.txt_Kd_Follow.Name = "txt_Kd_Follow";
            this.txt_Kd_Follow.Size = new System.Drawing.Size(129, 28);
            this.txt_Kd_Follow.TabIndex = 23;
            this.txt_Kd_Follow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Kd_Follow_KeyPress);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(437, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "更新至参数表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormPID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 266);
            this.Controls.Add(this.panel17);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPID";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数修正";
            this.Load += new System.EventHandler(this.FormPID_Load);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Static)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Dynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kp_Follow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Static)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Dynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ki_Follow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Static)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Dynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Kd_Follow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown txt_Kp_Static;
        private System.Windows.Forms.NumericUpDown txt_Kp_Dynamic;
        private System.Windows.Forms.NumericUpDown txt_Kp_Follow;
        private System.Windows.Forms.NumericUpDown txt_Ki_Static;
        private System.Windows.Forms.NumericUpDown txt_Ki_Dynamic;
        private System.Windows.Forms.NumericUpDown txt_Ki_Follow;
        private System.Windows.Forms.NumericUpDown txt_Kd_Static;
        private System.Windows.Forms.NumericUpDown txt_Kd_Dynamic;
        private System.Windows.Forms.NumericUpDown txt_Kd_Follow;
    }
}