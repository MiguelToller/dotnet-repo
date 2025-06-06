using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaCadastroVeiculo.Models;

namespace SistemaCadastroVeiculo.Pages.Carros
{
    public class DetalharModel : PageModel
    {
        private readonly ILogger<DetalharModel> _logger;

        public DetalharModel(ILogger<DetalharModel> logger)
        {
            _logger = logger;
        }

        public SistemaCadastroVeiculo.Models.Carro Carro { get; set; }

        public IActionResult OnGet(int id)
        {
            var carros = CarregarCarros();

            Carro = carros.FirstOrDefault(c => c.Id == id);

            if (Carro == null)
            {
                return RedirectToPage("/Carros/Index");
            }

            return Page();
        }

        public List<SistemaCadastroVeiculo.Models.Carro> CarregarCarros()
        {
            var carros = new List<SistemaCadastroVeiculo.Models.Carro>();

            if (System.IO.File.Exists("carros.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("carros.txt");

                foreach (var linha in linhas)
                {
                    try
                    {
                        var dados = linha.Split(';');

                        if (dados.Length < 7)
                        {
                            _logger.LogWarning("Linha inválida: {Linha}", linha);
                            continue;
                        }

                        var carro = new SistemaCadastroVeiculo.Models.Carro
                        {
                            Id = int.Parse(dados[0]),
                            Modelo = dados[1],
                            Marca = dados[2],
                            Renavam = long.Parse(dados[3]),
                            AnoFabricação = int.Parse(dados[4]),
                            AnoModelo = int.Parse(dados[5]),
                            CaminhoImagem = dados[6]
                        };

                        carros.Add(carro);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao processar linha: {Linha}", linha);
                    }
                }
            }

            return carros;
        }
    }
}
