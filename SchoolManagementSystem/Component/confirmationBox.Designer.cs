namespace SchoolManagementSystem.Component
{
    partial class confirmationBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confirmationBox));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnNo = new System.Windows.Forms.Button();
            this.pbMessage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnYes = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(452, 38);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Confirmation";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Candara", 11F);
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessage.Location = new System.Drawing.Point(59, 53);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(373, 42);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Header HeaderHeaderHeaderHeaderHeader Header HeaderHeaderHeaderHeaderHeader";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Orange;
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(452, 38);
            this.panelHeader.TabIndex = 1;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.Red;
            this.btnNo.Location = new System.Drawing.Point(0, 0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnNo.Size = new System.Drawing.Size(200, 33);
            this.btnNo.TabIndex = 13;
            this.btnNo.Text = "I don\'t want";
            this.btnNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // pbMessage
            // 
            this.pbMessage.Image = global::SchoolManagementSystem.Properties.Resources.confirmation_32x32;
            this.pbMessage.Location = new System.Drawing.Point(20, 54);
            this.pbMessage.Name = "pbMessage";
            this.pbMessage.Size = new System.Drawing.Size(32, 32);
            this.pbMessage.TabIndex = 2;
            this.pbMessage.TabStop = false;
            this.pbMessage.WaitOnLoad = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnYes);
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 33);
            this.panel1.TabIndex = 14;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.Green;
            this.btnYes.Location = new System.Drawing.Point(212, 0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnYes.Size = new System.Drawing.Size(200, 33);
            this.btnYes.TabIndex = 14;
            this.btnYes.Text = "Yes , Please";
            this.btnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // confirmationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 141);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbMessage);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblMessage);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Candara", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "confirmationBox";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 10);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "confirmation Box";
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pbMessage;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnYes;
    }
}