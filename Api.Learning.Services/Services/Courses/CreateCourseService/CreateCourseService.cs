using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.DataAccess.Repository.Teacher;
using Api.Learning.Dtos.Dtos.Course;
using Api.Learning.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.CreateCourseService
{
    public class CreateCourseService : ICreateCourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ITeacherRepository teacherRepository;

        public CreateCourseService(
            ICourseRepository _courseRepository,
            ITeacherRepository _teacherRepository
            )
        {
            courseRepository = _courseRepository;
            teacherRepository = _teacherRepository;
        }   

        public CourseDto execute(CreateCourseDto course)
        {

            bool existsTeacher = teacherRepository.existsTeacherWithId(course.TeacherId);

            if (!existsTeacher)
            {
                throw new BadRequestException("Teacher Id not exists.");
            }

            CourseEntity courseEntity = new CourseEntity()
            {
                Title = course.Title,
                Description = course.Description,
                TeacherId = course.TeacherId
            };

            courseEntity = courseRepository.createCourse(courseEntity);

            return new CourseDto
            {
                Description = courseEntity.Description,
                Title = courseEntity.Title,
                Id = courseEntity.Id,
                TeacherId = courseEntity.TeacherId
            };


        }
    }
}
