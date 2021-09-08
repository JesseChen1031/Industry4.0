using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Account> accounts { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Address> addresses { get; set; }

        public DbSet<order> orders { get; set; }

        public DbSet<deviceOW> deviceOWs { get; set; }

        public DbSet<product> products { get; set; }

        public DbSet<material> materials { get; set; }
        public DbSet<bin> bins { get; set; }
    }
}
