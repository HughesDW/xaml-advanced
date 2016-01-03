using System.Collections.Generic;
using System.ComponentModel;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private List<Order> _orderItems;

        protected override void OnDataLoaded()
        {

            OrderItems = base.Repository.Orders; 

        }

        public List<Order> OrderItems
        {
            get { return _orderItems; }
            set
            {
                if (value != _orderItems)
                {
                    _orderItems = value;
                    OnPropertyChanged(); 
                }
            }
        }
    }
}
