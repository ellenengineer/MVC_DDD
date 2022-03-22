using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class StatusVeiculoValidator : ValidationAttribute
    {


        public StatusVeiculoValidator()
            : base("{0} Deverá ser Disponível (D), Indisponível (I) ou Vendido (V)")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = Convert.ToString(value);

            bool valid = val.Equals("D") || val.Equals("I") || val.Equals("V");

            if (valid)
                return null;

            return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                , new string[] { validationContext.MemberName });
        }
    }

}
