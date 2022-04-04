using Caliburn.Micro;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public SelectedTableThis eventChange;
        public delegate void SelectedTableThis(Table selected);

        public TablesViewModel(bool isChooseTable)
        {
            isChoose = isChooseTable;
            TablesAllList = GetAllTableList();
            GetStatusAllTableList(TablesAllList);
            ListFloor = GetListFloor();
        }

        private void GetStatusAllTableList(List<Table> listTable)
        {
            EmtyCount = 0;
            BusyCount = 0;
            for (int i=0; i< listTable.Count; i++)
            {
                if (listTable[i].Status)
                {
                    EmtyCount++;
                }
                else
                    BusyCount++;
            }
            NotifyOfPropertyChange(() => EmtyCount);
            NotifyOfPropertyChange(() => BusyCount);
        }

        private ObservableCollection<int> GetListFloor()
        {
            ObservableCollection<int> listFloors = new ObservableCollection<int>();
            for(int i = 0; i < TablesAllList.Count; i++)
            {
                if(listFloors.Count != 0)
                {
                    bool isFloor = false;
                    for(int j = 0; j < listFloors.Count; j++)
                    {
                        if (TablesAllList[i].Floor == listFloors[j])
                            isFloor = true;
                    }
                    if(!isFloor)
                        listFloors.Add(TablesAllList[i].Floor) ;
                }
                else
                    listFloors.Add(TablesAllList[i].Floor);
                
            }

            return listFloors;
        }

        private int emtycount;
        public int EmtyCount
        { get { return emtycount; }
            set
            {
                emtycount = value;
                NotifyOfPropertyChange(() => EmtyCount);
            } }

        private int busycount;
        public int BusyCount
        {
            get { return busycount; }
            set
            {
                busycount = value;
                NotifyOfPropertyChange(() => BusyCount);
            }
        }

        private int _selectedIndexTable = -1;
        public int SelectedIndexTable
        {
            get
            {
                return _selectedIndexTable;
            }

            set
            {

                _selectedIndexTable = value;
                btTableSelected_Click(_selectedIndexTable);
                NotifyOfPropertyChange(() => SelectedIndexTable);
            }
        }

        public void btTableSelected_Click(int SelectedListTable)
        {


            TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
            //orderDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableDetailViewModel);
        }

        private List<Table> GetAllTableList()
        {
            
            return new List<Table>()
            {
                new Table(true,1,4),
                new Table(true,2,4),
                new Table(true,2,3),
                new Table(true,3,4),
                new Table(true,3,4),
                new Table(true,3,2),
                new Table(true,1,4),
                new Table(true,2,4),
                new Table(true,2,3),
                new Table(true,3,4),
                new Table(true,3,4),
                new Table(true,3,2),
            };
        }

        private ObservableCollection<int> listFloor;

        public ObservableCollection<int> ListFloor
        {
            get { return listFloor; }
            set { listFloor = value; NotifyOfPropertyChange(() => ListFloor); }
        }

        private int listFloorSelected;

        public int ListFloorSelected
        {
            get { return listFloorSelected; }
            set 
            { 
                listFloorSelected = value; 
                NotifyOfPropertyChange(() => ListFloorSelected);
                TablesList = GetTableList(ListFloorSelected, TablesAllList);
                GetStatusAllTableList(TablesList);
                NotifyOfPropertyChange(() => TablesList);
            }
        }

        private List<Table> GetTableList(int floor, List<Table> tablesList)
        {
            List<Table> list = new List<Table>();
            for (int i = 0; i < tablesList.Count; i++)
            {
                if(tablesList[i].Floor == floor)
                {
                    list.Add(tablesList[i]);
                    
                }

            }
            return list;
            
        }



        private List<Table> TablesAllList;

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

        
    }

    
}
