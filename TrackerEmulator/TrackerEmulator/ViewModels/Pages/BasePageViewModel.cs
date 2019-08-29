using System.Windows.Input;
using TrackerEmulator.Controls;
using Xamarin.Forms;

namespace TrackerEmulator.ViewModels.Pages
{
    public abstract class BasePageViewModel : BaseViewModel
    {
        #region Fields
        private string _title;
        #endregion

        #region Constructors
        protected BasePageViewModel(Page page)
        {
            PageView = page;
            PageView.BindingContext = this;

            PropertyChanged += (s, e) =>
            {
                if (s.Equals(this) && e.PropertyName == nameof(Title)) PageView.Title = Title;
            };
        }
        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public Page PageView { get; }

        public ICommand PageNavigationCommand
        {
            get
            {
                return new Command(async value =>
                {
                    if (!(Application.Current.MainPage is MyMasterDetailPage mdp)) return;

                    if (!(mdp.Detail is NavigationPage navPage)) return;

                    mdp.IsPresented = false;

                    await navPage.PopToRootAsync(false);
                    await navPage.PushAsync(PageView);
                });
            }
        }
        #endregion
    }
}
