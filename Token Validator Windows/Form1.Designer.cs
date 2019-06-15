namespace Token_Validator_Windows
{
    partial class Form1
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
            this.scanQR = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.fromClipboard = new System.Windows.Forms.Button();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.nicknameLabelHolder = new System.Windows.Forms.Label();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.userIDlabelHolder = new System.Windows.Forms.Label();
            this.expirationLabel = new System.Windows.Forms.Label();
            this.expirationLabelHolder = new System.Windows.Forms.Label();
            this.issuanceLabel = new System.Windows.Forms.Label();
            this.issuanceLabelHolder = new System.Windows.Forms.Label();
            this.authedLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanQR
            // 
            this.scanQR.Location = new System.Drawing.Point(12, 48);
            this.scanQR.Name = "scanQR";
            this.scanQR.Size = new System.Drawing.Size(135, 23);
            this.scanQR.TabIndex = 0;
            this.scanQR.Text = "Scan QR from screen";
            this.scanQR.UseVisualStyleBackColor = true;
            this.scanQR.Click += new System.EventHandler(this.scanQR_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.authedLabel);
            this.mainPanel.Controls.Add(this.expirationLabel);
            this.mainPanel.Controls.Add(this.expirationLabelHolder);
            this.mainPanel.Controls.Add(this.issuanceLabel);
            this.mainPanel.Controls.Add(this.issuanceLabelHolder);
            this.mainPanel.Controls.Add(this.nicknameLabel);
            this.mainPanel.Controls.Add(this.nicknameLabelHolder);
            this.mainPanel.Controls.Add(this.userIDLabel);
            this.mainPanel.Controls.Add(this.userIDlabelHolder);
            this.mainPanel.Controls.Add(this.fromClipboard);
            this.mainPanel.Controls.Add(this.scanQR);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1045, 410);
            this.mainPanel.TabIndex = 1;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 359);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(1045, 51);
            this.statusPanel.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(1045, 51);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromClipboard
            // 
            this.fromClipboard.Location = new System.Drawing.Point(12, 19);
            this.fromClipboard.Name = "fromClipboard";
            this.fromClipboard.Size = new System.Drawing.Size(135, 23);
            this.fromClipboard.TabIndex = 11;
            this.fromClipboard.Text = "Token from clipboard";
            this.fromClipboard.UseVisualStyleBackColor = true;
            this.fromClipboard.Click += new System.EventHandler(this.FromClipboard_Click);
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameLabel.Location = new System.Drawing.Point(441, 53);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(0, 29);
            this.nicknameLabel.TabIndex = 15;
            // 
            // nicknameLabelHolder
            // 
            this.nicknameLabelHolder.AutoSize = true;
            this.nicknameLabelHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nicknameLabelHolder.Location = new System.Drawing.Point(308, 53);
            this.nicknameLabelHolder.Name = "nicknameLabelHolder";
            this.nicknameLabelHolder.Size = new System.Drawing.Size(127, 29);
            this.nicknameLabelHolder.TabIndex = 14;
            this.nicknameLabelHolder.Text = "Nickname:";
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDLabel.Location = new System.Drawing.Point(441, 12);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(0, 29);
            this.userIDLabel.TabIndex = 13;
            // 
            // userIDlabelHolder
            // 
            this.userIDlabelHolder.AutoSize = true;
            this.userIDlabelHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIDlabelHolder.Location = new System.Drawing.Point(342, 12);
            this.userIDlabelHolder.Name = "userIDlabelHolder";
            this.userIDlabelHolder.Size = new System.Drawing.Size(93, 29);
            this.userIDlabelHolder.TabIndex = 12;
            this.userIDlabelHolder.Text = "UserID:";
            // 
            // expirationLabel
            // 
            this.expirationLabel.AutoSize = true;
            this.expirationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirationLabel.Location = new System.Drawing.Point(441, 134);
            this.expirationLabel.Name = "expirationLabel";
            this.expirationLabel.Size = new System.Drawing.Size(0, 29);
            this.expirationLabel.TabIndex = 19;
            // 
            // expirationLabelHolder
            // 
            this.expirationLabelHolder.AutoSize = true;
            this.expirationLabelHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirationLabelHolder.Location = new System.Drawing.Point(183, 134);
            this.expirationLabelHolder.Name = "expirationLabelHolder";
            this.expirationLabelHolder.Size = new System.Drawing.Size(252, 29);
            this.expirationLabelHolder.TabIndex = 18;
            this.expirationLabelHolder.Text = "Token expiration date:";
            // 
            // issuanceLabel
            // 
            this.issuanceLabel.AutoSize = true;
            this.issuanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issuanceLabel.Location = new System.Drawing.Point(441, 93);
            this.issuanceLabel.Name = "issuanceLabel";
            this.issuanceLabel.Size = new System.Drawing.Size(0, 29);
            this.issuanceLabel.TabIndex = 17;
            // 
            // issuanceLabelHolder
            // 
            this.issuanceLabelHolder.AutoSize = true;
            this.issuanceLabelHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issuanceLabelHolder.Location = new System.Drawing.Point(193, 93);
            this.issuanceLabelHolder.Name = "issuanceLabelHolder";
            this.issuanceLabelHolder.Size = new System.Drawing.Size(242, 29);
            this.issuanceLabelHolder.TabIndex = 16;
            this.issuanceLabelHolder.Text = "Token issuance date:";
            // 
            // authedLabel
            // 
            this.authedLabel.AutoSize = true;
            this.authedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authedLabel.ForeColor = System.Drawing.Color.Crimson;
            this.authedLabel.Location = new System.Drawing.Point(3, 338);
            this.authedLabel.Name = "authedLabel";
            this.authedLabel.Size = new System.Drawing.Size(256, 18);
            this.authedLabel.TabIndex = 20;
            this.authedLabel.Text = "Not authenticated, using API as guest.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 410);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "SCP:SL Token Validator V2";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scanQR;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button fromClipboard;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Label nicknameLabelHolder;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label userIDlabelHolder;
        private System.Windows.Forms.Label expirationLabel;
        private System.Windows.Forms.Label expirationLabelHolder;
        private System.Windows.Forms.Label issuanceLabel;
        private System.Windows.Forms.Label issuanceLabelHolder;
        private System.Windows.Forms.Label authedLabel;
    }
}

