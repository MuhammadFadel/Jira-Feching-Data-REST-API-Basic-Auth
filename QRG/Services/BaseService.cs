using Newtonsoft.Json;
using QRG.Models;
using QRG.Services.IServices;
using System.Net.Http.Headers;
using System.Text;

namespace QRG.Services
{
    public class BaseService : IBaseService
    {       
        public ResponseDto _responseDto { get; set; }
        public IHttpClientFactory _httpClientFactory { get; set; }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _responseDto = new ResponseDto();
        }

        public void Dispose()
        {            
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("QRGDemo");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);                
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization =                        
                        new AuthenticationHeaderValue("Basic", apiRequest.AccessToken);
                }

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                if(apiResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(apiResponse.StatusCode.ToString()); 

                var apiContent = await apiResponse.Content.ReadAsStringAsync();                
                var responseDto = new ResponseDto
                {
                    Result = apiContent,
                    DisplayMessage = "",
                    ErrorMessage = new List<string>(),
                    IsSuccess = true
                };
                var res = JsonConvert.SerializeObject(responseDto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;                
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { ex.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(responseDto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }

        }
    }
}
