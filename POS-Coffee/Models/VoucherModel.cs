using System.Collections.Generic;


namespace POS_Coffe.Models
{
    public class VoucherModel : BaseModel
    {
        private static VoucherModel _instance;
        public static VoucherModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new VoucherModel();
                }
            }
            return _instance;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int value { get; set; }
        public System.DateTime publishedDate { get; set; }
        public System.DateTime endDate { get; set; }
    }
    public class VoucherAPIHandlerData
    {

        private static VoucherAPIHandlerData _instance;
        public static VoucherAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new VoucherAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<VoucherModel> listVoucher = RestAPIHandler<VoucherModel>.parseJsonToModel(GlobalDef.VOUCHER_JSON_CONFIG_PATH);
        public List<VoucherModel> ListVoucher
        {
            get { return listVoucher; }
            set
            {
                listVoucher = value;
            }
        }
    }
}