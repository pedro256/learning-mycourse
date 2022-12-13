using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.DeleteCourseService
{
    public class DeleteCourseService : IDeleteCourseService
    {
        private readonly ICourseRepository courseRepository;

        public DeleteCourseService(
            ICourseRepository _courseRepository
            ) {
            courseRepository = _courseRepository;
        }

        public int execute(int id)
        {
            CourseEntity course = courseRepository.findOneById(id);
            if (course == null)
            {
                throw new BadRequestException("course not found .");
            }
            courseRepository.deleteCourse(course);
            return id;
        }
    }
}
