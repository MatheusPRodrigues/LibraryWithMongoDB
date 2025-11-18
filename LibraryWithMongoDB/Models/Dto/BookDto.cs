using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithMongoDB.Models.Dto
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int YearPublication { get; set; }
        public AuthorModel AuthorModel { get; set; }

        public BookDto(string id, string title, int yearPublication, AuthorModel authorModel)
        {
            this.Id = id;
            this.Title = title;
            this.YearPublication = yearPublication;
            this.AuthorModel = authorModel;
        }

        public override string? ToString()
        {
            return $"Id Livro: {this.Id}\n" +
                $"Título: {this.Title}\n" +
                $"Ano de publicação: {this.YearPublication}\n" +
                $"Autor do livro: {this.AuthorModel.AuthorName}\n" +
                $"País: {this.AuthorModel.Country}";
        }
    }
}
