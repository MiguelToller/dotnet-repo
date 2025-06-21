using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Tarefa.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título da tarefa é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        public string Titulo { get; set; }

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O status da tarefa é obrigatório")]
        [StringLength(50, ErrorMessage = "O status deve ter no máximo 50 caracteres")]
        public string Status { get; set; }

        // Chave estrangeira para o projeto
        [Required(ErrorMessage = "A tarefa deve estar vinculada a um projeto")]
        public int ProjetoId { get; set; }

        // Propriedade de navegação para o projeto
        [ForeignKey("ProjetoId")]
        public Projeto? Projeto { get; set; }
    }
}
