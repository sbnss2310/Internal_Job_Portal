using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using JobPostRepository;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace JobPostService.Controllers
{
    public class JobPostApiController : ApiController
    {
        IJobPostRepoAsync jobPostRepo = new JobPostRepoAsync();
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<JobPost> JobPosts = await jobPostRepo.viewPosts();
            return Ok(JobPosts);
        }
        [HttpGet]
        [Route("api/JobPostApi/GetOne/{PostId}")]
        public async Task<IHttpActionResult> GetOne(string PostId)
        {
            try
            {
                JobPost jobPost = await jobPostRepo.GetSinglePost(PostId);
                return Ok(jobPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("not found");
                return BadRequest(ex.Message);
            }
        }
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "JobPosts", routingKey: integrationEvent, basicProperties: null, body: body);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(JobPost jobPost)
        {
            await jobPostRepo.InsertJobPost(jobPost);
            var integrationEventData = JsonConvert.SerializeObject(new { PostId = jobPost.PostId });
            PublishToMessageQueue("jobposts.add", integrationEventData);
            return Created<JobPost>("/api/JobPostApi", jobPost);

        }
        [HttpPut]
        [Route("api/JobPostApi/{PostId}")]
        public async Task<IHttpActionResult> Update(string PostId, JobPost jobPost)
        {
            await jobPostRepo.UpdateJobPost(PostId, jobPost);
            return Ok(jobPost);
        }
        [HttpDelete]
        [Route("api/JobPostApi/delete/{PostId}")]
        public async Task<IHttpActionResult> Delete(string PostId)
        {
            await jobPostRepo.DeleteJobPost(PostId);
            return Ok();
        }



    }
}