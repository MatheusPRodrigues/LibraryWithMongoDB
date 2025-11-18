using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Utils;
using LibraryWithMongoDB.Views.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Services
{
    public class AuthorService
    {
        private readonly AuthorCollection _authorCollection;
        private readonly BookCollection _bookCollection;

        public AuthorService(AuthorCollection authorCollection, BookCollection bookCollection)
        {
            this._authorCollection = authorCollection;
            this._bookCollection = bookCollection;
        }

        public void InsertAuthor(AuthorModel author)
        {
            if (_authorCollection.FindByName(author.AuthorName).Result == null)
            {
                _authorCollection.AddAuthor(author);
                Console.WriteLine("Autor cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"O autor {author.AuthorName} já está cadastrado no sistema!");
            }
        }

        public List<AuthorModel> FindAll()
        {
            return _authorCollection.FindAll().Result;
        }

        public AuthorModel FindById(string id)
        {
            return _authorCollection.FindById(id).Result;
        }

        public AuthorModel DeleteById(string id)
        {
            _bookCollection.UpdateAuthorIdToNull(id);
            return _authorCollection.DeleteById(id).Result;  
        }

        public void UpdateOne(AuthorModel author)
        {
            _authorCollection.ReplaceOne(author);
        }
    }
}
