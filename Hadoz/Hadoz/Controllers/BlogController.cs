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
            return View();
        }

        public ActionResult BlogPost()
        {
            BlogPostBusinessService bpBS = new BlogPostBusinessService();
            BlogPostViewModel bpVM = bpBS.DisplayAllBlogPosts();
            return Json(bpVM);
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
