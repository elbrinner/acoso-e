using Bully.ViewModels.Base;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bully.ViewModels.Violencia
{
    public class ViolenciaGeneroViewModel : ViewModelBase
    {
        public ViolenciaGeneroViewModel()
        {
            Analytics.TrackEvent("Información de contacto sobre violencia de genero");
        }

        private ICommand callCommand;
        public ICommand CallCommand
        {
            get { return callCommand = callCommand ?? new DelegateCommand(DoCallCommandExecute); }
        }
        private void DoCallCommandExecute()
        {
            try
            {
                Analytics.TrackEvent("LLamada al 016 - Violencia de genero");
                Device.OpenUri(new Uri("tel:016"));
            }
            catch (Exception ex)
            {
                Analytics.TrackEvent("Error al llamar el teléfono 016 -"+ ex.Message );
                App.Current.MainPage.DisplayAlert("El teléfono es: 016", "No se puede realizar la llamada directamente desde tu dispositivo. El número que tienes que llamar es el 016", "Aceptar");
            }
        }


    }
}
