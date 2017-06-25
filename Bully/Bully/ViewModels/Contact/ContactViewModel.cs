using Bully.ViewModels.Base;
using Bully.ViewModels.Links;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bully.ViewModels.Contact
{
    public class ContactViewModel : ViewModelBase
    {

        public ContactViewModel()
        {
            Analytics.TrackEvent("Información de contacto sobre el acoso escolar");
        }
        private ICommand callCommand;

        public const string url = "https://convivencia.files.wordpress.com/2010/04/conflictos_alumnos.pdf";

        public string Url
        {
            get { return url; }
        }


        public ICommand CallCommand
        {
            get { return callCommand = callCommand ?? new DelegateCommand(DoCallCommandExecute); }
        }

        private void DoCallCommandExecute()
        {
            NavigationService.NavigateToAsync<LinksViewModel>();
        }
    }
}
