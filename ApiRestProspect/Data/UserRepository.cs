using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestProspect.Models;

namespace ApiRestProspect.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("Context");

        }


        private object MapModelUser(SqlDataReader reader)
        {

            if(reader == null)
            {
                return null;
                               
            }
            else
            {
                var model = new
                {
                    user_name = reader["user_name"].ToString(),
                    user_password = reader["user_password"].ToString(),
                    
                };
                return model;
            }

        }


        public async Task<object> GetLogin(string user_name, string user_password)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spLogin", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@user_name", user_name));
                    cmd.Parameters.Add(new SqlParameter("@user_password",user_password));
                    var response = new List<object>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapModelUser(reader));
                        }
                    }
                    return response;
                }
            }
        }
    }
}
