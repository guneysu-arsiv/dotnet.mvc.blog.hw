﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(_db.Posts.AsEnumerable());
        }

        public ActionResult New()
        {
            return View("Edit", new Models.Post());
        }

        public ActionResult Edit(int id)
        {
            var post = _db.Posts.Find(id);
            project.Models.Post model = new Models.Post()
            {
                ID = post.ID,
                Body = post.Body.Value,
                Title = post.Title
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
                    Summary = post.Body.Length < 160 ? post.Body : post.Body.Substring(0, 160)
                };


                _db.Bodies.Add(updatedOrNewBody);
                _db.SaveChanges();

                // New Post
                updatedOrNew = new Post()
                {
                    Body = updatedOrNewBody,
                    Title = post.Title,
                    ChangedTime = DateTime.Now,
                    CreatedTime = DateTime.Now
                };

                _db.Posts.Add(updatedOrNew);

            }
            else
            {
                updatedOrNew = _db.Posts.Find(post.ID);
                

                updatedOrNewBody = _db.Bodies.Find(updatedOrNew.Body.ID);
                updatedOrNewBody.Value = post.Body;
                updatedOrNewBody.Summary = post.Body.Length < 160 ? post.Body : post.Body.Substring(0, 160);

                updatedOrNew.Title = post.Title;
                updatedOrNew.Body = updatedOrNewBody;

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
            _db.Posts.Remove(_db.Posts.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Display(int id)
        {
            var post = _db.Posts.Find(id);

            var model = new project.Models.Post()
            {
                ID = post.ID,
                Body = "adasd",
                Title = post.Title,
                CreatedTime = post.CreatedTime
            };
            return View(model);
        }
    }
}