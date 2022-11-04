using System.Threading.Tasks;
using System.Collections.Generic;
using HardwareStore.Models;

namespace HardwareStore.Services
{
    public interface IToolService
    {
        Task<List<Tool>> getTools();
    }
}