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

        public ListVouchersViewModel()
        {
            VoucherList = new ObservableCollection<Voucher>()
            {
                new Voucher("10%",10),
                new Voucher("2%",10),
                new Voucher("30%",10),
                new Voucher("40%",10),
                new Voucher("50%",10),


            };
        }
        private ObservableCollection<Voucher> voucherList;
        public ObservableCollection<Voucher> VoucherList
        {
            get { return voucherList; }
            set { voucherList = value; NotifyOfPropertyChange(() => VoucherList); }
        }
    }
}
