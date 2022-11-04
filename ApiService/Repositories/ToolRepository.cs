using ApiService.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace ApiService.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly string _connectionString;

        public ToolRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        
        public async Task<Tool> Create(Tool tool)
        {
            var sqlQuery = "INSERT INTO Tools(Name, Price, Description) VALUES (@Name, @Price, @Description)";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new 
                {
                    tool.Name,
                    tool.Price,
                    tool.Description
                });

                return tool;
            }
        }

        public async Task Delete(int id)
        {
            var sqlQuery = $"DELETE from Tools WHERE Id={id}";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery);
            }
        }

        public async Task<IEnumerable<Tool>> Get()
        {
            var sqlQuery = "SELECT * FROM Tools";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Tool>(sqlQuery);
            } 
        }

        public async Task<Tool> Get(int id)
        {
            var sqlQuery = "SELECT * FROM Tools WHERE Id=@ToolId";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Tool>(sqlQuery, new { ToolId = id });
            }
        }

        public async Task Update(Tool tool)
        {
            var sqlQuery = "UPDATE Students SET Name=@Name, Price=@Price, Description=@Description WHERE Id=@Id";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    tool.Id,
                    tool.Name,
                    tool.Price,
                    tool.Description
                });
            }
        }
    }
}