using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Models
{
    public class AuthorModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string AuthorName { get; private set; }
        public string Country { get; private set; }

        public AuthorModel(string authorName, string country)
        {
            this.AuthorName = authorName;
            this.Country = country;
        }

        public AuthorModel(string Id, string authorName, string country)
        {
            this.Id = Id;
            this.AuthorName = authorName;
            this.Country = country;
        }
    }
}
