using Bully.Models.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bully.Helpers
{
    public class RssHelper
    {
        public static RssItem GetItemFromXmlElement(XElement pElement)
        {
            RssItem item = new RssItem
            {

                Title =
                    pElement.Element("title") != null ? pElement.Element("title").Value : string.Empty,
                Link = pElement.Element("link") != null ? pElement.Element("link").Value : string.Empty,
                Description =
                    pElement.Element("description") != null
                        ? pElement.Element("description").Value
                        : string.Empty,
                PublishDate =
                    pElement.Element("pubDate") != null
                        ? pElement.Element("pubDate").Value
                        : string.Empty,
            };

            var element = pElement.Element("enclosure");
            if (element != null)
            {
                foreach (var xAttribute in element.Attributes())
                {
                    if (xAttribute.Name == "url")
                    {
                        item.Image = xAttribute.Value;
                        break;
                    }
                }
            }
            else
            {
                item.Image = Constants.GlobalSettings.RSSImageDefault;
            }

            return item;
        }
    }
}
