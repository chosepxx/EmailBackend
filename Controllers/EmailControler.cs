using System.Collections.Generic;
using System.Net;
using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmail emailService;
        public EmailController (IEmail emailService){
             this.emailService = emailService;
        }

        [HttpPost("crud")]
        public String ListByYear([FromBody] List<Crud> actions)
        {
          
            return emailService.crudActions(actions);
        }
    }
}