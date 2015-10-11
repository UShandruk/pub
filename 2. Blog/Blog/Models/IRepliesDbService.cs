using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public interface IRepliesDbService
    {
        IQueryable<Reply> ExtractReplies();

        Reply FindReplyById(int? id);

        void AddReply(Reply reply);

        void ModifyReply(Reply reply);

        void RemoveRepliy(Reply reply);

        void SaveChanges();
    }
}
