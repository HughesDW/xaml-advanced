using System.Collections.Generic;
using System.ComponentModel;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
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
                _orderItems = value; 
                OnPropertyChanged();
            }
        }
    }
}
