using Api.Learning.Dtos.Dtos.Course;
using Api.Learning.Services.Services.Courses.CreateCourseService;
using Api.Learning.Services.Services.Courses.DeleteCourseService;
using Api.Learning.Services.Services.Courses.ListarCourseService;
using Api.Learning.Services.Services.Courses.ShowCourseService;
using Api.Learning.Services.Services.Courses.UpdateCourseService;
using Api.Learning.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Learning.Api.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly IListarCourser listAllCourses;
        private readonly IShowCourseService showCourseService;
        private readonly ICreateCourseService createCourseService;
        private readonly IUpdateCourseService updateCourseService;
        private readonly IDeleteCourseService deleteCourseService;


        public CourseController(
            IListarCourser _listAllCourses,
            IShowCourseService _showCourseService,
            ICreateCourseService _createCourseService,
            IUpdateCourseService _updateCourseService,
            IDeleteCourseService _deleteCourseService
            )
        {
            createCourseService = _createCourseService;
            showCourseService = _showCourseService;
            listAllCourses = _listAllCourses;
            updateCourseService = _updateCourseService;
            deleteCourseService = _deleteCourseService;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<CourseDto> lista = listAllCourses.execute();
            return Ok(lista);
        }

        [HttpGet("{Id}")]
        public IActionResult getOne(int Id)
        {
            try
            {
                var response = showCourseService.execute(Id);

                return Ok(response);
            }
            catch (BadRequestException excp)
            {
                return BadRequest(excp.Message);
            }
        }

        [HttpPost]
        public IActionResult createOne(
            [FromBody] CreateCourseDto createCourseDto)
        {
            try
            {
                var response =  createCourseService.execute(createCourseDto);

                return Created("", response);
            }catch(BadRequestException excp)
            {
                return BadRequest(excp.Message);    
            }
        }
        [HttpPut("{Id}")]
        public IActionResult updateOne(
            int Id,
            [FromBody] CourseDto courseDto
            )
        {
            try
            {
                courseDto.Id = Id;
                var response = updateCourseService.execute(courseDto);

                return NoContent();
            }
            catch (BadRequestException excp)
            {
                return BadRequest(excp.Message);
            }
        }

    }
}
