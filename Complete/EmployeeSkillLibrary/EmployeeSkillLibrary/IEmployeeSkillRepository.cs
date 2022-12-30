using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillLibrary
{
    public interface IEmployeeSkillRepository
    {
       
            Task<List<EmpSkill>> GetAllEmployeeskillsAsync();
            Task<List<Skill>> GetAllSkills();
            Task<Skill> GetSkillBySkillIdAsync(string skillId);
            Task<List<EmpSkill>> GetSkillsByEmployeeIdAsync(string empId);
            Task InsertEmployeeSkillAsync(EmpSkill empSkill);
            Task UpdateEmployeeSkillAsync(string skillId, string empId, EmpSkill empSkill);
            Task DeleteEmployeeSkillAsync(string skillId, string empId);
            Task <List<EmpSkill>> GetSkillByEmployeeIdAndSkillIdAsync(string skillId, string empId);

    }
}
