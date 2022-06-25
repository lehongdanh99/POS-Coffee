using System.Collections.Generic;

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
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string unit { get; set; }
        public int amount { get; set; }
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