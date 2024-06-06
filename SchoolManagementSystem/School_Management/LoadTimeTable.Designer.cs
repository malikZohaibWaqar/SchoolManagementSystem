namespace SchoolManagementSystem.School_Management
{
    partial class LoadTimeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadTimeTable));
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePng = new System.Windows.Forms.Button();
            this.btnPrintTimeTable = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panelTimeTable = new System.Windows.Forms.Panel();
            this.panelShedule = new System.Windows.Forms.Panel();
            this.panelLectureTiming = new System.Windows.Forms.Panel();
            this.panelWeekDays = new System.Windows.Forms.Panel();
            this.groupBox6.SuspendLayout();
            this.panelTimeTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.Font = new System.Drawing.Font("Candara", 10F);
            this.comboBoxClass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(115, 71);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(302, 23);
            this.comboBoxClass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(33, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select Class";
            // 
            // btnSavePng
            // 
            this.btnSavePng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(217)))), ((int)(((byte)(253)))));
            this.btnSavePng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePng.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSavePng.FlatAppearance.BorderSize = 0;
            this.btnSavePng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePng.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePng.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSavePng.Image = global::SchoolManagementSystem.Properties.Resources.save_24x24;
            this.btnSavePng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePng.Location = new System.Drawing.Point(790, 453);
            this.btnSavePng.Name = "btnSavePng";
            this.btnSavePng.Size = new System.Drawing.Size(120, 28);
            this.btnSavePng.TabIndex = 4;
            this.btnSavePng.Text = "Save to png";
            this.btnSavePng.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePng.UseVisualStyleBackColor = false;
            this.btnSavePng.Click += new System.EventHandler(this.btnSavePng_Click);
            // 
            // btnPrintTimeTable
            // 
            this.btnPrintTimeTable.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintTimeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintTimeTable.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrintTimeTable.FlatAppearance.BorderSize = 0;
            this.btnPrintTimeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintTimeTable.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintTimeTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrintTimeTable.Image = global::SchoolManagementSystem.Properties.Resources.print_24x24;
            this.btnPrintTimeTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintTimeTable.Location = new System.Drawing.Point(641, 455);
            this.btnPrintTimeTable.Name = "btnPrintTimeTable";
            this.btnPrintTimeTable.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnPrintTimeTable.Size = new System.Drawing.Size(143, 29);
            this.btnPrintTimeTable.TabIndex = 3;
            this.btnPrintTimeTable.Text = "Print Time Table";
            this.btnPrintTimeTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintTimeTable.UseVisualStyleBackColor = false;
            this.btnPrintTimeTable.Click += new System.EventHandler(this.btnPrintTimeTable_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panelTimeTable);
            this.groupBox6.Location = new System.Drawing.Point(36, 100);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(874, 347);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Table";
            // 
            // panelTimeTable
            // 
            this.panelTimeTable.AutoScroll = true;
            this.panelTimeTable.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTimeTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTimeTable.Controls.Add(this.panelShedule);
            this.panelTimeTable.Controls.Add(this.panelLectureTiming);
            this.panelTimeTable.Controls.Add(this.panelWeekDays);
            this.panelTimeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimeTable.Location = new System.Drawing.Point(3, 23);
            this.panelTimeTable.Name = "panelTimeTable";
            this.panelTimeTable.Size = new System.Drawing.Size(868, 321);
            this.panelTimeTable.TabIndex = 59;
            // 
            // panelShedule
            // 
            this.panelShedule.Location = new System.Drawing.Point(150, 43);
            this.panelShedule.Name = "panelShedule";
            this.panelShedule.Size = new System.Drawing.Size(276, 258);
            this.panelShedule.TabIndex = 5;
            // 
            // panelLectureTiming
            // 
            this.panelLectureTiming.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelLectureTiming.Location = new System.Drawing.Point(0, 43);
            this.panelLectureTiming.Name = "panelLectureTiming";
            this.panelLectureTiming.Size = new System.Drawing.Size(150, 258);
            this.panelLectureTiming.TabIndex = 4;
            // 
            // panelWeekDays
            // 
            this.panelWeekDays.Location = new System.Drawing.Point(0, 0);
            this.panelWeekDays.Name = "panelWeekDays";
            this.panelWeekDays.Size = new System.Drawing.Size(426, 43);
            this.panelWeekDays.TabIndex = 3;
            // 
            // LoadTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 503);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnSavePng);
            this.Controls.Add(this.btnPrintTimeTable);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoadTimeTable";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Load Time Table";
            this.groupBox6.ResumeLayout(false);
            this.panelTimeTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavePng;
        private System.Windows.Forms.Button btnPrintTimeTable;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panelTimeTable;
        private System.Windows.Forms.Panel panelShedule;
        private System.Windows.Forms.Panel panelLectureTiming;
        private System.Windows.Forms.Panel panelWeekDays;
    }
}