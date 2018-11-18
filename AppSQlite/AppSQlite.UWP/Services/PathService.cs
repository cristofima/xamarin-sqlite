using AppSQlite.Interfaces;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppSQlite.UWP.Services.PathService))]

namespace AppSQlite.UWP.Services
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.DatabaseName);
        }
    }
}