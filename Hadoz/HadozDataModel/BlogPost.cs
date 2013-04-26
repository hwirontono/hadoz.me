using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogPost
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Excerpt { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int Status { get; set; }
        public int AuthorID { get; set; }

        public List<BlogPostMetaTag> Tags { get; set; }
        public List<BlogCategory> Categories { get; set; }

        public BlogPost(int PostID, string Title, string Body, string Excerpt, string CreateDate, string UpdateDate, int Status, int AuthorID)
        {
            this.PostID = PostID;
            this.Title = Title;
            this.Body = Body;
            this.Excerpt = Excerpt;
            this.CreateDate = CreateDate;
            this.UpdateDate = UpdateDate;
            this.Status = Status;
            this.AuthorID = AuthorID;
        }

    }
}
