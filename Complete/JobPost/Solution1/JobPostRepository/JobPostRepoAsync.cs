using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JobPostRepository
{
    public class JobPostRepoAsync : IJobPostRepoAsync
    {
        JobPostsDBEntities dBEntities = new JobPostsDBEntities();
        public async Task DeleteJobPost(string postId)
        {
            JobPost jobPost = await GetSinglePost(postId);
            dBEntities.JobPosts.Remove(jobPost);
            await dBEntities.SaveChangesAsync();
        }



        public async Task<JobPost> GetSinglePost(string postId)
        {
            JobPost jobPost = await dBEntities.JobPosts.FindAsync(postId);
            return jobPost;
        }



        public async Task InsertJobPost(JobPost jobPost)
        {
            dBEntities.JobPosts.Add(jobPost);
            await dBEntities.SaveChangesAsync();



        }



        public async Task UpdateJobPost(string postId, JobPost jobPost)
        {
            JobPost jobPost1 = await GetSinglePost(postId);
            jobPost1.JobId = jobPost.JobId;
            jobPost1.LastDate = jobPost.LastDate;
            jobPost1.Vacancies = jobPost.Vacancies;
            await dBEntities.SaveChangesAsync();



        }



        public async Task<List<JobPost>> viewPosts()
        {
            List<JobPost> posts = await dBEntities.JobPosts.ToListAsync();
            return posts;
        }
    }
}