using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static CoffeePos.Models.TableModel;

namespace CoffeePos.ViewModels
{
    internal class TablesViewModel : Screen
    {
        bool isChoose;
        int floor = 1;
        public SelectedTableThis eventChooseTableToOrder;
        public delegate void SelectedTableThis(int SelectedTable);
        TableModel tablemodel = new TableModel();

        public TablesViewModel(bool isChooseTable)
        {
            tablemodel = CommonMethod.GetInstance().readJsonFileConfig();

            isChoose = isChooseTable;
            TablesAllList = GetAllTableList();
            GetStatusAllTableList(TablesAllList);
            ListFloor = GetListFloor();
            TablesList = GetTableList(listFloorSelected, TablesAllList);
        }

        private void GetStatusAllTableList(ObservableCollection<Table> listTable)
        {
            EmtyCount = 0;
            BusyCount = 0;
            for (int i = 0; i < listTable.Count; i++)
            {
                if (!listTable[i].TableStatus)
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
            for (int i = 0; i < TablesAllList.Count; i++)
            {
                if (listFloors.Count != 0)
                {
                    bool isFloor = false;
                    for (int j = 0; j < listFloors.Count; j++)
                    {
                        if (TablesAllList[i].TableFloor == listFloors[j])
                            isFloor = true;
                    }
                    if (!isFloor)
                        listFloors.Add(TablesAllList[i].TableFloor);
                }
                else
                    listFloors.Add(TablesAllList[i].TableFloor);

            }

            return listFloors;
        }

        private int emtycount;
        public int EmtyCount
        {
            get { return emtycount; }
            set
            {
                emtycount = value;
                NotifyOfPropertyChange(() => EmtyCount);
            }
        }

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

        private Table _selectedIndexTable;
        public Table SelectedIndexTable
        {
            get
            {
                return _selectedIndexTable;
            }

            set
            {

                _selectedIndexTable = value;
                if (_selectedIndexTable != null)
                {
                    btTableSelected_Click(_selectedIndexTable);
                }

                NotifyOfPropertyChange(() => SelectedIndexTable);
            }
        }

        public void btTableSelected_Click(Table SelectedListTable)
        {

            if (SelectedListTable.TableStatus)
            {
                TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
                //orderDetailViewModel.eventChange += HandleCallBack;

                WindowManager windowManager = new WindowManager();
                windowManager.ShowWindowAsync(tableDetailViewModel);
            }
            else if (isChoose && !SelectedListTable.TableStatus)
            {
                int tableIdChoose = SelectedListTable.TableID;
                eventChooseTableToOrder?.Invoke(tableIdChoose);
                //SelectedListTable.TableStatus = true;
                //GetStatusAllTableList(TablesList);
                this.TryCloseAsync();
            }
            NotifyOfPropertyChange(() => SelectedListTable.BgStatusTable);
        }

        private ObservableCollection<Table> GetAllTableList()
        {
            ObservableCollection<Table> tables = new ObservableCollection<Table>();
            foreach (var item in tablemodel.TableNumber)
            {
                tables.Add(item.Value);
            }           
            return tables;            
        }

        private ObservableCollection<int> listFloor;

        public ObservableCollection<int> ListFloor
        {
            get { return listFloor; }
            set { listFloor = value; NotifyOfPropertyChange(() => ListFloor); }
        }

        private int listFloorSelected = 1;

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

        private ObservableCollection<Table> GetTableList(int floor, ObservableCollection<Table> tablesList)
        {
            ObservableCollection<Table> list = new ObservableCollection<Table>();
            for (int i = 0; i < tablesList.Count; i++)
            {
                if (tablesList[i].TableFloor == floor)
                {
                    list.Add(tablesList[i]);

                }

            }
            return list;

        }



        public ObservableCollection<Table> TablesAllList;

        private ObservableCollection<Table> tables;
        public ObservableCollection<Table> TablesList
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
