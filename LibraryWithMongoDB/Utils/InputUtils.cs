using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Utils
{
    public class InputUtils
    {
        public static void PressEnterToContinue()
        {
            Console.WriteLine("Pressioner a tecla ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        public static string TextInput(string msgInput, string msgError)
        {
            bool validation = false;
            var text = "";
            do
            {
                Console.WriteLine(msgInput);
                text = Console.ReadLine() ?? "";

                if (String.IsNullOrEmpty(text))
                {
                    Console.WriteLine(msgError);
                    validation = true;
                }
                else
                {
                    validation = false;
                }
            }
            while (validation);

            return text;
        }

        public static string IdValue(string msgInput, string msgError)
        {
            bool validation = false;
            var id = "";
            do
            {
                Console.WriteLine(msgInput);
                id = Console.ReadLine() ?? "";

                if (id.Length != 24)
                {
                    Console.WriteLine(msgError);
                    validation = true;
                }
                else
                {
                    validation = false;
                }
            }
            while (validation);

            return id;
        }

        public static int InsertYear(string msgInput)
        {
            bool incorrect = true;
            var value = "";
            var year = 0;
            do
            {
                Console.WriteLine(msgInput);
                value = Console.ReadLine() ?? "";

                if (!int.TryParse(value, out year))
                {
                    Console.WriteLine("Informe somente números!");
                }
                else if (year > DateTime.Now.Year)
                {
                    Console.WriteLine("Ano informado é inválido!");
                }
                else
                {
                    incorrect = false;
                }
            }
            while (incorrect);

            return year;
        }
    }
}
