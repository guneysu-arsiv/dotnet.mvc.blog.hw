using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ChangedTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post()
        {
            CreatedTime = DateTime.Now;
        }
    }
}