#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrackerClientEmulator.Entites;
using TrackerClientEmulator.Helpers.Extension;
using Xamarin.Forms;

namespace TrackerClientEmulator.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Fields
        private static ObservableCollection<NavigationItem> _navigationItems;
        #endregion


        #region Constructors
        public NavigationViewModel(Page navPage)
        {
            CurrentNavigationPage = navPage;
            CurrentNavigationPage.BindingContext = this;
            CurrentNavigationPage.Title = "Tracker Emulator";

            NavigationItems = new ObservableCollection<NavigationItem>();
            NavigationItems.CollectionChanged += (_, e) => OnPropertyChanged(nameof(NavigationItems));

            foreach (var page in App.Pages)
            {
                NavigationItems.Add(new NavigationItem(page));
            }

            App.Pages.CollectionChanged += (_, e) =>
            {
                NavigationItems.AddPages((IEnumerable<BasePageViewModel>)e.NewItems);
            };

            CurrentNavigationPage.FindByName<ListView>("NavigationListView").ItemSelected += (_, e) =>
            {
                foreach (var item in NavigationItems)
                {
                    item.BackgroundColor = (Color)Application.Current.Resources["LightBackgroundColor"];
                }

                var itemSelected = (NavigationItem)e.SelectedItem;
                itemSelected.BackgroundColor = (Color)Application.Current.Resources["Primary"];
                NavigationItems[e.SelectedItemIndex].Command.Execute(itemSelected.CommandParameter);
            };
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
                OnPropertyChanged(nameof(NavigationItems));
            }
        }

        public Page CurrentNavigationPage { get; protected set; }
        #endregion


        #region Methods
        #endregion
    }
}
