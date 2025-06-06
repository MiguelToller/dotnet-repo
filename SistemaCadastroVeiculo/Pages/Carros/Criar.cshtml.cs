using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaCadastroVeiculo.Models;

namespace SistemaCadastroVeiculo.Pages.Carros
{
    public class CriarModel : PageModel
    {
        [BindProperty]
        public Carro Carro { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Carro.Imagem != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(Carro.Imagem.FileName);
                var extension = Path.GetExtension(Carro.Imagem.FileName);
                var uniqueName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var savePath = Path.Combine("wwwroot/uploads", uniqueName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    Carro.Imagem.CopyTo(stream);
                }

                Carro.CaminhoImagem = $"/uploads/{uniqueName}";
            }

            using (var writer = new StreamWriter("carros.txt", true))
            {
                writer.WriteLine($"{Carro.Id};{Carro.Modelo};{Carro.Marca};{Carro.Renavam};{Carro.AnoFabricação};{Carro.AnoModelo};{Carro.CaminhoImagem}");
            }

            return RedirectToPage("/Carros/Index");
        }
    }
}
