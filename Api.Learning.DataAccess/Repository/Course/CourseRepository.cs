using Api.Learning.DataAccess.Context;
using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Learning.DataAccess.Repository.Course
{
    public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
    {
        public CourseRepository(ApiLearningContext context) : base(context)
        {

        }
        public CourseEntity createCourse(CourseEntity data)
        {
            _context.CourseEntity.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void deleteCourse(CourseEntity data)
        {
            _context.CourseEntity.Attach(data);
            _context.CourseEntity.Remove(data);
            _context.SaveChanges();

        }

        public CourseEntity findOneById(int Id)
        {
            var ett = _context.CourseEntity.Include(x => x.Teacher).FirstOrDefault(x => x.Id == Id);
            return ett;
        }

        public CourseEntity updateCourse(CourseEntity data)
        {
            _context.CourseEntity.Update(data);
            _context.SaveChanges();
            return data;
        }
    }
}
