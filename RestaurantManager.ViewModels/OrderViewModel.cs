using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;
        private string _specialRequest;




        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand<object>(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand<object>(SubmitOrder);
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();

        }

        
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

        }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (value != _menuItems)
                {
                    _menuItems = value;
                    OnPropertyChanged(); 
                }
            }
        }

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value != _selectedMenuItem)
                {
                    _selectedMenuItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SpecialRequest
        {
            get { return _specialRequest; }
            set { _specialRequest = value;
                OnPropertyChanged();

            }
        }

        public void AddMenuItem(object parameter)
        {
            this.CurrentlySelectedMenuItems.Add(this.SelectedMenuItem);
        }

        public void SubmitOrder(object parameter)
        {
            base.Repository.Orders.Add(
                new Order
                {
                    Items = this.CurrentlySelectedMenuItems.ToList(),
                    Table = base.Repository.Tables.Last(),
                    SpecialRequests = this.SpecialRequest
                    
                    
                }
            );

            this.CurrentlySelectedMenuItems.Clear();
            this.SpecialRequest = "";
        }

        public ICommand AddMenuItemCommand { get; private set; }

        public ICommand SubmitOrderCommand { get; private set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }
    }
}
