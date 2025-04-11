using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    internal abstract class Chamado
    {
        public string titulo;
        public string descricao;
        public string status;

        public Chamado(string titulo, string descricao)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.status = "Aberto";
        }

        public abstract void Executar();
        
        public void Exibir()
        {
            Console.WriteLine("\nTitulo: " + titulo + "\nDescricao: " + descricao + "\nStatus = " + status);
        }
    }
}
