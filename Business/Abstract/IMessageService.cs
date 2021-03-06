using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        Message GetById(int id);
    }
}
