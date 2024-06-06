namespace SchoolManagementSystem.School_Management
{
    partial class GenerateTimeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateTimeTable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxSubject = new System.Windows.Forms.GroupBox();
            this.panelBoxSubject = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalSubjects = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFirstLectureStartTime = new System.Windows.Forms.ComboBox();
            this.txtBreakDuration = new System.Windows.Forms.NumericUpDown();
            this.txtLecturesPause = new System.Windows.Forms.NumericUpDown();
            this.txtBreakAfterLectures = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLecturesDuration = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtTimeTableName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panelTimeTable = new System.Windows.Forms.Panel();
            this.panelShedule = new System.Windows.Forms.Panel();
            this.panelLectureTiming = new System.Windows.Forms.Panel();
            this.panelWeekDays = new System.Windows.Forms.Panel();
            this.btnSaveTimeTable = new System.Windows.Forms.Button();
            this.btnAdvanceTimeTable = new System.Windows.Forms.Button();
            this.btnSimpleTimeTable = new System.Windows.Forms.Button();
            this.SubjectColorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.groupBoxSubject.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturesPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakAfterLectures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturesDuration)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panelTimeTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxSubject);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(30, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 173);
            this.panel1.TabIndex = 15;
            // 
            // groupBoxSubject
            // 
            this.groupBoxSubject.Controls.Add(this.panelBoxSubject);
            this.groupBoxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSubject.Font = new System.Drawing.Font("Candara", 10F);
            this.groupBoxSubject.Location = new System.Drawing.Point(462, 0);
            this.groupBoxSubject.Name = "groupBoxSubject";
            this.groupBoxSubject.Size = new System.Drawing.Size(478, 173);
            this.groupBoxSubject.TabIndex = 9;
            this.groupBoxSubject.TabStop = false;
            this.groupBoxSubject.Text = "Subject Information";
            // 
            // panelBoxSubject
            // 
            this.panelBoxSubject.AutoScroll = true;
            this.panelBoxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoxSubject.Location = new System.Drawing.Point(3, 20);
            this.panelBoxSubject.Name = "panelBoxSubject";
            this.panelBoxSubject.Size = new System.Drawing.Size(472, 150);
            this.panelBoxSubject.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxClass);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtTotalSubjects);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBoxFirstLectureStartTime);
            this.groupBox3.Controls.Add(this.txtBreakDuration);
            this.groupBox3.Controls.Add(this.txtLecturesPause);
            this.groupBox3.Controls.Add(this.txtBreakAfterLectures);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtLecturesDuration);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 173);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.Font = new System.Drawing.Font("Candara", 10F);
            this.comboBoxClass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(154, 20);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(302, 23);
            this.comboBoxClass.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select Class";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara", 10F);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(7, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Total Subjects";
            // 
            // txtTotalSubjects
            // 
            this.txtTotalSubjects.Font = new System.Drawing.Font("Candara", 10F);
            this.txtTotalSubjects.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTotalSubjects.Location = new System.Drawing.Point(154, 80);
            this.txtTotalSubjects.Name = "txtTotalSubjects";
            this.txtTotalSubjects.Size = new System.Drawing.Size(92, 24);
            this.txtTotalSubjects.TabIndex = 4;
            this.txtTotalSubjects.ValueChanged += new System.EventHandler(this.txtTotalSubjects_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Lecture Start at";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(7, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Break After Lectures";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(252, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lecture Duration";
            // 
            // comboBoxFirstLectureStartTime
            // 
            this.comboBoxFirstLectureStartTime.Font = new System.Drawing.Font("Candara", 10F);
            this.comboBoxFirstLectureStartTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxFirstLectureStartTime.FormattingEnabled = true;
            this.comboBoxFirstLectureStartTime.Location = new System.Drawing.Point(154, 49);
            this.comboBoxFirstLectureStartTime.Name = "comboBoxFirstLectureStartTime";
            this.comboBoxFirstLectureStartTime.Size = new System.Drawing.Size(302, 23);
            this.comboBoxFirstLectureStartTime.TabIndex = 3;
            // 
            // txtBreakDuration
            // 
            this.txtBreakDuration.Font = new System.Drawing.Font("Candara", 10F);
            this.txtBreakDuration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBreakDuration.Location = new System.Drawing.Point(367, 110);
            this.txtBreakDuration.Name = "txtBreakDuration";
            this.txtBreakDuration.Size = new System.Drawing.Size(89, 24);
            this.txtBreakDuration.TabIndex = 7;
            // 
            // txtLecturesPause
            // 
            this.txtLecturesPause.Font = new System.Drawing.Font("Candara", 10F);
            this.txtLecturesPause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLecturesPause.Location = new System.Drawing.Point(154, 110);
            this.txtLecturesPause.Name = "txtLecturesPause";
            this.txtLecturesPause.Size = new System.Drawing.Size(92, 24);
            this.txtLecturesPause.TabIndex = 6;
            // 
            // txtBreakAfterLectures
            // 
            this.txtBreakAfterLectures.Font = new System.Drawing.Font("Candara", 10F);
            this.txtBreakAfterLectures.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBreakAfterLectures.Location = new System.Drawing.Point(154, 140);
            this.txtBreakAfterLectures.Name = "txtBreakAfterLectures";
            this.txtBreakAfterLectures.Size = new System.Drawing.Size(92, 24);
            this.txtBreakAfterLectures.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(252, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Break Duration";
            // 
            // txtLecturesDuration
            // 
            this.txtLecturesDuration.Font = new System.Drawing.Font("Candara", 10F);
            this.txtLecturesDuration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLecturesDuration.Location = new System.Drawing.Point(367, 80);
            this.txtLecturesDuration.Name = "txtLecturesDuration";
            this.txtLecturesDuration.Size = new System.Drawing.Size(89, 24);
            this.txtLecturesDuration.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(7, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Pause Between Lecters";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.txtTimeTableName);
            this.panel2.Location = new System.Drawing.Point(30, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 20);
            this.panel2.TabIndex = 59;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(131)))), ((int)(((byte)(215)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 19);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(462, 1);
            this.splitter1.TabIndex = 56;
            this.splitter1.TabStop = false;
            // 
            // txtTimeTableName
            // 
            this.txtTimeTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeTableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTimeTableName.Font = new System.Drawing.Font("Candara", 10F);
            this.txtTimeTableName.Location = new System.Drawing.Point(0, 0);
            this.txtTimeTableName.Name = "txtTimeTableName";
            this.txtTimeTableName.Size = new System.Drawing.Size(462, 17);
            this.txtTimeTableName.TabIndex = 10;
            this.txtTimeTableName.Text = "Enter Time Table Name";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panelTimeTable);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(30, 276);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(940, 295);
            this.groupBox6.TabIndex = 14;
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
            this.panelTimeTable.Size = new System.Drawing.Size(934, 269);
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
            // btnSaveTimeTable
            // 
            this.btnSaveTimeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(217)))), ((int)(((byte)(253)))));
            this.btnSaveTimeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTimeTable.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSaveTimeTable.FlatAppearance.BorderSize = 0;
            this.btnSaveTimeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTimeTable.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveTimeTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveTimeTable.Image = global::SchoolManagementSystem.Properties.Resources.save_24x24;
            this.btnSaveTimeTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveTimeTable.Location = new System.Drawing.Point(835, 242);
            this.btnSaveTimeTable.Name = "btnSaveTimeTable";
            this.btnSaveTimeTable.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnSaveTimeTable.Size = new System.Drawing.Size(135, 28);
            this.btnSaveTimeTable.TabIndex = 13;
            this.btnSaveTimeTable.Text = "Save Time Table";
            this.btnSaveTimeTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveTimeTable.UseVisualStyleBackColor = false;
            this.btnSaveTimeTable.Click += new System.EventHandler(this.btnSaveTimeTable_Click);
            // 
            // btnAdvanceTimeTable
            // 
            this.btnAdvanceTimeTable.BackColor = System.Drawing.Color.Transparent;
            this.btnAdvanceTimeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvanceTimeTable.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAdvanceTimeTable.FlatAppearance.BorderSize = 0;
            this.btnAdvanceTimeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanceTimeTable.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdvanceTimeTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdvanceTimeTable.Image = global::SchoolManagementSystem.Properties.Resources.timetable_24x24;
            this.btnAdvanceTimeTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdvanceTimeTable.Location = new System.Drawing.Point(662, 242);
            this.btnAdvanceTimeTable.Name = "btnAdvanceTimeTable";
            this.btnAdvanceTimeTable.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnAdvanceTimeTable.Size = new System.Drawing.Size(167, 28);
            this.btnAdvanceTimeTable.TabIndex = 12;
            this.btnAdvanceTimeTable.Text = "Advance Time Table";
            this.btnAdvanceTimeTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdvanceTimeTable.UseVisualStyleBackColor = false;
            this.btnAdvanceTimeTable.Click += new System.EventHandler(this.btnGenerateTimeTable_Click);
            // 
            // btnSimpleTimeTable
            // 
            this.btnSimpleTimeTable.BackColor = System.Drawing.Color.Transparent;
            this.btnSimpleTimeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpleTimeTable.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSimpleTimeTable.FlatAppearance.BorderSize = 0;
            this.btnSimpleTimeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpleTimeTable.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpleTimeTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSimpleTimeTable.Image = global::SchoolManagementSystem.Properties.Resources.timetable_24x24;
            this.btnSimpleTimeTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpleTimeTable.Location = new System.Drawing.Point(492, 242);
            this.btnSimpleTimeTable.Name = "btnSimpleTimeTable";
            this.btnSimpleTimeTable.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnSimpleTimeTable.Size = new System.Drawing.Size(152, 28);
            this.btnSimpleTimeTable.TabIndex = 11;
            this.btnSimpleTimeTable.Text = "Simple Time Table";
            this.btnSimpleTimeTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSimpleTimeTable.UseVisualStyleBackColor = false;
            this.btnSimpleTimeTable.Click += new System.EventHandler(this.btnGenerateTimeTable_Click);
            // 
            // SubjectColorDialog
            // 
            this.SubjectColorDialog.AllowFullOpen = false;
            this.SubjectColorDialog.SolidColorOnly = true;
            // 
            // GenerateTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnSaveTimeTable);
            this.Controls.Add(this.btnAdvanceTimeTable);
            this.Controls.Add(this.btnSimpleTimeTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GenerateTimeTable";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Generate Time Table";
            this.Load += new System.EventHandler(this.TimeTable_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxSubject.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturesPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakAfterLectures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturesDuration)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panelTimeTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown txtTotalSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxFirstLectureStartTime;
        private System.Windows.Forms.NumericUpDown txtBreakDuration;
        private System.Windows.Forms.NumericUpDown txtLecturesPause;
        private System.Windows.Forms.NumericUpDown txtBreakAfterLectures;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtLecturesDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxSubject;
        private System.Windows.Forms.Panel panelBoxSubject;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txtTimeTableName;
        private System.Windows.Forms.Button btnSimpleTimeTable;
        private System.Windows.Forms.Button btnAdvanceTimeTable;
        private System.Windows.Forms.Button btnSaveTimeTable;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panelTimeTable;
        private System.Windows.Forms.Panel panelShedule;
        private System.Windows.Forms.Panel panelLectureTiming;
        private System.Windows.Forms.Panel panelWeekDays;
        private System.Windows.Forms.ColorDialog SubjectColorDialog;

    }
}