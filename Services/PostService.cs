using UndecidedApp.Data;
using UndecidedApp.Data.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace UndecidedApp.Services
{
    public class PostService : IPostService
    {
        private readonly UndecidedDBContext _dbContext;

        public PostService(UndecidedDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPost(Post newPost)
        {
            _dbContext.Post.Add(newPost);
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.SaveChanges();
        }

        public void DeletePost(Post postToDelete)
        {
            throw new System.NotImplementedException();
        }

        public void EditPost(Post updatePost)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _dbContext.Post.OrderBy(p => p.PostID).AsNoTracking().ToListAsync<Post>();
        }

        public Post GetPostById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Post>> IPostService.GetAllPost()
        {
            throw new System.NotImplementedException();
        }

        Task<Post> IPostService.GetPostById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}
