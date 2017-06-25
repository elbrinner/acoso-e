using Bully.DataXML;
using Bully.Models.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Mapper
{
    public static class MundoMapper
    {
        public static RssMundoResponse ToBusiness(this MundoResponseXml dto)
        {
            var response = new RssMundoResponse();
            foreach (var item in dto.rss.channel.Item)
            {
                response.List.Add(new RssItem(){
                    Title = item.title
               });
            }


            return response;

        }
    }
}
