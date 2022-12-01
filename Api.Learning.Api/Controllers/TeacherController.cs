using Api.Learning.Dtos.Dtos.Teacher;
using Api.Learning.Services.Services.Teachers.CreateTeacherService;
using Api.Learning.Services.Services.Teachers.DeleteTeacherService;
using Api.Learning.Services.Services.Teachers.ListTeachersService;
using Api.Learning.Services.Services.Teachers.ShowTeacherService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Learning.Api.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController:ControllerBase
    {
        private readonly ICreateTeacherService _createTeacherService;
        private readonly IListTeacherService _listTeacherService;
        private readonly IShowTeacherService _showTeacherService;
        private readonly IDeleteTeacherService _deleteTeacherService;


        public TeacherController(
            ICreateTeacherService createTeacherService, 
            IListTeacherService listTeacherService, 
            IShowTeacherService showTeacherService, 
            IDeleteTeacherService deleteTeacherService)
        {
            _createTeacherService = createTeacherService;
            _listTeacherService = listTeacherService;
            _showTeacherService = showTeacherService;
            _deleteTeacherService = deleteTeacherService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _listTeacherService.execute();
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult CreateOne(
            [FromBody] CreateTeacherDto createTeacherDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var result = _createTeacherService.execute(createTeacherDto);

            return Created("", result);
        }

        [HttpGet("{Id}")]
        public IActionResult GetOne(
            int Id
            )
        {
            var result = _showTeacherService.execute(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

    }
}
