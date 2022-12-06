using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Student
{
    public class UpdateStudentDto
    {
        public int? Id { get; set; }

        [MaxLength(150,ErrorMessage = "FirstName deve conter menos de 150 caracteres")]
        public string FirstName { get; set; }

        [MaxLength(150, ErrorMessage = "SecondName deve conter menos de 150 caracteres")]
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
