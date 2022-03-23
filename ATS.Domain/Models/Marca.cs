using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;


namespace ATS.Domain.Models
{
    public class Marca : BaseEntity
    {

        [Required(ErrorMessage = "Nome do Marca é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Status da Marca é obrigatório!")]
        [StatusMarcaPropValidator(ErrorMessage ="Status deverá ser Ativo (A) ou Cancelado (C)")]
        public string? Status { get; set; }


    }
}