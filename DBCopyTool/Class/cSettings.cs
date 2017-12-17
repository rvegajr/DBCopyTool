using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace DatabaseCopier.Class
{
    class cSettings
    {
        private string _sFilepath;
        private dsSettings _dsConfig;
        
        public cSettings(string sFilepath)
        {
            _sFilepath = sFilepath;

            ReadXML();
        }

        private void ReadXML()
        {
            _dsConfig = new dsSettings();
            try
            {
                _dsConfig.ReadXml(_sFilepath);
            }
            catch
            {
                //write new config file
                _dsConfig.WriteXml(_sFilepath);
            }

        }

        public DataTable GetServers()
        {
            return _dsConfig.dtSettings;
        }

        public string GetServerPassword(string sServername)
        {
            return GetSettingsRow(sServername).Password;
        }

        public string GetServerDefaultDatadir(string sServername)
        {
            return GetSettingsRow(sServername).DefaultDataDir ;
        }

        public string GetServerDefaultBackupdir(string sServername)
        {
            return GetSettingsRow(sServername).DefaultBackupDir ;
        }

        public string GetServerDefaultLogdir(string sServername)
        {
            return GetSettingsRow(sServername).DefaultLogDir;
        }

        public string GetServerUsername(string sServername)
        {
            return GetSettingsRow(sServername).Username;
        }

        public bool GetServerIntegratedSecurity(string sServername)
        {
            return GetSettingsRow(sServername).UseIntegrated;
        }

        public bool ServerHasAllSettings(string sServername)
        {
            if (GetServerDefaultBackupdir(sServername) == "")
                return false;

            if (GetServerDefaultDatadir(sServername) == "")
                return false;

            if (GetServerDefaultLogdir(sServername) == "")
                return false;

            if (GetServerIntegratedSecurity(sServername) || (GetServerUsername(sServername) != "" || GetServerPassword(sServername) != ""))
                return true;

            //else return false;
            return false;
        }

        public void SaveServer(string sServername, string sUsername, string sPassword, bool bUseIntegrated, string sDatadir, string sBackupdir, string sLogdir)
        {
            dsSettings.dtSettingsRow row;
            row = (dsSettings.dtSettingsRow)_dsConfig.dtSettings.Select("Servername='" + sServername + "'")[0];
            row.Username = sUsername;
            row.Password = sPassword;
            row.UseIntegrated = bUseIntegrated;
            row.DefaultDataDir = sDatadir;
            row.DefaultBackupDir = sBackupdir;
            row.DefaultLogDir = sLogdir;

            //check dirs
            if (!cHelper.CheckFilePathRegex(sDatadir))
            {
                throw new Exception("You can't use this datadir: " + sDatadir +  ". No UNC paths...and don't forget the trailing slash!");
            }

            if (!cHelper.CheckFilePathRegex(sBackupdir))
            {
                throw new Exception("You can't use this backupdir: " + sBackupdir + ". No UNC paths...and don't forget the trailing slash!");
            }

            if (!cHelper.CheckFilePathRegex(sLogdir))
            {
                throw new Exception("You can't use this logdir: " + sBackupdir + ". No UNC paths...and don't forget the trailing slash!");
            }
            
            //check login info
            if ((sUsername == "" || sPassword == "") && !(bUseIntegrated == true))
            {
                throw new Exception("Please specify a username and passwort or choose integrated security.");
            }
            
            if (cHelper.CheckFilePathRegex(sBackupdir) && cHelper.CheckFilePathRegex(sDatadir) && !((sUsername == "" || sPassword == "") && !(bUseIntegrated == true)))
            {
                WriteXML();
            }
        }

        private dsSettings.dtSettingsRow GetSettingsRow(string sServername)
        {
            return (dsSettings.dtSettingsRow)_dsConfig.dtSettings.Select("Servername='" + sServername + "'")[0]; 
        }

        private void WriteXML()
        {
            // Create the FileStream to write with.
            System.IO.FileStream myFileStream = new System.IO.FileStream(_sFilepath, System.IO.FileMode.Create);

            // Create an XmlTextWriter with the fileStream.
            System.Xml.XmlTextWriter myXmlWriter =
               new System.Xml.XmlTextWriter(myFileStream, System.Text.Encoding.Unicode);

            // Write to the file with the WriteXml method.
            _dsConfig.WriteXml(myXmlWriter);
            myXmlWriter.Close();
        }
        public void AddServer(string sServername)
        {            
            DataRow row = _dsConfig.dtSettings.NewRow();
            
            row["Servername"] = sServername ;
            row["Username"] = "";
            row["Password"] = "";
            row["UseIntegrated"] = "false";
            row["DefaultDataDir"] = "";
            row["DefaultBackupDir"] = "";
            row["DefaultLogDir"] = "";

            _dsConfig.dtSettings.Rows.Add(row);
            WriteXML();
        }

        public void RemoveServer(string sServername)
        {
            dsSettings.dtSettingsRow row;
            row = (dsSettings.dtSettingsRow)_dsConfig.dtSettings.Select("Servername='" + sServername + "'")[0];
            row.Delete();
            WriteXML();
        }
    }
}
