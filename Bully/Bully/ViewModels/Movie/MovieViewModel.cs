using Bully.Models;
using Bully.Models.Generic;
using Bully.ViewModels.Base;
using Bully.ViewModels.Generic;
using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.ViewModels.Movie
{
    public class MovieViewModel : ViewModelBase
    {
        public MovieViewModel()
        {
            Analytics.TrackEvent("Listado de peliculas y series");
            this.FillMovie();
            this.Title = "Películas y series";
        }

        private List<ItemGeneric> listMovie;
        private ItemGeneric selectedMovie;

        public List<ItemGeneric> ListMovie
        {
            get { return this.listMovie; }
            set
            {
                this.listMovie = value;
                RaisePropertyChanged();

            }
        }

        private async Task DoSelectedLink(ItemGeneric item)
        {
            Analytics.TrackEvent("Acceso al link de la pelicula" + item.Title);
            await NavigationService.NavigateToAsync<WebViewModel>(new LinkWebView() { Title = item.Title, Url = item.UrlShare });
        }

        public ItemGeneric SelectedMovie
        {
            get { return this.selectedMovie; }
            set
            {
                this.selectedMovie = value;
                RaisePropertyChanged();
                this.DoSelectedLink(value);

            }
        }

        private void FillMovie()
        {
            var tempList = new List<ItemGeneric>();
            tempList.Add(new ItemGeneric()
            {
                Title = "Por trece razones (2017)",
                Description = "Tras el sorprendente suicidio de una joven, un compañero de clase recibe varias cintas que desvelan el misterio de su trágica decisión.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt1837492/?ref_=nv_sr_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BYTFmNzRlNWYtMmFmNi00ZTFiLWJhODgtOGM5ODQ5NTgxZWUwL2ltYWdlXkEyXkFqcGdeQXVyMTExNDQ2MTI@._V1_SY1000_CR0,0,674,1000_AL_.jpg"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "Cyberbully (2011)",
                Description = "Taylor Hillridge, una adolescente de 17 años que cae víctima del acoso cibernético.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt1930315/?ref_=ttmi_tt",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTc5NDQzOTc2N15BMl5BanBnXkFtZTcwNDI5MzI4Nw@@._V1_.jpg"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "Carrie (2013)",
                Description = "Es un refrito del la pelicula de 1976 pero en un intento por reflejar las nuevas formas de acoso, la nueva adaptación de Carrie también recurrirá al bullying cibernético.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt1939659/",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BODg2MDU2MjYxNl5BMl5BanBnXkFtZTcwMDQ5MzU0OQ@@._V1_.jpg"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "Precious (2009)",
                Description = "Narra la vida de Claireece 'Precious' Jones, una adolescente obesa y analfabeta, víctima de diversos abusos.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt0929632/?ref_=nv_sr_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk3NDM4ODMwNl5BMl5BanBnXkFtZTcwMTYyNDIzMw@@._V1_SY1000_CR0,0,665,1000_AL_.jpg"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "Depois de Lúcia (2012)",
                Description = "Tras la muerte de su esposa Lucía, Roberto y su hija Alejandra deciden salir de Puerto Vallarta y mudarse a la Ciudad de México, con la intención de olvidarse de la tragedia y comenzar de nuevo.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt2368749/?ref_=fn_al_tt_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQwMTgxNDEwOV5BMl5BanBnXkFtZTcwMDg2NDk3OA@@._V1_SY1000_CR0,0,666,1000_AL_.jpg"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Bullying (2011)",
                Description = "Tras años de ser víctima del bullying, el director Lee Hirsch decidió realizar un fuerte documental en donde explora la vida de varios jóvenes que han vivido en carne propia estos acosos, así como las dolorosas consecuencias de estos maltratos.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt1682181/?ref_=nv_sr_2",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BNjk1MjYzNzUxOF5BMl5BanBnXkFtZTcwOTQyODU2Nw@@._V1_SY1000_CR0,0,674,1000_AL_.jpg"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "American Yearbook (2004)",
                Description = "Will Nash es un joven americano ordinario, cuyos sueños y aspiraciones pasan a segundo término cuando comienza a ser acosado por un par de jóvenes en su escuela. ",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt0386284/?ref_=fn_al_tt_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjAzMDczNDYxNl5BMl5BanBnXkFtZTcwMDMzNjQyMQ@@._V1_.jpg"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "All About Lily Chou-Chou",
                Description = "Shuusuke Hoshino y Yuichi Hasumi son dos amigos que han estado juntos desde la educación básica, sin embargo Hoshino es uno de los mejores estudiantes y por tal razón es continuamente atacado por sus compañeros.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt0297721/?ref_=fn_al_tt_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ0NjEyMzkwNl5BMl5BanBnXkFtZTcwMTIxODcyMQ@@._V1_.jpg"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Elefante(2003)",
                Description = "Alex y Eric son un par de estudiantes marginados que sufren toda clase de burlas y ataques de los jóvenes más populares de su clase. ",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://www.imdb.com/title/tt0363589/?ref_=fn_al_tt_1",
                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BZWRhNDZkMzQtZDQ3Ny00NjdjLWJmZjAtMWQxNDQyZTYzZjU0XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg"
            });
            
            this.ListMovie = tempList;
        }
    }
}
