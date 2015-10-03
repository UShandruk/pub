using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    interface IMessagesDbService
    {
        IOrderedQueryable<Message> ExtractMessages();
      
        Message FindMessageById(int? id);

        void AddMessage(Message message);

        void ModifyMessage(Message message);

        void RemoveMessage(int Id);

        void SaveChanges();
    }
}
