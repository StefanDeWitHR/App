using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Services;
using Xamarin.Forms;

namespace Core.Helpers
{
    public class PermissionManager : IPermissionManager
    {
        private readonly IPageDialogService _dialogService;

        public PermissionManager(IPageDialogService dialogService)
        {
            _dialogService = dialogService;

        }
        
        public async void ShareItemAsync(string subject , string title , ImageSource image)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                        await _dialogService.DisplayAlertAsync("Toegang nodig", "Toegang nodig om te delen", "OK");

                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Storage))
                        status = results[Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                
                    Xamarin.Forms.DependencyService.Get<IShare>().Share(subject,title,image);
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await _dialogService.DisplayAlertAsync("Toegang gewijgerd", "Probeer opnieuw", "OK");
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
