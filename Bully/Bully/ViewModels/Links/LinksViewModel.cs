using Bully.Models;
using Bully.Models.Generic;
using Bully.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bully.ViewModels.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;
using Bully.Constants;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Connectivity;

namespace Bully.ViewModels.Links
{
    public class LinksViewModel: ViewModelBase
    {

        private List<ItemGeneric> listLink;
        private ItemGeneric selectedLink;

        public List<ItemGeneric> ListLink
        {
            get { return this.listLink; }
            set
            {
                this.listLink = value;
                RaisePropertyChanged();

            }
        }

        private async Task DoSelectedLink(ItemGeneric item)
        {
            Analytics.TrackEvent("Acceso al link sobre acoso escolar - ONG " + item.Title);
            await  NavigationService.NavigateToAsync<WebViewModel>(new LinkWebView(){  Title = item.Title , Url = item.UrlShare});
        }

        public ItemGeneric SelectedLink
        {
            get { return this.selectedLink; }
            set
            {
                this.selectedLink = value;
                RaisePropertyChanged();
                this.DoSelectedLink(value);

            }
        }

        public LinksViewModel()
        {
            this.FillListLinkAsync();
            this.Title = "Asociaciones";
            Analytics.TrackEvent("Listado de Links sobre asociaciones sobre el acoso escolar");
        }

        private async Task FillListLinkAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Sin internet, no se puede conectar al servidor", "Aceptar");
                return;
            }
            var client = new MobileServiceClient(GlobalSettings.AzureUrl);
            this.IsBusy = true;
            this.ListLink = await client.GetTable<ItemGeneric>().ToListAsync();
            this.IsBusy = false;
        }

    }
}
