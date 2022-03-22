using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;


namespace ATS.Domain.Models
{
    public class Proprietario : BaseEntity
    {

        [Required(ErrorMessage = "Nome do Proprietario � obrigat�rio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do Proprietario � obrigat�rio!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Documento do Proprietario � obrigat�rio!")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Endereco do Proprietario � obrigat�rio!")]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Status do Propriet�rio � obrigat�rio!")]
        [StatusMarcaPropValidator(ErrorMessage ="Status dever� ser Ativo (A) ou Cancelado (C)")]
        public string Status { get; set; }


    }
}


