using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class ApplicationService(DapperContext _context) : IApplicationService
{
    public async Task<Response<bool>> AddApplication(Application application)
    {
        using var context=_context.Connection();
        string cmd="insert into Applications(jobid,userid,resume,status,createdat,updatedat)values(@JobId,@UserId,@Resume,@Status,@CreatedAt,@UpdatedAt)";
        var res=await context.ExecuteAsync(cmd,application);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteApplication(int id)
    {
        using var context=_context.Connection();
        string cmd="delete from Applications where Applicationid=@ApplicationId";
        var res=await context.ExecuteAsync(cmd,new {Applicationid=id});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);  
    }

    public async Task<Response<Application>> GetApplicationById(int id)
    {
        using var context=_context.Connection();
        string cmd="select * from Applications where Applicationid=@ApplicationId";
        var res=await context.QueryFirstOrDefaultAsync<Application>(cmd,new {Applicationid=id});
        if(res==null) return new Response<Application>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<Application>(res);  
    }

    public async Task<Response<List<Application>>> GetApplicationByStatus(string status)
    {
        using var context=_context.Connection();
        string cmd="select * from applications where Status=@Status";
        var res=(await context.QueryAsync<Application>(cmd,new {Status=status})).ToList();
        if(res==null) return new Response<List<Application>>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<List<Application>>(res);
    }

    public async Task<Response<List<Application>>> GetApplications()
    {
        using var context=_context.Connection();
        string cmd="select * from Applications";
        var res=(await context.QueryAsync<Application>(cmd)).ToList();
        if(res==null) return new Response<List<Application>>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<List<Application>>(res);  
    }

    public async Task<Response<bool>> UpdateApplication(Application application)
    {
       using var context=_context.Connection();
       string cmd="update Applications set applicationid=@ApplicationId,jobid=@JobId,userid=@UserId,resume=@Resume,status=@Status,createdat=@CreatedAt,updatedat=@UpdatedAt";
       var res=await context.ExecuteAsync(cmd,application);
       if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found Application!");
       return new Response<bool>(res>0);
    }
}
 