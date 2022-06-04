using System.Collections.Generic;


namespace POS_Coffe.Models
{
    public class VoucherModel
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
        public int VoucherID { get; set; }
        public string Name { get; set; }
        public int IDFood { get; set; }
        public int Value { get; set; }
        public bool isValue { get; set; }
        public string StrIDFood { get; set; }
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
        private List<VoucherModel> listVoucher = CommonMethod.GetInstance().ReadJsonFileConfigVoucher();
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