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
using static CoffeePos.Models.ReceiptModel;

namespace CoffeePos.ViewModels
{
    internal class TablesViewModel : Screen
    {
        private static TablesViewModel _instance;
        public static TablesViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TablesViewModel();
            }
            return _instance;
        }


        //public bool isChoose;
        
        public SelectedTableThis eventChooseTableToOrder;
        public delegate void SelectedTableThis(int SelectedTable);
        //TableModel tablemodel = new TableModel();

        public TablesViewModel()
        {
            TablesAllList = GetAllTableList();
            getData();


        }

        public void getData()
        {
            
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

        private Visibility confirmChooseMoreBtn;
        public Visibility ConfirmChooseMoreBtn
        {
            get 
            { 
                if(GlobalDef.IsChooseMoreTable)
                {
                    return Visibility.Visible;
                }    
                else
                {
                    return Visibility.Collapsed;
                }    
                
            }
            set { confirmChooseMoreBtn = value;
                NotifyOfPropertyChange(() => ConfirmChooseMoreBtn);
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

                //_selectedIndexTable = value;
                //if (_selectedIndexTable != null)
                //{
                //    btTableSelected_Click(_selectedIndexTable);
                //}

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
                    if(receipt.Table == SelectedListTable.TableID.ToString())
                    {
                        GlobalDef.ReceiptDetail = receipt;
                        GlobalDef.canEditDetail = true;
                        //TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
                        //WindowManager windowManager = new WindowManager();
                        GlobalDef.DetailFromHome = Visibility.Visible;
                        TableDetailViewModel.GetInstance().getdataTableDetail();
                        //tableDetailViewModel.eventSwitchTableCallBack += HandleSwitchTableCallBack;
                        GlobalDef.windowManager.ShowWindowAsync(TableDetailViewModel.GetInstance());
                        //this.TryCloseAsync();
                        break;
                    }
                }    
                
                //orderDetailViewModel.eventChange += HandleCallBack;

                
            }
            else if (GlobalDef.IsChooseTableToOrder && !SelectedListTable.TableStatus)
            {
                int tableIdChoose = SelectedListTable.TableID;
                eventChooseTableToOrder?.Invoke(tableIdChoose);
                //SelectedListTable.TableStatus = true;
                //GetStatusAllTableList(TablesList);
                this.TryCloseAsync();
            }
            else if (GlobalDef.IsChooseMoreTable && !SelectedListTable.TableStatus)
            {
                int tableIdChoose = SelectedListTable.TableID;
                eventChooseTableToOrder?.Invoke(tableIdChoose);
            }
            //NotifyOfPropertyChange(() => SelectedListTable.BgStatusTable);
        }

        //public void HandleSwitchTableCallBack(int SelectedTable)
        //{
        //    TablesAllList[SelectedTable].TableStatus = false;
        //    GlobalDef.IsChooseTableToOrder = true;
        //    //NotifyOfPropertyChange(() => TablesAllList[SelectedTable].BgStatusTable);
        //}

        private ObservableCollection<Table> GetAllTableList()
        {
            ObservableCollection<Table> tables = new ObservableCollection<Table>();
            foreach (Table table in CommonMethod.GetInstance().readTableJsonFileConfig())
            {
                tables.Add(table);
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
            GlobalDef.ReceiptDetail = receipt;
            GlobalDef.canEditDetail = false;
            //TableDetailViewModel tableDetailViewModel = new TableDetailViewModel();
            //tableDetailViewModel.eventChange += HandleCallBack;
            GlobalDef.DetailFromHome = Visibility.Visible;
            //WindowManager windowManager = new WindowManager();
            TableDetailViewModel.GetInstance().getdataTableDetail();
            GlobalDef.windowManager.ShowWindowAsync(TableDetailViewModel.GetInstance());
        }

        public void btBack_Click()
        {
            this.TryCloseAsync(true);
            //HomeViewModel home ;
            //tableDetailViewModel.eventChange += HandleCallBack;
            if(HomeViewModel.GetInstance() == null)
            {

            }
            //WindowManager windowManager = new WindowManager();
            GlobalDef.windowManager.ShowWindowAsync(HomeViewModel.GetInstance());
        }

    }


}
