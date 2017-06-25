using Bully.Helper;
using Bully.Interfaces.Navigation;
using Bully.ViewModels.About;
using Bully.ViewModels.Base;
using Bully.ViewModels.Bot;
using Bully.ViewModels.Ciberacoso;
using Bully.ViewModels.Contact;
using Bully.ViewModels.Generic;
using Bully.ViewModels.Links;
using Bully.ViewModels.Login;
using Bully.ViewModels.Main;
using Bully.ViewModels.Movie;
using Bully.ViewModels.News;
using Bully.ViewModels.Protocol;
using Bully.ViewModels.Violencia;
using Bully.Views.About;
using Bully.Views.Base;
using Bully.Views.Bot;
using Bully.Views.Ciberacoso;
using Bully.Views.Contact;
using Bully.Views.Generic;
using Bully.Views.Links;
using Bully.Views.Login;
using Bully.Views.Main;
using Bully.Views.Movie;
using Bully.Views.News;
using Bully.Views.Protocol;
using Bully.Views.Violencia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bully.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(ContactViewModel), typeof(ContactView)},
            { typeof(BotViewModel), typeof(BotView)},
            { typeof(LinksViewModel), typeof(LinksView)},
            { typeof(NewsViewModel), typeof(NewsView)},
            { typeof(IndexViewModel), typeof(IndexView)},
            { typeof(ProtocolViewModel), typeof(ProtocolView)},
            { typeof(GenericPdfViewModel), typeof(GenericPdfView)},
            { typeof(CiberacosoViewModel), typeof(CiberacosoView)},
            { typeof(InstagramViewModel), typeof(InstagramView)},
            { typeof(TwitterViewModel), typeof(TwitterView)},
            { typeof(FacebookViewModel), typeof(FacebookView)},
            { typeof(LoginViewModel), typeof(LoginView)},
            { typeof(ViolenciaGeneroViewModel), typeof(ViolenciaGeneroView)},
            { typeof(WebViewModel), typeof(Views.Generic.WebView)},
            { typeof(MovieViewModel), typeof(MovieView)},
            { typeof(AboutViewModel), typeof(AboutView)}
            



    };


        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        //Inicio de la aplicación APP.cs
        public Task InitializeAsync()
        {
            return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        protected virtual async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            

            if (page is MainView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;
                var navigationPage = mainPage.Detail as CustomNavigationPage;
               

                if (navigationPage != null)
                {

                    await navigationPage.PushAsync(page);
                }
                else
                {
                   
                    navigationPage = new CustomNavigationPage(page);
                    
                    mainPage.Detail = navigationPage;
                }

                if (Device.Idiom == TargetIdiom.Tablet && DeviceInfo.IsOrientationPortrait() == false || Device.Idiom == TargetIdiom.Desktop)
                {
                    mainPage.IsPresented = true;


                }
                else
                {
                    mainPage.IsPresented = false;

                }
               
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }
            }
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            page.Appearing += async (object sender, EventArgs e) =>
            {
                await viewModel.InitializeAsync(parameter);
            };

            return page;
        }
        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(ContactViewModel), typeof(ContactView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(BotViewModel), typeof(BotView));
            _mappings.Add(typeof(LinksViewModel), typeof(LinksView));
            _mappings.Add(typeof(NewsViewModel), typeof(NewsView));
            _mappings.Add(typeof(ProtocolViewModel), typeof(ProtocolView));
            _mappings.Add(typeof(IndexViewModel), typeof(IndexView));
            _mappings.Add(typeof(GenericPdfViewModel), typeof(GenericPdfView));
            _mappings.Add(typeof(WebViewModel), typeof(Views.Generic.WebView));
            _mappings.Add(typeof(CiberacosoViewModel), typeof(CiberacosoView));
            _mappings.Add(typeof(InstagramViewModel), typeof(InstagramView));
            _mappings.Add(typeof(TwitterViewModel), typeof(TwitterView));
            _mappings.Add(typeof(FacebookViewModel), typeof(FacebookView));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(ViolenciaGeneroViewModel), typeof(ViolenciaGeneroView));
            _mappings.Add(typeof(MovieViewModel), typeof(MovieView));
            _mappings.Add(typeof(AboutViewModel), typeof(AboutView));



        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public void RemovePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            CurrentApplication.MainPage.Navigation.RemovePage(page);

        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as MainView;

            if (mainPage != null)
            {
                mainPage.Detail.Navigation.RemovePage(
                     mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 1]);
            }

            return Task.FromResult(true);
        }

        /*
        public void RemovePage(TViewModel viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            CurrentApplication.MainPage.Navigation.RemovePage(page);
        }
        */

    }
}
