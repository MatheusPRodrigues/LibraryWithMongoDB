using LibraryWithMongoDB.Data;
using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Models.Dto;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Collections
{
    public class BookCollection
    {
        private readonly IMongoCollection<BookModel> _bookCollection;

        public BookCollection(DbContext context)
        {
            this._bookCollection = context.GetBookCollection();
        }

        public async void AddBook(BookModel book)
        {
            await _bookCollection.InsertOneAsync(book);
        }

        public async Task<BookModel> FindByName(string title)
        {
            return await _bookCollection.FindAsync(b => b.Title == title).Result.FirstOrDefaultAsync();
        }

        public async Task<List<BookModel>> FindAll()
        {
            return await _bookCollection.FindAsync(b => true).Result.ToListAsync();
        }

        public async Task<BookModel> FindById(string id)
        {
            return await _bookCollection.FindAsync(b => b.Id == id).Result.FirstOrDefaultAsync();
        }

        public async void ReplaceOne(BookModel bookModel)
        {
            await _bookCollection.ReplaceOneAsync(b => b.Id == bookModel.Id, bookModel);
        }

        public async Task<BookModel> DeleteById(string id)
        {
            return await _bookCollection.FindOneAndDeleteAsync(b => b.Id == id);
        }
    }
}
