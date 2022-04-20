using QRG.Models;
using QRG.Services.IServices;

namespace QRG.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetProjectByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,                
                ApiUrl = SD.JiraApiBase + "project/" + id + "?expand=description,lead",
                AccessToken = token
            });
        }

        public async Task<T> GetProjectsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,                
                ApiUrl = SD.JiraApiBase + "project/recent?expand=lead",
                AccessToken = token
            });
        }
    }        
}
