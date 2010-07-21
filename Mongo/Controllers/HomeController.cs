using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DomainModel.Concrete;
using DomainModel.Entities;
using DomainModel.Abstract;
using Mongo.Common;

namespace Mongo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IPostRepository postRepository;

        public HomeController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public ViewResult Index()
        {            
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult MongoBlog()
        {
            var posts = postRepository.GetPosts();     

            return View(posts.ToList());
        }

        public ViewResult PostCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostCreate(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CharCount = post.Body.Length;
                post.PostDate = DateTime.UtcNow;
                
                //post.Comments = new List<Comment>
                //{
                //    { new Comment() { TimePosted = DateTime.Now, Name = "Bob McBob", Email = "bob_mcbob@gmail.com", Body = "This article is too short!" } },
                //    { new Comment() { TimePosted = DateTime.Now, Name = "Jane McJane", Email = "Jane.McJane@gmail.com", Body = "I agree with Bob." } }
                //};

                postRepository.CreatePost(post);

                return RedirectToAction("MongoBlog");
            }
            else 
            {
                return View(post);
            }

        }

        public ViewResult PostPartial(string Id)
        {
            Post post = postRepository.GetPostById(Id);
            ViewData["PostId"] = post.Id;

            return View(post);
        }

        public ViewResult PostView(string Id)
        {
            ViewData["Post"] = postRepository.GetPostById(Id);

            ViewData["Id"] = Id;

            return View(new Comment());
        }

        //[CaptchaValidator]
        [HttpPost]
        public ActionResult PostView(Comment comment)
        {           
            //if (!captchaValid)
            //    ModelState.AddModelError("Captcha", "reCAPTCHA response was incorrect.");

            Post post = postRepository.GetPostById(Request.Params["PostId"]);

            if (ModelState.IsValid)
            {
                comment.TimePosted = DateTime.Now;

                postRepository.CreateComment(post.Id, comment);

                return RedirectToAction("PostView", new { Id = Request.Params["PostId"] });
            }
            else
            {
                ViewData["Post"] = post;

                ViewData["Id"] = post.Id;

                return View(comment);
            }
        }

        public ViewResult PostEdit(string Id)
        {
            Post post = postRepository.GetPostById(Id);

            return View(post);
        }

        [HttpPost]
        public ActionResult PostEdit(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CharCount = post.Body.Length;                

                postRepository.UpdatePost(post);

                return RedirectToAction("MongoBlog");
            }
            else
            {
                return View(post);
            }

        }

        public ActionResult PostDelete(string Id)
        {
            postRepository.DeletePost(Id);

            return RedirectToAction("MongoBlog");
        }

        public ActionResult Mode()
        {
            Session["AdminMode"] = (Convert.ToBoolean(Session["AdminMode"])) ? false : true;

            return RedirectToAction("MongoBlog");
        }

        public ActionResult CommentEdit(string Id, string CommentId)
        {
            return RedirectToAction("PostView", new { Id = Id });
        }

        public ActionResult CommentDelete(string Id, string CommentId)
        {
            postRepository.DeleteComment(Id, CommentId);

            return RedirectToAction("PostView", new { Id = Id });
        }

    }
}
