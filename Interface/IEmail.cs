using System;
using apiPersonaNet.Models;

public interface IEmail
{
    List<Email> getPersonEmails(int id);
    
    String crudActions(List<Crud> actions);
}