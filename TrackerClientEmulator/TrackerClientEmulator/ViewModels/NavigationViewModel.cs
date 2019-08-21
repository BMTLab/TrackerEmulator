#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrackerClientEmulator.Entites;
using TrackerClientEmulator.Helpers.Extension;
using Xamarin.Forms;

namespace TrackerClientEmulator.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Fields

        private static ObservableCollection<NavigationItem> _navigationItems;
        private Page _currentNavigationPage;
        private NavigationItem _selectedNavigationItem;
        private bool _isRefreshing = false;

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
                NavigationItems.AddPages((IEnumerable<BasePageViewModel>) e.NewItems);
            };

            SelectedNavigationItem = NavigationItems.First();
        }

        #endregion


        #region Properties

        public ObservableCollection<NavigationItem> NavigationItems
        {
            get => _navigationItems;
            set
            {
                _navigationItems = value;
                OnPropertyChanged(nameof(NavigationItems));
            }
        }

        public Page CurrentNavigationPage
        {
            get => _currentNavigationPage;
            set
            {
                _currentNavigationPage = value;
                OnPropertyChanged(nameof(CurrentNavigationPage));
            }
        }

        public NavigationItem SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set
            {
                if (value == null)
                    return;

                _selectedNavigationItem = value;

                foreach (var item in NavigationItems)
                {
                    item.BackgroundColor = new Color().LightBackgroundColor();
                }

                _selectedNavigationItem.BackgroundColor = new Color().Primary();
                _selectedNavigationItem.BorderColor = new Color().Primary();
                _selectedNavigationItem.Command.Execute(_selectedNavigationItem.CommandParameter);

                OnPropertyChanged(nameof(SelectedNavigationItem));
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    foreach (var item in NavigationItems)
                    {
                        item.BorderColor = new Color().LightBackgroundColor();
                    }

                    IsRefreshing = false;
                });
            }
        }

        #endregion


        #region Methods

        #endregion
    }
}
