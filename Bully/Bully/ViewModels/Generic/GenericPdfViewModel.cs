using Bully.Models;
using Bully.ViewModels.Base;
using Bully.Views.Generic;
using Microsoft.Azure.Mobile.Analytics;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bully.ViewModels.Generic
{
    public class GenericPdfViewModel : ViewModelBase
    {
        private ItemGeneric selectedLink;
        private Stream fileStream;

        private ICommand shareCommand;


        public ICommand ShareCommand
        {
            get { return shareCommand = shareCommand ?? new DelegateCommand(ShareButtom); }
        }


        private async void ShareButtom()
        {
            Analytics.TrackEvent("Compartir protocolo " + this.SelectedLink?.Title);
            await CrossShare.Current.Share(new ShareMessage() { Title = "Protocolo contra el acoso escolar de "+ this.SelectedLink.Title,Text =  this.SelectedLink.Description + " vía app Acceso Directo",  Url = this.SelectedLink.UrlShare });
        }
        public Stream FileStream
        {
            get { return this.fileStream; }
            set
            {
                this.fileStream = value;
                RaisePropertyChanged();
            }
        }

        public ItemGeneric SelectedLink
        {
            get { return this.selectedLink; }
            set
            {
                this.selectedLink = value;
                RaisePropertyChanged();
            }
        }
        public GenericPdfViewModel()
        {
            Analytics.TrackEvent("Página principal para leer un pdf");
        }

        
        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
            
                this.SelectedLink = navigationData as ItemGeneric;
                this.FileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Bully.Document." + this.SelectedLink.File);
                Title = SelectedLink.Title;
                MessagingCenter.Send<GenericPdfViewModel, ItemGeneric>(this, "LoadPdf", this.SelectedLink);
                Analytics.TrackEvent("Leer pdf" + SelectedLink.Title);
            }
        }



    }
}
