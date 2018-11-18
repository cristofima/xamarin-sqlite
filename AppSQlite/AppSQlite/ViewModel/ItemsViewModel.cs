using AppSQlite.Interfaces;
using AppSQlite.Models;
using AppSQlite.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSQlite.ViewModel
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<TaskItemViewModel> _items;

        private SqliteService _sqliteService;

        public ItemsViewModel()
        {
            _sqliteService = new SqliteService();

            Items = new ObservableCollection<TaskItemViewModel>();
            this.ResetList();
        }

        #region Propiedades

        public ObservableCollection<TaskItemViewModel> Items
        {
            get { return _items; }
            set
            {
                SetValue(ref this._items, value);
            }
        }

        #endregion Propiedades

        #region Comandos

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(GoItem);
            }
        }

        private async void GoItem()
        {
            MainViewModel.GetInstance().Item = new ItemViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ItemPage());
        }

        #endregion Comandos

        #region Métodos

        public async void ResetList()
        {
            var result = await _sqliteService.GetItemsAsync();

            this.Items.Clear();

            foreach (var item in result)
            {
                Items.Add(new TaskItemViewModel {
                    Id = item.Id,
                    Name = item.Name,
                    Done = item.Done,
                    Notes = item.Notes
                });
            }
        }

        #endregion Métodos
    }
}