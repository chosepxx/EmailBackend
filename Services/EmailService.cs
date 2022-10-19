using System.Collections.Generic;
using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class EmailService : IEmail
    {
        DataEmail dE = new DataEmail();
        public List<Email> getPersonEmails(int id){
            return dE.List(id);

        }

        public string crudActions(List<Crud> data){
            foreach (var item in data)
            {   
                dE.cruds(item);
            }
            return "OK";
        }
        

    }
}