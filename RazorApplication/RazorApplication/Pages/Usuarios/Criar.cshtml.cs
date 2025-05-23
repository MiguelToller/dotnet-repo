using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApplication.Models;

namespace RazorApplication.Pages
{
    public class CriarModel : PageModel
    {
        [BindProperty]
        public Usuario usuario { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                using (var writer = new StreamWriter("usuarios.txt", true))
                {
                    writer.WriteLine(usuario.Id + ";" + usuario.Nome + ";" + usuario.Senha + ";" + usuario.Email);
                    return RedirectToPage("/Usuarios/Index");
                }
            }
        }
    }
}
