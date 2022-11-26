using Api.Learning.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Learning.DataAccess.Entities.Student
{
    [Table("students")]
    public class StudentEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
