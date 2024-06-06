namespace SchoolManagementSystem.School_Management
{
    partial class LicenseSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseSetting));
            this.txtActivationKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.txtLicenseType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateLicense = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtActivationKey
            // 
            this.txtActivationKey.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivationKey.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtActivationKey.Location = new System.Drawing.Point(154, 96);
            this.txtActivationKey.Name = "txtActivationKey";
            this.txtActivationKey.ReadOnly = true;
            this.txtActivationKey.Size = new System.Drawing.Size(373, 27);
            this.txtActivationKey.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(33, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 63;
            this.label5.Text = "Activation Key";
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseKey.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLicenseKey.Location = new System.Drawing.Point(154, 129);
            this.txtLicenseKey.Multiline = true;
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(373, 74);
            this.txtLicenseKey.TabIndex = 3;
            // 
            // txtLicenseType
            // 
            this.txtLicenseType.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLicenseType.Location = new System.Drawing.Point(154, 63);
            this.txtLicenseType.Name = "txtLicenseType";
            this.txtLicenseType.ReadOnly = true;
            this.txtLicenseType.Size = new System.Drawing.Size(373, 27);
            this.txtLicenseType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(33, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 61;
            this.label4.Text = "License Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(33, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 60;
            this.label3.Text = "License Type";
            // 
            // btnUpdateLicense
            // 
            this.btnUpdateLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(217)))), ((int)(((byte)(253)))));
            this.btnUpdateLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateLicense.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnUpdateLicense.FlatAppearance.BorderSize = 0;
            this.btnUpdateLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateLicense.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLicense.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateLicense.Image = global::SchoolManagementSystem.Properties.Resources.save_24x24;
            this.btnUpdateLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateLicense.Location = new System.Drawing.Point(348, 209);
            this.btnUpdateLicense.Name = "btnUpdateLicense";
            this.btnUpdateLicense.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnUpdateLicense.Size = new System.Drawing.Size(179, 34);
            this.btnUpdateLicense.TabIndex = 4;
            this.btnUpdateLicense.Text = "Update License Key";
            this.btnUpdateLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateLicense.UseVisualStyleBackColor = false;
            this.btnUpdateLicense.Click += new System.EventHandler(this.btnUpdateLicense_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblID.Location = new System.Drawing.Point(328, 220);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(14, 14);
            this.lblID.TabIndex = 115;
            this.lblID.Text = "0";
            this.lblID.Visible = false;
            // 
            // LicenseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 255);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnUpdateLicense);
            this.Controls.Add(this.txtActivationKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.txtLicenseType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LicenseSetting";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 29);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "License Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivationKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.TextBox txtLicenseType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateLicense;
        private System.Windows.Forms.Label lblID;
    }
}