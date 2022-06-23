using System.Collections.Generic;


namespace POS_Coffe.Models
{

    public class EmployeeModel : BaseModel
    {
        private static EmployeeModel _instance;
        public static EmployeeModel GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new EmployeeModel();
                }
            }
            return _instance;
        }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Token { get; set; }

    }
    public class EmployeeAPIHandlerData
    {

        private static EmployeeAPIHandlerData _instance;
        public static EmployeeAPIHandlerData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new EmployeeAPIHandlerData();
                }
            }
            return _instance;
        }
        private List<EmployeeModel> listEmployee = CommonMethod.GetInstance().ReadJsonFileConfigEmployee();
        public List<EmployeeModel> ListEmployee
        {
            get { return listEmployee; }
            set
            {
                listEmployee = value;
            }
        }
    }
}