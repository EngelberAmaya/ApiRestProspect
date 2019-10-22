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
                SoftwareID = (long)reader["prospect_id"],
                softwareName = reader["SoftwareName"].ToString(),
                HardwareID = (long)reader["HardwareID"],
                hardwareName = reader["HardwareName"].ToString()
            };
            return model;
        }
        public async Task<object> GetById(long Id, long ExperienceYears)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProspects", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProspectId", Id));
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
