using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    [Table("books")]
    public class Book
    {
        /// <summary>
        /// Год издания
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Aвтор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Содержание (XML)
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Количество томов
        /// </summary>
        public int NumberOfVolumes { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="author">Aвтор</param>
        /// <param name="name">Название</param>
        /// <param name="content">Содержание (XML)</param>
        /// <param name="year">Год издания</param>
        public Book(int id, string author, string name, string content, int year, int numberOfVolumes)
        {
            Id = id;
            Author = author;
            Name = name;
            Content = content;
            Year = year;
            NumberOfVolumes = numberOfVolumes;
        }
    }
}
