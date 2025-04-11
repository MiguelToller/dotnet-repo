using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    internal class ChamadoSoftware : Chamado
    {
        public ChamadoSoftware(string titulo, string descricao) : base(titulo, descricao)
        {
        }

        public override void Executar()
        {
            status = "Em Atendimento";
            Console.WriteLine("\nExecutando diagnostico e reinstalacao de software.");
        }
    }
}
