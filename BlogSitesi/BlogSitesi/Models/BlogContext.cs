using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class BlogContext : DbContext

    {
        public BlogContext():base("BlogVt"){
            Database.SetInitializer(new BlogInitializer());//İnitializer sınıfa tanıtılmadan ekranda değiim görmeyiz.
            }

        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
    }

}