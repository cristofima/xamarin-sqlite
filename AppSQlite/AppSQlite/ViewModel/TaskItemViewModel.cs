using AppSQlite.Models;
using AppSQlite.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSQlite.ViewModel
{
    public class TaskItemViewModel : Item
    {

        #region Comandos

        public ICommand SelectItemCommand
        {
            get
            {
                return new RelayCommand(GoItemSelected);
            }
        }

        private async void GoItemSelected()
        {
            MainViewModel.GetInstance().Item = new ItemViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ItemPage());
        }

        #endregion Comandos
    }
}