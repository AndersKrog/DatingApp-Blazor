using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext appDbContext;

        public AccountRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Account> AddAccount(Account account)
        {
            if (account.profile != null)
            {
                appDbContext.Entry(account.profile).State = EntityState.Unchanged;
            }

            var result = await appDbContext.Accounts.AddAsync(account);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAccount(int accountId)
        {
            var result = await appDbContext.Accounts
                .FirstOrDefaultAsync(e => e.AccountId == accountId);
            if (result != null)
            {
                appDbContext.Accounts.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Account> GetAccount(int accountId)
        {
            return await appDbContext.Accounts
                .Include(e => e.profile)
                .FirstOrDefaultAsync(e => e.AccountId == accountId);
        }


        public async Task<Account> GetAccountByEmail(string email)
        {
            return await appDbContext.Accounts
                .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
