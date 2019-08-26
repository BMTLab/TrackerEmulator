#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.LocalNotification;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.ViewModels.Pages;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Navigation
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Constants
        public const string MenuTitleDefault = "Menu";
        #endregion


        #region Fields
        private static ObservableCollection<NavigationItem> _navigationItems;
        private Page _currentNavigationPage;
        private NavigationItem _selectedNavigationItem;
        private bool _isRefreshing;
        private string _menuTitle = MenuTitleDefault;
        #endregion


        #region Constructors
        static NavigationViewModel()
        {
            NavigationItem.ItemSelectedColor = new Color().Primary();
            NavigationItem.ItemNonSelectedColor = new Color().DarkBackgroundColor();
            NavigationItem.TextColorDefault = new Color().LightTextColor();
        }

        public NavigationViewModel(Page navPage)
        {
            CurrentNavigationPage = navPage;
            CurrentNavigationPage.BindingContext = this;

            NavigationItems = new ObservableCollection<NavigationItem>();
            NavigationItems.CollectionChanged += (_, e) => OnPropertyChanged(nameof(NavigationItems));

            foreach (var page in App.Pages)
            {
                NavigationItems.Add(new NavigationItem(page));
            }

            App.Pages.CollectionChanged += (_, e) => NavigationItems.AddPages((IEnumerable<BasePageViewModel>)e.NewItems);

            // Notifications trying
            //CurrentNavigationPage.FindByName<ListView>("NavigationListView").ItemSelected += (_, e) =>
            //{
            //    var request = new NotificationRequest
            //    {
            //        NotificationId = 1,
            //        Title = "Tracker Emulator",
            //        Description = ((NavigationItem)e.SelectedItem).Title,
            //        BadgeNumber = 1,
            //        Android = new AndroidOptions
            //        {
            //            //Color = Convert.ToInt32(new Color(3, 2, 4, 1).ToString()),
            //            IconName = "my_icon", Priority = NotificationPriority.High
            //        }
            //    };

            //    NotificationCenter.Current.Show(request);
            //};
            //

            SelectedNavigationItem = NavigationItems.First();
        }
        #endregion


        #region Properties
        public string MenuTitle
        {
            get => _menuTitle;
            set
            {
                _menuTitle = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<NavigationItem> NavigationItems
        {
            get => _navigationItems;
            set
            {
                _navigationItems = value;
                OnPropertyChanged();
            }
        }

        public Page CurrentNavigationPage
        {
            get => _currentNavigationPage;
            set
            {
                _currentNavigationPage = value;
                OnPropertyChanged();
            }
        }

        public NavigationItem SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set
            {
                if (value == null) return;

                _selectedNavigationItem = value;

                RefreshMenu();

                _selectedNavigationItem.Command.Execute(_selectedNavigationItem.CommandParameter);

                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
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
