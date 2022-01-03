using Shared.Models;

namespace Shared.Interfaces;

public interface IBrokerageService
{
    Stock GetOptionsInfo(string symbol, int year, int month);
}