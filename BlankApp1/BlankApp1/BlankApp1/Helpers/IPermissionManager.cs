using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.Helpers
{
    public interface IPermissionManager
    {
        void ShareItemAsync(string subject, string title, ImageSource image);
    }
}
