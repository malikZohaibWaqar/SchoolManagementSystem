namespace SchoolManagementSystem.Student_Management
{
    partial class StudentReports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGenderGrid = new System.Windows.Forms.ComboBox();
            this.comboBoxFeesCatagoryGrid = new System.Windows.Forms.ComboBox();
            this.comboBoxClassGrid = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerateDetailReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenerateDetailReport);
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxGenderGrid);
            this.panel1.Controls.Add(this.comboBoxFeesCatagoryGrid);
            this.panel1.Controls.Add(this.comboBoxClassGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(30, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(217)))), ((int)(((byte)(253)))));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerateReport.Image = global::SchoolManagementSystem.Properties.Resources.save_24x24;
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(462, 35);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(138, 27);
            this.btnGenerateReport.TabIndex = 136;
            this.btnGenerateReport.Text = "Simple Report";
            this.btnGenerateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(397, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 132;
            this.label3.Text = "Gender";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(3, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 19);
            this.label22.TabIndex = 130;
            this.label22.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 131;
            this.label2.Text = "Fees Category";
            // 
            // comboBoxGenderGrid
            // 
            this.comboBoxGenderGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenderGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGenderGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxGenderGrid.FormattingEnabled = true;
            this.comboBoxGenderGrid.Location = new System.Drawing.Point(462, 3);
            this.comboBoxGenderGrid.Name = "comboBoxGenderGrid";
            this.comboBoxGenderGrid.Size = new System.Drawing.Size(276, 27);
            this.comboBoxGenderGrid.TabIndex = 129;
            // 
            // comboBoxFeesCatagoryGrid
            // 
            this.comboBoxFeesCatagoryGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFeesCatagoryGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeesCatagoryGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxFeesCatagoryGrid.FormattingEnabled = true;
            this.comboBoxFeesCatagoryGrid.Location = new System.Drawing.Point(118, 36);
            this.comboBoxFeesCatagoryGrid.Name = "comboBoxFeesCatagoryGrid";
            this.comboBoxFeesCatagoryGrid.Size = new System.Drawing.Size(250, 27);
            this.comboBoxFeesCatagoryGrid.TabIndex = 128;
            // 
            // comboBoxClassGrid
            // 
            this.comboBoxClassGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClassGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClassGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxClassGrid.FormattingEnabled = true;
            this.comboBoxClassGrid.Location = new System.Drawing.Point(118, 3);
            this.comboBoxClassGrid.Name = "comboBoxClassGrid";
            this.comboBoxClassGrid.Size = new System.Drawing.Size(250, 27);
            this.comboBoxClassGrid.TabIndex = 127;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crystalReportViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(30, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 390);
            this.panel2.TabIndex = 1;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowExportButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(860, 390);
            this.crystalReportViewer.TabIndex = 0;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnGenerateDetailReport
            // 
            this.btnGenerateDetailReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(217)))), ((int)(((byte)(253)))));
            this.btnGenerateDetailReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateDetailReport.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGenerateDetailReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateDetailReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateDetailReport.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateDetailReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerateDetailReport.Image = global::SchoolManagementSystem.Properties.Resources.save_24x24;
            this.btnGenerateDetailReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateDetailReport.Location = new System.Drawing.Point(606, 35);
            this.btnGenerateDetailReport.Name = "btnGenerateDetailReport";
            this.btnGenerateDetailReport.Size = new System.Drawing.Size(132, 27);
            this.btnGenerateDetailReport.TabIndex = 136;
            this.btnGenerateDetailReport.Text = "Detail Report";
            this.btnGenerateDetailReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateDetailReport.UseVisualStyleBackColor = false;
            this.btnGenerateDetailReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // StudentReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "StudentReports";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Student Reports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentReports_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGenderGrid;
        private System.Windows.Forms.ComboBox comboBoxFeesCatagoryGrid;
        private System.Windows.Forms.ComboBox comboBoxClassGrid;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.Button btnGenerateDetailReport;
    }
}