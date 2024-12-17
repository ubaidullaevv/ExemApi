using Domain.Models;
using Infrastructore.Responses;
namespace Infrastructore.Interfaces;

public interface IApplicationService
{
    public Task<Response<List<Application>>> GetApplications();
    public Task<Response<bool>> AddApplication(Application application);
    public Task<Response<bool>> DeleteApplication(int id);
    public Task<Response<bool>> UpdateApplication(Application application);
    public Task<Response<Application>> GetApplicationById(int id);
    public Task<Response<List<Application>>> GetApplicationByStatus(string status);
}