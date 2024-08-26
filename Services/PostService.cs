using UndecidedApp.Data;
using UndecidedApp.Data.Models.PostModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.Extensions.Caching.Memory;
using AspNetCore;

namespace UndecidedApp.Services
{
    public class PostService : IPostService
    {
        private readonly UndecidedDBContext _dbContext;
        private readonly IMemoryCache _cache;

        private MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(System.TimeSpan.FromMinutes(30))
                .SetAbsoluteExpiration(System.TimeSpan.FromMinutes(300))
                .SetPriority(CacheItemPriority.NeverRemove)
                .SetSize(2048);

        public PostService(UndecidedDBContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public void AddPost(Post newPost)
        {
            _dbContext.Post.Add(newPost);
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.SaveChanges();
            string cacheKey = "posts";
            _cache.Remove(cacheKey);
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
            string cacheKey = "products";
            if(!_cache.TryGetValue(cacheKey, out List<Post>? posts)){
                posts = await _dbContext.Post.OrderBy(p => p.PostID).AsNoTracking().ToListAsync<Post>();
                _cache.Set(cacheKey, posts, cacheOptions);
            }
                         
            return posts;
            
        }

        public async Task<Post> GetPostById(ObjectId id)
        {
            string cacheKey = $"post_{id}";
            if(!_cache.TryGetValue(cacheKey, out Post? post)){
                post = await _dbContext.Post.AsNoTracking().FirstOrDefaultAsync(p => p.PostID == id);
                _cache.Set(cacheKey, post, cacheOptions);
            }
            return post;
    
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
