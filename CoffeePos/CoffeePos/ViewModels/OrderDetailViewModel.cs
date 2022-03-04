using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CoffeePos.ViewModels
{
    internal class OrderDetailViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public OrderDetailViewModel()
        {
            this.orderCount = 1;
        }

        private int orderCount;

        public int OrderCount
        {
            get 
            { 
                return this.orderCount; 
            }
            set 
            { 
                this.orderCount = value;
                NotifyOfPropertyChange(() => this.orderCount);
            }
        }
        
        public void btnLess_Click()
        {
            if(this.orderCount > 1)
            {
                this.orderCount--;
            }
            

            NotifyOfPropertyChange(() => this.orderCount);
            
        }

        public void btnAdd_Click()
        {
            this.orderCount++;
            NotifyOfPropertyChange(() => this.orderCount);
        }
    }
}
