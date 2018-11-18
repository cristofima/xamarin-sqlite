using AppSQlite.ViewModel;
using AppSQlite.Views;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace AppSQlite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ItemsListPage());
        }

        protected override void OnStart()
        {
            Debug.WriteLine("App OnStart");
            this.InitMessagingCenter();
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("App OnSleep");
            this.DestroyMessagingCenter();
        }

        protected override void OnResume()
        {
            Debug.WriteLine("App OnResume");
            // Handle when your app resumes
        }

        private void InitMessagingCenter()
        {
            MessagingCenter.Subscribe<ItemPage>
             (this, "ResetListTask", (sender) =>
             {
                 MainViewModel.GetInstance().ItemsList.ResetList();
             });
        }

        private void DestroyMessagingCenter()
        {
            MessagingCenter.Unsubscribe<ItemPage>(this, "ResetListTask");
        }
    }
}