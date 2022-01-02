using System.Collections.Generic;
using Shared.Models;

namespace Shared.Interfaces;

public interface IOptionRules
{
    public List<Option> Evaluate(Stock stock);
}