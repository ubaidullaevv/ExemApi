using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Infrastructore.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class JobController(IJobService JobService):ControllerBase
{
 [HttpPost]
 public async Task<Response<bool>> Add(Job job)
 {
    var response= await JobService.AddJob(job);
    return response;
 }
 [HttpGet]
 public async Task<Response<List<Job>>> GetAll()
 {
    var response=await JobService.GetJobs();
    return response;
 }
 [HttpPut]
 public async Task<Response<bool>> Update(Job job)
 {
    var response= await JobService.UpdateJob(job);
    return response;
 }
 [HttpGet("get-by-id")]
 public async Task<Response<Job>> GetById(int id)
 {
    var response= await JobService.GetJobById(id);
    return response;
 }
 [HttpDelete]
 public async Task<Response<bool>> Delete(int id)
 {
    var response=await JobService.DeleteJob(id);
    return response;
 }
}