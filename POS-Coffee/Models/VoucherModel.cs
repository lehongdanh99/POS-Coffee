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
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public System.DateTime PublishDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
    public class VoucherAPIHandlerFakeData
    {

        private static VoucherAPIHandlerFakeData _instance;
        public static VoucherAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new VoucherAPIHandlerFakeData();
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