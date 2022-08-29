using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using RegisterAndLoginProj.Models;
using System.Data.SqlClient;

namespace RegisterAndLoginProj.Services
{
    public class UserDAO
    {
        bool success = false;
        string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public bool FindUserByNameAndPassword(UserModel user)
        {
            /* return true if found in the db
            Find documentation for all this stuff in microsoft docs undet
            SqlCommand.Parameters Property
            */
            string sqlStatement = @"Select * from dbo.Users where UserName = @username AND Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);

                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        success = true;
                       //System.Windows.Forms.MessageBox.Show("Test");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return success;
        }
    }

}
