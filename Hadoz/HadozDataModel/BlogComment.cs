﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogComment
    {
        public int CommentID { get; set; }
        public int PostID { get; set;}
        public string CommentAuthor { get; set; }
        public string CommentAuthorEmail { get; set; }
        public string CommentAuthorIP { get; set; }
        public string CommentDate { get; set; }
        public string CommentBody { get; set; }
        public bool IsApproved { get; set; }
        public int CommentStatus { get; set; }
        public int Parent { get; set; }

        public BlogComment(int CommentID, int PostID, string CommentAuthor, string CommentAuthorEmail, 
                           string CommentAuthorIP, string CommentDate, string CommentBody, 
                           bool IsApproved, int CommentStatus, int Parent)
        {
            this.CommentID = CommentID;
            this.PostID = PostID;
            this.CommentAuthor = CommentAuthor;
            this.CommentAuthorEmail = CommentAuthorEmail;
            this.CommentAuthorIP = CommentAuthorIP;
            this.CommentDate = CommentDate;
            this.CommentBody = CommentBody;
            this.IsApproved = IsApproved;
            this.CommentStatus = CommentStatus;
            this.Parent = Parent;
        }

    }
}
