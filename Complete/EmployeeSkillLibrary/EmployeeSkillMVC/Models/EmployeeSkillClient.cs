using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EmployeeSkillLibrary;
using Newtonsoft.Json;

namespace EmployeeSkillMVC.Models
{
    public class EmployeeSkillClient
    {
        public HttpClient webApi;
        public EmployeeSkillClient()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:49969/api/employeeskill/");
        }
        public async Task DeleteEmployeeSkillAsync(string SkillId,string EmpId)
        {
            await webApi.DeleteAsync("" + EmpId+ SkillId);
        }
        public async Task<List<EmpSkill>> GetAllEmployeeSkillsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            List<EmpSkill> employeeskills = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
            return employeeskills;
        }
        public async Task<List<EmpSkill>> GetEmployeeSkillsByEmployeeIdAsync(string EmpId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + EmpId);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<EmpSkill> emp = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
                return emp;
            }
            else
            {
                throw new Exception(str);
            }
        }
        public async Task<Skill> GetSkillBySkillIdAsync(string SkillId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + SkillId);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Skill skill = JsonConvert.DeserializeObject<Skill>(str);
                return skill;
            }
            else
            {
                throw new Exception(str);
            }
        }
        public async Task<List<EmpSkill>> GetEmployeeSkillByEmployeeIdandSkillIdAsync(string SkillId,string EmpId)
        {
            HttpResponseMessage response = await webApi.GetAsync("" +SkillId+ EmpId);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<EmpSkill> empskill = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
                return empskill;
            }
            else
            {
                throw new Exception(str);
            }
        }
        public async Task InsertEmployeeSkillAsync(EmpSkill empSkill)
        {
            var json = JsonConvert.SerializeObject(empSkill);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }
        public async Task UpdateEmployeeAsync(string SkillId,string EmpId, EmpSkill emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" +SkillId+'/'+EmpId, data);
        }
    }
}