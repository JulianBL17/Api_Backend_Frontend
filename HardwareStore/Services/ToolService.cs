using HardwareStore.Models;
using Microsoft.AspNetCore.Components;

namespace HardwareStore.Services
{
    public class ToolService : IToolService
    {
        private readonly HttpClient httpClient;

        public ToolService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
       
        async Task<List<Tool>> IToolService.getTools()
        {
            return await httpClient.GetFromJsonAsync<List<Tool>>("api/Tools");

        }
    }
}