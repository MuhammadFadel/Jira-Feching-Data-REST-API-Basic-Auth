using QRG.Models;
using QRG.Services.IServices;

namespace QRG.Services
{
    public class GitlabProjectService : BaseService, IGitlabProjectService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitlabProjectService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetProjectByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects/" + id ,
                AccessToken = token
            });
        }

        public async Task<T> GetProjectsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.GitlabApiBase + "projects" + "?owned=true",
                AccessToken = token
            });
        }
    }
}
