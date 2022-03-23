using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;


namespace ATS.Domain.Models
{
    public class Marca : BaseEntity
    {

        [Required(ErrorMessage = "Nome do Marca � obrigat�rio!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Status da Marca � obrigat�rio!")]
        [StatusMarcaPropValidator(ErrorMessage ="Status dever� ser Ativo (A) ou Cancelado (C)")]
        public string? Status { get; set; }


    }
}