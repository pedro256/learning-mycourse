using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.DataAccess.Repository.Course
{
    public interface ICourseRepository : IGenericRepository<CourseEntity>
    {

        CourseEntity createCourse(CourseEntity data);
        void deleteCourse(CourseEntity data);
        CourseEntity updateCourse(CourseEntity data);

        CourseEntity findOneById(int id);
    }
}
