using Bully.Interfaces.Facade;
using Bully.Models;
using Bully.Models.Generic;
using Bully.Models.Rss;
using Bully.Services.Facade;
using Bully.ViewModels.Base;
using Bully.ViewModels.Generic;
using Microsoft.Azure.Mobile.Analytics;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.ViewModels.News
{
    public class NewsViewModel : ViewModelBase
    {

        private List<RssItem> listLink;
        private RssItem selectedLink;
        protected NewsFacade newsFacade;

        public List<RssItem> ListLink
        {
            get { return this.listLink; }
            set
            {
                this.listLink = value;
                RaisePropertyChanged();

            }
        }

        private async Task DoSelectedLink(RssItem item)
        {
            Analytics.TrackEvent("Lectura de noticia sobre acoso escolar: " +item.Title);
            await NavigationService.NavigateToAsync<WebViewModel>(new LinkWebView() { Title = item.Title, Url = item.Link });
        }

        public RssItem SelectedLink
        {
            get { return this.selectedLink; }
            set
            {
                this.selectedLink = value;
                RaisePropertyChanged();
                this.DoSelectedLink(value);

            }
        }



        private async void FillListLink()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
            
                await App.Current.MainPage.DisplayAlert("Error", "Sin internet, no se puede conectar al servidor","Aceptar");

                return;
            }
            
            this.IsBusy = true;
            var response = await this.newsFacade.NewsAsync();
            this.IsBusy = false;
            if (response == null)
            {

            }
            this.ListLink = response;
        }




        private List<RssItem> rss;


        private List<RssItem> Rss
        {
            get { return this.rss; }
            set
            {
                this.rss = value;
                RaisePropertyChanged();
            }
        }

        public NewsViewModel()
        {
            this.newsFacade = new NewsFacade();
            this.FillListLink();
            this.Title = "Últimas noticias";
            Analytics.TrackEvent("Listado de noticias sobre acoso escolar");
        }




    }
}
