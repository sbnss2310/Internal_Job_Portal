using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobPostMVC.Models;
using JobPostRepository;




namespace JobPostMVC.Controllers
{
    
    public class JobPostController : Controller
    {
        JobPostClientRepo postClient = new JobPostClientRepo();
        // GET: JobPost



        [NonAction]
        public static async Task<List<SelectListItem>> GetJobIds()
        {
            JobRepoAsync jobRepo = new JobRepoAsync();
            List<Job> jobs = await jobRepo.GetAllJobsAsync();
            List<SelectListItem> jids = new List<SelectListItem>();
            foreach (Job job in jobs)
            {
                jids.Add(new SelectListItem { Text = job.JobId, Value = job.JobId });
            }
            return jids;
        }
        public async Task<ActionResult> Index()
        {
            List<JobPost> jobPosts = await postClient.GetAllJobPostsAsync();
            return View(jobPosts);
        }



        // GET: JobPost/Details/5
        public async Task<ActionResult> Details(string PostId)
        {
            JobPost jobPost = await postClient.GetJobPostByIdAsync(PostId);
            return View(jobPost);
        }



        // GET: JobPost/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: JobPost/Create
        [HttpPost]
        public async Task<ActionResult> Create(JobPost jobPost)
        {
            try
            {
                // TODO: Add insert logic here
                await postClient.InsertJobPostAsync(jobPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: JobPost/Edit/5
        public async Task<ActionResult> Edit(string PostId)
        {
            JobPost jobPost = await postClient.GetJobPostByIdAsync(PostId);
            return View(jobPost);
        }



        // POST: JobPost/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string PostId, JobPost jobPost)
        {
            try
            {
                // TODO: Add update logic here
                await postClient.UpdateJobPostAsync(PostId, jobPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: JobPost/Delete/5
        public async Task<ActionResult> Delete(string PostId)
        {
            JobPost jobPost = await postClient.GetJobPostByIdAsync(PostId);
            return View(jobPost);
        }



        // POST: JobPost/Delete/5
        [HttpPost]
        public async  Task<ActionResult> Delete(string PostId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                await postClient.DeleteJobPostAsync(PostId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


