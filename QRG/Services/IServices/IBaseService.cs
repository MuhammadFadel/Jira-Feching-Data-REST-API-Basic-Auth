using QRG.Models;

namespace QRG.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto _responseDto { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
