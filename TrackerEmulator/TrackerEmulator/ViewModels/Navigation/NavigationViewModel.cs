#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 18.08.2019 13:47
#endregion


using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using TrackerEmulator.ViewModels.Pages;

using Xamarin.Forms;


namespace TrackerEmulator.ViewModels.Navigation
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Constants
        public const string MenuTitleDefault = "Tracker Emulator";
        #endregion


        #region Fields
        private static ObservableCollection<NavigationItem> _navigationItems;

        private Page _currentNavigationPage;
        private NavigationItem _selectedNavigationItem;
        private bool _isRefreshing;
        private string _menuTitle;
        #endregion


        #region Constructors
        static NavigationViewModel()
        {
            NavigationItem.ItemSelectedColor = new Color().Primary();
            NavigationItem.ItemNonSelectedColor = new Color().WhiteBackgroundColor();

            NavigationItem.ItemNonSelectedTextColor = new Color().DarkTextColor();
            NavigationItem.ItemSelectedTextColor = new Color().LightTextColor();
        }


        public NavigationViewModel(Page navPage)
        {
            #region Initialize Fields
            MenuTitle = MenuTitleDefault;

            CurrentNavigationPage = navPage;
            CurrentNavigationPage.BindingContext = this;
            NavigationItems = new ObservableCollection<NavigationItem>();

            foreach (var page in App.Pages)
            {
                NavigationItems.Add(new NavigationItem(page));
            }

            SelectedNavigationItem = NavigationItems.First();
            #endregion


            InitializeEventHandlers();


            /* Notifications trying
            CurrentNavigationPage.FindByName<ListView>("NavigationListView").ItemSelected += (_, e) =>
            {
                var request = new NotificationRequest
                {
                    NotificationId = 1,
                    Title = "Tracker Emulator",
                    Description = ((NavigationItem)e.SelectedItem).Title,
                    BadgeNumber = 1,
                    Android = new AndroidOptions
                    {
                        //Color = Convert.ToInt32(new Color(3, 2, 4, 1).ToString()),
                        IconName = "my_icon",
                        Priority = NotificationPriority.High
                    }
                };

                NotificationCenter.Current.Show(request);
            };
            */
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
                if (value == null)
                    return;

                _selectedNavigationItem = value;
                _selectedNavigationItem.ContentPageViewModel.PushPage();
                RefreshMenu();
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


        #region Commands
        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = true;

            await RefreshMenu();

            IsRefreshing = false;
        });
            
        
        #endregion
        #endregion


        #region Methods
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task RefreshMenu()
        {
            foreach (var item in NavigationItems)
                item.IsActive = false;

            SelectedNavigationItem.IsActive = true;

            return Task.CompletedTask;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async void InitializeEventHandlers()
        {
            App.Pages.CollectionChanged += (_, e) =>
            {
                foreach (var page in e.NewItems)
                {
                    NavigationItems.Add(new NavigationItem(page as BasePageViewModel));
                }
            };

            await Task.CompletedTask;
        }
        #endregion
    }
}