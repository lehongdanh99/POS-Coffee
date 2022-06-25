using System.Collections.Generic;


namespace POS_Coffe.Models
{
    public class StatisticModel : BaseModel
    {
        private static StatisticModel _instance;
        public static StatisticModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new StatisticModel();
                }
            }
            return _instance;
        }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int receiptTotal { get; set; }
        public int revenue { get; set; }
        public List<ReceiptModel> receipts { get; set; }
    }
    public class StatisticAPIHandlerData
    {

        private static StatisticAPIHandlerData _instance;
        public static StatisticAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new StatisticAPIHandlerData();
                }
            }
            return _instance;
        }

        //private List<StatisticModel> listStatistic = RestAPIHandler<StatisticModel>.parseJsonToModel(GlobalDef.STATISTIC_JSON_CONFIG_PATH)
        private List<StatisticModel> listStatistic = RestAPIHandler<StatisticModel>.GetDate(GlobalDef.STATISTIC_JSON_CONFIG_PATH + GlobalDef.PATHGETDATE, GlobalDef.TOKEN);
        public List<StatisticModel> ListStatistic
        {
            get { return listStatistic; }
            set
            {
                listStatistic = value;
            }
        }
    }
}