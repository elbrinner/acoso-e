using Bully.Models.Generic;
using Bully.ViewModels.Base;
using Bully.ViewModels.Generic;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bully.ViewModels.Ciberacoso
{
    public class InstagramViewModel : ViewModelBase
    {

        public InstagramViewModel()
        {
            Analytics.TrackEvent("Página principal de como denunciar el ciberbully en el Instagram");
        }

        private ICommand callCommand;


        public ICommand CallCommand
        {
            get { return callCommand = callCommand ?? new DelegateCommand(DoCallCommandExecute); }
        }

        private void DoCallCommandExecute()
        {
            Analytics.TrackEvent("Botón denunciar en instagram");
            NavigationService.NavigateToAsync<WebViewModel>(new LinkWebView()
            {
                Title = "Denunciar en Instagram",
                Url = "https://help.instagram.com/contact/383679321740945"
            });
        }
    }
}
