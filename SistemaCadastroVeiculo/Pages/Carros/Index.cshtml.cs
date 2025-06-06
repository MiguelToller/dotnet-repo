using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaCadastroVeiculo.Models;
using SistemaCadastroVeiculo.Models;

namespace SistemaCadastroVeiculo.Pages.Carros
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Carro> ListaCarros { get; set; }

        public void OnGet()
        {
            ListaCarros = new List<Carro>();

            if (System.IO.File.Exists("carros.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("carros.txt");

                foreach (var linha in linhas)
                {
                    try
                    {
                        var dados = linha.Split(";");

                        if (dados.Length < 7)
                        {
                            _logger.LogWarning("Linha inválida no arquivo: {Linha}", linha);
                            continue;
                        }

                        var carro = new Carro
                        {
                            Id = int.Parse(dados[0]),
                            Modelo = dados[1],
                            Marca = dados[2],
                            Renavam = long.Parse(dados[3]),
                            AnoFabricação = int.Parse(dados[4]),
                            AnoModelo = int.Parse(dados[5]),
                            CaminhoImagem = dados[6]
                        };

                        ListaCarros.Add(carro);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao processar linha: {Linha}", linha);
                    }
                }
            }
        }
    }
}
