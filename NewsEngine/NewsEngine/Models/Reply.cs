using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine.Models
{
    public class Reply
    {
        public int Id { get; set; }
        
        [Display(Name = "Текст")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PublishDate { get; set; }
        public virtual Message Message { get; set; } //К какому сообщению относится ответ. Обязательно virtual.
        public int MessageId { get; set; } //Необязательное поле, но в большинстве случаев лучше сделать
        //Оно автоматически распознает Id в Entity Framework
    }
}