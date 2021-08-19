using System;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IOptionsTransactionService
    {
        Task<OptionTransactionBase> GetOptionTransaction(string id);
    }
}
