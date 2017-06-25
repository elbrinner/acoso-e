using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bully.Views.Ciberacoso
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstagramView : ContentPage
    {
        public InstagramView()
        {
            InitializeComponent();
            outerScrollView.Scrolled += OnScroll;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            outerScrollView.Scrolled -= OnScroll;
        }

        public void OnScroll(object sender, ScrolledEventArgs e)
        {
            var imageHeight = header.Height * 1.5;
            var scrollRegion = header.Height - outerScrollView.Height;
            var parallexRegion = imageHeight - outerScrollView.Height;
            var factor = outerScrollView.ScrollY - parallexRegion * (outerScrollView.ScrollY / scrollRegion);
            header.TranslationY = factor;
            header.Opacity = 1 - (factor / imageHeight);
            // headers.Scale = 1 - ((factor) / (imageHeight * 2)); 
        }
    }
}
