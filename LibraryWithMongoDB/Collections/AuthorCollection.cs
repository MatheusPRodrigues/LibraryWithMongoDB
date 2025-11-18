using LibraryWithMongoDB.Data;
using LibraryWithMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Collections
{
    public class AuthorCollection
    {
        private readonly IMongoCollection<AuthorModel> _authorCollection;

        public AuthorCollection(DbContext dbContext)
        {
            this._authorCollection = dbContext.GetAuthorCollection();
        }

        public async void AddAuthor(AuthorModel author)
        {
            await _authorCollection.InsertOneAsync(author);
        }

        public async Task<AuthorModel> FindByName(string name)
        {
            return await _authorCollection.FindAsync(a => a.AuthorName == name).Result.FirstOrDefaultAsync();
        }

        public async Task<List<AuthorModel>> FindAll()
        {
            return await _authorCollection.FindAsync(a => true).Result.ToListAsync();
        }

        public async Task<AuthorModel> FindById(string id)
        {
            return await _authorCollection.FindAsync(a => a.Id == id).Result.FirstOrDefaultAsync();
        }

        public async Task<List<AuthorModel>> FindAuthorsForUpdateBook(string? id)
        {
            return await _authorCollection.FindAsync(a => a.Id != id).Result.ToListAsync();   
        }

        public async Task<AuthorModel> DeleteById(string id)
        {
            return await _authorCollection.FindOneAndDeleteAsync(a => a.Id == id);
        }

        public async Task ReplaceOne(AuthorModel author)
        {
            await _authorCollection.ReplaceOneAsync(a => a.Id == author.Id, author);
        }
    }
}
