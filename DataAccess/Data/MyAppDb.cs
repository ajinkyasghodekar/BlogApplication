﻿using BlogApplication.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MyAppDb : DbContext
    {

        public MyAppDb(DbContextOptions<MyAppDb> options) : base(options)
        {

        }

        // Table for Blog
        public DbSet<Blog> BlogsTable { get; set; }

        // Table for Users
        public DbSet<Users> UsersTable { get; set; }

        // Table for AuthSecurity
        public DbSet<AuthSecurity> AuthSecurityTable { get; set; }

        // Table for Subscription
        public DbSet<Subscription> Subscriptions { get; set; }

        // Inserting sample data to Users table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(

                new Blog()
                {
                    BlogId = 1,
                    BlogTitle = "Neque porro quisquam est qui",
                    BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                    BlogCategory = "Nature",
                    NoOfSubscriptions = 10
                },
                new Blog()
                {
                    BlogId = 2,
                    BlogTitle = "Porro quisqu ameque  est qui",
                    BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                    BlogCategory = "Politics",
                    NoOfSubscriptions = 30
                },
                new Blog()
                {
                    BlogId = 3,
                    BlogTitle = "Eest qui eque porro quisquam ",
                    BlogContent = "Lorem Neque Neque porro quisquam Neque porro quisquam est qui Neque porro quisquam est quiest quiporro quisquam est qui",
                    BlogCategory = "Weather",
                    NoOfSubscriptions = 20
                });
        }
    }
}
