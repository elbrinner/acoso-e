using Bully.Models.Generic;
using Bully.ViewModels.Base;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.ViewModels.Generic
{
    public class WebViewModel : ViewModelBase
    {

        private LinkWebView enlace;

        public LinkWebView Enlace
        {
            get { return this.enlace; }
            set
            {
                this.enlace = value;
                //RaisePropertyChanged("Enlace");
                this.RaisePropertyChanged("Enlace");
            }
        }

        public WebViewModel()
        {
            this.Title = "Web externa";
            Analytics.TrackEvent("Página principal webview");
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {

                this.Enlace = navigationData as LinkWebView;
                 Title = this.Enlace.Title;
                Analytics.TrackEvent("Abrir web externa" + this.Enlace.Title + " => url:" + this.Enlace.Url);
            }
        }

    }
}
