using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bully.Views.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bully.Views.Main
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            InitializeComponent();
        }

    }

}
