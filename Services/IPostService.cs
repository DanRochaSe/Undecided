using UndecidedApp.Data.Models.PostModels;
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace UndecidedApp.Services
{
    public interface IPostService
    {

        Task<IEnumerable<Post>> GetAllPost();

        Task<Post?> GetPostById(ObjectId id);

        void AddPost(Post newPost);

        void EditPost(Post updatePost);

        void DeletePost(Post postToDelete);

        

    }
}
