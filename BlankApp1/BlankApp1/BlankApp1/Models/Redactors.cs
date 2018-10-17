using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace Core.Models
{
    public class Redactors : BindableBase
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                SetProperty(ref _Name, value);
            }
        }
    }
}
