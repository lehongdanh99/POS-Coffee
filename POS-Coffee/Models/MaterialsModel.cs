using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class MaterialsModel : BaseModel
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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
    }
    public class MaterialAPIHandlerData
    {

        private static MaterialAPIHandlerData _instance;
        public static MaterialAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new MaterialAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<MaterialsModel> listMaterial = RestAPIHandler<MaterialsModel>.parseJsonToModel(GlobalDef.MATERIALS_JSON_CONFIG_PATH);
        public List<MaterialsModel> ListMaterial
        {
            get { return listMaterial; }
            set
            {
                listMaterial = value;
            }
        }
    }

}