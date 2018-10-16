using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class ContactViewModel
    {
        public DelegateCommand<string> OnPhoneLabelTappedCommand { get; }


        public ContactViewModel()
        {
            OnPhoneLabelTappedCommand= new DelegateCommand<string>(PhoneNumberCall);
        }

        public void PhoneNumberCall(string param)
        {
            try
            {
                Device.OpenUri(new Uri("tel:"+param));

            }
            catch
            {
                throw new System.Exception("Something went wrong");
            }
        }
    }
}
