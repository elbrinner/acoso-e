using Bully.ViewModels.Base;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bully.ViewModels.Ciberacoso
{
    public class CiberacosoViewModel : ViewModelBase
    {
        private ICommand callFacebookCommand;
        private ICommand callTwitterCommand;
        private ICommand callInstagramCommand;

        public ICommand CallFacebookCommand
        {
            get { return callFacebookCommand = callFacebookCommand ?? new DelegateCommand(DoCallFacebookCommandExecute); }
        }

        private void DoCallFacebookCommandExecute()
        {
            Analytics.TrackEvent("Botón de información de como denunciar en el facebook");
            NavigationService.NavigateToAsync<FacebookViewModel>();
        }

        public ICommand CallTwitterCommand
        {
            get { return callTwitterCommand = callTwitterCommand ?? new DelegateCommand(DoCallTwitterCommandExecute); }
        }

        private void DoCallTwitterCommandExecute()
        {
            Analytics.TrackEvent("Botón de información de como denunciar en el twitter");
            NavigationService.NavigateToAsync<TwitterViewModel>();
        }

        public ICommand CallInstagramCommand
        {
            get { return callInstagramCommand = callInstagramCommand ?? new DelegateCommand(DoCallInstagramCommandExecute); }
        }

        private void DoCallInstagramCommandExecute()
        {
            Analytics.TrackEvent("Botón de información de como denunciar en el instragram");
            NavigationService.NavigateToAsync<InstagramViewModel>();
        }

        public CiberacosoViewModel()
        {
            Analytics.TrackEvent("Página principal de como denuncuar el ciberbully");
        }
    }
}
