using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JobPostRepository
{
    public interface IJobPostRepoAsync
    {
        Task InsertJobPost(JobPost jobPost);
        Task UpdateJobPost(string postId, JobPost jobPost);
        Task DeleteJobPost(string postId);
        Task<List<JobPost>> viewPosts();
        Task<JobPost> GetSinglePost(string postId);
    }
}