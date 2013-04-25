using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HadozDataModel;
using System.Collections;

namespace HadozViewModel
{
    public class BlogPostViewModel : ViewInformation
    {
        public List<BlogPost> BlogPosts { get; set; }
        //public List<BlogPostMetaTag> BlogTags { get; set; }
        //public List<BlogCategory> BlogCategories { get; set; }

        public BlogPostViewModel()
        {
            BlogPosts = new List<BlogPost>();
            //BlogTags = new List<BlogPostMetaTag>();
            //BlogCategories = new List<BlogCategory>();

            ValidationErrors = new Hashtable();
            ReturnMessage = new List<string>();
        }

    }
}
