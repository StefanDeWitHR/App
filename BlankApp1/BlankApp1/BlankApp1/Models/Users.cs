using System;
using System.Collections.Generic;

using System.Text;
using Prism.Mvvm;


namespace Core.Models
{
    public class Users : BindableBase
    {

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                SetProperty(ref _Gender, value);
            }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { 
                SetProperty(ref _FirstName, value);
               
            }
        }
        private string _SecondName;
        public string SecondName
        {
            get { return _SecondName; }
            set
            {
                SetProperty(ref _SecondName, value);
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {

                SetProperty(ref _LastName, value);
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {

                SetProperty(ref _Email, value);
            }
        }

        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {

                SetProperty(ref _CompanyName, value);
            }
        }
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {

                SetProperty(ref _PhoneNumber, value);
            }
        }
    }
}
