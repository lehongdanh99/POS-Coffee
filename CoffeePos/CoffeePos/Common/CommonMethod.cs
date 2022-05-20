﻿using CoffeePos.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CoffeePos.Common
{
    public class CommonMethod
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CommonMethod _instance;
        private TableModel model = new TableModel();
        private List<Foods> foodModel;
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

        public List<Foods> readFoodJsonFileConfig()
        {
            string json = String.Empty;
            using (StreamReader r = new StreamReader(GlobalDef.JSON_FOOD_CONFIG_PATH))
            {
                json = r.ReadToEnd();
                foodModel = JsonConvert.DeserializeObject<List<Foods>>(json);
            }
            log.Info($"Read file Table config to Table model {json.ToString()} ");
            return foodModel;
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

        public ImageSource convertByte(byte[] byteImage)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(byteImage);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            return biImg as ImageSource;
        }
    }
}

