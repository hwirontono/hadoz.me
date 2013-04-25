using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogAuthor
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }

        public BlogAuthor(int AuthorID, string AuthorName, string AuthorEmail)
        {
            this.AuthorID = AuthorID;
            this.AuthorName = AuthorName;
            this.AuthorEmail = AuthorEmail;
        }
    }
}
