using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillLibrary
{
    public class EmployeeSkillRepository : IEmployeeSkillRepository
    {
        EmployeeSkillsDBEntities EmployeeSkillsDB = new EmployeeSkillsDBEntities();
        public async Task DeleteEmployeeSkillAsync(string skillId, string empId)
        {

            List<EmpSkill> empSkill1 = await GetSkillByEmployeeIdAndSkillIdAsync(skillId, empId);
            EmpSkill emp = empSkill1.First();
            EmployeeSkillsDB.EmpSkills.Remove(emp);
            await EmployeeSkillsDB.SaveChangesAsync();
        }

        public async  Task<List<EmpSkill>> GetAllEmployeeskillsAsync()
        {
            
            List<EmpSkill> empSkills = await EmployeeSkillsDB.EmpSkills.ToListAsync();
            return empSkills;
        }

        public async Task<Skill> GetSkillBySkillIdAsync(string skillId)
        {
            try
            {
                Skill skill = await (from skil in EmployeeSkillsDB.Skills where skil.SkillId == skillId select skil).FirstAsync();
                return skill;
            }
            catch(Exception)
            {
                throw new Exception("Skill doesn't exists for this Id");
            }
        }

        public async Task<List<EmpSkill>> GetSkillsByEmployeeIdAsync(string empId)
        {
            try
            {
                 List<EmpSkill> empSkills= await(from empskill in EmployeeSkillsDB.EmpSkills where empskill.EmpId == empId select empskill).ToListAsync();
                return empSkills;
            }
            catch (Exception)
            {
                throw new Exception("Skill doesn't exists for this Id");
            }
        }

        public async  Task InsertEmployeeSkillAsync(EmpSkill empSkill)
        {
            EmployeeSkillsDB.EmpSkills.Add(empSkill);
            await EmployeeSkillsDB.SaveChangesAsync();

            
        }

        public async Task UpdateEmployeeSkillAsync(string skillId, string empId, EmpSkill empSkill)
        {
            List<EmpSkill> empSkill1 = await GetSkillByEmployeeIdAndSkillIdAsync(skillId, empId);
            EmpSkill emp = empSkill1.FirstOrDefault();
            emp.SkillExperience = empSkill.SkillExperience;
            await EmployeeSkillsDB.SaveChangesAsync();

        }
       /* public async Task<List<EmpSkill>> GetSkillByEmployeeIdAndSkillIdAsync(string skillId, string empId)
        {
            List<EmpSkill> empSkill = await (from skill in EmployeeSkillsDB.EmpSkills where skill.SkillId == skillId && skill.EmpId == empId select skill).ToListAsync();
            return empSkill;

        }*/
        public async Task<List<EmpSkill>> GetSkillByEmployeeIdAndSkillIdAsync(string skillId, string empId)
        {
            List<EmpSkill> empSkill = await (from skill in EmployeeSkillsDB.EmpSkills where skill.SkillId == skillId && skill.EmpId == empId select skill).ToListAsync();
            return empSkill;

        }
        public async Task<List<Skill>> GetAllSkills()
        {
            List<Skill> skills = await EmployeeSkillsDB.Skills.ToListAsync();
            return skills;
        }
    }
}
