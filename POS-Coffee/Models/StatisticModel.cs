using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class StatisticModel
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
        public DateTime Day { get; set; }
        public string VoucherName { get; set; }
        public string Table { get; set; }
        public int TotalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int CustomerPay { get; set; }
        public string TypePayment { get; set; }
        public string TypeService { get; set; }
        public int Sum { get; set; }
    }
    public class StatisticAPIHandlerFakeData
    {

        private static StatisticAPIHandlerFakeData _instance;
        public static StatisticAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new StatisticAPIHandlerFakeData();
                }
            }
            return _instance;
        }
        private List<StatisticModel> listStatistic = CommonMethod.GetInstance().ReadJsonFileConfigStatistic();
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