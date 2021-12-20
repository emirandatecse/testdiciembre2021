using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TipoCambio.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        public TokenController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<JsonResult> GetTokenGenerate()
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken("emirandatecse@email.com");
            var jsonString = new JsonResult(token);
            return jsonString;
        }
    }
}
