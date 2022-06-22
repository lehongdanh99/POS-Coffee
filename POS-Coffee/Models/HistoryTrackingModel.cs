using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class HistoryTrackingModel: BaseModel
    {
        private static HistoryTrackingModel _instance;
        public static HistoryTrackingModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new HistoryTrackingModel();
                }
            }
            return _instance;
        }
        public int HistoryID { get; set; }
        public int EmpID { get; set; }
        public string TableEffect { get; set; }
        public string OccurTime { get; set; }
        public string ActionType { get; set; }
    }
    public class HistoryTrackingAPIHandlerFakeData
    {

        private static HistoryTrackingAPIHandlerFakeData _instance;
        public static HistoryTrackingAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new HistoryTrackingAPIHandlerFakeData();
                }
            }
            return _instance;
        }
        private List<HistoryTrackingModel> listHistoryTracking = RestAPIHandler<HistoryTrackingModel>.parseJsonToModel(GlobalDef.HISTORYTRACKING_JSON_CONFIG_PATH);
        public List<HistoryTrackingModel> ListHistoryTracking
        {
            get { return listHistoryTracking; }
            set
            {
                listHistoryTracking = value;
            }
        }
    }
}