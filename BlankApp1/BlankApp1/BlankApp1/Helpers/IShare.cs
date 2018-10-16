using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.Helpers
{
    public interface IShare
    {
       void Share(string subject, string message, ImageSource image);
    
    }
}
