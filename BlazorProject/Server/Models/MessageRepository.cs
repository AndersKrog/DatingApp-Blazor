using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext appDbContext;

        public MessageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Message> AddMessage(Message message)
        {
            var result = await appDbContext.Messages.AddAsync(message);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        
        public async Task<Message> GetMessage(int FromId, int ToId)
        {
            
            return await appDbContext.Messages
                .FirstOrDefaultAsync(e => e.FromId == FromId || e.ToId == ToId);
        }
        
        public async Task<IEnumerable<Message>> GetMessages(int FromId, int ToId)
        {

            IQueryable<Message> query = appDbContext.Messages;

            query = query.Where(e => e.FromId == FromId || e.ToId == ToId);

            return await query.ToListAsync();
            
            //return await Ok(appDbContext.Profiles.ToListAsync());
            //return null;

        }


        /*
        public async Task DeleteMessage(int messageId)
        {
            var result = await appDbContext.Messages
                .FirstOrDefaultAsync(e => e.MessageId == messageId);
            if (result != null)
            {
                appDbContext.Messages.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
        */
    }
}
