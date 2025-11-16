// See https://aka.ms/new-console-template for more information
using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Views.Author;

AuthorCollection repository = new AuthorCollection(new LibraryWithMongoDB.Data.DbContext());
AuthorService authorService = new AuthorService(repository);
CrudView crudView = new CrudView(authorService);

//crudView.Create();
//crudView.ReadAll();
//crudView.ReadById();
//crudView.DeleteById();
crudView.Update();