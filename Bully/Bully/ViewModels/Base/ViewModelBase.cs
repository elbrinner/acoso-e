using Bully.Interfaces.Navigation;
using Bully.Services.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bully.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;
        protected string title;
        protected bool isBusy;

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                this.RaisePropertyChanged("IsBusy");
            }
        }

        public ViewModelBase()
        {
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
           
            return Task.FromResult(false);
        }


        public virtual void OnDisappearing()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}