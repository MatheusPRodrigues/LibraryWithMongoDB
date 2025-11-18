using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Services
{
    public class BookService
    {
        private readonly AuthorCollection _authorCollection;
        private readonly BookCollection _bookCollection;

        public BookService(AuthorCollection authorCollection, BookCollection bookCollection)
        {
            this._authorCollection = authorCollection;
            this._bookCollection = bookCollection;
        }

        public void InsertBook(BookModel book)
        {
            if (_bookCollection.FindByName(book.Title).Result == null)
            {
                if (_authorCollection.FindById(book.AuthorId).Result != null)
                {
                    _bookCollection.AddBook(book);
                    Console.WriteLine("Livro cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe nenhum autor com o Id informado!");
                }
            }
            else
            {
                Console.WriteLine($"O livro {book.Title} já está cadastrado no sistema!");
            }
        }

        public List<AuthorModel> AuthorToSelectForBook() 
        {
            return _authorCollection.FindAll().Result;
        }

        public List<AuthorModel> FindAuthorsForUpdateBook(string? id)
        {
            return _authorCollection.FindAuthorsForUpdateBook(id).Result;
        }

        public List<BookDto> FindAllWithAuthors()
        {
            var books = new List<BookDto>();

            var booksInDB = _bookCollection.FindAllWithAuthors().Result;

            foreach (var b in booksInDB)
            {
                var author = _authorCollection.FindById(b.AuthorId).Result;

                books.Add(
                    new BookDto(b.Id, b.Title, b.YearPublication, author)
                );
            }

            return books;  
        }

        public List<BookDto> FindAll()
        {
            var books = new List<BookDto>();

            var booksInDB = _bookCollection.FindAll().Result;

            foreach (var b in booksInDB)
            {
                var author = _authorCollection.FindById(b.AuthorId).Result;

                books.Add(
                    new BookDto(b.Id, b.Title, b.YearPublication, author)
                );
            }

            return books;
        }

        public BookDto FindById(string id)
        {
            var book = _bookCollection.FindById(id).Result;

            if (book != null)
            {
                var author = _authorCollection.FindById(book.AuthorId).Result;

                return new BookDto(
                        book.Id,
                        book.Title,
                        book.YearPublication,
                        author
                    );
            }
            else
                return null;
        }

        public AuthorModel UpdateAutorView(string id)
        {
            return _authorCollection.FindById(id).Result;
        }

        public void UpdateOne(BookDto bookDto)
        {
            var book = new BookModel(
                    bookDto.Id,
                    bookDto.Title,
                    bookDto.AuthorModel != null ? bookDto.AuthorModel.Id : null,
                    bookDto.YearPublication
                );

            _bookCollection.ReplaceOne(book);
        }

        public BookDto DeleteById(string id)
        {
            var book = _bookCollection.DeleteById(id).Result;

            if (book != null)
            {
                var author = _authorCollection.FindById(book.AuthorId).Result;

                return new BookDto(
                        book.Id,
                        book.Title,
                        book.YearPublication,
                        author
                    );
            }
            else
                return null;
        }

        public bool ThereAreBooks()
        {
            return _bookCollection.FindAll().Result.Count() > 0;
        }
    }
}
