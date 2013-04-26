using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogPostMetaTag
    {
        public int TagID { get; set; }
        public int PostID { get; set; }
        public string TagKey { get; set; }
        public string TagValue { get; set; }

        public BlogPostMetaTag(int TagID, int PostID, string TagKey, string TagValue)
        {
            this.TagID = TagID;
            this.PostID = PostID;
            this.TagKey = TagKey;
            this.TagValue = TagValue;
        }

    }
}
