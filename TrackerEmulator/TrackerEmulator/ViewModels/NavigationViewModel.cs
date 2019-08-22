﻿#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels
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

        static NavigationViewModel()
        {
            NavigationItem.ItemSelectedColor = new Color().Primary();
            NavigationItem.ItemNonSelectedColor = new Color().LightBackgroundColor();
            NavigationItem.TextColorDefault = new Color().LightTextColor();
        }

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

                RefreshMenu();

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
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await RefreshMenu();

                    IsRefreshing = false;
                });
            }
        }

        #endregion


        #region Methods

        public Task RefreshMenu()
        {
            foreach (var item in NavigationItems)
            {
                item.IsActive = false;
            }

            SelectedNavigationItem.IsActive = true;

            return Task.CompletedTask;
        }
        #endregion
    }
}
