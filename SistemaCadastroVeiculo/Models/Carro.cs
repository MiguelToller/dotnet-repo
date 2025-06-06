using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroVeiculo.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatório")]
        [StringLength(20, ErrorMessage = "O nome deve ter até 20 caracteres")]
        public String Modelo { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória")]
        [StringLength(20, ErrorMessage = "A marca deve ter até 20 caracteres")]
        public String Marca { get; set; }

        [Required(ErrorMessage = "O Renavam é obrigatório")]
        [Range(11111111111, 99999999999, ErrorMessage = "O Renavam deve ter até 11 números")]
        public long Renavam { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório")]
        [Range(1900, 2100, ErrorMessage = "Ano de fabricação inválido")]
        public int AnoFabricação { get; set; }

        [Required(ErrorMessage = "O ano modelo é obrigatório")]
        [Range(1900, 2100, ErrorMessage = "Ano de fabricação inválido")]
        public int AnoModelo { get; set; }

        public string? CaminhoImagem { get; set; }

        [NotMapped]
        [Display(Name = "Imagem do carro")]
        public IFormFile? Imagem { get; set; }


    }
}
