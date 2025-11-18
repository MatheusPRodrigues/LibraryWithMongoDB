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
        private readonly AuthorCollection _collection;

        public AuthorService(AuthorCollection repository)
        {
            this._collection = repository;
        }

        public void InsertAuthor(AuthorModel author)
        {
            if (_collection.FindByName(author.AuthorName).Result == null)
            {
                _collection.AddAuthor(author);
                Console.WriteLine("Autor cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"O autor {author.AuthorName} já está cadastrado no sistema!");
            }
        }

        public List<AuthorModel> FindAll()
        {
            return _collection.FindAll().Result;
        }

        public AuthorModel FindById(string id)
        {
            return _collection.FindById(id).Result;
        }

        public AuthorModel DeleteById(string id)
        {
            return _collection.DeleteById(id).Result;  
        }

        public void UpdateOne(AuthorModel author)
        {
            _collection.ReplaceOne(author);
        }
    }
}
