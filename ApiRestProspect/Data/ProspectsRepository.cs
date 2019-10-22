﻿using ApiRestProspect.Models;
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
        public async Task<object> GetAll(long? Id, long? Age_Min, long? Age_Max,
                                long? Salary_Min, long? Salary_Max)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProspects", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@prospect_id", Id));
                    cmd.Parameters.Add(new SqlParameter("@age_min", Age_Min));
                    cmd.Parameters.Add(new SqlParameter("@age_max", Age_Max));
                    cmd.Parameters.Add(new SqlParameter("@salary_min", Salary_Min));
                    cmd.Parameters.Add(new SqlParameter("@salary_max", Salary_Max));
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
        public async Task<object> PostProspect(Prospect item)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertProspects", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@prospect_name", item.prospect_name));
                    cmd.Parameters.Add(new SqlParameter("@prospect_lastname", item.prospect_lastname));
                    cmd.Parameters.Add(new SqlParameter("@prospect_birthday", item.prospect_birthday));
                    cmd.Parameters.Add(new SqlParameter("@city_id", item.city_id));
                    cmd.Parameters.Add(new SqlParameter("@prospect_address", item.prospect_address));
                    cmd.Parameters.Add(new SqlParameter("@prospect_phonenumber", item.prospect_phonenumber));
                    cmd.Parameters.Add(new SqlParameter("@prospect_cv", item.prospect_cv));
                    cmd.Parameters.Add(new SqlParameter("@prospect_photo", item.prospect_photo));
                    cmd.Parameters.Add(new SqlParameter("@prospect_link", item.prospect_link));
                    cmd.Parameters.Add(new SqlParameter("@prospect_salary", item.prospect_salary));
                    cmd.Parameters.Add(new SqlParameter("@title_id", item.title_id));
                    
                    var response = new List<object>();
                    await sql.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();
                    return response;
                }
            }
        }
        public async Task<object> PutProspect(Prospect item)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProspect", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@prospect_id", item.prospect_id));
                    cmd.Parameters.Add(new SqlParameter("@prospect_name", item.prospect_name));
                    cmd.Parameters.Add(new SqlParameter("@prospect_lastname", item.prospect_lastname));
                    cmd.Parameters.Add(new SqlParameter("@prospect_birthday", item.prospect_birthday));
                    cmd.Parameters.Add(new SqlParameter("@city_id", item.city_id));
                    cmd.Parameters.Add(new SqlParameter("@prospect_address", item.prospect_address));
                    cmd.Parameters.Add(new SqlParameter("@prospect_phonenumber", item.prospect_phonenumber));
                    cmd.Parameters.Add(new SqlParameter("@prospect_cv", item.prospect_cv));
                    cmd.Parameters.Add(new SqlParameter("@prospect_photo", item.prospect_photo));
                    cmd.Parameters.Add(new SqlParameter("@prospect_link", item.prospect_link));
                    cmd.Parameters.Add(new SqlParameter("@prospect_salary", item.prospect_salary));
                    cmd.Parameters.Add(new SqlParameter("@title_id", item.title_id));

                    var response = new List<object>();
                    await sql.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();
                    return response;
                }
            }
        }
    }
}
