using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Text.Json;
using Newtonsoft.Json;

namespace RTTSSyncApp.Models
{
    public class Configuration
    {
        public class DocTypeInfo
        {
            public string DocId { get; set; }
            public string DocName { get; set; }
            public string BPName { get; set; }
        }
        public class AppConfig
        {
            public string[] AllowedFileExt { get; set; }
            public int MaxFileSize { get; set; }
            public string AppLogPath { get; set; }
        }

        public class RTTSConfig
        {
            public string OauthUrl { get; set; }
            public string ApiUrl { get; set; }
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string ReturnAllfields { get; set; }
            public string ReturnOCR { get; set; }
        }

        // Configuration items
        public static List<DocTypeInfo> DocTypes { get; set; }
        public static string[] AllowedFileExt { get; set; }
        public static int MaxFileSize { get; set; }
        public static string AppLogPath { get; set; }
        public static string OauthUrl { get; set; }
        public static string ApiUrl { get; set; }
        public static string ClientId { get; set; }
        public static string ClientSecret { get; set; }
        public static string ReturnAllfields { get; set; }
        public static string ReturnOCR { get; set; }



        public Configuration()
        {
            // Load doc type info from cinfig file
            string DocTypeInfoPath = ConfigurationManager.AppSettings["docTypeInfoPath"];
            string appConfigPath = ConfigurationManager.AppSettings["appConfigPath"];
            string RTTSConfigPath = ConfigurationManager.AppSettings["RTTSConfigPath"];

            try
            {
                string docTypeInfoStringData = System.IO.File.ReadAllText(DocTypeInfoPath);
                DocTypes = new List<DocTypeInfo>(JsonConvert.DeserializeObject<DocTypeInfo[]>(docTypeInfoStringData));


                string appConfigStringData = System.IO.File.ReadAllText(appConfigPath);
                AppConfig appConfig = JsonConvert.DeserializeObject<AppConfig>(appConfigStringData);
                AllowedFileExt = appConfig.AllowedFileExt;
                MaxFileSize = appConfig.MaxFileSize;
                AppLogPath = appConfig.AppLogPath;

                string RTTSConfigStringData = System.IO.File.ReadAllText(RTTSConfigPath);
                RTTSConfig RTTSConfig = JsonConvert.DeserializeObject<RTTSConfig>(RTTSConfigStringData);
                OauthUrl = RTTSConfig.OauthUrl;
                ApiUrl = RTTSConfig.ApiUrl;
                ClientId = RTTSConfig.ClientId;
                ClientSecret = RTTSConfig.ClientSecret;
                ReturnAllfields = RTTSConfig.ReturnAllfields;
                ReturnOCR = RTTSConfig.ReturnOCR;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot initialize configurations");
            }

        }
    }
}