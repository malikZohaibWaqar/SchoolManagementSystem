namespace SchoolManagementSystem.HR_Management
{
    partial class EmployeeReports
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
            this.comboBoxMinExperianceGrid = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxQualificationGrid = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployeeTypeGrid = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartmentGrid = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxMinExperianceGrid);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxQualificationGrid);
            this.panel1.Controls.Add(this.comboBoxEmployeeTypeGrid);
            this.panel1.Controls.Add(this.comboBoxDepartmentGrid);
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
            this.btnGenerateReport.Location = new System.Drawing.Point(749, 3);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(108, 60);
            this.btnGenerateReport.TabIndex = 136;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // comboBoxMinExperianceGrid
            // 
            this.comboBoxMinExperianceGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinExperianceGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMinExperianceGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxMinExperianceGrid.FormattingEnabled = true;
            this.comboBoxMinExperianceGrid.Location = new System.Drawing.Point(493, 34);
            this.comboBoxMinExperianceGrid.Name = "comboBoxMinExperianceGrid";
            this.comboBoxMinExperianceGrid.Size = new System.Drawing.Size(187, 27);
            this.comboBoxMinExperianceGrid.TabIndex = 133;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(374, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 23);
            this.label21.TabIndex = 134;
            this.label21.Text = "Min Experiance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(374, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 132;
            this.label3.Text = "Qualification";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(3, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 19);
            this.label22.TabIndex = 130;
            this.label22.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 131;
            this.label2.Text = "Employee Type";
            // 
            // comboBoxQualificationGrid
            // 
            this.comboBoxQualificationGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQualificationGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxQualificationGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxQualificationGrid.FormattingEnabled = true;
            this.comboBoxQualificationGrid.Location = new System.Drawing.Point(493, 3);
            this.comboBoxQualificationGrid.Name = "comboBoxQualificationGrid";
            this.comboBoxQualificationGrid.Size = new System.Drawing.Size(250, 27);
            this.comboBoxQualificationGrid.TabIndex = 129;
            // 
            // comboBoxEmployeeTypeGrid
            // 
            this.comboBoxEmployeeTypeGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployeeTypeGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEmployeeTypeGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxEmployeeTypeGrid.FormattingEnabled = true;
            this.comboBoxEmployeeTypeGrid.Location = new System.Drawing.Point(118, 36);
            this.comboBoxEmployeeTypeGrid.Name = "comboBoxEmployeeTypeGrid";
            this.comboBoxEmployeeTypeGrid.Size = new System.Drawing.Size(250, 27);
            this.comboBoxEmployeeTypeGrid.TabIndex = 128;
            // 
            // comboBoxDepartmentGrid
            // 
            this.comboBoxDepartmentGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartmentGrid.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDepartmentGrid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxDepartmentGrid.FormattingEnabled = true;
            this.comboBoxDepartmentGrid.Location = new System.Drawing.Point(118, 3);
            this.comboBoxDepartmentGrid.Name = "comboBoxDepartmentGrid";
            this.comboBoxDepartmentGrid.Size = new System.Drawing.Size(250, 27);
            this.comboBoxDepartmentGrid.TabIndex = 127;
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
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowExportButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(860, 390);
            this.crystalReportViewer.TabIndex = 0;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(686, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 135;
            this.label1.Text = "(years)";
            // 
            // EmployeeReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EmployeeReports";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Employee Reports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeReports_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMinExperianceGrid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxQualificationGrid;
        private System.Windows.Forms.ComboBox comboBoxEmployeeTypeGrid;
        private System.Windows.Forms.ComboBox comboBoxDepartmentGrid;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.Label label1;
    }
}