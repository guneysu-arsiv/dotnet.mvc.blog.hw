using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.EF;

namespace project.Models
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ChangedTime { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public long Hit { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool Published { get; set; }
        public Post()
        {
            CreatedTime = DateTime.Now;
        }
    }
}