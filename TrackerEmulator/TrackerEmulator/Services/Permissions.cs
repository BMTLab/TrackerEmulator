//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 28.08.2019 12:51

using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace TrackerEmulator.Services
{
    public class Permissions
    {
        public static async Task<PermissionStatus> CheckPermissions<TPermission>()
            where TPermission : BasePermission, new()
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<TPermission>();

            if (permissionStatus != PermissionStatus.Denied)
                return PermissionStatus.Granted;

            var title = $"{typeof(TPermission).Name} Permission";
            var question =
                $"To use this plugin the {typeof(TPermission).Name} permission is required. Please go into Settings and turn on {typeof(TPermission).Name} for the app.";
            const string positive = "Settings";
            const string negative = "Maybe Later";
            var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
            if (task == null) return permissionStatus;

            var result = await task;
            if (result)
            {
                CrossPermissions.Current.OpenAppSettings();
            }

            return permissionStatus;
        }
    }
}
