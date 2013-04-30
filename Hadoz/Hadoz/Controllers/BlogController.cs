using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HadozBusinessServices;
using HadozViewModel;

namespace Hadoz.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            BlogPostBusinessService bpBS = new BlogPostBusinessService();
            BlogPostViewModel bpVM = bpBS.DisplayAllBlogPosts();
            return View("Index", bpVM);
        }

        public ActionResult BlogPost(int PostID = 1)
        {
            //Server.HtmlEncode(PostID);
            //BlogPostBusinessService bpBS = new BlogPostBusinessService();
            //BlogPostViewModel bpVM = bpBS.DisplayAllBlogPosts();


            return View();
        }

        [HttpPost()]
        public ActionResult GetAllBlogPosts()
        {
            BlogPostBusinessService bpBS = new BlogPostBusinessService();
            BlogPostViewModel bpVM = bpBS.DisplayAllBlogPosts();
            return Json(bpVM);
        }
    }
}
