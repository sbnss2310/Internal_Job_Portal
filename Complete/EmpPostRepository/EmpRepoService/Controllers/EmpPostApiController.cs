using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmpPostRepository;
using EmpPostRepository.Repos;

namespace EmpRepoService.Controllers
{
    public class EmpPostApiController : ApiController
    {
        IEmpRepo repo = new EmpRepo();
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmpPost> post = await repo.GetAllPostsAsync();
            return Ok<List<EmpPost>>(post);
        }
        [HttpGet]
        [Route("api/emppostapi/get/{postId}/{EmpId}")]
        public async Task<IHttpActionResult> GetOne(string PostId, string EmpId)
        {
            try
            {
                EmpPost ePost = await repo.GetApplicationbyIdAsync(PostId,EmpId);

                return Ok(ePost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("not found");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/emppostapi/getlist/{EmpId}")]
        public async Task<IHttpActionResult> GetListofPosts(string EmpId)
        {
            try
            {
               List<EmpPost> ePost = await repo.GetPostsByEmpIdAsync(EmpId);

                return Ok<List<EmpPost>>(ePost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("not found");
                return BadRequest(ex.Message);
            }
        }
        /*public async Task<IHttpActionResult> GetListofPosts()
        {
            try
            {
                List<Post> posts = await repo.

                return Ok<List<EmpPost>>(ePost);
            }
            catch (Exception ex)
            {
                Console.WriteLine("not found");
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost]
        public async Task<IHttpActionResult> Post(EmpPost empPost)
        {

            await repo.InsertPostAsync(empPost);
            return Created<EmpPost>("/api/empPostApi", empPost);

        }
        [HttpPut]
        [Route("api/emppostapi/update/{postId}/{EmpId}")]
        public async Task<IHttpActionResult> Update(string postId, string EmpId,EmpPost empPost)
        {
            await repo.UpdatePostAsync(postId,EmpId, empPost);
            return Ok(empPost);
        }
        [HttpDelete]
        [Route("api/emppostapi/delete/{postId}/{EmpId}")]
        public async Task<IHttpActionResult> Delete(string postId, string EmpId)
        {
            await repo.DeletePostAsync(postId, EmpId);
            return Ok();
        }

    }
}
