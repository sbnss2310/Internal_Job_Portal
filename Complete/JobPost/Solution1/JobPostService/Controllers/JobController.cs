using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobPostRepository;
using System.Threading.Tasks;



namespace JobPostService.Controllers
{
    public class JobController : ApiController
    {
        IJobRepoAsync jobRepo = new JobRepoAsync();
        [HttpGet]
        public async Task<IHttpActionResult> GetAllJobsAsync()
        {
            List<Job> jobs = await jobRepo.GetAllJobsAsync();
            return Ok(jobs);
        }
    }
}