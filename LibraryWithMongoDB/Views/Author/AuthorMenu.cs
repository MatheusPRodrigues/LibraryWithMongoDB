using LibraryWithMongoDB.Collections;
using LibraryWithMongoDB.Data;
using LibraryWithMongoDB.Services;
using LibraryWithMongoDB.Utils;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Views.Author
{
    public class AuthorMenu
    {
        public static void Menu(AuthorService authorService)
        {
            var operations = new AuthorViews(authorService);

            var repete = true;
            var option = "";
            do
            {
                Console.Clear();
                Console.WriteLine("===================== AUTORES =====================");
                Console.WriteLine("1 - Cadastrar Autor");
                Console.WriteLine("2 - Exibir todos Autores");
                Console.WriteLine("3 - Exibir um Autor pelo Id");
                Console.WriteLine("4 - Atualizar um Autor");
                Console.WriteLine("5 - Deletar um Autor");
                Console.WriteLine("0 - Retornar para menu anterior");
                Console.WriteLine("===================================================");
                Console.Write("=> ");
                option = Console.ReadLine() ?? "-1";

                switch (option)
                {
                    case "1":
                        operations.Create();
                        break;
                    case "2":
                        operations.ReadAll();
                        break;
                    case "3":
                        operations.ReadById();
                        break;
                    case "4":
                        operations.Update();
                        break;
                    case "5":
                        operations.DeleteById();
                        break;
                    case "0":
                        Console.WriteLine("Retornando para menu principal...");
                        InputUtils.PressEnterToContinue();
                        repete = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente uma das opções do menu!");
                        InputUtils.PressEnterToContinue();
                        break;
                }
            }
            while (repete);
        }
    }
}
