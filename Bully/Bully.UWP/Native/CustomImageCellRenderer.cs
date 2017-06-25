using Bully.UWP.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ImageCell), typeof(CustomImageCellRenderer))]
namespace Bully.UWP.Native
{
    public class CustomImageCellRenderer : ImageCellRenderer
    {
        public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        {
            var fixedTemplate = (Windows.UI.Xaml.DataTemplate)App.Current.Resources["ImageCellFixed"];

            return fixedTemplate;
        }
    }
}
