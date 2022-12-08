using Api.Learning.DataAccess.Entities.Base;
using Api.Learning.DataAccess.Entities.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Learning.DataAccess.Entities.Course
{
    [Table("courses")]
    public class CourseEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public virtual TeacherEntity Teacher { get; set; }  
        [ForeignKey(nameof(TeacherEntity))]
        public int TeacherId { get; set; }
    }
}
