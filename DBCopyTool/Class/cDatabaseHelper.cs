using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseCopier.Class
{
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    

    class cDatabaseHelper
    {

        public event ProgressEventHandler Progress;

        private SqlConnection _con;
        private string _sDatabaseName;

        private string _internalError = "";
        
        /// <summary>
        /// Constructor for cDatabasehelper
        /// </summary>
        /// <param name="sServername">Name/IP of the server to connect to</param>
        /// <param name="bUseIntegratedSecurity">Use integrated security</param>
        /// <param name="sUsername">Server Username</param>
        /// <param name="sPassword">Server Password</param>
        /// <param name="sDatabaseName">Initial Database</param>
        public cDatabaseHelper(string sServername, bool bUseIntegratedSecurity, string sUsername, string sPassword, string sDatabaseName)
        {
            _con = new SqlConnection();
            _con.ConnectionString = BuildConnectionString(sServername, bUseIntegratedSecurity, sUsername, sPassword, sDatabaseName );
            _con.InfoMessage += new SqlInfoMessageEventHandler(_con_InfoMessage);
            
            _sDatabaseName = sDatabaseName;
        }

        /// <summary>
        /// Fired by connection on sql server infomessage.
        /// Used to report the progress of a backup or restore operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            //the progress information is a PRINT information with error.class = 0
            //if a REAL error occurs, then the program has to save this error because it's not
            //possible to throw an exception to the db-call :-(
            if (e.Errors.Count > 0)
            {
                if (e.Errors[0].Class > 0)
                {
                    //save error for use
                    _internalError += e.Message + " ";
                }
            }            

            //prepare progress information and raise event for caller
            string myMsg = e.Message;
            string sProgress;
            int iProgress;
            //get the first three characters from message
            sProgress = e.Message.Substring(0, 3);
            
            try
            {
                //if we can convert the first three characters to an int then it's ok
                //for example the message "51 percent completed" will result in 51
                iProgress = Convert.ToInt32(sProgress);

                //fire progress event
                Progress(this, new ProgressEventArgs(iProgress));
            }
            catch { 
            //nothing to catch here, if we can't convert...who cares?                     
            }
                        
        }

        /// <summary>
        /// Gets all user databases for this connection
        /// </summary>
        /// <returns>Table with all database names</returns>
        public DataTable GetDatabases()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _con;

            //get all user databases ordered by name
            cmd.CommandText = "select name from sys.databases where name not in ('master', 'model', 'msdb', 'tempdb') order by name";

            SqlDataReader reader;
            DataTable dt = new DataTable();
            
            //get data
            try
            {
                Connect();
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                DisconnectDB();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the databases. " + ex.Message);
            }

            return dt;
        }

        /// <summary>
        /// Tests the connection to the server
        /// </summary>
        /// <returns>true if suceeded</returns>
        public bool TestConnection()
        {
            try
            {
                Connect();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the default backup dir of the sql server
        /// </summary>
        /// <returns>default backup dir</returns>
        public string GetDefaultBackupdir()
        {
            string sBackupDir;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _con;

            cmd.CommandText = "declare @path nvarchar(1000);"
                            +" EXEC master.dbo.xp_instance_regread N'hkey_local_machine',N'software\\microsoft\\mssqlserver\\mssqlserver',N'backupdirectory', @path output, 'no_output' "
                            +" SELECT @path + '\\' BackupPath;";

            try
            {
                Connect();
                sBackupDir = cmd.ExecuteScalar().ToString();
                DisconnectDB();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the default backup directory. " + ex.Message);
            }

            return sBackupDir;
        }

        /// <summary>
        /// Gets the default data dir of the sql server
        /// </summary>
        /// <returns>default data dir</returns>
        public string GetDefaultDatadir()
        {
            string sDatadir;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _con;
            
            cmd.CommandText = "declare @path nvarchar(1000); "
                             +"exec master.dbo.xp_instance_regread N'hkey_local_machine',N'software\\microsoft\\mssqlserver\\setup',N'sqldataroot', @path output, 'no_output' "
                             +"SELECT @path + '\\Data\\' DataPath;";

            try
            {
                Connect();
                sDatadir = cmd.ExecuteScalar().ToString();
                DisconnectDB();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the default data directory. " + ex.Message);
            }

            return sDatadir;
        }

        /// <summary>
        /// Gets the default log dir of the sql server
        /// </summary>
        /// <returns>default data dir</returns>
        public string GetDefaultLogdir()
        {
            string sDatadir;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _con;

            cmd.CommandText = "declare @path nvarchar(1000); "
                            + "  exec master.dbo.xp_instance_regread N'hkey_local_machine',N'software\\microsoft\\mssqlserver\\mssqlserver',N'defaultlog', @path output, 'no_output'"

                            + "  if @path IS NOT NULL"
                            + "      BEGIN"
                            + "          select @path + '\\'"
                            + "      END"
                            + "      ELSE"
                            + "      BEGIN"
                            + "          exec master.dbo.xp_instance_regread N'hkey_local_machine',N'software\\microsoft\\mssqlserver\\setup',N'sqldataroot', @path output, 'no_output' "
                            + "          SELECT @path + '\\Data\\' DataPath"
                            + "      END";

            try
            {
                Connect();
                sDatadir = cmd.ExecuteScalar().ToString();
                DisconnectDB();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the default log directory. " + ex.Message);
            }

            return sDatadir;
        }

        /// <summary>
        /// Build the connection string
        /// </summary>
        /// <param name="sServername"></param>
        /// <param name="bUseIntegratedSecurity"></param>
        /// <param name="sUsername"></param>
        /// <param name="sPassword"></param>
        /// <param name="sDatabaseName"></param>
        /// <returns></returns>
        private string BuildConnectionString(string sServername, bool bUseIntegratedSecurity, string sUsername, string sPassword, string sDatabaseName)
        {
            string conString;

            conString = "Data Source=";
            conString += sServername + ";";
            conString += "Initial Catalog=";
            conString += sDatabaseName + ";";

            if (!bUseIntegratedSecurity)
                conString += "User Id=" + sUsername + ";Password=" + sPassword + ";";
            else
                conString += "Trusted_Connection=True;";

            return conString;
        }

        private void DisconnectDB()
        {
            try
            {
                _con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error closing connection to Database. " + ex.Message);
            }
        }

        private void Connect()
        {
            try
            {
                _con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to Database. " + ex.Message);
            }
        }

        public void BackupDatabase(string sDestinationFile)
        {
            //Fire infomessageevent on every message
            //needed for progress information
            _con.FireInfoMessageEventOnUserErrors = true;
                   
            //prepare command text
            string cmdText;
            cmdText = "BACKUP DATABASE [@@DbName@@] TO DISK = N'@@DestinationFile@@' WITH NOFORMAT, NOINIT, NAME=N'AutoBackupFromDBCopier',SKIP,NOREWIND,NOUNLOAD,STATS=10";
            cmdText = cmdText.Replace("@@DbName@@", _sDatabaseName);
            cmdText = cmdText.Replace("@@DestinationFile@@", sDestinationFile);
                        
            SqlCommand cmd = new SqlCommand(cmdText, _con);
            //no timeout (large database => long backup)
            cmd.CommandTimeout = 0;

            try
            {
                Connect();
                cmd.ExecuteNonQuery();
                DisconnectDB();

                //if we had an error (we don't get it in the surrounding try catch because of FireInfoMessageEventOnUserErrors = true)
                if (_internalError != "")
                {
                    //throw this error
                    throw new Exception(_internalError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error backing up the database. " + ex.Message);
            }
            finally
            {
                DisconnectDB();
            }
        }

        public void ClearConnections(string sDestinationDatabaseName)
        {
            //Fire infomessageevent on every message
            //needed for progress information
            _con.FireInfoMessageEventOnUserErrors = true;

            //prepare command text
            string cmdText;
            cmdText = @"
ALTER DATABASE[@@DbName@@] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
";
            cmdText = cmdText.Replace("@@DbName@@", sDestinationDatabaseName);

            SqlCommand cmd = new SqlCommand(cmdText, _con);
            //no timeout (large database => long backup)
            cmd.CommandTimeout = 0;

            try
            {
                Connect();
                cmd.ExecuteNonQuery();
                DisconnectDB();

                //if we had an error (we don't get it in the surrounding try catch because of FireInfoMessageEventOnUserErrors = true)
                if (_internalError != "")
                {
                    //throw this error
                    throw new Exception(_internalError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error clearing up the database connections. " + ex.Message);
            }
            finally
            {
                DisconnectDB();
            }
        }
        public void RestoreDatabase(string sDestinationDatabaseName, string sBackupFilename, string sDestinationDataFolder, string sDestinationLogFolder)
        {
            SqlCommand cmd = new SqlCommand();
            
            //no timeout (large backup...)
            cmd.CommandTimeout = 0;

            string sRestoreCommand;
            cmd.Connection = _con;

            //Get filenames of database files
            cmd.CommandText = "RESTORE FILELISTONLY FROM  DISK = N'" + sBackupFilename + "';";

            //Prepare restore command
            sRestoreCommand = "RESTORE DATABASE [" + sDestinationDatabaseName  +"] FROM DISK = N'" 
                            + sBackupFilename + "' WITH FILE=1 ";
            
            //connect to server
            Connect();
            
            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();

                //add filenames for restore
                int iDataFiles = 0;
                int iLogFiles = 0;
                while (reader.Read())
                {
                    sRestoreCommand += ",MOVE N'" + reader[0] + "' TO N'";
                                    
                                    

                    if (reader[2].ToString() == "D")
                    {
                        sRestoreCommand += sDestinationDataFolder;
                        sRestoreCommand += sDestinationDatabaseName;
                        if (iDataFiles > 0)
                        {
                            sRestoreCommand += "_" + iDataFiles;
                        }

                        sRestoreCommand += ".mdf'";
                        iDataFiles++;
                    }

                    if (reader[2].ToString() == "L")
                    {
                        sRestoreCommand += sDestinationLogFolder;
                        sRestoreCommand += sDestinationDatabaseName;
                        if (iLogFiles > 0)
                        {
                            sRestoreCommand += "_" + iLogFiles;
                        }
                        sRestoreCommand += "_Log.ldf'";
                        iLogFiles++;
                    }
                }
                sRestoreCommand += ", NOUNLOAD, REPLACE, STATS = 10";

                reader.Close();

                //Fire infomessageevent on every message
                //needed for progress information
                _con.FireInfoMessageEventOnUserErrors = true;

                //execute restore
                cmd.CommandText = sRestoreCommand;
                cmd.ExecuteNonQuery();

                //if we had an error (we don't get it in the surrounding try catch because of FireInfoMessageEventOnUserErrors = true)
                if (_internalError != "")
                {
                    //throw this error
                    throw new Exception(_internalError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error restoring the database. " + ex.Message);
            }

            //disconnect
            DisconnectDB();

        }
    }
}
