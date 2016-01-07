using System.Collections.Generic;
using System.ComponentModel;
using RestaurantManager.Models;
using System.Windows.Input;
using System;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        public ExpediteViewModel()
        {
            ClearOrdersCommand = new DelegateCommand<object>(ClearOrders);

        }

        public void ClearOrders(object obj)
        {
            base.Repository?.Orders.Clear();
            OnPropertyChanged("OrderItems");
        }

        protected override void OnDataLoaded()
        {
            OnPropertyChanged("OrderItems");

        }

        public ICommand ClearOrdersCommand { get; private set; }

        //public List<Order> OrderItems
        //{
        //    get { return base.Repository?.Orders; }
        //}

        public ObservableCollection<Order> OrderItems
        {
            get { return base.Repository?.Orders; }
        }
    }
}
