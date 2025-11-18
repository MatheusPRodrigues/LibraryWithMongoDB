using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Data;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Utils;
using LibraryWithMongoDB.Views.Author;
using LibraryWithMongoDB.Views.Book;

void MainMenu()
{
    var context = new DbContext();

    var authorCollection = new AuthorCollection(context);
    var bookCollection = new BookCollection(context);

    var authorService = new AuthorService(authorCollection, bookCollection);
    var bookService = new BookService(authorCollection, bookCollection);

    var repete = true;
    var option = "";

    do
    {
        Console.Clear();
        Console.WriteLine("===================== MENU PRINCIPAL =====================");
        Console.WriteLine("1 - Menu de operação dos Autores");
        Console.WriteLine("2 - Menu de operação dos Livros");
        Console.WriteLine("0 - Encerrar Sistema");
        Console.WriteLine("==========================================================");
        Console.Write("=> ");
        option = Console.ReadLine() ?? "-1";

        switch(option)
        {
            case "1":
                AuthorMenu.Menu(authorService);
                break;
            case "2":
                BookMenu.Menu(bookService);
                break;
            case "0":
                Console.Clear();
                repete = false;
                break;
            default:
                Console.WriteLine("Opção inválida! Tente uma das opções do menu!");
                InputUtils.PressEnterToContinue();
                break;
        }
    }
    while (repete);
    
    Console.WriteLine("Programa encerrado com sucesso!");
}

MainMenu();