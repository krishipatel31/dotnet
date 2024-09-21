using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if(value != null)
            { 
            string[] strings = value.ToString().Split('@');
            if (strings[1].ToUpper() ==AllowedDomain.ToUpper())
            {
                return null;
            }

            return new ValidationResult(ErrorMessage,
            new[] { validationContext.MemberName });
        }
     return null;
    }
}
}
