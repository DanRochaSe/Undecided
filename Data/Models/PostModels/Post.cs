﻿using Microsoft.Identity.Client;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace UndecidedApp.Data.Models.PostModels
{
    public class Post
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        public ObjectId? PostID { get; set; } = ObjectId.GenerateNewId();

        [Required]
        public string Title { get; set; }

        [Required]

        public string PostBody { get; set; }

        public IList<string> Tags { get; set; }

        public float? Raring { get; set; } = 0.0f;

        public int? AuthorID { get; set; } = 0;

        public string? AuthorName { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
