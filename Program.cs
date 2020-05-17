using System;
using Microsoft.EntityFrameworkCore;

namespace efc3
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BlogDB;Integrated Security=true;");

            using(var db = new BlogContext(optionsBuilder.Options))
            {
                // db.Database.EnsureCreated();

                db.Blogs.Add(new Blog()
                {
                    Rating = 5,
                    Url = "https://blog.miniasp.com"
                });

                db.SaveChanges();
            }
            Console.WriteLine("Hello World!");
        }
    }
}