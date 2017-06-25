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

namespace Bully.ViewModels.Protocol
{
    public class ProtocolViewModel : ViewModelBase
    {
        private List<ItemGeneric> listLink;
        private ItemGeneric selectedLink;

        public List<ItemGeneric> ListLink
        {
            get { return this.listLink; }
            set
            {
                this.listLink = value;
                RaisePropertyChanged();

            }
        }

        private void DoSelectedLink(ItemGeneric item)
        {
            Analytics.TrackEvent("Lectura del Protocolos de actuación "+ item.Title);
            NavigationService.NavigateToAsync<GenericPdfViewModel>(item);
        }

        public ItemGeneric SelectedLink
        {
            get { return this.selectedLink; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value.File) )
                {
                    this.DoSelectedLink(value);
                }
                this.selectedLink = value;
                RaisePropertyChanged();
               
               
            }
        }


        public ProtocolViewModel()
        {
            this.Title = "Protocolos de actuación";
            this.FillListLink();
            Analytics.TrackEvent("Listado Protocolos de actuación");
        }

        private void FillListLink()
        {
            var tempList = new List<ItemGeneric>();
            tempList.Add(new ItemGeneric() {
                Title = "Andalucía",
                Description = "Protocolos de actuación e intervención ante situaciones de acoso escolar, ciberacoso, maltrato infantil, violencia de género en el ámbito educativo, identidad de género o agresiones hacia el profesorado o personal no docente.",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://agrega.juntadeandalucia.es/repositorio/11102013/dc/es-an_2013101112_9132009/guia/elementos/f_prevencion/protocolo_acoso_escolar.pdf",
                File = "Andalucia.pdf"
            });
            tempList.Add(new ItemGeneric()
            {
                Title = "Aragón",
                Description = "El  presente  documento  va  dirigido  a  los  centros  educativos  públicos  y  privados  concertados  de  la  enseñanza no universitaria de Aragón.",
                Type = TypeElement.LinkWeb,
                File = "Aragon.pdf",
                UrlShare = "https://convivencia.files.wordpress.com/2010/04/conflictos_alumnos.pdf"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Canarias",
                Description = "La cultura de la mediación , jornadas de trabajo sobre convivencia escolar",
                Type = TypeElement.LinkWeb,
                File = "Canarias.pdf",
                UrlShare = "http://www.gobiernodecanarias.org/educacion/dts/pdf/jornada_cultura_mediacion.pdf"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Cantabria",
                Description = "Protocolo de actuación para los centros educativos ante una posible situación de acoso escolar",
                Type = TypeElement.LinkWeb,
                 File = "Cantabria.pdf",
                UrlShare = "http://www.educantabria.es/docs/planes/convivencia/Protocolo_acoso_escolar_sept_2016.pdf"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Castilla-La Mancha",
                Description = "La Consejería de Educación, Cultura y Deportes, por la que se acuerda dar publicidad al protocolo de actuación ante situaciones de acoso escolar en los centros docentes públicos no universitarios de Castilla-La Mancha. ",
                Type = TypeElement.LinkWeb,
                 File = "Castilla.pdf",
                 UrlShare = "http://www.educa.jccm.es/es/maltratoiguales/protocolo-actuacion-situaciones-acoso-escolar.ficheros/20563-RESOLUCION%20PROTOCOLO%20DE%20ACOSO.pdf"
            });

            /*
            tempList.Add(new ItemGeneric()
            {
                Title = "Comunitat Valenciana",
                Description = "",
                Type = TypeElement.LinkWeb,
                File = "",
                UrlShare = "",
            });
            */

            tempList.Add(new ItemGeneric()
            {
                Title = "Generalitat de Catalunya",
                Description = "Protocol de prevenció, detecció i intervenció enfront el ciberassetjament entre iguals",
                Type = TypeElement.LinkWeb,
                UrlShare = "http://xtec.gencat.cat/web/.content/centres/projeducatiu/convivencia/recursos/resconflictes/assetjament_iguals/documents/protocol-ciberassetjament-arxiu-unificat.pdf",
                 File = "Catalunia.pdf"
            });

            /*
            tempList.Add(new ItemGeneric()
            {
                Title = "Galicia",
                Description = "",
                Type = TypeElement.LinkWeb,
            });
            */

            tempList.Add(new ItemGeneric()
            {
                Title = "Comunidad de Madrid",
                Description = "Guía didáctica mejora de la convivencia y prevención del acoso escolar",
                Type = TypeElement.LinkWeb,
                File = "Madrid.pdf",
                UrlShare = "http://www.educa2.madrid.org/web/educamadrid/principal/files/91290b4b-1f66-4e26-9f4a-91bb4f0ccb7a/GUIA DIDÁCTICA PARA SECUNDARIA_2017.pdf?t=1488281684550"
            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Murcia",
                Description = "Protocolos de Apoyo a Víctimas Escolares",
                Type = TypeElement.LinkWeb,
                 File = "Murcia.pdf",
                UrlShare = "https://www.carm.es/web/integra.servlets.Blob?ARCHIVO=Protocolos%20de%20victimas%20definitiva_presentaci%F3n.pdf&TABLA=ARCHIVOS&CAMPOCLAVE=IDARCHIVO&VALORCLAVE=110400&CAMPOIMAGEN=ARCHIVO&IDTIPO=60&RASTRO=c792$m4001,4531,50502",

            });

            tempList.Add(new ItemGeneric()
            {
                Title = "Navarra",
                Description = "Guía ante el caso de posible acoso escolar",
                Type = TypeElement.LinkWeb,
                File = "Navarra.pdf",
                UrlShare = "https://www.educacion.navarra.es/documents/27590/38595/acciones_acoso_escolar.pdf/f2f70688-ca80-4332-9149-b807ee4a78e9",

            });

            tempList.Add(new ItemGeneric()
            {
                Title = "País Vasco",
                Description = "Guía de actuación en los centros educativos ante el maltrato entre iguales",
                Type = TypeElement.LinkWeb,
                File = "Pais_vasco_2.pdf",
                UrlShare = "http://www.hezkuntza.ejgv.euskadi.eus/contenidos/informacion/dig_publicaciones_innovacion/es_conviven/adjuntos/600015c_Pub_EJ_guia_agresion_iguales_c.pdf",

            });

            this.ListLink = tempList;
        }


    }
}
