using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPostRepository.Repos
{
   public  class PostRepo
    {
        EmpPostsDBEntities postsDBEntities = new EmpPostsDBEntities();
        public void AddPost(string PostId)
        {
            Post post2add = new Post { PostId = PostId };
            postsDBEntities.Posts.Add(post2add);
            postsDBEntities.SaveChanges();
        }
    }
}
