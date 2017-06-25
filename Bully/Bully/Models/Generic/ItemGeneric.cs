using Bully.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Models
{
    public class ItemGeneric
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string Image { get; set; }
        public string UrlShare { get; set; }
        public TypeElement Type { get; set; }

    }
}
