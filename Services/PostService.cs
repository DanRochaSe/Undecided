using UndecidedApp.Data;
using UndecidedApp.Data.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Data;
using ZstdSharp.Unsafe;

namespace UndecidedApp.Services
{
    public class PostService : IPostService
    {
        private readonly UndecidedDBContext _dbContext;

        private readonly Dictionary<string, IEnumerable<Post>> _cache = new Dictionary<string, IEnumerable<Post>>();

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

            if (_cache.TryGetValue("posts", out IEnumerable<Post>? posts))
            {
                return posts;
            }

            IEnumerable<Post> postList  =  await _dbContext.Post.OrderByDescending(p => p.CreatedAt).ToListAsync<Post>();
            _cache["posts"] = postList;

            return postList;

        }

        public async Task<Post> GetPostById(ObjectId id)
        {
            return await _dbContext.Post.FindAsync(id);
    
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
