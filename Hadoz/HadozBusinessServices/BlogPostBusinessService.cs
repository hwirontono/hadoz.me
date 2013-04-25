using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HadozDataAccessServices;
using HadozDataModel;
using HadozViewModel;


namespace HadozBusinessServices
{
    public class BlogPostBusinessService
    {
        public BlogPostViewModel DisplayAllBlogPosts()
        {
            BlogPostDataAccessService bpDAS = new BlogPostDataAccessService();

            BlogPostViewModel bpVM = new BlogPostViewModel();
            bpVM.BlogPosts = bpDAS.GetAllBlogPosts();
            
            //loop the blogposts to get tags and categories

            foreach (var post in bpVM.BlogPosts)
            {
                post.Categories = bpDAS.GetCategoriesForAPost(post.PostID);
                post.Tags = bpDAS.GetTagsForAPost(post.PostID);
            }
            
            return bpVM;
        }
    }
}
