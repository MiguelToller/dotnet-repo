using System.ComponentModel.DataAnnotations;

namespace Projeto_Tarefa.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do projeto deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataTermino { get; set; }  // Opcional

        // Relacionamento 1 Projeto -> N Tarefas
        public ICollection<Tarefa>? Tarefas { get; set; } = new List<Tarefa>();
    }
}
