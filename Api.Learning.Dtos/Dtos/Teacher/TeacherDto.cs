using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Teacher
{
   public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
