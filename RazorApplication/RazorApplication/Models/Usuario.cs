using System.ComponentModel.DataAnnotations;

namespace RazorApplication.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(30, ErrorMessage ="O nome deve ter até 30 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="A senha é obrigatória")]
        [StringLength(10, MinimumLength = 6, ErrorMessage ="A senha deve ter entre 6 a 10 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage ="O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage ="O e-mail deve ser válido")]
        public string Email { get; set; }
    }
}
