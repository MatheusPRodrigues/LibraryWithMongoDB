using LibraryWithMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _context;

        public DbContext()
        {
            var client = new MongoClient("mongodb+srv://libraryadmin:library123@localhost:27017/");
            this._context = client.GetDatabase("Library");
        }

        public IMongoCollection<AuthorModel> GetAuthorCollection()
        {
            return this._context.GetCollection<AuthorModel>("Authors");
        }

        public IMongoCollection<BooksModel> GetBookCollection()
        {
            return this._context.GetCollection<BooksModel>("Books");
        }
    }
}
