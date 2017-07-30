using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bully.Views.Violencia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViolenciaGeneroView : ContentPage
    {
        public ViolenciaGeneroView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            InitializeComponent();
        }
    }
}