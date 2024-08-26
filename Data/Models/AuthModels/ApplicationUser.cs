using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.EntityFrameworkCore;
using MongoDbGenericRepository.Attributes;

namespace UndecidedApp.Data.Models.AuthModels
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {

    }
}
