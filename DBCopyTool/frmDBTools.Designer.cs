namespace DatabaseCopier
{
    partial class frmDBTools
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtFromServerPassword = new System.Windows.Forms.TextBox();
            this.chkFromServerIntegrated = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFromServerUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtToServerPassword = new System.Windows.Forms.TextBox();
            this.chkToServerIntegrated = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtToServerUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDestBackupDir = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbToDatabase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbToServer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFromServer = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtServerPassword = new System.Windows.Forms.TextBox();
            this.chkServerUseIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtServerUser = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnGetDefaultDatadir = new System.Windows.Forms.Button();
            this.btnGetDefaultBackupdir = new System.Windows.Forms.Button();
            this.txtDefaultDatadir = new System.Windows.Forms.TextBox();
            this.txtDefaultbackupDir = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbServers = new System.Windows.Forms.ListBox();
            this.btnAddServersFromNetwork = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbCopy = new System.Windows.Forms.ToolStripProgressBar();
            this.txtDefaultLogDir = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnGetDefaultLogDir = new System.Windows.Forms.Button();
            this.txtDestLogDir = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.btnCopy);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Copy database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtFromServerPassword);
            this.groupBox6.Controls.Add(this.chkFromServerIntegrated);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtFromServerUser);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Location = new System.Drawing.Point(8, 70);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(253, 108);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Login information";
            // 
            // txtFromServerPassword
            // 
            this.txtFromServerPassword.Enabled = false;
            this.txtFromServerPassword.Location = new System.Drawing.Point(64, 45);
            this.txtFromServerPassword.Name = "txtFromServerPassword";
            this.txtFromServerPassword.Size = new System.Drawing.Size(169, 20);
            this.txtFromServerPassword.TabIndex = 8;
            this.txtFromServerPassword.UseSystemPasswordChar = true;
            // 
            // chkFromServerIntegrated
            // 
            this.chkFromServerIntegrated.AutoSize = true;
            this.chkFromServerIntegrated.Enabled = false;
            this.chkFromServerIntegrated.Location = new System.Drawing.Point(18, 71);
            this.chkFromServerIntegrated.Name = "chkFromServerIntegrated";
            this.chkFromServerIntegrated.Size = new System.Drawing.Size(132, 17);
            this.chkFromServerIntegrated.TabIndex = 7;
            this.chkFromServerIntegrated.Text = "use integrated security";
            this.chkFromServerIntegrated.UseVisualStyleBackColor = true;
            this.chkFromServerIntegrated.CheckedChanged += new System.EventHandler(this.chkFromServerIntegrated_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pass:";
            // 
            // txtFromServerUser
            // 
            this.txtFromServerUser.Enabled = false;
            this.txtFromServerUser.Location = new System.Drawing.Point(64, 19);
            this.txtFromServerUser.Name = "txtFromServerUser";
            this.txtFromServerUser.Size = new System.Drawing.Size(169, 20);
            this.txtFromServerUser.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "User:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtToServerPassword);
            this.groupBox7.Controls.Add(this.chkToServerIntegrated);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.txtToServerUser);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new System.Drawing.Point(267, 70);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(253, 108);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Login information";
            // 
            // txtToServerPassword
            // 
            this.txtToServerPassword.Enabled = false;
            this.txtToServerPassword.Location = new System.Drawing.Point(64, 45);
            this.txtToServerPassword.Name = "txtToServerPassword";
            this.txtToServerPassword.Size = new System.Drawing.Size(169, 20);
            this.txtToServerPassword.TabIndex = 8;
            this.txtToServerPassword.UseSystemPasswordChar = true;
            // 
            // chkToServerIntegrated
            // 
            this.chkToServerIntegrated.AutoSize = true;
            this.chkToServerIntegrated.Enabled = false;
            this.chkToServerIntegrated.Location = new System.Drawing.Point(18, 71);
            this.chkToServerIntegrated.Name = "chkToServerIntegrated";
            this.chkToServerIntegrated.Size = new System.Drawing.Size(132, 17);
            this.chkToServerIntegrated.TabIndex = 7;
            this.chkToServerIntegrated.Text = "use integrated security";
            this.chkToServerIntegrated.UseVisualStyleBackColor = true;
            this.chkToServerIntegrated.CheckedChanged += new System.EventHandler(this.chkToServerIntegrated_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Pass:";
            // 
            // txtToServerUser
            // 
            this.txtToServerUser.Enabled = false;
            this.txtToServerUser.Location = new System.Drawing.Point(64, 19);
            this.txtToServerUser.Name = "txtToServerUser";
            this.txtToServerUser.Size = new System.Drawing.Size(169, 20);
            this.txtToServerUser.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "User:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(8, 410);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(511, 23);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDestLogDir);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txtDestBackupDir);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtSourceDir);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtDestDir);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(9, 259);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(511, 145);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings";
            // 
            // txtDestBackupDir
            // 
            this.txtDestBackupDir.Enabled = false;
            this.txtDestBackupDir.Location = new System.Drawing.Point(124, 51);
            this.txtDestBackupDir.Name = "txtDestBackupDir";
            this.txtDestBackupDir.Size = new System.Drawing.Size(367, 20);
            this.txtDestBackupDir.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Destination backup dir:";
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Enabled = false;
            this.txtSourceDir.Location = new System.Drawing.Point(124, 23);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(367, 20);
            this.txtSourceDir.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Source backup dir:";
            // 
            // txtDestDir
            // 
            this.txtDestDir.Enabled = false;
            this.txtDestDir.Location = new System.Drawing.Point(124, 79);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.Size = new System.Drawing.Size(367, 20);
            this.txtDestDir.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Destination data dir:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbFromDatabase);
            this.groupBox3.Location = new System.Drawing.Point(8, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 69);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "from Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Source";
            // 
            // cmbFromDatabase
            // 
            this.cmbFromDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDatabase.FormattingEnabled = true;
            this.cmbFromDatabase.Location = new System.Drawing.Point(78, 27);
            this.cmbFromDatabase.Name = "cmbFromDatabase";
            this.cmbFromDatabase.Size = new System.Drawing.Size(152, 21);
            this.cmbFromDatabase.TabIndex = 0;
            this.cmbFromDatabase.DropDown += new System.EventHandler(this.cmbFromDatabase_DropDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbToDatabase);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(267, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 69);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "to Database";
            // 
            // cmbToDatabase
            // 
            this.cmbToDatabase.FormattingEnabled = true;
            this.cmbToDatabase.Location = new System.Drawing.Point(81, 27);
            this.cmbToDatabase.Name = "cmbToDatabase";
            this.cmbToDatabase.Size = new System.Drawing.Size(152, 21);
            this.cmbToDatabase.TabIndex = 4;
            this.cmbToDatabase.DropDown += new System.EventHandler(this.cmbToDatabase_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Destination";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbToServer);
            this.groupBox2.Location = new System.Drawing.Point(267, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 59);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "to Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination";
            // 
            // cmbToServer
            // 
            this.cmbToServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToServer.FormattingEnabled = true;
            this.cmbToServer.Location = new System.Drawing.Point(81, 19);
            this.cmbToServer.Name = "cmbToServer";
            this.cmbToServer.Size = new System.Drawing.Size(152, 21);
            this.cmbToServer.TabIndex = 2;
            this.cmbToServer.SelectedIndexChanged += new System.EventHandler(this.cmbToServer_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFromServer);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 59);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "from Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source";
            // 
            // cmbFromServer
            // 
            this.cmbFromServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromServer.FormattingEnabled = true;
            this.cmbFromServer.Location = new System.Drawing.Point(78, 19);
            this.cmbFromServer.Name = "cmbFromServer";
            this.cmbFromServer.Size = new System.Drawing.Size(152, 21);
            this.cmbFromServer.TabIndex = 0;
            this.cmbFromServer.SelectedIndexChanged += new System.EventHandler(this.cmbFromServer_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.btnAddServersFromNetwork);
            this.tabPage2.Controls.Add(this.btnRemoveSelected);
            this.tabPage2.Controls.Add(this.btnAddServer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.lbServers);
            this.groupBox8.Location = new System.Drawing.Point(8, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(517, 398);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Choose server";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnGetDefaultLogDir);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.txtDefaultLogDir);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.btnSaveChanges);
            this.groupBox9.Controls.Add(this.btnGetDefaultDatadir);
            this.groupBox9.Controls.Add(this.btnGetDefaultBackupdir);
            this.groupBox9.Controls.Add(this.txtDefaultDatadir);
            this.groupBox9.Controls.Add(this.txtDefaultbackupDir);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.lblServer);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Location = new System.Drawing.Point(6, 107);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(500, 285);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Selected server details";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnTestConnection);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.txtServerPassword);
            this.groupBox10.Controls.Add(this.chkServerUseIntegratedSecurity);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.txtServerUser);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Location = new System.Drawing.Point(9, 32);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(479, 136);
            this.groupBox10.TabIndex = 15;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Login information";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Enabled = false;
            this.btnTestConnection.Location = new System.Drawing.Point(111, 99);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(143, 23);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test it";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Test connection:";
            // 
            // txtServerPassword
            // 
            this.txtServerPassword.Enabled = false;
            this.txtServerPassword.Location = new System.Drawing.Point(64, 45);
            this.txtServerPassword.Name = "txtServerPassword";
            this.txtServerPassword.Size = new System.Drawing.Size(409, 20);
            this.txtServerPassword.TabIndex = 8;
            this.txtServerPassword.UseSystemPasswordChar = true;
            // 
            // chkServerUseIntegratedSecurity
            // 
            this.chkServerUseIntegratedSecurity.AutoSize = true;
            this.chkServerUseIntegratedSecurity.Enabled = false;
            this.chkServerUseIntegratedSecurity.Location = new System.Drawing.Point(20, 76);
            this.chkServerUseIntegratedSecurity.Name = "chkServerUseIntegratedSecurity";
            this.chkServerUseIntegratedSecurity.Size = new System.Drawing.Size(132, 17);
            this.chkServerUseIntegratedSecurity.TabIndex = 7;
            this.chkServerUseIntegratedSecurity.Text = "use integrated security";
            this.chkServerUseIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkServerUseIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkServerUseIntegratedSecurity_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Pass:";
            // 
            // txtServerUser
            // 
            this.txtServerUser.Enabled = false;
            this.txtServerUser.Location = new System.Drawing.Point(64, 19);
            this.txtServerUser.Name = "txtServerUser";
            this.txtServerUser.Size = new System.Drawing.Size(409, 20);
            this.txtServerUser.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "User:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Save settings:";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(95, 256);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(143, 23);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Save serversettings";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnGetDefaultDatadir
            // 
            this.btnGetDefaultDatadir.Enabled = false;
            this.btnGetDefaultDatadir.Location = new System.Drawing.Point(413, 198);
            this.btnGetDefaultDatadir.Name = "btnGetDefaultDatadir";
            this.btnGetDefaultDatadir.Size = new System.Drawing.Size(75, 23);
            this.btnGetDefaultDatadir.TabIndex = 10;
            this.btnGetDefaultDatadir.Text = "get it";
            this.btnGetDefaultDatadir.UseVisualStyleBackColor = true;
            this.btnGetDefaultDatadir.Click += new System.EventHandler(this.btnGetDefaultDatadir_Click);
            // 
            // btnGetDefaultBackupdir
            // 
            this.btnGetDefaultBackupdir.Enabled = false;
            this.btnGetDefaultBackupdir.Location = new System.Drawing.Point(413, 172);
            this.btnGetDefaultBackupdir.Name = "btnGetDefaultBackupdir";
            this.btnGetDefaultBackupdir.Size = new System.Drawing.Size(75, 23);
            this.btnGetDefaultBackupdir.TabIndex = 9;
            this.btnGetDefaultBackupdir.Text = "get it";
            this.btnGetDefaultBackupdir.UseVisualStyleBackColor = true;
            this.btnGetDefaultBackupdir.Click += new System.EventHandler(this.btnGetDefaultBackupdir_Click);
            // 
            // txtDefaultDatadir
            // 
            this.txtDefaultDatadir.Location = new System.Drawing.Point(95, 200);
            this.txtDefaultDatadir.Name = "txtDefaultDatadir";
            this.txtDefaultDatadir.Size = new System.Drawing.Size(312, 20);
            this.txtDefaultDatadir.TabIndex = 8;
            // 
            // txtDefaultbackupDir
            // 
            this.txtDefaultbackupDir.Location = new System.Drawing.Point(95, 174);
            this.txtDefaultbackupDir.Name = "txtDefaultbackupDir";
            this.txtDefaultbackupDir.Size = new System.Drawing.Size(312, 20);
            this.txtDefaultbackupDir.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Data dir:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Backup dir:";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(92, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(94, 13);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "no server selected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Servername/IP:";
            // 
            // lbServers
            // 
            this.lbServers.FormattingEnabled = true;
            this.lbServers.Location = new System.Drawing.Point(6, 19);
            this.lbServers.Name = "lbServers";
            this.lbServers.Size = new System.Drawing.Size(505, 82);
            this.lbServers.TabIndex = 0;
            this.lbServers.SelectedIndexChanged += new System.EventHandler(this.lbServers_SelectedIndexChanged);
            // 
            // btnAddServersFromNetwork
            // 
            this.btnAddServersFromNetwork.Location = new System.Drawing.Point(182, 410);
            this.btnAddServersFromNetwork.Name = "btnAddServersFromNetwork";
            this.btnAddServersFromNetwork.Size = new System.Drawing.Size(165, 23);
            this.btnAddServersFromNetwork.TabIndex = 6;
            this.btnAddServersFromNetwork.Text = "Add servers from network";
            this.btnAddServersFromNetwork.UseVisualStyleBackColor = true;
            this.btnAddServersFromNetwork.Click += new System.EventHandler(this.btnAddServersFromNetwork_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Enabled = false;
            this.btnRemoveSelected.Location = new System.Drawing.Point(353, 410);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(161, 23);
            this.btnRemoveSelected.TabIndex = 5;
            this.btnRemoveSelected.Text = "Remove selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(11, 410);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(165, 23);
            this.btnAddServer.TabIndex = 4;
            this.btnAddServer.Text = "Add server";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.dateiToolStripMenuItem.Text = "&File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.beendenToolStripMenuItem.Text = "&Quit";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.pbCopy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(543, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(29, 17);
            this.tsStatus.Text = "Idle.";
            // 
            // pbCopy
            // 
            this.pbCopy.Name = "pbCopy";
            this.pbCopy.Size = new System.Drawing.Size(300, 16);
            // 
            // txtDefaultLogDir
            // 
            this.txtDefaultLogDir.Location = new System.Drawing.Point(95, 226);
            this.txtDefaultLogDir.Name = "txtDefaultLogDir";
            this.txtDefaultLogDir.Size = new System.Drawing.Size(312, 20);
            this.txtDefaultLogDir.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 229);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Log dir:";
            // 
            // btnGetDefaultLogDir
            // 
            this.btnGetDefaultLogDir.Enabled = false;
            this.btnGetDefaultLogDir.Location = new System.Drawing.Point(413, 224);
            this.btnGetDefaultLogDir.Name = "btnGetDefaultLogDir";
            this.btnGetDefaultLogDir.Size = new System.Drawing.Size(75, 23);
            this.btnGetDefaultLogDir.TabIndex = 18;
            this.btnGetDefaultLogDir.Text = "get it";
            this.btnGetDefaultLogDir.UseVisualStyleBackColor = true;
            this.btnGetDefaultLogDir.Click += new System.EventHandler(this.btnGetDefaultLogDir_Click);
            // 
            // txtDestLogDir
            // 
            this.txtDestLogDir.Enabled = false;
            this.txtDestLogDir.Location = new System.Drawing.Point(124, 105);
            this.txtDestLogDir.Name = "txtDestLogDir";
            this.txtDestLogDir.Size = new System.Drawing.Size(367, 20);
            this.txtDestLogDir.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Destination log dir:";
            // 
            // frmDBTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDBTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Copy Tool";
            this.Load += new System.EventHandler(this.frmDBTools_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtDestDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFromDatabase;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbToServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFromServer;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.ListBox lbServers;
        private System.Windows.Forms.ComboBox cmbToDatabase;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkFromServerIntegrated;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFromServerUser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkToServerIntegrated;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtToServerUser;
        private System.Windows.Forms.TextBox txtFromServerPassword;
        private System.Windows.Forms.TextBox txtToServerPassword;
        private System.Windows.Forms.Button btnAddServersFromNetwork;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDefaultbackupDir;
        private System.Windows.Forms.TextBox txtDefaultDatadir;
        private System.Windows.Forms.Button btnGetDefaultBackupdir;
        private System.Windows.Forms.Button btnGetDefaultDatadir;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtServerPassword;
        private System.Windows.Forms.CheckBox chkServerUseIntegratedSecurity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtServerUser;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDestBackupDir;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolStripProgressBar pbCopy;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnGetDefaultLogDir;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDefaultLogDir;
        private System.Windows.Forms.TextBox txtDestLogDir;
        private System.Windows.Forms.Label label20;
    }
}