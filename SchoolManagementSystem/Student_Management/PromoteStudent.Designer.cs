namespace SchoolManagementSystem.Student_Management
{
    partial class PromoteStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromoteStudent));
            this.comboBoxCurrentClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxPromoteClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StudentCheckboxPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelStudentList = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnPassOut = new System.Windows.Forms.Button();
            this.btnPromoteSelected = new System.Windows.Forms.Button();
            this.btnPromoteAll = new System.Windows.Forms.Button();
            this.StudentCheckboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCurrentClass
            // 
            this.comboBoxCurrentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentClass.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCurrentClass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxCurrentClass.FormattingEnabled = true;
            this.comboBoxCurrentClass.Location = new System.Drawing.Point(164, 64);
            this.comboBoxCurrentClass.Name = "comboBoxCurrentClass";
            this.comboBoxCurrentClass.Size = new System.Drawing.Size(222, 27);
            this.comboBoxCurrentClass.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(30, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 44;
            this.label7.Text = "Current Class ";
            // 
            // comboBoxPromoteClass
            // 
            this.comboBoxPromoteClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPromoteClass.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPromoteClass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxPromoteClass.FormattingEnabled = true;
            this.comboBoxPromoteClass.Location = new System.Drawing.Point(164, 97);
            this.comboBoxPromoteClass.Name = "comboBoxPromoteClass";
            this.comboBoxPromoteClass.Size = new System.Drawing.Size(222, 27);
            this.comboBoxPromoteClass.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(33, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "Promote to Class";
            // 
            // StudentCheckboxPanel
            // 
            this.StudentCheckboxPanel.AutoScroll = true;
            this.StudentCheckboxPanel.Controls.Add(this.splitter1);
            this.StudentCheckboxPanel.Controls.Add(this.panelStudentList);
            this.StudentCheckboxPanel.Controls.Add(this.splitter2);
            this.StudentCheckboxPanel.Location = new System.Drawing.Point(37, 136);
            this.StudentCheckboxPanel.Name = "StudentCheckboxPanel";
            this.StudentCheckboxPanel.Size = new System.Drawing.Size(648, 279);
            this.StudentCheckboxPanel.TabIndex = 95;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 278);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(648, 1);
            this.splitter1.TabIndex = 92;
            this.splitter1.TabStop = false;
            // 
            // panelStudentList
            // 
            this.panelStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStudentList.Location = new System.Drawing.Point(0, 1);
            this.panelStudentList.Name = "panelStudentList";
            this.panelStudentList.Size = new System.Drawing.Size(648, 278);
            this.panelStudentList.TabIndex = 3;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(648, 1);
            this.splitter2.TabIndex = 89;
            this.splitter2.TabStop = false;
            // 
            // btnPassOut
            // 
            this.btnPassOut.BackColor = System.Drawing.Color.Transparent;
            this.btnPassOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassOut.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPassOut.FlatAppearance.BorderSize = 0;
            this.btnPassOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassOut.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPassOut.Image = global::SchoolManagementSystem.Properties.Resources.passout_24x24;
            this.btnPassOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassOut.Location = new System.Drawing.Point(221, 421);
            this.btnPassOut.Name = "btnPassOut";
            this.btnPassOut.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnPassOut.Size = new System.Drawing.Size(159, 28);
            this.btnPassOut.TabIndex = 4;
            this.btnPassOut.Text = "Pass out selected";
            this.btnPassOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPassOut.UseVisualStyleBackColor = false;
            this.btnPassOut.Click += new System.EventHandler(this.btnPassout_Click);
            // 
            // btnPromoteSelected
            // 
            this.btnPromoteSelected.BackColor = System.Drawing.Color.Transparent;
            this.btnPromoteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromoteSelected.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPromoteSelected.FlatAppearance.BorderSize = 0;
            this.btnPromoteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromoteSelected.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromoteSelected.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPromoteSelected.Image = global::SchoolManagementSystem.Properties.Resources.promoteselected_24x24;
            this.btnPromoteSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromoteSelected.Location = new System.Drawing.Point(386, 421);
            this.btnPromoteSelected.Name = "btnPromoteSelected";
            this.btnPromoteSelected.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnPromoteSelected.Size = new System.Drawing.Size(166, 28);
            this.btnPromoteSelected.TabIndex = 4;
            this.btnPromoteSelected.Text = "Promote Selected";
            this.btnPromoteSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPromoteSelected.UseVisualStyleBackColor = false;
            this.btnPromoteSelected.Click += new System.EventHandler(this.btnPromoteSelected_Click);
            // 
            // btnPromoteAll
            // 
            this.btnPromoteAll.BackColor = System.Drawing.Color.Transparent;
            this.btnPromoteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromoteAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPromoteAll.FlatAppearance.BorderSize = 0;
            this.btnPromoteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromoteAll.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromoteAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPromoteAll.Image = global::SchoolManagementSystem.Properties.Resources.promoteall_24x24;
            this.btnPromoteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromoteAll.Location = new System.Drawing.Point(558, 421);
            this.btnPromoteAll.Name = "btnPromoteAll";
            this.btnPromoteAll.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnPromoteAll.Size = new System.Drawing.Size(127, 28);
            this.btnPromoteAll.TabIndex = 5;
            this.btnPromoteAll.Text = "Promote All";
            this.btnPromoteAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPromoteAll.UseVisualStyleBackColor = false;
            this.btnPromoteAll.Click += new System.EventHandler(this.btnPromoteAll_Click);
            // 
            // PromoteStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 459);
            this.Controls.Add(this.btnPassOut);
            this.Controls.Add(this.btnPromoteSelected);
            this.Controls.Add(this.btnPromoteAll);
            this.Controls.Add(this.StudentCheckboxPanel);
            this.Controls.Add(this.comboBoxCurrentClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxPromoteClass);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PromoteStudent";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Promote Students";
            this.StudentCheckboxPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCurrentClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxPromoteClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel StudentCheckboxPanel;
        private System.Windows.Forms.Panel panelStudentList;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnPromoteAll;
        private System.Windows.Forms.Button btnPromoteSelected;
        private System.Windows.Forms.Button btnPassOut;

    }
}