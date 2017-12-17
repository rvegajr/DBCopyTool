using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DatabaseCopier.Class;



namespace DatabaseCopier
{
    public partial class frmDBTools : Form
    {

        private cSettings mySettings;

#region "Initialization"
        /// <summary>
        /// Toolstripbutton to close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmDBTools()
        {
            InitializeComponent();

        }

#endregion

#region "Copy database tab"
        private DataTable GetDatabaseNames(string sServer, bool bIntegrated, string sUsername, string sPassword)
        {
            cDatabaseHelper db = new cDatabaseHelper(sServer, bIntegrated, sUsername, sPassword, "master");
            return db.GetDatabases();
        }

        private void cmbFromDatabase_DropDown(object sender, EventArgs e)
        {
            //Load possible Databases                        
            cmbFromDatabase.ValueMember = "name";
            cmbFromDatabase.DisplayMember = "name";
            try
            {
                cmbFromDatabase.DataSource = GetDatabaseNames(cmbFromServer.Text, chkFromServerIntegrated.Checked, txtFromServerUser.Text, txtFromServerPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbToDatabase_DropDown(object sender, EventArgs e)
        {
            //Load possible Databases
            cmbToDatabase.ValueMember = "name";
            cmbToDatabase.DisplayMember = "name";
            try
            {
                cmbToDatabase.DataSource = GetDatabaseNames(cmbToServer.Text, chkToServerIntegrated.Checked, txtToServerUser.Text, txtToServerPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkFromServerIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromServerIntegrated.Checked)
            {
                txtFromServerUser.Enabled = false;
                txtFromServerPassword.Enabled = false;
            }
            else
            {
                txtFromServerUser.Enabled = true;
                txtFromServerPassword.Enabled = true;
            }
        }

        private void chkToServerIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToServerIntegrated.Checked)
            {
                txtToServerUser.Enabled = false;
                txtToServerPassword.Enabled = false;
            }
            else
            {
                txtToServerUser.Enabled = true;
                txtToServerPassword.Enabled = true;
            }
        }



        private void LoadSettings()
        {
            mySettings = new cSettings(Application.StartupPath + "\\config.xml");

            foreach (DataRow row in mySettings.GetServers().Rows)
            {
                lbServers.Items.Add(row[0].ToString());
                cmbFromServer.Items.Add(row[0].ToString());
                cmbToServer.Items.Add(row[0].ToString());
            }
        }

        private void frmDBTools_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }



        private void cmbFromServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFromServerUser.Text = mySettings.GetServerUsername(cmbFromServer.Text);
            txtFromServerPassword.Text = mySettings.GetServerPassword(cmbFromServer.Text);
            chkFromServerIntegrated.Checked = Convert.ToBoolean(mySettings.GetServerIntegratedSecurity(cmbFromServer.Text));
            txtSourceDir.Text = mySettings.GetServerDefaultBackupdir(cmbFromServer.Text);

        }

        private void cmbToServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToServerUser.Text = mySettings.GetServerUsername(cmbToServer.Text);
            txtToServerPassword.Text = mySettings.GetServerPassword(cmbToServer.Text);
            chkToServerIntegrated.Checked = Convert.ToBoolean(mySettings.GetServerIntegratedSecurity(cmbToServer.Text));
            txtDestDir.Text = mySettings.GetServerDefaultDatadir(cmbToServer.Text);
            txtDestBackupDir.Text = mySettings.GetServerDefaultBackupdir(cmbToServer.Text);
            txtDestLogDir.Text = mySettings.GetServerDefaultLogdir(cmbToServer.Text);
        }
  
        #endregion

#region "Actions"
        /// <summary>
        /// Set the progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationProgress(object sender, ProgressEventArgs e)
        {
            pbCopy.Value = e.Progress;
            Application.DoEvents();
        }

