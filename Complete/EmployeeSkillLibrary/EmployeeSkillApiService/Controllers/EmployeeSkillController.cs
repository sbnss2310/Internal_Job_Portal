using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmployeeSkillLibrary;

namespace EmployeeSkillApiService.Controllers
{
    public class EmployeeSkillController : ApiController
    {
        IEmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository();
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmpSkill> empSkills = await employeeSkillRepository.GetAllEmployeeskillsAsync();
            return Ok<List<EmpSkill>>(empSkills);
        }



        [HttpGet]
        [Route("api/EmployeeSkill/BySkill/{skillId}")]
        public async Task<IHttpActionResult> GetSkillsBySkillId(String skillId)
        {
            Skill skill = await employeeSkillRepository.GetSkillBySkillIdAsync(skillId);



            return Ok<Skill>(skill);




        }
        [HttpGet]
        [Route("api/EmployeeSkill/{empId}")]
        public async Task<IHttpActionResult> GetSkillsByEmpId(string empId)
        {
            List<EmpSkill> empSkills = await employeeSkillRepository.GetSkillsByEmployeeIdAsync(empId);
            return Ok<List<EmpSkill>>(empSkills);
        }



        [HttpGet]
        [Route("api/EmployeeSkill/{skillId}/{empId}")]



        public async Task<IHttpActionResult> GetEmployeeSkillByBoth(string skillId, string empId)
        {
            List<EmpSkill> empSkill = await employeeSkillRepository.GetSkillByEmployeeIdAndSkillIdAsync(skillId, empId);
            return Ok<List<EmpSkill>>(empSkill);



        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(EmpSkill empSkill)
        {
            await employeeSkillRepository.InsertEmployeeSkillAsync(empSkill);
            return Created("api/EmployeeSkill", empSkill);



        }
        [HttpPut]
        [Route("api/EmployeeSkill/{skillId}/{empId}")]
        public async Task<IHttpActionResult> Update(string skillId, string empId, EmpSkill empSkill)
        {
            await employeeSkillRepository.UpdateEmployeeSkillAsync(skillId, empId, empSkill);
            return Ok<EmpSkill>(empSkill);
        }



        [HttpDelete]
        [Route("api/EmployeeSkill/Delete/{skillId}/{empId}")]
        public async Task<IHttpActionResult> Delete(string skillId, string empId)
        {
            await employeeSkillRepository.DeleteEmployeeSkillAsync(skillId, empId);
            return Ok();
        }
    }

}

