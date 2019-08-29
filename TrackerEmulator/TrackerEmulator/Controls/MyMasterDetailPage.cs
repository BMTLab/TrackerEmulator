#region HEADER
//    TrackerEmulator.TrackerEmulator
//    Created by Nikita Neverov at 20.08.2019 14:27
#endregion

using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace TrackerEmulator.Controls
{
    public class MyMasterDetailPage : MasterDetailPage
    {
        #region Fields
        private DateTime _lastTime;
        #endregion


        #region Methods
        protected override bool OnBackButtonPressed()
        {
            try
            {
                var time = DateTime.Now;
                var timeDiff = time - _lastTime;


                if (_lastTime.Millisecond != 0 && timeDiff.Milliseconds <= 300 && timeDiff.Milliseconds >= 50)
                {
                    Process.GetCurrentProcess().CloseMainWindow();
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
        #endregion
    }
}
