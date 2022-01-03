using Shared.Interfaces;
using Shared.Models;

namespace Ally;

public class AllyBrokerageService : IBrokerageService
{
    public Stock GetOptionsInfo(string symbol, int year, int month)
    {
        return new Stock() {Symbol = symbol};
    }
}