using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using Bully.ViewModels.Generic;
using Bully.Models;
using System.Collections.ObjectModel;
using Plugin.Share.Abstractions;
using Plugin.Share;
using Syncfusion.SfPdfViewer.XForms;

namespace Bully.Views.Generic
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenericPdfView : ContentPage
    {
        public GenericPdfView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //Stream fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Bully.Document.teste.pdf");

            //pdfViewerControl.LoadDocument(fileStream);
            //pageCountLabel.Text = pdfViewerControl.PageCount.ToString();
            //pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            base.OnAppearing();
            MessagingCenter.Subscribe<GenericPdfViewModel, ItemGeneric>(this, "LoadPdf", (sender, arg) =>
            {
                LoadPdf(arg);
            });

        }

        private void LoadPdf(ItemGeneric item)
        {
            try
            {
             var vm = BindingContext as GenericPdfViewModel;

                        if (vm != null)
                        {
                            if(pdfViewerControl.PageCount !=0)
                            {
                                 pdfViewerControl = new SfPdfViewer();
                            }
                            pdfViewerControl.LoadDocument(vm.FileStream);
                            this.Title = vm.Title;
                            //vm.FileStream = null;

                        }
            }
            catch (Exception ex)
            {
                
            }
           
        }

        //https://components.xamarin.com/gettingstarted/syncfusionessentialstudio#PDFViewer
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<ItemGeneric,ItemGeneric>(this, "LoadPdf");
            
        }



    }
}
