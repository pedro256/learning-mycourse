using Api.Learning.DataAccess.Repository.Teacher;
using Api.Learning.Dtos.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.ListTeachersService
{
    public class ListTeacherService : IListTeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public ListTeacherService(ITeacherRepository _teacherRepository)
        {
            teacherRepository = _teacherRepository;
        }
    
        public List<TeacherDto> execute()
        {
            var result = teacherRepository.GetAll();
            List<TeacherDto> response = result.Select(x => new TeacherDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Email = x.Email,
                Description = x.Description,
                BirthDate = x.BirthDate
            }).ToList();

            return response;
        }
    }
}
