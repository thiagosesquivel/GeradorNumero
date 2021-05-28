using Microsoft.EntityFrameworkCore;
using GeradorNumero.Models;

namespace GeradorNumero.Data{
    public class Context : DbContext{
        public Context(DbContextOptions<Context>options):base(options){

        }

        public DbSet<User> Users {get;set;}
        public DbSet<CardNumber> CardNumbers {get;set;}

    }
}