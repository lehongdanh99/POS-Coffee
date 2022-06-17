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
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class EmployeeAPIHandlerFakeData
    {

        private static EmployeeAPIHandlerFakeData _instance;
        public static EmployeeAPIHandlerFakeData GetInstance()
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    _instance = new EmployeeAPIHandlerFakeData();
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