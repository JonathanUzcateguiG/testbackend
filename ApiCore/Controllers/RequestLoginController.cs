using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hogwarts.Domain.Model.RequestLogin;
using Hogwarts.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLoginController : ControllerBase
    {
        private readonly IRequestLoginService _requestLoginService;

        public RequestLoginController(IRequestLoginService requestLoginService) : base()
        {
            _requestLoginService = requestLoginService;
        }

        [Route("[action]")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RequestLoginModel))]
        public async Task<ActionResult<List<RequestLoginModel>>> GetAll()
        {
            var requestLoginList = await _requestLoginService.FindAllRequestLogin();
            return Ok(requestLoginList);
        }

        [Route("[action]")]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RequestLoginModel))]
        public async Task<ActionResult<RequestLoginModel>> Post([FromBody] CreateRequestLoginDto createRequestLoginDto)
        {
            var requestLogin = await _requestLoginService.Create(createRequestLoginDto);

            return Ok(requestLogin);
        }

        [Route("[action]")]
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RequestLoginModel))]
        public async Task<ActionResult<RequestLoginModel>> Put([FromBody] UpdateRequestLoginDto updateRequestLoginDto)
        {
            var requestLogin = await _requestLoginService.Update(updateRequestLoginDto);

            return Ok(requestLogin);
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<ActionResult<RequestLoginModel>> Delete([FromQuery] int id)
        {
            var requestLogin = await _requestLoginService.Delete(id);
            return Ok(requestLogin);
        }
    }
}
