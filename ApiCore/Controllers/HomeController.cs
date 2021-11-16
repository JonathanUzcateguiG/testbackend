using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hogwarts.Domain.Model.Home;
using Hogwarts.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiCore.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService) : base()
        {
            _homeService = homeService;
        }

        [Route("[action]")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(HomeModel))]
        public async Task<ActionResult<List<HomeModel>>> GetAll()
        {
            var homeList = await _homeService.FindAllHome();
            return Ok(homeList);
        }
    }
}
