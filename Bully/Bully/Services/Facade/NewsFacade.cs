using Bully.Constants;
using Bully.DataXML;
using Bully.Mapper;
using Bully.Models.Rss;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Bully.Services.Facade
{
    public class NewsFacade
    {
        HttpClient client;
        public NewsFacade()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<List<RssItem>> NewsAsync()
        {

            var url = new Uri(string.Format(CultureInfo.InvariantCulture, GlobalSettings.DataNews));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<List<RssItem>>(content);
                }
            }
            return null;

        }





    }
}
