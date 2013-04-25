using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HadozDataModel
{
    public class BlogCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public BlogCategory(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
        }

    }
}
