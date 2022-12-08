using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Learning.Dtos.Dtos.Course
{
    public class CreateCourseDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int TeacherId { get; set; }
    }
}
