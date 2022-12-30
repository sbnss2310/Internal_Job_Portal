using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpPostMVC.Models;
using EmpPostRepository;
using EmpPostRepository.Repos;

namespace EmpPostMVC.Controllers
{
    public class EmpPostMVCController : Controller
    {

        EmpPostClient client = new EmpPostClient();

        // GET: EmpPostMVC
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<EmpPost> posts =await  client.GetAllEmpPost();
            return View(posts);
        }

        // GET: EmpPostMVC/Details/5
        [HttpGet]
        [Route("EmpPost/Details/{postId}/{EmpId}")]
        public async Task<ActionResult> Details(string EmpId)
        {
            List<EmpPost> post = await client.GetAllEmpPostVthEmpId(EmpId);
            
            return View(post);
        }

        // GET: EmpPostMVC/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmpPostMVC/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmpPost empPost)
        {
            try
            {
                
                await client.InsertEmpAsync(empPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpPostMVC/Edit/5
        [Route("EmpPost/Edit/{postId}/{EmpId}")]
        public async  Task<ActionResult> Edit(string PostId, string EmpId)
        {
            EmpPost empPost = await client.GetApplicationById(PostId, EmpId);
            return View(empPost);
        }

        // POST: EmpPostMVC/Edit/5
        [HttpPost]
        [Route("EmpPost/Edit/{postId}/{EmpId}")]
        public async Task<ActionResult> Edit(string postId,string EmpId,  EmpPost empPost)
        {
            try
            {
                await client.UpdateEmpAsync(postId,EmpId,  empPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpPostMVC/Delete/5
        public async Task<ActionResult> Delete(string postId, string EmpId)
        {
            EmpPost empPost = await client.GetApplicationById(postId, EmpId);
            return View(empPost);
        }

        // POST: EmpPostMVC/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string postId,string EmpId , EmpPost empPost)
        {
            try
            {
                await client.DeleteEmpAsync(postId, EmpId);
                return RedirectToAction("Index");
            }
            catch { return View();
            }
        }
        [NonAction]
        public static async Task<List<SelectListItem>> GetPostIds()
        {
            EmpRepo empRepo = new EmpRepo();
            List<Post> posts = await empRepo.GetAllPostsDD();
            List<SelectListItem> pids = new List<SelectListItem>();
            foreach (Post post in posts)
            {
                pids.Add(new SelectListItem { Text = post.PostId, Value = post.PostId });
            }
            return pids;
        }
    }
}
