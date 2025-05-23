using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApplication.Pages
{
    public class ProdutoModel : PageModel
    {
        public List<Produto> Produtos { get; set; }
        public void OnGet()
        {
            Produtos = new List<Produto>
            {
                new Produto { Descricao = "Coca cola", Preco = 8.99m },
                new Produto { Descricao = "Pepsi", Preco = 8.99m }
            };
        }
    }

    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
