using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IsolationLevelCheck.Properties;
using Microsoft.Win32;

namespace IsolationLevelCheck {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private String conS, iLvl;

        private static IList<String> GetServerList() {
            var servers = new List<String>();
            // Get servers from the registry (if any)
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            Object installedInstances = null;
            if (key != null) { installedInstances = key.GetValue("InstalledInstances"); }
            List<String> instances = null;
            if (installedInstances != null) { instances = ((String[])installedInstances).ToList(); }
            if (Environment.Is64BitOperatingSystem) {
                /* The above registry check gets routed to the syswow portion of 
                 * the registry because we're running in a 32-bit app. Need 
                 * to get the 64-bit registry value(s) */
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                key = key.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                installedInstances = null;
                if (key != null) { installedInstances = key.GetValue("InstalledInstances"); }
                String[] moreInstances = null;
                if (installedInstances != null) {
                    moreInstances = (String[])installedInstances;
                    if (instances == null) {
                        instances = moreInstances.ToList();
                    } else {
                        instances.AddRange(moreInstances);
                    }
                }
            }
            foreach (var item in instances) {
                var name = System.Environment.MachineName;
                if (item != "MSSQLSERVER") { name += @"\" + item; }
                if (!servers.Contains(name.ToUpper())) { servers.Add(name.ToUpper()); }
            }

            return servers;
        }

        private IList<String> GetDataBaseList(String serverName) {

            try {
                using (var sqlConn = new SqlConnection(GetConnectionString(null))) {
                    sqlConn.Open();
                    var tblDatabases = sqlConn.GetSchema("Databases");
                    sqlConn.Close();

                    return (from DataRow row in tblDatabases.Rows select row["database_name"].ToString()).ToList();
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
                return new List<String>();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e) {
            cmbox_serverName.SelectedIndexChanged -= cmbox_serverName_SelectedIndexChanged;
            cmbox_serverName.DataSource = GetServerList();
            cmbox_serverName.SelectedIndex = -1;
            cmbox_serverName.SelectedIndexChanged += cmbox_serverName_SelectedIndexChanged;
            SetIsolationLevelList(); 
        }

        private void cmbox_serverName_SelectedIndexChanged(object sender, EventArgs e) {
            lbl_isolationLevelValue.Text = "";
            lbl_isolationLevelValue.Enabled = false;
            lbl_isolationLevel.Enabled = false;

            if (!String.IsNullOrEmpty(cmbox_serverName.Text)) {
                cmbox_databaseName.DataSource = GetDataBaseList(cmbox_serverName.Text);
            }
        }

        private String GetConnectionString(String dbName) {
            if (String.IsNullOrEmpty(cmbox_serverName.Text)) {
                return null;
            }
            var connection = new SqlConnectionStringBuilder { DataSource = cmbox_serverName.Text, IntegratedSecurity = true };
            if (!String.IsNullOrEmpty(dbName)) {
                connection.InitialCatalog = dbName;
            }
            if (rdbtn_sqlAuth.Checked) {
                connection.UserID = txtbox_username.Text;
                connection.Password = txtbox_password.Text;
                connection.IntegratedSecurity = false;
            }
            return connection.ToString();
        }

        private void rdbtn_sqlAuth_CheckedChanged(object sender, EventArgs e) {
            ChangeAuthMethod();
        }

        private void ChangeAuthMethod() {
            if (rdbtn_sqlAuth.Checked) {
                txtbox_password.Enabled = true;
                txtbox_username.Enabled = true;
                lbl_password.Enabled = true;
                lbl_username.Enabled = true;
            } else {
                txtbox_password.Enabled = false;
                txtbox_username.Enabled = false;
                lbl_password.Enabled = false;
                lbl_username.Enabled = false;
            }
        }

        private void rdbtn_windowsAuth_CheckedChanged(object sender, EventArgs e) {
            ChangeAuthMethod();
        }

        private void btn_databaseRefresh_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(cmbox_serverName.Text)) {
                cmbox_databaseName.DataSource = GetDataBaseList(cmbox_serverName.Text);
            }
        }

        private void rdbtn_setIsolationLevel_CheckedChanged(object sender, EventArgs e) {
            ChachgeIsolationLevel();
        }

        private void rdbtn_useDatabaseLevel_CheckedChanged(object sender, EventArgs e) {
            ChachgeIsolationLevel();
        }

        private void ChachgeIsolationLevel() {
            if (rdbtn_setIsolationLevel.Checked) {
                lbl_isolationLevelSet.Enabled = true;
                cmbox_isolationLevel.Enabled = true;
            } else {
                lbl_isolationLevelSet.Enabled = false;
                cmbox_isolationLevel.Enabled = false;
                cmbox_isolationLevel.SelectedIndex = -1;
            }

            lbl_isolationLevelValue.Text = "";
            lbl_isolationLevelValue.Enabled = false;
            lbl_isolationLevel.Enabled = false;
        }

        private void SetIsolationLevelList() {
            cmbox_isolationLevel.DataSource = new List<String>
            {
                "Serializable", "Repeatable Read", "Read Committed", "Read Uncommitted"
            };
            cmbox_isolationLevel.SelectedIndex = -1;
        }

        private void btn_check_Click(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(cmbox_serverName.Text) || String.IsNullOrEmpty(cmbox_databaseName.Text)) {
                MessageBox.Show("Select a server and a database");
                return;
            }

            conS = GetConnectionString(cmbox_databaseName.Text);
            iLvl = (rdbtn_setIsolationLevel.Checked) ? cmbox_isolationLevel.Text : "";
            pictureBox1.Image = Resources.circle_loading;
            var gp = Transparent(pictureBox1.Image);
            pictureBox1.Parent = this;
            pictureBox1.BringToFront();
            panel1.Enabled = false;
            pictureBox1.Region = new System.Drawing.Region(gp);
            pictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();          
            
        }

        private void cmbox_databaseName_SelectedIndexChanged(object sender, EventArgs e) {
            lbl_isolationLevelValue.Text = "";
            lbl_isolationLevelValue.Enabled = false;
            lbl_isolationLevel.Enabled = false;
        }

        private void cmbox_isolationLevel_SelectedIndexChanged(object sender, EventArgs e) {
            lbl_isolationLevelValue.Text = "";
            lbl_isolationLevelValue.Enabled = false;
            lbl_isolationLevel.Enabled = false;
        }

        public static System.Drawing.Drawing2D.GraphicsPath Transparent(Image im)  
        {  
            int x;  
            int y;  
            var bmp = new Bitmap(im);  
            var gp = new System.Drawing.Drawing2D.GraphicsPath();  
            var mask = bmp.GetPixel(0, 0);  
  
            for (x = 0; x <= bmp.Width - 1; x++)  
            {  
                for (y = 0; y <= bmp.Height - 1; y++)  
                {  
                    if (!bmp.GetPixel(x, y).Equals(mask))  
                    {  
                        gp.AddRectangle(new Rectangle(x, y, 1, 1));  
                    }  
                }  
            }  
            bmp.Dispose();  
            return gp;  
  
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            iLvl = IsolationLevelCheck.CheckLevel(conS, iLvl);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message);
            } else {
                lbl_isolationLevelValue.Text = iLvl;
                lbl_isolationLevel.Enabled = true;
                lbl_isolationLevelValue.Enabled = true;
                panel1.Enabled = true;
                pictureBox1.Image = null;
                pictureBox1.Visible = false;
            }
        }

    }
}
