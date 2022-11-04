using ApiService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public interface IToolRepository
    {
        Task<IEnumerable<Tool>> Get();
        Task<Tool> Get(int id);
        Task<Tool> Create(Tool tool);
        Task Update(Tool tool);
        Task Delete(int id);
    }
}
