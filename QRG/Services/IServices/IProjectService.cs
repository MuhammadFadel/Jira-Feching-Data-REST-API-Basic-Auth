namespace QRG.Services.IServices
{
    public interface IProjectService
    {
        Task<T> GetProjectByIdAsync<T>(int id, string token);
        Task<T> GetProjectsAsync<T>(string token);
    }
}
