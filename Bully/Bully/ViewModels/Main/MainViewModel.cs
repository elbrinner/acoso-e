using Bully.ViewModels.Base;
using Bully.ViewModels.Contact;
using System.Threading.Tasks;

namespace Bully.ViewModels.Main
{
    public class MainViewModel : ViewModelBase
    {
        private MainMenuViewModel _menuViewModel;

        public MainViewModel(MainMenuViewModel menuViewModel)
        {
            _menuViewModel = menuViewModel;
            this.Title = "Menu 1";
        }

        public MainMenuViewModel MenuViewModel
        {
            get
            {
                return _menuViewModel;
            }

            set
            {
                _menuViewModel = value;
                RaisePropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    _menuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<IndexViewModel>()
                );
        }
    }
}