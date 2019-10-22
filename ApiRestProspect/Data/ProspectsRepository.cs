using ApiRestProspect.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Data
{
    public class ProspectsRepository
    {
        private readonly string _connectionString;

        public ProspectsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("Context");
        }

        private object MapProspect(SqlDataReader reader)
        {
            var model = new
            {
                prospect_id = (int)reader["prospect_id"],
                prospect_name = reader["prospect_Name"].ToString(),
                prospect_lastname = reader["prospect_lastname"].ToString(),
                prospect_birthday = (DateTime)reader["prospect_birthday"],
                city_id = reader["city_Id"].ToString(),
                prospect_address= reader["prospect_address"].ToString(),
                prospect_phonenumber= reader["prospect_phonenumber"].ToString(),
                prospect_cv= reader["prospect_cv"].ToString(),
                prospect_photo= reader["prospect_photo"].ToString(),
                prospect_link= reader["prospect_link"].ToString(),
                prospect_salary= (int)reader["prospect_salary"],
                title_id= reader["title_id"].ToString()
            };
            return model;
        }
        public async Task<object> GetById(long? Id, long? ExperienceYears)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProspects", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@ProspectId", Id));
                    var response = new List<object>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapProspect(reader));
                        }
                    }
                    return response;
                }
            }
        }
    }
}
