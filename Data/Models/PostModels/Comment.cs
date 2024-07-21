using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UndecidedApp.Data.Models.PostModels
{
    public class Comment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        public ObjectId CommentID { get; set; } = ObjectId.GenerateNewId();

        public string CommentBody { get; set; } = String.Empty;

        public int AuthorID { get; set; }
        
        public string AuthorName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int PostID { get; set; }

    }
}
