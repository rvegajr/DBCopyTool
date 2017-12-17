using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DatabaseCopier.Class
{
    public delegate void StepsEventHandler(object sender, StepsEventArgs e);

    public class StepsEventArgs : EventArgs
    {
        private readonly Steps _step = 0;

        public StepsEventArgs(Steps step)
        {
            _step = step;
        }

        //Properties.
        public Steps Step
        {
            get { return _step; }
        }
    }

    public enum Steps : uint
        {
            IDLE = 0,
            BACKUP = 1,
            COPY = 2,
            RESTORE = 3,
            ERROR = 4,
            CLEAR_CONN = 10,
    }

    class cDatabaseCopy
    {
        public event ProgressEventHandler Progress;
        public event StepsEventHandler StepChanged;

        private void OperationProgress(object sender, ProgressEventArgs e)
        {
            Progress(this, new ProgressEventArgs(e.Progress));
        }
        
        public void CopyDatabase(   string sSourceBackupDir,
                                    string sSourceDatabase,
                                    string sDestDatabase,
                                    string sDestDir,
                                    string sDestBackupDir,
                                    string sDestLogDir,
                                    string sSourceServer,
                                    string sDestServer,
                                    string sSourceServerUsername,
                                    string sSourceServerPassword,
                                    bool bSourceServerUseIntegratedSecurity,
                                    string sDestServerUsername,
                                    string sDestServerPassword,
                                    bool bDestServerUseIntegratedSecurity)
        {
            //create paths            
            string sDatabaseBackupFile = sSourceBackupDir + sSourceDatabase + "_CopyTool.bak";
            string sDatabaseRestoreFile = sDestBackupDir  + sSourceDatabase + "_CopyTool.bak";

            string sUncSourceFile = cHelper.MakeUncPath(sDatabaseBackupFile, sSourceServer);
            string sUncDestFile = cHelper.MakeUncPath(sDatabaseRestoreFile, sDestServer);

            //delete old backup if exists
            cHelper.DeleteFileIfExists(sUncSourceFile);

            //backp the database            
            StepChanged(this, new StepsEventArgs(Steps.BACKUP));
            cDatabaseHelper dbBackup = new cDatabaseHelper(sSourceServer, bSourceServerUseIntegratedSecurity, sSourceServerUsername, sSourceServerPassword, sSourceDatabase);

            dbBackup.Progress += new ProgressEventHandler(OperationProgress);
            dbBackup.BackupDatabase(sDatabaseBackupFile);
            //delete old backup if exists
            StepChanged(this, new StepsEventArgs(Steps.COPY));
            //cHelper.DeleteFileIfExists(sUncDestFile);

            //copy File
            cFileCopy c = new cFileCopy();
            c.Progress += new ProgressEventHandler(OperationProgress);
            c.XCopy(sUncSourceFile, sUncDestFile);

            //restore the database
            cDatabaseHelper dbRestore = new cDatabaseHelper(sDestServer, bDestServerUseIntegratedSecurity, sDestServerUsername, sDestServerPassword, "master");
            StepChanged(this, new StepsEventArgs(Steps.CLEAR_CONN));
            dbRestore.ClearConnections(sDestDatabase);

            StepChanged(this, new StepsEventArgs(Steps.RESTORE));
            dbRestore.Progress += new ProgressEventHandler(OperationProgress);
            dbRestore.RestoreDatabase(sDestDatabase, sDatabaseRestoreFile, sDestDir, sDestLogDir);

            //cleanup

            try
            {
                File.Delete(sUncSourceFile);
                File.Delete(sUncDestFile);                
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't delete file. " + ex.Message + " Source: " + sUncSourceFile + " Dest: " + sUncDestFile);
            }

            StepChanged(this, new StepsEventArgs(Steps.IDLE));
        }
    }
}
