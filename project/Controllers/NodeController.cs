using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using project.EF;


namespace project.Controllers
{
    public class NodeController : Controller
    {
        private Context _db = new Context();

        // GET: Admin
        public ActionResult Index()
        {
            var posts = Helpers.getPosts();

            return View(posts);
        }



        public ActionResult New()
        {
            return View(
                "Edit", 
                new Models.Post()
                {
                    Categories =  _db.Categories.AsEnumerable()
                });
        }

        public ActionResult Edit(int id)
        {
            var post = _db.Posts.Find(id);
            project.Models.Post model = new Models.Post()
            {
                ID = post.ID,
                Body = post.Body.Value,
                Summary = post.Body.Summary,
                Title = post.Title,
                Categories = _db.Categories.AsEnumerable()
            };

            return View("Edit", model);
        }

        public ActionResult Update(Models.Post post)
        {
            project.EF.Post updatedOrNew;
            project.EF.Body updatedOrNewBody;

            var transaction = _db.Database.BeginTransaction();

            if (post.ID == 0)
            {
                updatedOrNewBody = new Body()
                {
                    Value = post.Body,
                    Summary = post.Summary
                };


                _db.Bodies.Add(updatedOrNewBody);
                _db.SaveChanges();

                // New Post
                updatedOrNew = new Post()
                {
                    Body = updatedOrNewBody,
                    Title = post.Title,
                    ChangedTime = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    Category =  _db.Categories.Find(post.CategoryId)
                };

                _db.Posts.Add(updatedOrNew);

            }
            else
            {
                updatedOrNew = _db.Posts.Find(post.ID);
                

                updatedOrNewBody = _db.Bodies.Find(updatedOrNew.Body.ID);
                updatedOrNewBody.Value = post.Body;
                updatedOrNewBody.Summary = post.Summary;

                updatedOrNew.Title = post.Title;
                updatedOrNew.Body = updatedOrNewBody;
                updatedOrNew.Category = _db.Categories.Find(post.CategoryId);

            }

            try
            {
                _db.SaveChanges();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            updatedOrNew.ChangedTime = DateTime.Now;
            
            transaction.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var post = _db.Posts.Find(id);
            var body = _db.Bodies.Find(post.Body.ID);
            
            _db.Posts.Remove(post);
            _db.Bodies.Remove(body);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Display(int id)
        {
            var post = _db.Posts.Find(id);
            IncrementHit(id);

            var model = new project.Models.Post()
            {
                ID = post.ID,
                Body = post.Body.Value,
                Title = post.Title,
                CreatedTime = post.CreatedTime,
                CategoryId =  post.Category.ID
            };

            
            

            return View(model);
        }

        public void IncrementHit(int id)
        {
            var post = _db.Posts.Find(id);
            post.Hit++;
            _db.SaveChanges();
        }
    }
}