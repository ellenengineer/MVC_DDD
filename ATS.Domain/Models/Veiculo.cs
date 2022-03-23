using ATS.Domain.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Models
{
    public class Veiculo : BaseEntity
    {

        [Required(ErrorMessage = "O Proprietario é obrigatório!")]
        public int ProprietariosId { get; set; }    

        public Proprietario? Proprietarios { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória!")]
        public int MarcaId { get; set; }

        public Marca? Marca { get; set; }

        [Required(ErrorMessage = "O RENAVAM é obrigatório!")]
        public string? RENAVAM { get; set; }

        [Required(ErrorMessage = "O Modelo é obrigatório!")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "O Ano de Fabricacao é obrigatório!")]
        public string? AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O Ano do modelo é obrigatório!")]
        public int AnoModelo { get; set; }

        [Required(ErrorMessage = "A Quilometragem é obrigatória!")]
        public string? Quilometragem { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório!")]
        public decimal Valor { get; set; }


        [Required(ErrorMessage = "O Status é obrigatório!")]
        [StatusVeiculoValidator(ErrorMessage = "Status deverá ser Disponível (D), indisponível (I) ou Vendido (V)")]
        public string? Status { get; set; }
    }
}
