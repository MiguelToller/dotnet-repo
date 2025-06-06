using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaCadastroVeiculo.Models;

namespace SistemaCadastroVeiculo.Pages.Carros
{
    public class EditarModel : PageModel
    {
        private readonly ILogger<EditarModel> _logger;

        public EditarModel(ILogger<EditarModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public SistemaCadastroVeiculo.Models.Carro Carro { get; set; }

        public void OnGet(int id)
        {
            var carros = CarregarCarros();
            Carro = carros.FirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var linhas = System.IO.File.ReadAllLines("carros.txt").ToList();

            for (int i = 0; i < linhas.Count; i++)
            {
                var dados = linhas[i].Split(';');

                if (int.Parse(dados[0]) == Carro.Id)
                {
                    // Se o usuário não passou uma nova imagem, manter a antiga
                    if (string.IsNullOrEmpty(Carro.CaminhoImagem))
                    {
                        Carro.CaminhoImagem = dados[6]; // Caminho antigo da imagem
                    }

                    linhas[i] = $"{Carro.Id};{Carro.Modelo};{Carro.Marca};{Carro.Renavam};{Carro.AnoFabricação};{Carro.AnoModelo};{Carro.CaminhoImagem}";
                    break;
                }
            }

            System.IO.File.WriteAllLines("carros.txt", linhas);
            return RedirectToPage("/Carros/Index");
        }


        public List<Carro> CarregarCarros()
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
                            _logger.LogWarning("Linha inválida no arquivo: {Linha}", linha);
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
