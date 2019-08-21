#region HEADER
//    TrackerClientEmulator.TrackerClientEmulator
//    Created by Nikita Neverov at 20.08.2019 14:27
#endregion

using System;
using Xamarin.Forms;

namespace TrackerClientEmulator.Models
{
    public class MyMasterDetailPage : MasterDetailPage
    {
        private DateTime _lastTime;

        protected override bool OnBackButtonPressed()
        {
            try
            {
                var time = DateTime.Now;
                var timeDiff = time - _lastTime;


                if (_lastTime.Millisecond != 0 && timeDiff.Milliseconds <= 300 && timeDiff.Milliseconds >= 50)
                {
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
                else
                {
                    _lastTime = time;

                    if (!IsPresented)
                        IsPresented = true;
                    else
                        base.OnBackButtonPressed();
                }

                return true;
            }
            catch (Exception)
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}
