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
    public class FacebookViewModel : ViewModelBase
    {
        private ICommand callCommand;


        public ICommand CallCommand
        {
            get { return callCommand = callCommand ?? new DelegateCommand(DoCallCommandExecute); }
        }

        private void DoCallCommandExecute()
        {
            Analytics.TrackEvent("Botón denunciar en facebook");
            NavigationService.NavigateToAsync<WebViewModel>(new LinkWebView(){
                Title = "Denunciar en Facebook" ,
                Url = "https://www.facebook.com/help/181495968648557"
            });
        }

        public FacebookViewModel()
        {
            Analytics.TrackEvent("Página principal de como denunciar el ciberbully en el facebook");
        }


    }
}
