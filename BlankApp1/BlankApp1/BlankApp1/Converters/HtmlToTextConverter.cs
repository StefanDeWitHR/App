using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Core.Converters
{
    public class HtmlToTextConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
            string convertedValue = value as string;
            string regex = Regex.Replace(convertedValue, "<.*?>", string.Empty); // REMOVE HTML tags
            string LdecodedHTML = System.Web.HttpUtility.HtmlDecode(regex); // UNICODE WEB
            return LdecodedHTML;
       }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
