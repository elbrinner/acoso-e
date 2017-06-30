using Bully.Models.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Interfaces.Facade
{
    public interface INewsFacade
    {
        Task<List<RssItem>> NewsAsync();

        Task<List<RssItem>> RSSAsync();
    }
}
