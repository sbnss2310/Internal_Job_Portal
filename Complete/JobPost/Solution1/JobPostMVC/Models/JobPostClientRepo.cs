using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JobPostRepository;
using Newtonsoft.Json;



namespace JobPostMVC.Models
{
    public class JobPostClientRepo
    {
        public HttpClient webApi;
        public JobPostClientRepo()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:51768/api/JobPostApi/");
        }
        
        public async Task DeleteJobPostAsync(string PostId)
        {
            await webApi.DeleteAsync("delete/" + PostId);
        }

        public async Task<List<JobPost>> GetAllJobPostsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<JobPost> jobPosts = JsonConvert.DeserializeObject<List<JobPost>>(str);
            return jobPosts;
        }





        public async Task<JobPost> GetJobPostByIdAsync(string PostId)
        {
            try
            {
                HttpResponseMessage response = await webApi.GetAsync("GetOne/" + PostId);
                string str = await response.Content.ReadAsStringAsync();
                JobPost jobPost = JsonConvert.DeserializeObject<JobPost>(str);
                return jobPost;
            }
            catch (Exception)
            {
                throw new Exception("No such job post");
            }
        }





        public async Task InsertJobPostAsync(JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);



        }





        public async Task UpdateJobPostAsync(string PostId, JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + PostId, data);
        }
    }
}