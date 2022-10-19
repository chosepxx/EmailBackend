using System.Collections.Generic;
using System.Net;
using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson services;
        private readonly IEmail emailService;
        public PersonController (IPerson services,IEmail emailService){
            this.services = services;
             this.emailService = emailService;
        }

        [HttpPost("ids")]
        public List<PersonInfo> ListByYear([FromBody] int[] ids)
        {
            Console.WriteLine("ingreso peticion");
            Console.WriteLine(JsonConvert.SerializeObject(ids));
            return services.getPersonList(ids);
        }

        [HttpGet("top100")]
        public List<PersonInfo> List()
        {
            Console.WriteLine("ingreso peticion");
            return services.getTop100List();
        }


        [HttpPost("auth")]
        public string Auth([FromBody] LoginCredentials auth)
        {
            UserModel um =  services.auth(auth);
            var json_auth = JsonConvert.SerializeObject(um);
            return json_auth;
            
        }

         [HttpGet("email/{id}")]
        public List<Email> emailList([FromRoute] int id)
        {
            Console.WriteLine(id);
           return emailService.getPersonEmails(id);
            
        }

        [HttpGet("/")]
        public string index()
        {
            string info = "Api person online";
            return info;
        }
    }
}
