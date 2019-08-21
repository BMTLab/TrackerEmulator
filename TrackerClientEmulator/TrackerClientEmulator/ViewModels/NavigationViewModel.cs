#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using TrackerClientEmulator.Helpers.Extension;
using TrackerClientEmulator.Views;


namespace TrackerClientEmulator.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Fields
        internal static ObservableCollection<NavigationItem> _navigationItems;
        //private NavigationItem _selectedItem;
        #endregion

        
        #region Constructors
        static NavigationViewModel()
        {

        }

        public NavigationViewModel(Page navPage)
        {
            CurrentNavigationPage = navPage;
            CurrentNavigationPage.BindingContext = this;

            NavigationItems = new ObservableCollection<NavigationItem>();
            //NavigationItems.CollectionChanged += (_, e) => OnPropertyChanged(nameof(NavigationItems));

            foreach (var page in App.Pages)
            {
                NavigationItems.Add(new NavigationItem(page));
            }

            App.Pages.CollectionChanged += (_, e) =>
            {
                NavigationItems.AddPages((IEnumerable<BasePageViewModel>)e.NewItems);
            };

            //CurrentNavigationPage.FindByName<NavigationItem>("NavigationItem").Title = "sdfyhyd";
            //NavigationItems[1].BackgroundColor = Color.Blue;
            CurrentNavigationPage.FindByName<ListView>("NavigationListView").Footer = "Mielta";
            //CurrentNavigationPage.FindByName<ListView>("NavigationListView").ItemSelected += (_, e) =>
            //{
            //    foreach (var page in NavigationItems)
            //    {
            //        page.BackgroundColor = Color.Blue;
            //    }

            //    NavigationItems[1].Title = "sdg";
            //    //OnPropertyChanged(nameof(NavigationItems));
            //};

            OnPropertyChanged(nameof(NavigationItems));
        }
        #endregion


        #region Properties
        public ObservableCollection<NavigationItem> NavigationItems
        {
            get
            {
                return _navigationItems;
            }
            set
            {
                _navigationItems = value;

            }
        }

        public Page CurrentNavigationPage { get; protected set; }

        //public object SelectedItem
        //{
        //    get
        //    {
        //        return _selectedItem;
        //    }
        //    set
        //    {
        //        if (value == null)
        //            return;

        //        _selectedItem = value as NavigationItem;

        //        if (_selectedItem == null)
        //            return;

        //        _selectedItem.BackgroundColor = Color.Violet;
        //        OnPropertyChanged(nameof(SelectedItem));
        //    }
        //}
        #endregion


        #region Methods

        #endregion
    }
}
