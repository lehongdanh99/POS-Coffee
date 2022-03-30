using Caliburn.Micro;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CoffeePos.ViewModels
{
    internal class TablesViewModel : Screen
    {
        bool isChoose;
        int floor = 1;

        public TablesViewModel(bool isChooseTable)
        {
            isChoose = isChooseTable;
            TablesList = GetAllTableList(floor);
        }

        private SolidColorBrush colorTable;
        public SolidColorBrush ColorTable { get { return colorTable; }
            set
            {
                colorTable = value;
                NotifyOfPropertyChange(() => ColorTable);
            } }

        private List<Table> GetAllTableList(int floor)
        {
            
            return new List<Table>()
            {
                new Table(true,1,4),
                new Table(true,2,4),
                new Table(true,2,3),
                new Table(true,3,4),
                new Table(true,3,4),
                new Table(true,3,2),
            };
        }

        private List<Table> GetTableList(int floor, List<Table> tablesList)
        {
            for (int i = 0; i < tablesList.Count; i++)
            {

            }
            
        }

        private bool is1thFloor = true;
        private bool is2thFloor = false;
        private bool is3thFloor = false;

        private SolidColorBrush bg1thFloor;
        public SolidColorBrush Bg1thFloor
        {
            get
            {
                return bg1thFloor;
            }
            set
            {
                bg1thFloor = value;
                NotifyOfPropertyChange(() => Bg1thFloor);
            }
        }

        private SolidColorBrush bg2thFloor;
        public SolidColorBrush Bg2thFloor
        {
            get
            {
                return bg2thFloor;
            }
            set
            {
                bg2thFloor = value;
                NotifyOfPropertyChange(() => Bg2thFloor);
            }
        }

        private SolidColorBrush bg3thFloor;
        public SolidColorBrush Bg3thFloor
        {
            get
            {
                return bg3thFloor;
            }
            set
            {
                bg3thFloor = value;
                NotifyOfPropertyChange(() => Bg3thFloor);
            }
        }

        private List<Table> tables;
        public List<Table> TablesList
        {
            get { return tables; }
            set { tables = value; NotifyOfPropertyChange(() => TablesList); }
        }

        public void btDetail_Click()
        {
            TableDetailViewModel registerViewModel = new TableDetailViewModel();
            WindowManager windowManager = new WindowManager();
            windowManager.ShowDialogAsync(registerViewModel);

        }

        public void bt1thFloor_Click()
        {
            if (is1thFloor != true)
            {
                Bg1thFloor = new SolidColorBrush(Colors.Orange);
                Bg2thFloor = new SolidColorBrush(Colors.LightGray);
                Bg3thFloor = new SolidColorBrush(Colors.LightGray);
                is1thFloor = true;
                is2thFloor = false;
                is3thFloor = false;
                floor = 1;
                TablesList = GetTableList(floor);
            }
        }

        public void bt2thFloor_Click()
        {
            if (is2thFloor != true)
            {
                Bg1thFloor = new SolidColorBrush(Colors.LightGray);
                Bg2thFloor = new SolidColorBrush(Colors.Orange);
                Bg3thFloor = new SolidColorBrush(Colors.LightGray);
                is1thFloor = false;
                is2thFloor = true;
                is3thFloor = false;
                floor = 2;
                TablesList = GetTableList(floor);
            }
        }

        public void bt3thFloor_Click()
        {
            if (is2thFloor != true)
            {
                Bg1thFloor = new SolidColorBrush(Colors.LightGray);
                Bg2thFloor = new SolidColorBrush(Colors.LightGray);
                Bg3thFloor = new SolidColorBrush(Colors.Orange);
                is1thFloor = false;
                is2thFloor = false;
                is3thFloor = true;
                floor = 3;
                TablesList = GetTableList(floor);
            }
        }
    }

    
}
