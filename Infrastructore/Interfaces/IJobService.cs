using Domain.Models;
using Infrastructore.Responses;
namespace Infrastructore.Interfaces;

public interface IJobService
{
    public Task<Response<List<Job>>> GetJobs();
    public Task<Response<bool>> AddJob(Job job);
    public Task<Response<bool>> DeleteJob(int id);
    public Task<Response<bool>> UpdateJob(Job job);
    public Task<Response<Job>> GetJobById(int id);
    public Task<Response<Job>> GetAvarageSalary(Job job);
    public Task<Response<List<Job>>> GetLastJobs();
}