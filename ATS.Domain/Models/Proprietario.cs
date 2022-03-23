using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ATS.Domain.Validator;


namespace ATS.Domain.Models
{
    public class Proprietario : BaseEntity
    {

        [Required(ErrorMessage = "Nome do Proprietario é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Email do Proprietario é obrigatório!")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Documento do Proprietario é obrigatório!")]
        public string? Documento { get; set; }


        [Required(ErrorMessage = "cep é obrigatório!")]
        public string? CEP { get;set; }

        public string? Endereco { get; set; }


        [Required(ErrorMessage = "Status do Proprietário é obrigatório!")]
        [StatusMarcaPropValidator(ErrorMessage ="Status deverá ser Ativo (A) ou Cancelado (C)")]
        public string? Status { get; set; }


    }
}


