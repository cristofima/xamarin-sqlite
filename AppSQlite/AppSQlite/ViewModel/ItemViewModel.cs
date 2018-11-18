using AppSQlite.Interfaces;
using AppSQlite.Models;
using AppSQlite.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSQlite.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        private Item _item;

        private SqliteService _sqliteService;

        #region Propiedades

        public bool IsVisibleDelete { get; set; }
        public string TitlePage { get; set; }

        public Item Item
        {
            get { return _item; }
            set
            {
                SetValue(ref this._item, value);
            }
        }

        #endregion Propiedades

        public ItemViewModel() : this(null)
        {
        }

        public ItemViewModel(Item it)
        {
            if (it != null)
            {
                Item = new Item(it);
                this.IsVisibleDelete = true;
                this.TitlePage = "Editar Tarea";
            }
            else
            {
                Item = new Item();
                this.TitlePage = "Nueva Tarea";
            }
            _sqliteService = new SqliteService();

            SelectItemCommand = new Command<Item>(
            async (Item item) =>
            {
                MainViewModel.GetInstance().Item = new ItemViewModel(item);
                await Application.Current.MainPage.Navigation.PushAsync(new ItemPage());
            });
        }

        #region Comandos

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(SaveItem);
            }
        }

        private async void SaveItem()
        {
            await _sqliteService.SaveItemAsync(Item);
            DependencyService.Get<IMessage>().ShortAlert($"Tarea {Item.Name} guardada");
            MainViewModel.GetInstance().ItemsList.ResetList();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteItem);
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(Cancel);
            }
        }

        private async void DeleteItem()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmación",
                "Desea eliminar la tarea",
                "Aceptar", "Cancelar");
            if (answer)
            {
                await _sqliteService.DeleteItemAsync(Item);
                DependencyService.Get<IMessage>().ShortAlert($"Tarea {Item.Name} eliminada");
                MainViewModel.GetInstance().ItemsList.ResetList();

                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async void Cancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public ICommand SelectItemCommand { private set; get; }

        #endregion Comandos
    }
}