using ApiRestProspect.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestProspect.Data
{
    public class SoftwareRepository
    {
        private readonly string _connectionString;
       // string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=prospect;Trusted_Connection=True;";

        public SoftwareRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("Context");
           // _connectionString = configuration.GetConnectionString("Context");
        }

        private object MapModelSoftware(SqlDataReader reader)
        {
            var model = new
            {
                software_id = (long)reader["software_id"],
                software_name = reader["software_name"].ToString(),
            };
            return model;
        }

        public async Task InsertSoftware(Software software)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertSoftware", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@software_name", software.software_name));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task UpdateSoftware(int software_id, Software software)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateSoftware", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@software_id", software.software_id));
                    cmd.Parameters.Add(new SqlParameter("@software_name", software.software_name));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
        public async Task DeletedSoftware(int software_id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spdeleteSoftware", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@software_id", software_id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }
    }
}