using System.ComponentModel;

namespace IsolationLevelCheck {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmbox_serverName = new System.Windows.Forms.ComboBox();
            this.cmbox_databaseName = new System.Windows.Forms.ComboBox();
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.grpb_logOn = new System.Windows.Forms.GroupBox();
            this.txtbox_password = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txtbox_username = new System.Windows.Forms.TextBox();
            this.rdbtn_sqlAuth = new System.Windows.Forms.RadioButton();
            this.rdbtn_windowsAuth = new System.Windows.Forms.RadioButton();
            this.lbl_databaseName = new System.Windows.Forms.Label();
            this.grpbbox_isolationLevelCheck = new System.Windows.Forms.GroupBox();
            this.lbl_isolationLevelSet = new System.Windows.Forms.Label();
            this.cmbox_isolationLevel = new System.Windows.Forms.ComboBox();
            this.rdbtn_setIsolationLevel = new System.Windows.Forms.RadioButton();
            this.rdbtn_useDatabaseLevel = new System.Windows.Forms.RadioButton();
            this.btn_check = new System.Windows.Forms.Button();
            this.lbl_isolationLevel = new System.Windows.Forms.Label();
            this.lbl_isolationLevelValue = new System.Windows.Forms.Label();
            this.btn_databaseRefresh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpb_logOn.SuspendLayout();
            this.grpbbox_isolationLevelCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbox_serverName
            // 
            this.cmbox_serverName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_serverName.FormattingEnabled = true;
            this.cmbox_serverName.Location = new System.Drawing.Point(4, 19);
            this.cmbox_serverName.Name = "cmbox_serverName";
            this.cmbox_serverName.Size = new System.Drawing.Size(310, 21);
            this.cmbox_serverName.TabIndex = 1;
            this.cmbox_serverName.SelectedIndexChanged += new System.EventHandler(this.cmbox_serverName_SelectedIndexChanged);
            // 
            // cmbox_databaseName
            // 
            this.cmbox_databaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_databaseName.FormattingEnabled = true;
            this.cmbox_databaseName.Location = new System.Drawing.Point(4, 222);
            this.cmbox_databaseName.Name = "cmbox_databaseName";
            this.cmbox_databaseName.Size = new System.Drawing.Size(194, 21);
            this.cmbox_databaseName.TabIndex = 2;
            this.cmbox_databaseName.SelectedIndexChanged += new System.EventHandler(this.cmbox_databaseName_SelectedIndexChanged);
            // 
            // lbl_serverName
            // 
            this.lbl_serverName.AutoSize = true;
            this.lbl_serverName.Location = new System.Drawing.Point(4, 3);
            this.lbl_serverName.Name = "lbl_serverName";
            this.lbl_serverName.Size = new System.Drawing.Size(70, 13);
            this.lbl_serverName.TabIndex = 3;
            this.lbl_serverName.Text = "Server name:";
            // 
            // grpb_logOn
            // 
            this.grpb_logOn.Controls.Add(this.txtbox_password);
            this.grpb_logOn.Controls.Add(this.lbl_password);
            this.grpb_logOn.Controls.Add(this.lbl_username);
            this.grpb_logOn.Controls.Add(this.txtbox_username);
            this.grpb_logOn.Controls.Add(this.rdbtn_sqlAuth);
            this.grpb_logOn.Controls.Add(this.rdbtn_windowsAuth);
            this.grpb_logOn.Location = new System.Drawing.Point(4, 49);
            this.grpb_logOn.Name = "grpb_logOn";
            this.grpb_logOn.Size = new System.Drawing.Size(309, 142);
            this.grpb_logOn.TabIndex = 5;
            this.grpb_logOn.TabStop = false;
            this.grpb_logOn.Text = "Log on to the server:";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Enabled = false;
            this.txtbox_password.Location = new System.Drawing.Point(110, 102);
            this.txtbox_password.MaxLength = 14;
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.Size = new System.Drawing.Size(193, 20);
            this.txtbox_password.TabIndex = 5;
            this.txtbox_password.UseSystemPasswordChar = true;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Enabled = false;
            this.lbl_password.Location = new System.Drawing.Point(48, 105);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(56, 13);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "Password:";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Enabled = false;
            this.lbl_username.Location = new System.Drawing.Point(46, 79);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(58, 13);
            this.lbl_username.TabIndex = 3;
            this.lbl_username.Text = "Username:";
            // 
            // txtbox_username
            // 
            this.txtbox_username.Enabled = false;
            this.txtbox_username.Location = new System.Drawing.Point(110, 76);
            this.txtbox_username.Name = "txtbox_username";
            this.txtbox_username.Size = new System.Drawing.Size(193, 20);
            this.txtbox_username.TabIndex = 2;
            // 
            // rdbtn_sqlAuth
            // 
            this.rdbtn_sqlAuth.AutoSize = true;
            this.rdbtn_sqlAuth.Location = new System.Drawing.Point(16, 51);
            this.rdbtn_sqlAuth.Name = "rdbtn_sqlAuth";
            this.rdbtn_sqlAuth.Size = new System.Drawing.Size(173, 17);
            this.rdbtn_sqlAuth.TabIndex = 1;
            this.rdbtn_sqlAuth.Text = "Use SQL Server Authentication";
            this.rdbtn_sqlAuth.UseVisualStyleBackColor = true;
            this.rdbtn_sqlAuth.CheckedChanged += new System.EventHandler(this.rdbtn_sqlAuth_CheckedChanged);
            // 
            // rdbtn_windowsAuth
            // 
            this.rdbtn_windowsAuth.AutoSize = true;
            this.rdbtn_windowsAuth.Checked = true;
            this.rdbtn_windowsAuth.Location = new System.Drawing.Point(16, 28);
            this.rdbtn_windowsAuth.Name = "rdbtn_windowsAuth";
            this.rdbtn_windowsAuth.Size = new System.Drawing.Size(162, 17);
            this.rdbtn_windowsAuth.TabIndex = 0;
            this.rdbtn_windowsAuth.TabStop = true;
            this.rdbtn_windowsAuth.Text = "Use Windows Authentication";
            this.rdbtn_windowsAuth.UseVisualStyleBackColor = true;
            this.rdbtn_windowsAuth.CheckedChanged += new System.EventHandler(this.rdbtn_windowsAuth_CheckedChanged);
            // 
            // lbl_databaseName
            // 
            this.lbl_databaseName.AutoSize = true;
            this.lbl_databaseName.Location = new System.Drawing.Point(4, 206);
            this.lbl_databaseName.Name = "lbl_databaseName";
            this.lbl_databaseName.Size = new System.Drawing.Size(85, 13);
            this.lbl_databaseName.TabIndex = 6;
            this.lbl_databaseName.Text = "Database name:";
            // 
            // grpbbox_isolationLevelCheck
            // 
            this.grpbbox_isolationLevelCheck.Controls.Add(this.lbl_isolationLevelSet);
            this.grpbbox_isolationLevelCheck.Controls.Add(this.cmbox_isolationLevel);
            this.grpbbox_isolationLevelCheck.Controls.Add(this.rdbtn_setIsolationLevel);
            this.grpbbox_isolationLevelCheck.Controls.Add(this.rdbtn_useDatabaseLevel);
            this.grpbbox_isolationLevelCheck.Location = new System.Drawing.Point(4, 249);
            this.grpbbox_isolationLevelCheck.Name = "grpbbox_isolationLevelCheck";
            this.grpbbox_isolationLevelCheck.Size = new System.Drawing.Size(308, 113);
            this.grpbbox_isolationLevelCheck.TabIndex = 7;
            this.grpbbox_isolationLevelCheck.TabStop = false;
            this.grpbbox_isolationLevelCheck.Text = "Isolation Level Check:";
            // 
            // lbl_isolationLevelSet
            // 
            this.lbl_isolationLevelSet.AutoSize = true;
            this.lbl_isolationLevelSet.Enabled = false;
            this.lbl_isolationLevelSet.Location = new System.Drawing.Point(48, 77);
            this.lbl_isolationLevelSet.Name = "lbl_isolationLevelSet";
            this.lbl_isolationLevelSet.Size = new System.Drawing.Size(78, 13);
            this.lbl_isolationLevelSet.TabIndex = 10;
            this.lbl_isolationLevelSet.Text = "Isolation Level:";
            // 
            // cmbox_isolationLevel
            // 
            this.cmbox_isolationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_isolationLevel.Enabled = false;
            this.cmbox_isolationLevel.FormattingEnabled = true;
            this.cmbox_isolationLevel.Location = new System.Drawing.Point(132, 74);
            this.cmbox_isolationLevel.Name = "cmbox_isolationLevel";
            this.cmbox_isolationLevel.Size = new System.Drawing.Size(170, 21);
            this.cmbox_isolationLevel.TabIndex = 8;
            this.cmbox_isolationLevel.SelectedIndexChanged += new System.EventHandler(this.cmbox_isolationLevel_SelectedIndexChanged);
            // 
            // rdbtn_setIsolationLevel
            // 
            this.rdbtn_setIsolationLevel.AutoSize = true;
            this.rdbtn_setIsolationLevel.Location = new System.Drawing.Point(16, 51);
            this.rdbtn_setIsolationLevel.Name = "rdbtn_setIsolationLevel";
            this.rdbtn_setIsolationLevel.Size = new System.Drawing.Size(155, 17);
            this.rdbtn_setIsolationLevel.TabIndex = 1;
            this.rdbtn_setIsolationLevel.Text = "Set Example Isolation Level";
            this.rdbtn_setIsolationLevel.UseVisualStyleBackColor = true;
            this.rdbtn_setIsolationLevel.CheckedChanged += new System.EventHandler(this.rdbtn_setIsolationLevel_CheckedChanged);
            // 
            // rdbtn_useDatabaseLevel
            // 
            this.rdbtn_useDatabaseLevel.AutoSize = true;
            this.rdbtn_useDatabaseLevel.Checked = true;
            this.rdbtn_useDatabaseLevel.Location = new System.Drawing.Point(16, 28);
            this.rdbtn_useDatabaseLevel.Name = "rdbtn_useDatabaseLevel";
            this.rdbtn_useDatabaseLevel.Size = new System.Drawing.Size(164, 17);
            this.rdbtn_useDatabaseLevel.TabIndex = 0;
            this.rdbtn_useDatabaseLevel.TabStop = true;
            this.rdbtn_useDatabaseLevel.Text = "Use Database Isolation Level";
            this.rdbtn_useDatabaseLevel.UseVisualStyleBackColor = true;
            this.rdbtn_useDatabaseLevel.CheckedChanged += new System.EventHandler(this.rdbtn_useDatabaseLevel_CheckedChanged);
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(204, 368);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(103, 30);
            this.btn_check.TabIndex = 8;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // lbl_isolationLevel
            // 
            this.lbl_isolationLevel.AutoSize = true;
            this.lbl_isolationLevel.Enabled = false;
            this.lbl_isolationLevel.Location = new System.Drawing.Point(4, 377);
            this.lbl_isolationLevel.Name = "lbl_isolationLevel";
            this.lbl_isolationLevel.Size = new System.Drawing.Size(78, 13);
            this.lbl_isolationLevel.TabIndex = 9;
            this.lbl_isolationLevel.Text = "Isolation Level:";
            // 
            // lbl_isolationLevelValue
            // 
            this.lbl_isolationLevelValue.AutoSize = true;
            this.lbl_isolationLevelValue.Location = new System.Drawing.Point(88, 377);
            this.lbl_isolationLevelValue.Name = "lbl_isolationLevelValue";
            this.lbl_isolationLevelValue.Size = new System.Drawing.Size(0, 13);
            this.lbl_isolationLevelValue.TabIndex = 10;
            // 
            // btn_databaseRefresh
            // 
            this.btn_databaseRefresh.Location = new System.Drawing.Point(203, 216);
            this.btn_databaseRefresh.Name = "btn_databaseRefresh";
            this.btn_databaseRefresh.Size = new System.Drawing.Size(103, 30);
            this.btn_databaseRefresh.TabIndex = 11;
            this.btn_databaseRefresh.Text = "Refresh";
            this.btn_databaseRefresh.UseVisualStyleBackColor = true;
            this.btn_databaseRefresh.Click += new System.EventHandler(this.btn_databaseRefresh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(95, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_databaseRefresh);
            this.panel1.Controls.Add(this.lbl_isolationLevelValue);
            this.panel1.Controls.Add(this.lbl_isolationLevel);
            this.panel1.Controls.Add(this.btn_check);
            this.panel1.Controls.Add(this.grpbbox_isolationLevelCheck);
            this.panel1.Controls.Add(this.lbl_databaseName);
            this.panel1.Controls.Add(this.grpb_logOn);
            this.panel1.Controls.Add(this.lbl_serverName);
            this.panel1.Controls.Add(this.cmbox_databaseName);
            this.panel1.Controls.Add(this.cmbox_serverName);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 415);
            this.panel1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 417);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Database Isolation Level Check";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpb_logOn.ResumeLayout(false);
            this.grpb_logOn.PerformLayout();
            this.grpbbox_isolationLevelCheck.ResumeLayout(false);
            this.grpbbox_isolationLevelCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbox_serverName;
        private System.Windows.Forms.ComboBox cmbox_databaseName;
        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.GroupBox grpb_logOn;
        private System.Windows.Forms.RadioButton rdbtn_sqlAuth;
        private System.Windows.Forms.RadioButton rdbtn_windowsAuth;
        private System.Windows.Forms.TextBox txtbox_password;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox txtbox_username;
        private System.Windows.Forms.Label lbl_databaseName;
        private System.Windows.Forms.GroupBox grpbbox_isolationLevelCheck;
        private System.Windows.Forms.ComboBox cmbox_isolationLevel;
        private System.Windows.Forms.RadioButton rdbtn_setIsolationLevel;
        private System.Windows.Forms.RadioButton rdbtn_useDatabaseLevel;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label lbl_isolationLevel;
        private System.Windows.Forms.Label lbl_isolationLevelValue;
        private System.Windows.Forms.Button btn_databaseRefresh;
        private System.Windows.Forms.Label lbl_isolationLevelSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;

    }
}

