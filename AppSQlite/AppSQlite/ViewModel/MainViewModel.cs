using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region ViewModels
        public ItemsViewModel ItemsList
        {
            get;
            set;
        }

        public ItemViewModel Item
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;

            this.ItemsList = new ItemsViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
