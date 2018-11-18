using System;
using System.IO;
using AppSQlite.Droid.Services;
using AppSQlite.Interfaces;
using Xamarin.Forms;

// Utilizamos el atributo assembly:Dependency para poder realizar la resolución de la implementación con DependencyService.
[assembly: Dependency(typeof(PathService))]
namespace AppSQlite.Droid.Services
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.DatabaseName);
        }
    }
}