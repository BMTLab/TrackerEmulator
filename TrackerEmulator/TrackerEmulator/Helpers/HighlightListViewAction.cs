using System.Threading.Tasks;
using TrackerEmulator.Entites;
using TrackerEmulator.Helpers.Extension;
using Xamarin.Forms;

namespace TrackerEmulator.Helpers
{
    public class HighlightListViewAction : TriggerAction<ListView>
    {
        protected override async void Invoke(ListView listView)
        {
            var selectedItem = listView.SelectedItem;
            ((ImeiItem) selectedItem).BackgroundColor = new Color().Primary();
            await Task.CompletedTask;
        }
    }
}
