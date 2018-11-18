using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        public ItemPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Replace with your code…
            Debug.WriteLine("ItemPage OnAppearing");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            // Replace with your code…
            Debug.WriteLine("ItemPage OnDisappearing");
            MessagingCenter.Send(this, "ResetListTask");
            base.OnDisappearing();
        }
    }
}