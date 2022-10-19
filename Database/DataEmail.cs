using apiPersonaNet.Models;
using apiPersonaNet.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace apiPersonaNet.Database
{
     public class DataEmail : DBConnection
    {
        public DataEmail() { }

           public List<Email> List(int id){
            var list = new List<Email>();
            using (var sqlconn = new SqlConnection(getConnection())){
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_getPersonEmail, sqlconn);
                cmd.Parameters.AddWithValue("id",id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Email tmp = new Email();
                        tmp.EmailAddress = res["EmailAddress"].ToString();
                        tmp.EmailAddressID = Convert.ToInt32(res["EmailAddressID"]);

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }
    


           public string cruds(Crud actions){
            var json_actions = JsonConvert.SerializeObject(actions);
            using (var sqlconn = new SqlConnection(getConnection())){
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_crudEmail, sqlconn);
                cmd.Parameters.AddWithValue("json",json_actions);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                 
                    
                }
            }
            return "OK";
        }
}
}