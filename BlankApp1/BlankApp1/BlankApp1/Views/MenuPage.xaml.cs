using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MenuPage()
        {
            InitializeComponent();
          
        }

        public bool IsPresentedAfterNavigation
        {
            get { return false; }
        }
    }

}