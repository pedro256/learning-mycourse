using Api.Learning.DataAccess.Repository.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.DeleteTeacherService
{
    public class DeleteTeacherService : IDeleteTeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public DeleteTeacherService(
            ITeacherRepository _teacherRepository
            )
        {
            teacherRepository = _teacherRepository;
        }

        public int execute(int Id)
        {
            var result = teacherRepository.GetById(Id);
            if (result==null)
            {
                return 0;
            }
            teacherRepository.deleteTeacher(result);
            return Id;
        }
    }
}
