using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Infrastructore.Context;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController(IApplicationService ApplicationService):ControllerBase
{
 [HttpPost]
 public async Task<Response<bool>> Add(Application application)
 {
    var response= await ApplicationService.AddApplication(application);
    return response;
 }
 [HttpGet]
 public async Task<Response<List<Application>>> GetAll()
 {
    var response=await ApplicationService.GetApplications();
    return response;
 }
 [HttpPut]
 public async Task<Response<bool>> Update(Application application)
 {
    var response= await ApplicationService.UpdateApplication(application);
    return response;
 }
 [HttpGet("get-by-id")]
 public async Task<Response<Application>> GetById(int id)
 {
    var response= await ApplicationService.GetApplicationById(id);
    return response;
 }
 [HttpDelete]
 public async Task<Response<bool>> Delete(int id)
 {
    var response=await ApplicationService.DeleteApplication(id);
    return response;
 }
 [HttpGet("get-by-status")]
 public async Task<Response<List<Application>>> GetByStatus(string status)
 {
    var res=ApplicationService.GetApplicationByStatus(status);
    return res;
 }
}