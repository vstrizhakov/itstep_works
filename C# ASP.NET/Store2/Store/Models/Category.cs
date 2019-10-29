using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }

        public Category() { }

        public Category(string name, int? parentcategoryid = null)
        {
            Name = name;
            ParentCategoryId = parentcategoryid;
        }
    }
}