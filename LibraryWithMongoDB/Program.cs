// See https://aka.ms/new-console-template for more information
using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Views.Author;
using LibraryWithMongoDB.Data;
using LibraryWithMongoDB.Views.Book;

var dbContext = new DbContext();

AuthorCollection repository = new AuthorCollection(dbContext);
AuthorService authorService = new AuthorService(repository);
AuthorViews authorView = new AuthorViews(authorService);

BookCollection bookCollection = new BookCollection(dbContext);
BookService bookService = new BookService(repository, bookCollection);
BookViews bookViews = new BookViews(bookService);

//authorView.Create();
//crudView.ReadAll();
//crudView.ReadById();
//crudView.DeleteById();
//authorView.Update();

//bookViews.Create();
//bookViews.Create();
//bookViews.ReadAll();
//bookViews.ReadById();
//bookViews.DeleteById();
bookViews.Update();