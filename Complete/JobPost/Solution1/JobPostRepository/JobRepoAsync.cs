using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JobPostRepository
{
    public class JobRepoAsync : IJobRepoAsync
    {
        JobPostsDBEntities jobEntity = new JobPostsDBEntities();
        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> jobs = await jobEntity.Jobs.ToListAsync();
            return jobs;
        }
    }
}