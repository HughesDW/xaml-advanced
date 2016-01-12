using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ViewModel()
        {
            LoadData();
        }
        
        private async void LoadData()
        {
            this.IsLoading = true;

            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();

            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }




    }
}
