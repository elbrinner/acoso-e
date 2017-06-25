using Bully.Helpers;
using Bully.Services.Facade;
using Bully.ViewModels.Base;
using Bully.ViewModels.Main;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bully.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
     
        AzureService azureService;

        private ICommand loginCommand;
        private ICommand mainCommand;

        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () => await DoLoginCommandExecute()));


		public ICommand MainCommand => mainCommand ?? (mainCommand = new Command(async () => await DoMainCommandExecute()));

        private async Task DoMainCommandExecute()
        {
			await this.NavigationService.RemoveLastFromBackStackAsync();
			await NavigationService.NavigateToAsync<MainViewModel>();
        }

        private async Task DoLoginCommandExecute()
        {
            try
            {
               if (await LoginAsync()) //IsBusy !! !(await LoginAsync()))
                {
                    //quitar navegaction de la pila antes
                    await this.NavigationService.RemoveLastFromBackStackAsync();
                    await NavigationService.NavigateToAsync<MainViewModel>();

                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                
            }
          

        }

       

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
            {
                return Task.FromResult(true);
            }

            return azureService.LoginAsync();
        }

        public LoginViewModel(){

            azureService = DependencyService.Get<AzureService>();
			this.Title = "Bienvenido";
            Analytics.TrackEvent("Página login social");
            this.LoginAuto();
        }

        private async void LoginAuto()
        {
            if (!string.IsNullOrWhiteSpace(Settings.UserId))
            {
               await  this.DoLoginCommandExecute();
            }
        }
    }
}
