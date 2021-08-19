using System;

namespace Data.MongoDB
{
    public class OptionTransactionRepository : IOptionTransactionRepository
    {
        public async Task<OptionTransactionBase> GetAsync(int optionTransactionId)
        {
            var filter = Builders<OptionTransactionBase>.Filter.Eq("Id", optionTransactionId);
            return await _context.OptionTransactions.Find(filter).FirstOrDefaultAsync();                                    
        }
    }
}
