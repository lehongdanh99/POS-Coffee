using Caliburn.Micro;
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
            VoucherList = new ObservableCollection<Voucher>()
            {
                new Voucher("10%",10),
                new Voucher("2%",2),
                new Voucher("30%",30),
                new Voucher("40%",40),
                new Voucher("50%",50),
                new Voucher("Mua 1 tặng 1",0,"Cà phê Sữa")


            };

            
            
        }
        public void GetEnableVoucher()
        {
            foreach (var voucher in VoucherList)
            {

                if (voucher.NameFood != null)
                {
                    foreach (var food in FoodOrderModel.GetInstance().FoodOrders)
                    {
                        if (voucher.NameFood == food.FoodOrderName)
                        {
                            voucher.IsCanChoose = true;
                        }
                    }
                    voucher.IsCanChoose = false;
                }
                else
                {
                    voucher.IsCanChoose = true;
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

            if(voucher.NameFood == "")
            this.TryCloseAsync();
        }
    }
}
