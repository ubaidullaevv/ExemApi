using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Npgsql; 
using Dapper;
using System.Net;

namespace Services;

public class JobService(DapperContext _context) : IJobService
{
    public async Task<Response<bool>> AddJob(Job job)
    {
        using var context=_context.Connection();
        string cmd="insert into Jobs(userid,title,description,salary,country,city,status,createdat,updatedat)values(@UserId,@Title,@Description,@Salary,@Country,@City,@Status,@CreatedAt,@UpdatedAt)";
        var res=await context.ExecuteAsync(cmd,job);
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteJob(int id)
    {
        using var context=_context.Connection();
        string cmd="delete from Jobs where Jobid=@JobId";
        var res=await context.ExecuteAsync(cmd,new {Jobid=id});
        if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<bool>(res>0);  
    }

    public async Task<Response<Job>> GetAvarageSalary(Job job)
    {
        using var context=_context.Connection();
        string cmd="select avg(salary) as salary_avg from jobs group by title";
        var res=await context.QueryFirstOrDefaultAsync<Job>(cmd,job);
        if(res==null) return new Response<Job>(HttpStatusCode.NotFound,"Client Eror!");
        return new Response<Job>(res);  
    }


    

    public async Task<Response<Job>> GetJobById(int id)
    {
        using var context=_context.Connection();
        string cmd="select * from Jobs where Jobid=@JobId";
        var res=await context.QueryFirstOrDefaultAsync<Job>(cmd , new {JobId=id});
        if(res==null) return new Response<Job>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<Job>(res);  
    }

    public async Task<Response<List<Job>>> GetJobs()
    {
        using var context=_context.Connection();
        string cmd="select * from Jobs";
        var res=(await context.QueryAsync<Job>(cmd)).ToList();
        if(res==null) return new Response<List<Job>>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<List<Job>>(res);  
    }

    public async Task<Response<List<Job>>> GetLastJobs()
    {
         using var context=_context.Connection();
        string cmd="select * from Jobs order by desc CreatedAt limit 10";
        var res=(await context.QueryAsync<List<Job>>(cmd)).ToList();
        if(res==null) return new Response<List<Job>>(HttpStatusCode.InternalServerError,"Server Eror!");
        return new Response<List<Job>>(res);
    }

    public async Task<Response<bool>> UpdateJob(Job job)
    {
       using var context=_context.Connection();
       string cmd="update Jobs set Jobid=@JobId,userid=@UserId,title=@Title,description=@Description,salary=@Salary,country=@Country,city=@City,status=@Status,createdat=@CreatedAt,updatedat=@UpdatedAt";
       var res=await context.ExecuteAsync(cmd,job);
       if(res==0) return new Response<bool>(HttpStatusCode.NotFound,"Cannot found Job!");
       return new Response<bool>(res>0);
    }
}
 