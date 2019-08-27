using Android.Content;
using Android.Graphics;
using Android.Views;
using TrackerEmulator.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using PickerRenderer = Xamarin.Forms.Platform.Android.PickerRenderer;

[assembly: ExportRenderer(typeof(Picker), typeof(OverriddenPickerRenderer))]

namespace TrackerEmulator.Droid.Renderers
{
    public class OverriddenPickerRenderer : PickerRenderer
    {
        public OverriddenPickerRenderer(Context context) : base(context) {}

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            Control.Gravity = GravityFlags.CenterHorizontal;
            Control.TextSize = 16;
        }
    }
}
