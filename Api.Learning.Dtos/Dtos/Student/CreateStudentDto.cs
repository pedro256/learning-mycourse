using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Student
{
    public class CreateStudentDto: StudentDto
    {
        [Required(ErrorMessage =" First Name é requerido")]
        public new string FirstName { get; set; }

        [EmailAddress(ErrorMessage ="Email inválido")]
        [Required(ErrorMessage = " Email é requerido")]
        public new string Email { get; set; }

        [PasswordExampleCustomValidation]
        [Required(ErrorMessage = " Password é requerido")]
        public new string Password { get; set; }
    }

    public class PasswordExampleCustomValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (string)value == "1234" ?
                new ValidationResult("Senha muito fácil !") :
                ValidationResult.Success;
        }
    }
}
