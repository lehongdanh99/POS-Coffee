using CoffeePos.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CoffeePos.Common
{
    public class CommonMethod
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CommonMethod _instance;
        private TableModel model = new TableModel();
        public static CommonMethod GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new CommonMethod();
                }
            }
            return _instance;
        }

        public TableModel readJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.JSON_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                model = JsonConvert.DeserializeObject<TableModel>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return model;
        }
    }
}


