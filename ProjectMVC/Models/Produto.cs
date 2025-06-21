using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVC.Models
{
    public class Produto
    {
        [Key] // Define que "Id" é a chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        [Range(0.01, 9999.99, ErrorMessage = "O preço deve estar entre 0.01 e 9999.99")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
    }
}
