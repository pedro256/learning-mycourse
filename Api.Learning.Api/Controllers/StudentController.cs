using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Services.Services.Students.CreateStudentService;
using Api.Learning.Services.Services.Students.DeleteStudentService;
using Api.Learning.Services.Services.Students.ListarStudentService;
using Api.Learning.Services.Services.Students.ShowStudentService;
using Api.Learning.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Learning.Api.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {

        private readonly ICreateStudentServices createStudentServices;
        private readonly IListarStudentService listarStudentService;
        private readonly IShowStudentService showStudentService;
        private readonly IDeleteStudentService deleteStudentService;

        public StudentController(
            ICreateStudentServices _createStudentServices,
            IListarStudentService _listarStudentService,
            IShowStudentService _showStudentService,
            IDeleteStudentService _deleteStudentService
            )
        {
            createStudentServices = _createStudentServices;
            listarStudentService = _listarStudentService;
            showStudentService = _showStudentService;
            deleteStudentService = _deleteStudentService;
        }

        [HttpPost]
        public IActionResult createStudent(
            [FromBody] CreateStudentDto dto
            )
        {

            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var result = createStudentServices.execute(dto);
                return Created("", result);
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            

            
        }

        [HttpGet]
        public IActionResult listAllStudents()
        {
            var result = listarStudentService.execute();

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult findById(
            int Id)
        {
            var result = showStudentService.execute(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult deleteOne(
            int Id
            )
        {
            int result = deleteStudentService.execute(Id);
            if (result==0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
