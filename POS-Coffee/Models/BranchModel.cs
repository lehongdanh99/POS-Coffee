using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Coffe.Models
{
    public class BranchModel : BaseModel
    {
        public int id { get; set; }
        public string branchName { get; set; }
    }
    public class BranchAPIHandlerData
    {
        private static BranchAPIHandlerData _instance;
        public static BranchAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new BranchAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<BranchModel> listBranch = RestAPIHandler<BranchModel>.parseJsonToModel(GlobalDef.BRANCH_JSON_CONFIG_PATH);
        public List<BranchModel> ListBranch
        {
            get { return listBranch; }
            set
            {
                listBranch = value;
            }
        }
    }
}