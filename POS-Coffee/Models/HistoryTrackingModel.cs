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
        public int id { get; set; }
        public EmployeeModel employee { get; set; }
        public string actionType { get; set; }
        public string table { get; set; }
        public int tableId { get; set; }
        public System.DateTime occurTime { get; set; }
    }
    public class HistoryTrackingAPIHandlerData
    {

        private static HistoryTrackingAPIHandlerData _instance;
        public static HistoryTrackingAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new HistoryTrackingAPIHandlerData();
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