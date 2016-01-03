using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;

        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand<object>(AddMenuItem);
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();


            //this.CurrentlySelectedMenuItems.Add(MenuItems[3]);
            //this.CurrentlySelectedMenuItems.Add(MenuItems[5]);
        }




        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            //this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            ////{
            ////    this.MenuItems[3],
            ////    this.MenuItems[5]
            ////};
            //this.CurrentlySelectedMenuItems.Add(MenuItems[3]);
            //this.CurrentlySelectedMenuItems.Add(MenuItems[5]);

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


        public void AddMenuItem(object parameter)
        {
            this.CurrentlySelectedMenuItems.Add(this.SelectedMenuItem);
        }

        public ICommand AddMenuItemCommand { get; private set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }
    }
}
