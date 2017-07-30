using Bully.Models;
using Bully.Services.Menu;
using Bully.ViewModels;
using Bully.ViewModels.About;
using Bully.ViewModels.Bot;
using Bully.ViewModels.Ciberacoso;
using Bully.ViewModels.Contact;
using Bully.ViewModels.Links;
using Bully.ViewModels.Main;
using Bully.ViewModels.Movie;
using Bully.ViewModels.News;
using Bully.ViewModels.Protocol;
using Bully.ViewModels.Violencia;
using System.Collections.ObjectModel;

namespace Bully.Services.Menu
{
    public class MenuService : IMenuService
	{
		public ObservableCollection<MenuItem> LoadMenu()
		{
            return new ObservableCollection<MenuItem> {
               // new MenuItem("Main", typeof(MainViewModel)),
                new MenuItem("Contacto", typeof(ContactViewModel)),
                //new MenuItem("Bot ayuda", typeof(BotViewModel)), //ok
                new MenuItem("Enlaces", typeof(LinksViewModel)),
                new MenuItem("Noticias", typeof(NewsViewModel)),
                new MenuItem("Ciberacoso", typeof(CiberacosoViewModel)),
                new MenuItem("Películas/Series", typeof(MovieViewModel)),                
                new MenuItem("Protocolos", typeof(ProtocolViewModel)),
                new MenuItem("Violencia de Género", typeof(ViolenciaGeneroViewModel)) ,
                new MenuItem("Acerca de Acceso directo", typeof(AboutViewModel))
        };
		}
	}
}