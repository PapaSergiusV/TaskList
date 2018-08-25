using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public DbSet<TList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TaskList;Trusted_Connection=True;");
        }
    }
}
