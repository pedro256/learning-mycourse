using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Services.Services.Students.CreateStudentService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Learning.Api.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {

        private readonly ICreateStudentServices createStudentServices;

        public StudentController(
            ICreateStudentServices _createStudentServices
            )
        {
            this.createStudentServices = _createStudentServices;
        }

        [HttpPost]
        public IActionResult createStudent(
            [FromBody] CreateStudentDto dto
            )
        {

            if (!ModelState.IsValid) { return BadRequest(); }

            var result = createStudentServices.execute(dto);

            return Created("",result);
        }
    }
}
