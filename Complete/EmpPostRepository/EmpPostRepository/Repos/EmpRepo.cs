using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPostRepository.Repos
{
    public class EmpRepo : IEmpRepo
    {
        EmpPostsDBEntities ent = new EmpPostsDBEntities();
        public async Task DeletePostAsync(string postId,string EmpId)    
        {
            EmpPost empPost = await GetApplicationbyIdAsync(postId,EmpId);
            ent.EmpPosts.Remove(empPost);
            await ent.SaveChangesAsync();
        }
       

        public async Task<List<EmpPost>> GetAllPostsAsync()
        {
            List<EmpPost> posts = await ent.EmpPosts.ToListAsync();
            return posts;
        }
        /*public async Task<EmpPost> GetPostbyIdAsync(string postId, string empId)
        {
            try
            {
                EmpPost post = await(from p in ent.EmpPosts where p.PostId == postId && p.EmpId==empId select p).FirstAsync();
                return post;
            }
            catch (Exception)
            {
                throw new Exception("No such post");
            }
        }*/

        public async Task<List<EmpPost>> GetPostsByEmpIdAsync(string EmpId)
        {
            List<EmpPost> posts = await(from p in ent.EmpPosts where p.EmpId == EmpId select p).ToListAsync();
            if (posts.Count > 0)
                return posts;
            else
                throw new Exception("Employee has no applications");
            
        }

        public async Task<List<EmpPost>> GetPostbyIdAsync(string postId)
        {
            List<EmpPost> posts = await(from p in ent.EmpPosts where p.PostId == postId select p).ToListAsync();
            if (posts.Count > 0)
                return posts;
            else
                throw new Exception("No posts found");
        }

        public async Task InsertPostAsync(EmpPost empPost)
        {
            empPost.AppliedDate = DateTime.Now;
            empPost.ApplicationStatus = "Reviewing";
            ent.EmpPosts.Add(empPost);
            await ent.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(string postId,string EmpId, EmpPost empPost)
        {
            EmpPost record = await GetApplicationbyIdAsync(postId,EmpId);
            record.ApplicationStatus = empPost.ApplicationStatus;
            await ent.SaveChangesAsync();
        }
        public async Task<List<Post>> GetAllPostsDD()
        {
            List<Post> posts = await ent.Posts.ToListAsync();
            return posts;
        }

        public async Task<EmpPost> GetApplicationbyIdAsync(string postId, string EmpId)
        {
            try
            {
                EmpPost post = await(from p in ent.EmpPosts where p.PostId == postId && p.EmpId == EmpId select p).FirstAsync();
                return post;
            }
            catch (Exception)
            {
                throw new Exception("No such post");
            }
        }

        

       
    }
}
