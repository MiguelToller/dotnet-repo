using Microsoft.EntityFrameworkCore;
using Projeto_Tarefa.Models;

namespace Projeto_Tarefa.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
