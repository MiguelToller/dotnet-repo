using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApplication.Models;

namespace RazorApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Usuario> Usuarios { get; set; }

        public void OnGet()
        {
            Usuarios = new List<Usuario>();

            if (System.IO.File.Exists("usuarios.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");

                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');

                    var usuario = new Usuario()
                    {
                        Id = int.Parse(dados[0]),
                        Nome = dados[1],
                        Senha = dados[2],
                        Email = dados[3]
                    };
                    Usuarios.Add(usuario);
                }
            }

        }
    }
}