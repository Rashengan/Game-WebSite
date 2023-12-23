using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Project.Models;

namespace Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<MakeComment> MakeComments => Set<MakeComment>();
    }
}