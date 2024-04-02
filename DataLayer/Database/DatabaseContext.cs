﻿using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DataBaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DataBaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            var user = new DataBaseUser()
            {
                Id = 1,
                Name = "Test",
                Password = "password",
                Role = PSProject.Other.UserEnumRoles.ADMIN,
                Expire = DateTime.Now.AddYears(10)
            };
            modelBuilder.Entity<DataBaseUser>().HasData(user);

        }

    }
}
