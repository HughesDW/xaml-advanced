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
            DeleteOrderCommand = new DelegateCommand<Order>(DeleteOrder);

        }

        private void DeleteOrder(Order obj)
        {
            base.Repository?.Orders.Remove(obj);
            //OnPropertyChanged("OrderItems");
            OrderItems.Remove(obj);
        }

        public void ClearOrders(object obj)
        {
            base.Repository?.Orders.Clear();
            OnPropertyChanged("OrderItems");
        }

        protected override void OnDataLoaded()
        {
            this.IsLoading = false;
            OnPropertyChanged("OrderItems");

        }

        public ICommand ClearOrdersCommand { get; private set; }
        public ICommand DeleteOrderCommand { get; private set; }

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
