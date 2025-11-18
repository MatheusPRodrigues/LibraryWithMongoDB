using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Models.Dto;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Utils;
using LibraryWithMongoDB.Views.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Views.Book
{
    public class BookViews
    {
        private BookService _bookService;

        public BookViews(BookService bookService)
        {
            this._bookService = bookService;
        }

        public void Create()
        {
            Console.Clear();
            var authors = _bookService.AuthorToSelectForBook();
            if (authors != null)
            {
                Console.WriteLine("========= CADASTRAR LIVRO =========");
                var bookTitle = InputUtils.TextInput("Digite o título do livro:", "Insira um título para o livro!");

                Console.Clear();
                Console.WriteLine("========= CADASTRAR LIVRO =========");
                Console.WriteLine("========= SELECIONE O AUTOR DO LIVRO =========");

                ShowAuthors(authors);

                Console.WriteLine("*Selecione o Id do autor desse livro, caso ele não exista na lista de autores disponíveis digite -1");
                var inputId = InputUtils.TextInput("Digite o Id do autor:", "Insira um Id para o autor!");

                if (inputId == "-1")
                {
                    Console.WriteLine("Cadastro do livro cancelado!");
                    InputUtils.PressEnterToContinue();
                }
                else if (inputId.Length != 24)
                {
                    Console.WriteLine("O Id do autor é inválido!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("========= CADASTRAR LIVRO =========");
                    var year = InputUtils.InsertYear("Digite o ano de publicação do livro:");

                    _bookService.InsertBook(new BookModel(bookTitle, inputId, year));
                    InputUtils.PressEnterToContinue();
                }
            }
            else
            {
                Console.WriteLine("Ainda não há nenhum autor cadastro!\n É necessário ter o autor do livro cadastrado primeiro!");
                InputUtils.PressEnterToContinue();
            }
        }

        public void ReadAll()
        {
            Console.Clear();
            if (_bookService.ThereAreBooks())
            {
                Console.WriteLine("========= EXIBINDO TODOS OS LIVROS =========");
                ShowAllBooksDtos(_bookService.FindAll());
            }
            else
                Console.WriteLine("Não existe nenhum livro cadastrado até o momento!");

            InputUtils.PressEnterToContinue();
        }

        public void ReadById()
        {
            Console.Clear();
            if (_bookService.ThereAreBooks())
            {
                Console.WriteLine("========= EXIBIR LIVRO POR ID =========");
                var id = InputUtils.IdValue("Digite o ID do Livro que deseja consultar:", "ID do livro inválido! Tente novamente!");

                Console.Clear();
                var book = _bookService.FindById(id);
                if (book != null)
                {
                    Console.WriteLine("========= LIVRO ENCONTRADO =========");
                    Console.WriteLine(book);
                }
                else
                    Console.WriteLine("Livro não pode ser encontrado no sistema!");
            }
            else
                Console.WriteLine("Não existe nenhum livro cadastrado até o momento!");

            InputUtils.PressEnterToContinue();
        }

        public void Update()
        {
            Console.Clear();
            if (_bookService.ThereAreBooks())
            {
                Console.WriteLine("========= SELECIONE UM LIVRO PARA ATUALIZAÇÃO =========");
                ShowAllBooksDtos(_bookService.FindAll());

                Console.WriteLine("\n*Selecione e copie o ID do livro que deseja atualizar!");
                var id = InputUtils.IdValue("Digite o ID do livro que deseja atualizar:", "ID do livro inválido! Tente novamente!");

                var bookToUpdate = _bookService.FindById(id);

                Console.Clear();
                if (bookToUpdate != null)
                {
                    if (UpdateBook(bookToUpdate))
                    {
                        Console.WriteLine("Atualização realizada com sucesso!");
                        InputUtils.PressEnterToContinue();
                        Console.WriteLine("========= LISTA DE LIVROS ATUALIZADA =========");
                        ShowAllBooksDtos(_bookService.FindAll());
                    }
                    else
                        Console.WriteLine("A operação de atualização foi cancelada!");
                }
                else
                    Console.WriteLine("Livro não encontrado para atualização!");
            }
            else
                Console.WriteLine("Não existe nenhum livro cadastrado até o momento!");

            InputUtils.PressEnterToContinue();
        }

        public void DeleteById()
        {
            Console.Clear();
            if (_bookService.ThereAreBooks())
            {
                Console.WriteLine("========= SELECIONE UM LIVRO PARA EXCLUSÃO =========");
                ShowAllBooksDtos(_bookService.FindAll());

                Console.WriteLine("\n*Selecione e copie o ID do livro que deseja excluir!");
                var id = InputUtils.IdValue("Digite o ID do Livro que deseja excluir:", "ID do livro inválido! Tente novamente!");

                var bookDeleted = _bookService.DeleteById(id);

                Console.Clear();
                if (bookDeleted != null)
                {
                    Console.WriteLine("Livro deletado com sucesso!");
                    Console.WriteLine(bookDeleted);
                }
                else
                    Console.WriteLine("Livro não encontrado para exclusão!");
            }
            else
                Console.WriteLine("Não existe nenhum livro cadastrado até o momento!");

            InputUtils.PressEnterToContinue();
        }

        private void ShowAllBooksDtos(List<BookDto> bookDtos)
        {
            foreach (var b in bookDtos)
            {
                Console.WriteLine(b);
                Console.WriteLine();
            }
        }

        private void ShowAuthors(List<AuthorModel> authors)
        {
            foreach (var a in authors)
            {
                Console.WriteLine(a);
                Console.WriteLine();
            }
        }

        private bool UpdateBook(BookDto book)
        {
            var repete = true;
            var isUpdated = false;
            var option = "";
            do
            {
                Console.Clear();
                Console.WriteLine("========= VISUALIZADOR DE ALTERAÇÕES DO LIVRO =========\n");
                Console.WriteLine(book);

                Console.WriteLine("\n1 - Alterar título");
                Console.WriteLine("2 - Alterar ano de publicação");
                Console.WriteLine("3 - Alterar autor");
                Console.WriteLine("4 - Atualizar");
                Console.WriteLine("0 - Cancelar atualização");
                Console.WriteLine("Digite a opção que deseja:");
                option = Console.ReadLine() ?? "-1";

                switch (option)
                {
                    case "1":
                        book.Title = InputUtils.TextInput("Digite o título do livro:", "Insira um título para o livro!");
                        break;
                    case "2":
                        book.YearPublication = InputUtils.InsertYear("Digite o ano de publicação do livro");
                        break;
                    case "3":
                        var author = UpdateAuthorOfTheBook();

                        if (author != null)
                            book.AuthorModel = author;
                        else
                            Console.WriteLine("Autor não encontrado! Tente novamente!");
                        break;
                    case "4":
                        _bookService.UpdateOne(book);
                        isUpdated = true;
                        repete = false;
                        break;
                    case "0":
                        isUpdated = false;
                        repete = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione uma das opções do menu!");
                        InputUtils.PressEnterToContinue();
                        break;
                }
            }
            while (repete);

            return isUpdated;
        }

        private AuthorModel UpdateAuthorOfTheBook()
        {
            Console.Clear();
            Console.WriteLine("========= SELECIONE UM AUTOR PARA ATUALIZAÇÃO =========");
            ShowAuthors(_bookService.AuthorToSelectForBook());
            Console.WriteLine("\n*Selecione e copie o ID do autor que deseja selecionar para o livro!");
            var id = InputUtils.IdValue("Digite o ID do Autor que deseja selecionar:", "ID do autor inválido! Tente novamente!");

            return _bookService.UpdateAutorView(id);
        }
    }
}
