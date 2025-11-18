using LibraryWithMongoDB.Models;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Views.Author
{
    public class AuthorViews
    {
        private AuthorService authorService;

        public AuthorViews(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("========= CADASTRAR AUTOR =========");
            var authorName = InputUtils.TextInput("Digite o nome do autor:", "Insira um nome para o autor!");

            Console.Clear();
            Console.WriteLine("========= CADASTRAR AUTOR =========");
            var authorCountry = InputUtils.TextInput("Digite o país do autor:", "Insira um pais para o autor!");

            authorService.InsertAuthor(new AuthorModel(authorName, authorCountry));
            InputUtils.PressEnterToContinue();
        }

        public void ReadAll()
        {
            var authors = authorService.FindAll();

            Console.Clear();
            if (ThereAreAuthors(authors))
            {
                Console.WriteLine("========= EXIBINDO TODOS AUTORES =========");
                ShowAllAuthors(authors);
            }
            else
            {
                Console.WriteLine("Não existe nenhum autor cadastrado até o momento!");
            }
            InputUtils.PressEnterToContinue();
        }

        public void ReadById()
        {
            Console.Clear();
            Console.WriteLine("========= EXIBIR AUTOR POR ID =========");
            var id = InputUtils.IdValue("Digite o ID do Autor que deseja consultar:", "ID do autor inválido! Tente novamente!");

            var author = authorService.FindById(id);
            if (author == null)
                Console.WriteLine("Autor não pode ser encontrado no sistema!");
            else
            {
                Console.WriteLine("========= AUTOR ENCONTRADO =========");
                Console.WriteLine(author);
            }
            InputUtils.PressEnterToContinue();
        }

        public void Update()
        {
            var authors = authorService.FindAll();
            Console.Clear();
            if (ThereAreAuthors(authors))
            {
                Console.WriteLine("========= SELECIONE UM AUTOR PARA ATUALIZAÇÃO =========");
                ShowAllAuthors(authors);
                Console.WriteLine("\n*Selecione e copie o ID do autor que deseja atualizar!");
                var id = InputUtils.IdValue("Digite o ID do Autor que deseja atualizar:", "ID do autor inválido! Tente novamente!");

                var authorToUpdate = authorService.FindById(id);
                
                Console.Clear();
                if (authorToUpdate != null)
                {
                    if (UpdateAuthor(authorToUpdate))
                    {
                        Console.WriteLine("Atualização realizada com sucesso!");
                        InputUtils.PressEnterToContinue();
                        Console.WriteLine("========= LISTA DE AUTORES ATUALIZADA =========");
                        ShowAllAuthors(authorService.FindAll());
                    }
                    else
                    {
                        Console.WriteLine("A operação de atualização foi cancelada!");
                    }
                }
                else
                {
                    Console.WriteLine("Autor não encontrado para atualização!");
                }
            }
            else
                Console.WriteLine("Não há autores cadastrados no sistema!");

            InputUtils.PressEnterToContinue();
        }

        public void DeleteById()
        {
            Console.Clear();
            var authors = authorService.FindAll();

            if (ThereAreAuthors(authors))
            {
                Console.WriteLine("========= SELECIONE UM AUTOR PARA EXCLUSÃO =========");
                ShowAllAuthors(authors);
                Console.WriteLine("\n*Selecione e copie o ID do autor que deseja excluir!");
                var id = InputUtils.IdValue("Digite o ID do Autor que deseja excluir:", "ID do autor inválido! Tente novamente!");

                var authorDeleted = authorService.DeleteById(id);

                Console.Clear();
                if (authorDeleted != null)
                {
                    Console.WriteLine("Autor deletado com sucesso!");
                    Console.WriteLine(authorDeleted);
                }
                else
                {
                    Console.WriteLine("Autor não encontrado para exclusão!");
                }
            }
            else
            {
                Console.WriteLine("Não há autores cadastrados no sistema!");
            }
            InputUtils.PressEnterToContinue();
        }

        private bool ThereAreAuthors(List<AuthorModel> authors)
        {
            return authors.Count() > 0;
        }

        private void ShowAllAuthors(List<AuthorModel> authors)
        {
            foreach (var a in authors)
            {
                Console.WriteLine(a);
                Console.WriteLine();
            }
        }

        private bool UpdateAuthor(AuthorModel author)
        {
            var repete = true;
            var isUpdated = false;
            var option = "";
            do
            {
                Console.Clear();
                Console.WriteLine("========= VISUALIZADOR DE ALTERAÇÕES DO AUTOR =========\n");
                Console.WriteLine($"Nome do autor: {author.AuthorName}");
                Console.WriteLine($"País: {author.Country}");

                Console.WriteLine("\n1 - Alterar nome");
                Console.WriteLine("2 - Alterar país");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("0 - Cancelar atualização");
                Console.WriteLine("Digite a opção que deseja:");
                option = Console.ReadLine() ?? "-1";

                switch (option)
                {
                    case "1":
                        author.SetAuthorName(
                            InputUtils.TextInput("Digite o nome do autor:", "Insira um nome para o autor!")
                        );
                        break;
                    case "2":
                        author.SetCountry(
                            InputUtils.TextInput("Digite o país do autor:", "Insira um pais para o autor!") 
                        );
                        break;
                    case "3":
                        authorService.UpdateOne(author);
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
    }
}
