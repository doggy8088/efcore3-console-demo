﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efc3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using(var db = new BlogContext())
            {
                db.Blogs.Add(new Blog()
                {
                    Rating = 5,
                    Url = "https://www.miniasp.com"
                });

                var blog = db.Blogs.Find(1);
                blog.Rating = 4;
                db.SaveChanges();

                var all = await db.Blogs.ToListAsync();

                foreach (var item in all)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.Rating);
                    Console.WriteLine(item.Url);
                    Console.WriteLine();
                }

                var blog_del = db.Blogs.OrderBy(p => p.BlogId).Last();
                db.Blogs.Remove(blog_del);
                db.SaveChanges();
            }
        }
    }
}
