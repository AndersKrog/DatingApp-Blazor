using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Shared;

namespace BlazorProject.Server.Models
{
    public interface IMessageRepository
    {
        Task<Message> GetMessage(int FromId,int ToId);
        Task<Message> AddMessage(Message message);
        //Task DeleteMessage(int messageId);
        Task<IEnumerable<Message>> GetMessages(int FromId, int ToId);
    }
}
