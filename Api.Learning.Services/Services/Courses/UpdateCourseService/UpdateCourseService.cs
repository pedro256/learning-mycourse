using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.Dtos.Dtos.Course;
using Api.Learning.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Courses.UpdateCourseService
{
    public class UpdateCourseService : IUpdateCourseService
    {
        private readonly ICourseRepository courseRepository;

        public UpdateCourseService(
            ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        public CourseDto execute(CourseDto dto)
        {
            CourseEntity ett = courseRepository.findOneById(dto.Id);
            if (ett == null)
            {
                throw new BadRequestException("course not found.");
            }

            if(ett.Title != dto.Title && dto.Title != null)
            {
                ett.Title = dto.Title;
            }

            if (ett.Description != dto.Description && dto.Description != null)
            {
                ett.Description = dto.Description;
            }

            courseRepository.updateCourse(ett);

            return dto;
        }
    }
}
