using System.Threading.Tasks;
using TrackerEmulator.Helpers.Extension;
using Xamarin.Forms;

namespace TrackerEmulator.Helpers.TriggerActions
{
    public class HighlightButtonAction : TriggerAction<Button>
    {
        protected override async void Invoke(Button button)
        {
            button.BackgroundColor = new Color().Primary();
            button.TextColor = new Color().DarkTextColor();
            await Task.Delay(100);
            button.TextColor = new Color().LightTextColor();
            button.BackgroundColor = new Color().DarkBackgroundColor();
        }
    }
}
