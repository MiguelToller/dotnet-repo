using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
