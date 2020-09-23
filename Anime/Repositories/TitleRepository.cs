using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anime.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Anime.Repositories
{
    public class TitleRepository : ITitleRepository

    {
        private readonly IConfiguration _config;

        public TitleRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Title> GetTitles()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT Id, [Name], ImageUrl, Notes
FROM Title";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Title> titles = new List<Title>();
                    while (reader.Read())
                    {
                        Title title = new Title
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        titles.Add(title);
                    }
                    reader.Close();
                    return titles;
                }
            }
        }
        public Title GetTitleById(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
SELECT Id, [Name], ImageUrl, Notes
FROM Title 
WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Title title = new Title
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        reader.Close();
                        return title;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

    }
}
