using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using DatabaseCopier.Class;
using System.Data;

namespace DatabaseCopier
{
    static class Program
    {
        //http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/ea8b0fd5-a660-46f9-9dcb-d525cc22dcbd/
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static cSettings _settings;
        private static int _progress;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "SQL Server Database Copy Tool";
            
            _settings = new cSettings(Application.StartupPath + "\\config.xml");

            //check if we are in commandline with arguments
            if (args.Length > 0)
            {
                if (args.Length == 4)
                {
                    //do things
                    string sFromServer = args[0];
                    string sToServer = args[1];
                    string sFromDatabase = args[2];
                    string sToDatabase = args[3];

                    if (!PreCheckServer(sFromServer) || !PreCheckServer(sToServer))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        cDatabaseCopy dbc = new cDatabaseCopy();
                        dbc.Progress += new ProgressEventHandler(OperationProgress);
                        dbc.StepChanged += new StepsEventHandler(StepChanged);

                        try
                        {
                            dbc.CopyDatabase(_settings.GetServerDefaultBackupdir(sFromServer),
                                             sFromDatabase,
                                             sToDatabase,
                                             _settings.GetServerDefaultDatadir(sToServer),
                                             _settings.GetServerDefaultBackupdir(sToServer),
                                             _settings.GetServerDefaultLogdir(sToServer),
                                             sFromServer,
                                             sToServer,
                                             _settings.GetServerUsername(sFromServer),
                                             _settings.GetServerPassword(sFromServer),
                                             _settings.GetServerIntegratedSecurity(sFromServer),
                                             _settings.GetServerUsername(sToServer),
                                             _settings.GetServerPassword(sToServer),
                                             _settings.GetServerIntegratedSecurity(sToServer));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Exiting...");
                            Application.Exit();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("No chance...! Use DbCopyTool.exe YOUR_FROM_SERVER YOUR_TO_SERVER YOUR_FROM_DB YOUR_TO_DB");
                    Console.WriteLine("Exiting...");
                }
            }
            else
            {
                //hide console
                setConsoleWindowVisibility(false, Console.Title);  
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmDBTools main = new frmDBTools();
                Application.Run(main);
            }

            setConsoleWindowVisibility(true, Console.Title);
        }

        private static void OperationProgress(object sender, ProgressEventArgs e)
        {
            int old = _progress;
            _progress = (int)((float)e.Progress / 10.0) * 10;
            if (_progress > old)
            {
                Console.WriteLine(_progress + " % ");
            }

            Application.DoEvents();
        }

        private static void StepChanged(object sender, StepsEventArgs e)
        {
            if (e.Step == Steps.BACKUP)
            {
                Console.WriteLine();
                Console.WriteLine("Creating Backup...");
            }

            if (e.Step == Steps.COPY)
            {
                //Copy backupfile to dest
                Console.WriteLine();
                Console.WriteLine("Copying file...");
             }

            if (e.Step == Steps.RESTORE)
            {
                Console.WriteLine();
                Console.WriteLine("Restoring database...");
            }

            if (e.Step == Steps.IDLE)
            {
                Console.WriteLine();
                Console.WriteLine("Successfully copied database...");            
            }
        }

        private static bool PreCheckServer(string sServername)
        {
            bool bServerIsOk = true;

            //check if server exists and has all settings
            if (!_settings.GetServers().Rows.Contains(sServername))
            {
                Console.WriteLine("The server {0} does not exist in your configuration. Please start DbCopyTool without parameters and add it...", sServername);
                bServerIsOk = false;
            }
            else
            {
                if (!_settings.ServerHasAllSettings(sServername))
                {
                    Console.WriteLine("Some settings for your server {0} are missing. Please start DbCopyTool without parameters and add them...", sServername);
                    bServerIsOk = false;
                }
            }
            return bServerIsOk;
        }


        public static void setConsoleWindowVisibility(bool visible, string title)
        {
            IntPtr hWnd = FindWindow(null, title);

            if (hWnd != IntPtr.Zero)
            {
                if (!visible)
                    //Hide the window                   
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE               
                else
                    //Show window again                   
                    ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA          
            }
        }
    }
}
