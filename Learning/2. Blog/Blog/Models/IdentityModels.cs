﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Blog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Message> Messages { get; set; } //Создается таблица
        public DbSet<Reply> Replies { get; set; } //Создается таблица
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}