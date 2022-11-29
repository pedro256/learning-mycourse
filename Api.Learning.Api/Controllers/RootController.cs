using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Api.Learning.MyCourse.Dtos;

namespace Api.Learning.MyCourse.Controllers
{
    [ApiController]
    [Route("/api/root")]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public LifeResponseDto Get()
        {
            LifeResponseDto response = new LifeResponseDto();
            response.Name = "Api Course";
            response.Version = "1.1.2";
            response.Life = true;

            return response;
        }
    }
}
