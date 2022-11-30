using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Student
{
    public class CreateStudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage =" First Name é requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage =" SecondName é requerido")]
        public string SecondName { get;set; }

        [EmailAddress(ErrorMessage ="Email inválido")]
        [Required(ErrorMessage = " Email é requerido")]
        public string Email { get; set; }

        [PasswordExampleCustomValidation]
        [Required(ErrorMessage = " Password é requerido")]
        public string Password { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage =" BirthDate é requerido")]
        public DateTime BirthDate { get; set; }
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
