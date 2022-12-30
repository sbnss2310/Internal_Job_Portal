using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeeSkillMVC.Models;
using EmployeeSkillLibrary;

namespace EmployeeSkillMVC.Controllers
{
    public class EmployeeSkillController : Controller
    {
        EmployeeSkillClient client = new EmployeeSkillClient();
        // GET: EmployeeSkill
        public async Task<ActionResult> Index()
        {
           List<EmpSkill> empSkills=   await client.GetAllEmployeeSkillsAsync();
            return View(empSkills);
        }

        // GET: EmployeeSkill/Details/5
        public async Task<ActionResult> Details(string EmpId)
        {
            List<EmpSkill> empSkills = await client.GetEmployeeSkillsByEmployeeIdAsync(EmpId);
            return View(empSkills);
        }

        // GET: EmployeeSkill/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeSkill/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmpSkill empskill)
        {
            try
            {
               await client.InsertEmployeeSkillAsync(empskill);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeSkill/Edit/5
        public  ActionResult Edit( EmpSkill empSkill)
        {
           //List<EmpSkill> empskill =await  client.GetEmployeeSkillByEmployeeIdandSkillIdAsync(empSkill.SkillId, empSkill.EmpId);
            return View();

        }

        // POST: EmployeeSkill/Edit/5
        [HttpPost]
        [Route("/Edit/{SkillId}/{EmpId}")]
        public async Task<ActionResult> Edit(string SkillId, string EmpId, EmpSkill empSkill )
        {
            try
            {
                await client.UpdateEmployeeAsync(SkillId,EmpId, empSkill);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeSkill/Delete/5
        public ActionResult Delete(EmpSkill empSkill)
        {
           
            return View();
        }

        // POST: EmployeeSkill/Delete/5
        [HttpPost]
        [Route("/Delete/{SkillId}/{EmpId}")]
        public async Task<ActionResult> Delete(string SkillId, string EmpId, FormCollection collection)
        {
            try
            {
                await client.DeleteEmployeeSkillAsync(SkillId, EmpId);                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
