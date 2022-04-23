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
    internal class PaymentViewModel : Screen
    {
        public PaymentViewModel()
        {
            MoneySuggestList = getMoneySuggestList();
        }

        private ObservableCollection<MoneySuggest> getMoneySuggestList()
        {
            return new ObservableCollection<MoneySuggest>()
            {
                new MoneySuggest(1000),
                new MoneySuggest(2000),
                new MoneySuggest(5000),
                new MoneySuggest(10000),
                new MoneySuggest(20000),
                new MoneySuggest(50000),
                new MoneySuggest(100000),
                new MoneySuggest(200000),
                new MoneySuggest(500000),
            };
        }

        private ObservableCollection<MoneySuggest> moneySuggest = new ObservableCollection<MoneySuggest>();
        public ObservableCollection<MoneySuggest> MoneySuggestList
        {
            get { return moneySuggest; }
            set { moneySuggest = value;
                NotifyOfPropertyChange(() => MoneySuggestList);
            }
        }
    }
}
