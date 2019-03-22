using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Core.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
