using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.Dtos.Dtos.Course;
using Api.Learning.Dtos.Dtos.Teacher;
using Api.Learning.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.ShowCourseService
{
    public class ShowCourseService : IShowCourseService
    {
        private readonly ICourseRepository courseRepository;


        public ShowCourseService(
            ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }   

        public CourseDto execute(int id)
        {
            CourseEntity course =  courseRepository.findOneById(id);
            if (course == null)
            {
                throw new BadRequestException("courser id not exits .");
            }
            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Teacher = new TeacherDto {
                    Id = course.Teacher.Id,
                    FirstName = course.Teacher.FirstName,
                    Email = course.Teacher.Email
                }
            };
        }
    }
}
