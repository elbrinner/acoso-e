using Bully.ViewModels.Base;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.ViewModels.About
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel()
        {
            Analytics.TrackEvent("Información sobre la app");
            this.Title = "Acerca de Acceso directo";
        }
    }
}
