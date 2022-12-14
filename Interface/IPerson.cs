using apiPersonaNet.Models;

public interface IPerson
{
    List<PersonInfo>  getPersonList(int[] ids);
    UserModel auth(LoginCredentials auth);

    List<PersonInfo>  getTop100List();

}