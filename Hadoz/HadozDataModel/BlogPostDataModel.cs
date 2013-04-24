using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogPostDataModel
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public StringBuilder Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Author { get; set; }
        public List<string> Tags { get; set; }

    }
}
