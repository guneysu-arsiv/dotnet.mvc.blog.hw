using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.EF;

namespace project.Controllers
{
    public class Helpers
    {
        public static List<Models.Post> getPosts()
        {

            Context _db = new Context();
            var posts = new List<Models.Post>();
            foreach (var post in _db.Posts.AsEnumerable())
            {
                posts.Add(
                    new Models.Post()
                    {
                        Summary = post.Body.Summary,
                        Category = _db.Categories.Find(post.Category.ID).Name,
                        ChangedTime = post.ChangedTime,
                        CreatedTime = post.CreatedTime,
                        Hit = post.Hit,
                        Title = post.Title,
                        ID = post.ID,
                        Published =  post.Published
                    });
            }
            return posts;
        }
    }
}