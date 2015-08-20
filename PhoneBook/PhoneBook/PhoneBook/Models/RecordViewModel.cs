using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class RecordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [StringLength(25, MinimumLength = 1)] 
        [RegularExpression("^[а-яА-Я]+$", ErrorMessage = "Имя не должно содержать цифр, спецсимволов и латинских букв.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [StringLength(15, MinimumLength = 1)] 
        [RegularExpression("^[а-яА-Я]+$", ErrorMessage = "Фамилия не должна содержать цифр, спецсимволов и латинских букв.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [StringLength(20, MinimumLength = 1)] 
        [RegularExpression("^[0-9]+$", ErrorMessage = "Пожалуйста, вводите только цифры.")]
        public string Phone { get; set; }
    }
}