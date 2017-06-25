using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Models.Rss
{
    public class RSSFeedItem
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }
        public int Id { get; set; }
    }
}
