using Xamarin.Forms;

namespace TrackerEmulator.Helpers
{
    public class HighlightFrameAction : TriggerAction<Frame>
    {
        protected override void Invoke(Frame frame)
        {
            frame.HasShadow = true;
        }
    }
}
