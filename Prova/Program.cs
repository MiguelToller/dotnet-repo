namespace Prova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o titulo: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Insira a descricao: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("O Chamado e 'Hardware' ou 'Software'?");
            string chamado = Console.ReadLine().ToUpper();

            if (chamado == "HARDWARE")
            {
                ChamadoHardware ch = new ChamadoHardware(titulo, descricao);
                ch.Exibir();
                ch.Executar();
                ch.Exibir();
            }
            else if (chamado == "SOFTWARE")
            {
                ChamadoSoftware cs = new ChamadoSoftware(titulo, descricao);
                cs.Exibir();
                cs.Executar();
                cs.Exibir();
            }
            else
            {
                Console.WriteLine("\nOpcao invalida...");
            }
        }
    }
}