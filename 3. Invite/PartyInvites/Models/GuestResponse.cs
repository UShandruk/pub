using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse //Ответ гостя
    {
        [Required(ErrorMessage="Пожалуйста, введите Ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage="Пожалуйста, введите Ваш email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage="Ошибка в написании Вашего email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Пожалуйста, введите Ваш номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage="Пожалуйста, выберете ответ")]
        public bool? WillAttend { get; set; } //Придет или нет
    }
}