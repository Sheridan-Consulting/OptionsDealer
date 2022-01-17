using Shared.Repositories;

namespace Shared.Interfaces
{
    public interface IDataService
    {
        public IOptionRuleRepository OptionRuleRepository { get; }
    }
}