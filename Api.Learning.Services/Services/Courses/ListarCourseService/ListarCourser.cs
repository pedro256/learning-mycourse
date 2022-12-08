using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.Dtos.Dtos.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Learning.Services.Services.Courses.ListarCourseService
{
    public class ListarCourser : IListarCourser
    {
        private readonly ICourseRepository courseRepository;

        public ListarCourser(ICourseRepository _courseRepository)
        {
           courseRepository = _courseRepository;
        }

        public List<CourseDto> execute()
        {
            List<CourseEntity> courses = courseRepository.GetAll().ToList();
            return courses.Select(c => new CourseDto
            {
                Title = c.Title,
                Description = c.Description,
                Id = c.Id,
                TeacherId = c.TeacherId
            }).ToList();


        }
    }
}
