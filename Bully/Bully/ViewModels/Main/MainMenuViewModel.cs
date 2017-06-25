using Bully.Models;
using Bully.Services.Menu;
using Bully.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using Microsoft.Azure.Mobile.Analytics;

namespace Bully.ViewModels.Main
{
    public class MainMenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _menu;
        private MenuItem _selectedMenu;

        private ICommand indexCommand;


        public ICommand IndexCommand
        {
            get { return indexCommand = indexCommand ?? new DelegateCommand(DoIndexCommandExecute); }
        }

        private  async void DoIndexCommandExecute()
        {
            await this.NavigationService.NavigateToAsync<IndexViewModel>();
        }

        private IMenuService _menuService;

        public MainMenuViewModel(
            IMenuService menuService)
        {
            _menuService = menuService;
            this.Title = "Menu viewmodel";
            Analytics.TrackEvent("Menú principal de la app");
        }

        public ObservableCollection<MenuItem> Menu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                this.RaisePropertyChanged("Menu");
            }
        }

        public MenuItem SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;

                if (_selectedMenu.PageType != null)
                    NavigationService.NavigateToAsync(_selectedMenu.PageType);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            Menu = _menuService.LoadMenu();

            return base.InitializeAsync(navigationData);
        }
    }
}