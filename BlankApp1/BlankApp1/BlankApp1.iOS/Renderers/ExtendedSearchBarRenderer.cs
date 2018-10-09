using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(SearchBar), typeof(App.iOS.Renderers.ExtendedSearchBarRenderer))]

namespace App.iOS.Renderers
{
    // This custom render is to remove the cancel button of the component SearchBar
    // Issue = Cancel button crash on IOS
    public class ExtendedSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Text")
            {
                Control.ShowsCancelButton = false;
            }
        }
    }
}
