using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    internal class ChamadoHardware : Chamado
    {
        public ChamadoHardware(string titulo, string descricao) : base(titulo, descricao)
        {
            this.titulo = titulo;
            this.descricao = descricao;
        }

        public override void Executar()
        {
            status = "Em Atendimento";
            Console.WriteLine("\nAnalisando componentes de hardware...");
        }
    }
}
