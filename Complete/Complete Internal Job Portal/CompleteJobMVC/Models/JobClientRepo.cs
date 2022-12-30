using JobPostRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JobPostMVC.Models
{
    public class JobClientRepo
    {
        public HttpClient webApi;
        public JobClientRepo()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:51768/api/Job/");
        }
        public async Task<List<Job>> GetAllJobsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
            List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(str);
            return jobs;
        }
    }
}