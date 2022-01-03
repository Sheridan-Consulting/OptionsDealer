using System.Net.Http.Json;
using Ally.Mapping;
using Ally.Models;
using Ally.Models.Stocks;
using Microsoft.Extensions.Options;
using Shared.Interfaces;
using Shared.Models;
using Shared.Models.Configuration;
using Shared.Models.Rules;

namespace Ally;

public class AllyBrokerageService : IBrokerageService
{
    private readonly IOptions<AppSettingsConfiguration> _options;
    private readonly string stockUrl = "https://devapi.invest.ally.com/v1/market/ext/quotes.json?symbols={0}";

    private readonly string optionUrl =
        "https://devapi.invest.ally.com/v1/market/options/search.json?symbol={0}&query=xyear={1} and xmonth={2}";

    public AllyBrokerageService(IOptions<AppSettingsConfiguration> options)
    {
        _options = options;
    }
    public Stock GetOptionsInfo(string symbol, int year, int month)
    {
        var mapper = new AllyMapToStock(CallOptionApi(symbol, year.ToString(), month.ToString()),CallStockApi(symbol));
        return mapper.ToStock();
    }

    private AllyStockChain CallStockApi(string symbol)
    {
        OAuth.OAuthMessageHandler handler = new OAuth.OAuthMessageHandler(
            _options.Value.Ally.OAuth_ConsumerKey,
            _options.Value.Ally.OAuth_ConsumerSecret,
            _options.Value.Ally.OAuth_Token,
            _options.Value.Ally.OAuth_TokenSecret);
        var client = new HttpClient(handler);

        var result = client.GetFromJsonAsync<AllyStockChain>(String.Format(stockUrl,symbol)).Result;

        return result;
    }
    private AllyOptionChain CallOptionApi(string symbol,string year,string month)
    {
        OAuth.OAuthMessageHandler handler = new OAuth.OAuthMessageHandler(
            _options.Value.Ally.OAuth_ConsumerKey,
            _options.Value.Ally.OAuth_ConsumerSecret,
            _options.Value.Ally.OAuth_Token,
            _options.Value.Ally.OAuth_TokenSecret);
        var client = new HttpClient(handler);

        var result = client.GetFromJsonAsync<AllyOptionChain>(String.Format(optionUrl,symbol,year,month)).Result;
        return result;
    }
}