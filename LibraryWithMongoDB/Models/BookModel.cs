using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Models
{
    public class BookModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string AuthorId { get; private set; }
        public int YearPublication { get; set; }

        public BookModel(string id, string title, string authorId, int yearPublication)
        {
            this.Id = id;
            this.Title = title;
            this.AuthorId = authorId;
            this.YearPublication = yearPublication;
        }

        public BookModel(string title, string authorId, int yearPublication)
        {
            Title = title;
            AuthorId = authorId;
            YearPublication = yearPublication;
        }
    }
}
