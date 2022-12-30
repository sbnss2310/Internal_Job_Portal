using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmpPostRepository.Repos
{
    public interface IEmpRepo
    {
        Task<List<EmpPost>> GetAllPostsAsync();

        Task<EmpPost> GetApplicationbyIdAsync(string postId, string EmpId );
        Task<List<EmpPost>> GetPostsByEmpIdAsync(string EmpId);
        Task<List<EmpPost>> GetPostbyIdAsync(string postId);
        //emps
        Task InsertPostAsync(EmpPost empPost);
        //manager
        Task UpdatePostAsync(string postId, string empId, EmpPost empPost);
        //manager
        Task DeletePostAsync(string postId,string EmpId);
    }
}
