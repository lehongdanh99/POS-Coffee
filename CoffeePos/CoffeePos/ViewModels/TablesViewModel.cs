using Caliburn.Micro;
using CoffeePos.Common;
using CoffeePos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static CoffeePos.Models.ListTable;
using static CoffeePos.Models.ReceiptModel;
using static CoffeePos.Models.TableModel;

namespace CoffeePos.ViewModels
{
    internal class TablesViewModel : Screen
    {
        private static TablesViewModel _instance;
        public static TablesViewModel GetInstance(bool isChooseTable = default)
        {
            if(isChooseTable == default)
            {
                
            }
            if (_instance == null)
            {
                _instance = new TablesViewModel(isChooseTable);
            }
            return _instance;
        }


        public bool isChoose;
        
        public SelectedTableThis eventChooseTableToOrder;
        public delegate void SelectedTableThis(int SelectedTable);
        //TableModel tablemodel = new TableModel();

        public TablesViewModel(bool isChooseTable)
        { 

            isChoose = isChooseTable;
            TablesAllList = GetAllTableList();
            GetStatusAllTableList();
            ListFloor = GetListFloor();
            TablesList = GetTableList(listFloorSelected, TablesAllList);
        }

        private void GetStatusAllTableList()
        {
            EmtyCount = 0;
            BusyCount = 0;
            for (int i = 0; i < TablesAllList.Count; i++)
            {
                if (!TablesAllList[i].TableStatus)
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

        public void SwtitchTable()
        {

        }

        public void btTableSelected_Click(Table SelectedListTable)
        {

            if (SelectedListTable.TableStatus)
            {
                foreach(Receipt receipt in ReceiptModel.GetInstance().ListReceipt)
                {
                    if(receipt.Table == SelectedListTable.TableID)
                    {
                        TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, true);
                        WindowManager windowManager = new WindowManager();
                        tableDetailViewModel.eventSwitchTableCallBack += HandleSwitchTableCallBack;
                        windowManager.ShowWindowAsync(tableDetailViewModel);
                        //this.TryCloseAsync();
                        break;
                    }
                }    
                
                //orderDetailViewModel.eventChange += HandleCallBack;

                
            }
            else if (isChoose && !SelectedListTable.TableStatus)
            {
                int tableIdChoose = SelectedListTable.TableID;
                eventChooseTableToOrder?.Invoke(tableIdChoose);
                //SelectedListTable.TableStatus = true;
                //GetStatusAllTableList(TablesList);
                this.TryCloseAsync();
            }
            //NotifyOfPropertyChange(() => SelectedListTable.BgStatusTable);
        }

        private void HandleSwitchTableCallBack(int SelectedTable)
        {
            TablesAllList[SelectedTable].TableStatus = false;
            isChoose = true;
            //NotifyOfPropertyChange(() => TablesAllList[SelectedTable].BgStatusTable);
        }

        private ObservableCollection<Table> GetAllTableList()
        {
            ObservableCollection<Table> tables = new ObservableCollection<Table>();
            foreach (var item in ListTable.GetInstance().ListTables.TableNumber)
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
                GetStatusAllTableList();
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


        private ObservableCollection<Table> tablesAllList;
        public ObservableCollection<Table> TablesAllList
        {
            get { return tablesAllList; }
            set { tablesAllList = value; NotifyOfPropertyChange(() => TablesAllList); }
        }

        private ObservableCollection<Table> tables;
        public ObservableCollection<Table> TablesList
        {
            get { return tables; }
            set { tables = value; NotifyOfPropertyChange(() => TablesList); }
        }

        //public void btDetail_Click()
        //{
        //    TableDetailViewModel registerViewModel = new TableDetailViewModel();
        //    WindowManager windowManager = new WindowManager();
        //    windowManager.ShowDialogAsync(registerViewModel);

        //}

        public void Choose(Receipt receipt)
        {

            TableDetailViewModel tableDetailViewModel = new TableDetailViewModel(receipt, false);
            //tableDetailViewModel.eventChange += HandleCallBack;

            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(tableDetailViewModel);
        }

        public void btBack_Click()
        {
            this.TryCloseAsync(true);
            //HomeViewModel home ;
            //tableDetailViewModel.eventChange += HandleCallBack;
            if(HomeViewModel.GetInstance() == null)
            {

            }
            WindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(HomeViewModel.GetInstance());
        }

    }


}
