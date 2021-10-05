using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Shared;

namespace BlazorProject.Server.Models
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int accountId);
        Task<Account> GetAccountByEmail(string email);
        Task<Account> AddAccount(Account account);
        Task DeleteAccount(int accountId);
    }
}
