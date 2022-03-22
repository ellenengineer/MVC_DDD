using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class StatusMarcaPropValidator : ValidationAttribute
    {


        public StatusMarcaPropValidator()
            : base("{0} Deverá ser Ativo (A) ou CANCELADO (C)")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = Convert.ToString(value);

            bool valid = val.Equals("A") || val.Equals("C");

            if (valid)
                return null;

            return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                , new string[] { validationContext.MemberName });
        }
    }

}
