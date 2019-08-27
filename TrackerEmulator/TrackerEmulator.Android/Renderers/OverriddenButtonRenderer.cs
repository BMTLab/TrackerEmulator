using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using TrackerEmulator.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Button), typeof(OverriddenButtonRenderer))]

namespace TrackerEmulator.Droid.Renderers
{
    public class OverriddenButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public OverriddenButtonRenderer(Context context) : base(context) { }

        //protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        //{
        //    base.OnElementChanged(e);

        //    if (Control == null)
        //        return;
        //}

        protected override AppCompatButton CreateNativeControl()
        {
            var context = new ContextThemeWrapper(Context, Resource.Style.Widget_AppCompat_Button_Borderless);
            var button  = new AppCompatButton(context, null, Resource.Style.Widget_AppCompat_Button_Borderless);

            button.Click += async (_, e) =>
            {
                var oldvalue = button.Background;
                button.Background = (Drawable) Application.Current.Resources["Primary"];
                await Task.Delay(1000);
                button.Background = oldvalue;
            };

            return button;
        }
    }
}
