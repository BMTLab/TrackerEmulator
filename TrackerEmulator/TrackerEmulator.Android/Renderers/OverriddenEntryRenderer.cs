using Android.Content;
using Android.Views;
using TrackerEmulator.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(OverriddenEntryRenderer))]

namespace TrackerEmulator.Droid.Renderers
{
    public class OverriddenEntryRenderer : EntryRenderer
    {
        public OverriddenEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

        }
    }
}
