using apiSecurity.Models;
using apiSecurity.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace apiSecurity.Database
{
    public class DataRoles
    {
        public DataRoles() { }

        public List<Roles> List(LoginCredentials login){
            var json_ids = JsonConvert.SerializeObject(login);
            var list = new List<Roles>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection())){
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_verify_user_roles, sqlconn);
                cmd.Parameters.AddWithValue("user_information", json_ids);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Roles tmp = new Roles();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.IdRole = Convert.ToInt32(res["IdRole"]);
                        tmp.Name = res["Name"].ToString();
                        tmp.Acronym = res["Acronym"].ToString();
                        tmp.IdPermission = Convert.ToInt32(res["IdPermission"]);
                        tmp.SpaName = res["SpaName"].ToString();
                        list.Add(tmp);
                    }
                }
                 sqlconn.Close();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
            }
           
            return list;
        }
    }
}