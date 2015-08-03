using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine.Models
{
    public class Message
    {
        public int Id {get; set;} //Primary key (ключевое поле), чтобы эффективно работал поиск 
        
        [Display(Name = "Заголовок")]
        [Required]
        [StringLength(25, MinimumLength=5)]
        public string Title {get; set;}

       
        [Display(Name = "Текст")]
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Text {get; set;}

        [Display(Name = "Дата публикации")]
        public DateTime PublishDate { get; set; } //Дата публикации сообщения
        public virtual ICollection<Reply> Replies { get; set; } //Возможность узнать, какие ответы есть у сообщения
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; } //string, а не int, т.к. имя юзера.
    }
}
