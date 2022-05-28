using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePos.ViewModels
{
    internal class ListVouchersViewModel : Screen
    {
        private static ListVouchersViewModel _instance;
        public static ListVouchersViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListVouchersViewModel();
            }
            return _instance;
        }

        public SelectedVoucher eventChooseVoucher;
        public delegate void SelectedVoucher(Voucher selectedVoucher);

        public ListVouchersViewModel()
        {
            

            GetVoucher();
            getCustomer();

        }

        public void GetVoucher()
        {
            VoucherList = new ObservableCollection<Voucher>();
            foreach (Voucher voucher in CommonMethod.GetInstance().readVoucherJsonFileConfig())
            {
                VoucherList.Add(voucher);
            }
        }

        public void getCustomer()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
            foreach (Customer cus in CommonMethod.GetInstance().readCustomerJsonFileConfig())
            {
                customers.Add(cus);
            }
        }
        public void GetEnableVoucher()
        {
            foreach (var voucher in VoucherList)
            {
                if(voucher.isValid)
                {
                    voucher.IsCanChoose = true;
                    if (voucher.IDFood != 0)
                    {
                        foreach (var food in FoodOrderModel.GetInstance().FoodOrders)
                        {
                            if (voucher.IDFood == food.FoodOrderID)
                            {
                                voucher.IsCanChoose = true;
                            }
                            else
                                voucher.IsCanChoose = false;
                        }

                    }
                } 
                else
                {
                    voucher.IsCanChoose = false;
                }    
                

            }
        }
        private ObservableCollection<Voucher> voucherList;
        public ObservableCollection<Voucher> VoucherList
        {
            get { return voucherList; }
            set { voucherList = value; NotifyOfPropertyChange(() => VoucherList); }
        }

        public void ChooseVoucher(Voucher voucher)
        {
            eventChooseVoucher?.Invoke(voucher);

            if(voucher.IDFood == null)
            this.TryCloseAsync();
        }
    }
}
