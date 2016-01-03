using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            //{
            //    this.MenuItems[3],
            //    this.MenuItems[5]
            //};
            this.CurrentlySelectedMenuItems.Add(MenuItems[3]);
            this.CurrentlySelectedMenuItems.Add(MenuItems[5]);

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

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }
    }
}
