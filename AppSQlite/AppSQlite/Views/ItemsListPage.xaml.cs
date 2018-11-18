using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsListPage : ContentPage
    {
        public ItemsListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Replace with your code…
            Debug.WriteLine("ItemsListPage OnAppearing");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            // Replace with your code…
            Debug.WriteLine("ItemsListPage OnDisappearing");
            base.OnDisappearing();
        }
    }
}