        /// <summary>
        /// Sets the progress indicator which step has been reached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepChanged(object sender, StepsEventArgs e)
        {
            switch (e.Step)
            {
                case Steps.BACKUP:
                    {
                        tsStatus.Text = "Creating Backup...";
                        break;
                    }
                case Steps.COPY:
                    {
                        //Copy backupfile to dest
                        tsStatus.Text = "Copiing file...";
                        pbCopy.Value = 0;
                        break;
                    }
                case Steps.RESTORE:
                    {
                        tsStatus.Text = "Restoring database...";
                        pbCopy.Value = 0;
                        break;
                    }
                case Steps.IDLE:
                        {
                            tsStatus.Text = "Idle.";
                            pbCopy.Value = 0;
                            MessageBox.Show("Sucessfully copied database..", "Wohooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
            }

            this.Refresh();

        }

        /// <summary>
        /// Checks if everything is filled out.
        /// </summary>
        /// <returns>true if everything is filled out</returns>
        private bool PreCheckSettings()
        {
            //check servers
            if (cmbFromServer.Text == "" || cmbToServer.Text == "")
            {
                MessageBox.Show("Please choose a source and a destination server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check databases
            if (cmbFromDatabase.Text == "" || cmbToDatabase.Text == "")
            {
                MessageBox.Show("Please choose a source and a destination database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check login information from server
            if ((txtFromServerUser.Text == "" || txtFromServerPassword.Text == "") && !chkFromServerIntegrated.Checked)
            {
                MessageBox.Show("Please provide login information for the source server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check login information to server
            if ((txtToServerUser.Text == "" || txtToServerPassword.Text == "") && !chkToServerIntegrated.Checked)
            {
                MessageBox.Show("Please provide login information for the destination server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check directories (source)
            if (!cHelper.CheckFilePathRegex(txtSourceDir.Text))
            {
                MessageBox.Show("You can't use this source directory. No UNC Paths and don't forget the trailing slash.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check directories (dest bacup)
            if (!cHelper.CheckFilePathRegex(txtDestBackupDir.Text))
            {
                MessageBox.Show("You can't use this destination backup directory. No UNC Paths and don't forget the trailing slash.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check directories (dest data)
            if (!cHelper.CheckFilePathRegex(txtDestDir.Text))
            {
                MessageBox.Show("You can't use this destination data directory. No UNC Paths and don't forget the trailing slash.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check directories (dest log)
            if (!cHelper.CheckFilePathRegex(txtDestLogDir.Text))
            {
                MessageBox.Show("You can't use this destination log directory. No UNC Paths and don't forget the trailing slash.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;           
        }


        /// <summary>
        /// Copy the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            cDatabaseCopy dbc = new cDatabaseCopy();

            dbc.Progress += new ProgressEventHandler(OperationProgress);
            dbc.StepChanged += new StepsEventHandler(StepChanged);


            if (PreCheckSettings())                        
            {
                try
                {
                    dbc.CopyDatabase(txtSourceDir.Text, cmbFromDatabase.Text, cmbToDatabase.Text,
                                     txtDestDir.Text, txtDestBackupDir.Text, txtDestLogDir.Text, cmbFromServer.Text, cmbToServer.Text,
                                     txtFromServerUser.Text, txtFromServerPassword.Text,
                                     chkFromServerIntegrated.Checked, txtToServerUser.Text, txtToServerPassword.Text,
                                     chkToServerIntegrated.Checked);
                }
                catch (Exception ex)
                {
                    //reset status information
                    tsStatus.Text = "Error.";
                    pbCopy.Value = 0;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion     

#region "Servers Tab"
        private void AddServer(string sServername)
        {
            lbServers.Items.Add(sServername);
            cmbFromServer.Items.Add(sServername);
            cmbToServer.Items.Add(sServername);
            mySettings.AddServer(sServername);
        }

        private void RemoveServer(string sServername)
        {
            lbServers.Items.Remove(sServername);
            mySettings.RemoveServer(sServername);
            cmbFromServer.Items.Remove(sServername);
            cmbToServer.Items.Remove(sServername);
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            //string sNewServer;
            //sNewServer = Interaction.InputBox("Servername/Server-IP?", "Add server", "", this.Location.X + 50, this.Location.Y + 50);
            //AddServer(sNewServer);           
            frmAddServer frm = new frmAddServer();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (lbServers.Items.Contains(frm.Servername))
                {
                    MessageBox.Show("You already added that server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddServer(frm.Servername);
                }
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedIndex > -1)
            {
                RemoveServer(lbServers.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No server selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddServersFromNetwork_Click(object sender, EventArgs e)
        {
            DataTable dtInstances;
            dtInstances = cHelper.GetServersFromNetwork();

            if (dtInstances == null)
            {
                MessageBox.Show("No sql server instances found");
            }
            else
            {
                foreach (DataRow row in dtInstances.Rows)
                {
                    //Add server if it doesn't exist
                    bool bExists = false;
                    foreach (string s in lbServers.Items)
                    {
                        if (s == row[0].ToString())
                            bExists = true;
                    }

                    if (!bExists)
                        AddServer(row[0].ToString());

                }
            }
        }

        private void btnGetDefaultBackupdir_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
                MessageBox.Show("No server selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    cDatabaseHelper db = new cDatabaseHelper(lbServers.SelectedItem.ToString(), chkServerUseIntegratedSecurity.Checked, txtServerUser.Text, txtServerPassword.Text, "master");
                    txtDefaultbackupDir.Text = db.GetDefaultBackupdir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnGetDefaultDatadir_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
                MessageBox.Show("No server selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    cDatabaseHelper db = new cDatabaseHelper(lbServers.SelectedItem.ToString(), chkServerUseIntegratedSecurity.Checked, txtServerUser.Text, txtServerPassword.Text, "master");
                    txtDefaultDatadir.Text = db.GetDefaultDatadir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnGetDefaultLogDir_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
                MessageBox.Show("No server selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    cDatabaseHelper db = new cDatabaseHelper(lbServers.SelectedItem.ToString(), chkServerUseIntegratedSecurity.Checked, txtServerUser.Text, txtServerPassword.Text, "master");
                    txtDefaultLogDir.Text = db.GetDefaultLogdir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            cDatabaseHelper db = new cDatabaseHelper(lbServers.SelectedItem.ToString(), chkServerUseIntegratedSecurity.Checked, txtServerUser.Text, txtServerPassword.Text, "master");

            if (db.TestConnection())
            {
                btnTestConnection.Text = "Connection OK";
                btnTestConnection.ForeColor = Color.Green;
            }
            else
            {
                btnTestConnection.Text = "no connection";
                btnTestConnection.ForeColor = Color.Red;
            }
        }

        private void ToggleEnabled(bool enabled)
        {
            txtDefaultbackupDir.Enabled = enabled;
            txtDefaultDatadir.Enabled = enabled;
            txtDefaultLogDir.Enabled = enabled;
            txtServerUser.Enabled = enabled;
            txtServerPassword.Enabled = enabled;
            chkServerUseIntegratedSecurity.Enabled = enabled;

            btnTestConnection.Enabled = enabled;
            btnGetDefaultBackupdir.Enabled = enabled;
            btnGetDefaultDatadir.Enabled = enabled;
            btnGetDefaultLogDir.Enabled = enabled;
            btnSaveChanges.Enabled = enabled;
            btnRemoveSelected.Enabled = enabled;
        }


        private void lbServers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbServers.SelectedIndex != -1)
            {
                lblServer.Text = lbServers.SelectedItem.ToString();

                txtDefaultbackupDir.Text = mySettings.GetServerDefaultBackupdir(lbServers.SelectedItem.ToString());
                txtDefaultDatadir.Text = mySettings.GetServerDefaultDatadir(lbServers.SelectedItem.ToString());
                txtDefaultLogDir.Text = mySettings.GetServerDefaultLogdir(lbServers.SelectedItem.ToString());
                txtServerUser.Text = mySettings.GetServerUsername(lbServers.SelectedItem.ToString());
                txtServerPassword.Text = mySettings.GetServerPassword(lbServers.SelectedItem.ToString());
                chkServerUseIntegratedSecurity.Checked = Convert.ToBoolean(mySettings.GetServerIntegratedSecurity(lbServers.SelectedItem.ToString()));

                btnTestConnection.Text = "Test it";
                btnTestConnection.ForeColor = Color.Black;

                ToggleEnabled(true);
            }
            else
            {
                ToggleEnabled(false);

                lblServer.Text = "No server selected";
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                mySettings.SaveServer(lbServers.SelectedItem.ToString(), txtServerUser.Text, txtServerPassword.Text, chkServerUseIntegratedSecurity.Checked, txtDefaultDatadir.Text, txtDefaultbackupDir.Text, txtDefaultLogDir.Text);
                MessageBox.Show("Server saved...", "Server saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server not saved. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkServerUseIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServerUseIntegratedSecurity.Checked)
            {
                txtServerUser.Enabled = false;
                txtServerPassword.Enabled = false;
            }
            else
            {
                txtServerUser.Enabled = true;
                txtServerPassword.Enabled = true;
            }
        }
#endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }



    }  
}


