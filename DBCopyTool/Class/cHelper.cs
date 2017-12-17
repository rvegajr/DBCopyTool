using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data;
using System.Net;
using System.IO;

namespace DatabaseCopier.Class
{
    static class cHelper
    {

        public static DataTable GetServersFromNetwork()
        {
             // Retrieve the enumerator instance and then the data.
             SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
             DataTable dtInstances = instance.GetDataSources();
             return dtInstances;

        }


        public static bool CheckFilePathRegex(string sFilepath)
        {
            //check if dirs are dirs
            Regex reFoldername = new Regex("^[A-Za-z]:\\\\(.)*(\\\\)*$");

            if (!reFoldername.IsMatch(sFilepath) || !sFilepath.EndsWith("\\"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string MakeUncPath(string sText, string sServer)
        {
            string sUncPath;
            char driveLetter;
            driveLetter = sText.Substring(0, 1)[0];


            sServer = sServer.Replace(sServer, getIpFromServer(sServer));
            sUncPath = sText.Replace(driveLetter + ":\\", "\\\\" + sServer + "\\" + driveLetter + "$\\");
            return sUncPath;
        }

        public static void DeleteFileIfExists(string sUncFileName)
        {
            //Check if file exists and delete..
            if (File.Exists(sUncFileName))
            {
                File.Delete(sUncFileName);
            }
        }


        private static string getIpFromServer(string sServername)
        {
            string returnIP;
            if (sServername.Contains(@"\"))
            {
                sServername = sServername.Substring(0, sServername.IndexOf(@"\"));
                IPHostEntry ip = Dns.GetHostEntry(sServername);
                IPAddress[] IpA = ip.AddressList;
                IPAddress ipItem = null;
                foreach (var ipAddressItem in IpA)
                {
                    //favor IP4 Addresses
                    if (ipAddressItem.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        ipItem = ipAddressItem;
                }
                if (ipItem!=null) {
                    returnIP = ipItem.ToString();
                }
                else if (IpA[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    returnIP = IpA[0].ToString().Replace(":", "-").Replace("%", "s") + ".ipv6-literal.net";
                }
                else
                {
                    returnIP = IpA[0].ToString();
                }

            }
            else
            {
                //To get a host with a www address
                IPHostEntry ip = Dns.GetHostEntry(sServername);
                IPAddress[] IpA = ip.AddressList;

                if (IpA[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    returnIP = IpA[0].ToString().Replace(":", "-").Replace("%", "s") + ".ipv6-literal.net";
                }
                else
                {
                    returnIP = IpA[0].ToString();
                }
            }

            return returnIP;
        } 
  
  }
}
