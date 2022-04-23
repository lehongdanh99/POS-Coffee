using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class MaterialsModel
    {
        private static MaterialsModel _instance;
        public static MaterialsModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new MaterialsModel();
                }
            }
            return _instance;
        }
        public int FoodID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Picture { get; set; }
        public string Type { get; set; }

        private List<MaterialsModel> lstEmpl;

        public List<MaterialsModel> LstEmpl
        {
            get
            {
                if (lstEmpl == null)
                    lstEmpl = new List<MaterialsModel>();
                return lstEmpl;
            }
            set
            {
                lstEmpl = value;
            }
        }

    }
}