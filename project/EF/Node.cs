using System;

namespace project.EF
{
    public abstract class Node
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public bool Sticky { get; set; }
        public Body Body { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ChangedTime { get; set; }
        public long Hit { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}