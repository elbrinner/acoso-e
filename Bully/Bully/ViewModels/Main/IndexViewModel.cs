using Bully.ViewModels.Base;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bully.ViewModels.Main
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel()
        {
            this.Title = "Index pagina";
            Analytics.TrackEvent("Página inicial de la app");
        }

        private ICommand callCommand;
        private ICommand callSkypeCommand;
        private ICommand emailCommand;


        public ICommand EmailCommand
        {
            get { return emailCommand = emailCommand ?? new DelegateCommand(DoEmailCommandExecute); }
        }
        public ICommand CallCommand
        {
            get { return callCommand = callCommand ?? new DelegateCommand(DoCallCommandExecute); }
        }

        public ICommand CallSkypeCommand
        {
            get { return callSkypeCommand = callSkypeCommand ?? new DelegateCommand(DoCallSkypeCommandExecute); }
        }

        private void DoCallSkypeCommandExecute()
        {
            try
            {
                Device.OpenUri(new Uri("skype:600909073"));
            }
            catch (Exception ex)
            {
                Analytics.TrackEvent("Error al llamar por skype" + ex.Message);
                App.Current.MainPage.DisplayAlert("El telefono es: 678644768", "No se puede realizar la llamada directamente desde tu dispositivo. El número que tienes que llamar es el 900 9000 9000", null);
            }
        }

        private void DoEmailCommandExecute()
        {
            try
            {
                Analytics.TrackEvent("Enviar un email a acoso escolar");
                Device.OpenUri(new Uri("mailto:convivencia.escolar@mecd.es?subject=Denunciar acoso escolar&body=via app acceso directo"));
            }
            catch (Exception ex)
            {
                Analytics.TrackEvent("Error al enviar email  a convivencia.escolar@mecd.es" + ex.Message);
                App.Current.MainPage.DisplayAlert("Error", "Envíe el email directamente a convivencia.escolar@mecd.es", null);

            }
        }
        private void DoCallCommandExecute()
        {
            try
            {
                Analytics.TrackEvent("LLamada al servicio de acoso escolar: 900018018");
                Device.OpenUri(new Uri("tel:900018018"));
            }
            catch (Exception ex)
            {
                Analytics.TrackEvent("Error al llamar a 900 018 018" + ex.Message);
                App.Current.MainPage.DisplayAlert("El teléfono es: 900 018 018", "No se puede realizar la llamada directamente desde tu dispositivo. El número que tienes que llamar es el 900 018 018", "Aceptar");
            }
        }

      
    }


}
