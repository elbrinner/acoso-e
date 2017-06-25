using Bully.Interfaces.Facade;
using Bully.Interfaces.Navigation;
using Bully.Services.Facade;
using Bully.Services.Menu;
using Bully.Services.Navigation;
using Bully.ViewModels.About;
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
using Microsoft.Practices.Unity;
using System;

namespace Bully.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _unityContainer;
        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            // ViewModels
            _unityContainer.RegisterType<MainViewModel>();
            _unityContainer.RegisterType<ContactViewModel>();
            _unityContainer.RegisterType<BotViewModel>();
            _unityContainer.RegisterType<LinksViewModel>();
            _unityContainer.RegisterType<NewsViewModel>();
            _unityContainer.RegisterType<ProtocolViewModel>();
            _unityContainer.RegisterType<IndexViewModel>();
            _unityContainer.RegisterType<GenericPdfViewModel>();
			_unityContainer.RegisterType<WebViewModel>();
            _unityContainer.RegisterType<CiberacosoViewModel>();

            _unityContainer.RegisterType<InstagramViewModel>();
            _unityContainer.RegisterType<TwitterViewModel>();
            _unityContainer.RegisterType<InstagramViewModel>();
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<ViolenciaGeneroViewModel>();
            _unityContainer.RegisterType<MovieViewModel>();
            _unityContainer.RegisterType<AboutViewModel>();


            // Services
            _unityContainer.RegisterType<INavigationService, NavigationService>();
            _unityContainer.RegisterType<IMenuService, MenuService>();
            
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}