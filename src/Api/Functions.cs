
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using api;
using api.Models;
using Shared.Models;
using Shared.Models.Rules;

public class Functions
{
    private readonly IOptionTrader _optionTrader;

    public Functions(IOptionTrader optionTrader)
    {
        _optionTrader = optionTrader;
    }
    [Function("option-toBuy")]
    public async Task<HttpResponseData> Option_GetOptionToBuy([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "options/bysymbol/{symbol}")] HttpRequestData req,string symbol)
    {
        var stock = _optionTrader.GetAllStockInfo(symbol);
        var optionsToBuy = _optionTrader.FindOptionsToBuy(stock);
        return await req.OkObjectResponse(stock);
    }
    [Function("option-toBuy-withparameters")]
    public async Task<HttpResponseData> Option_GetOptionToBuyWithParameters([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "options/bysymbol/{symbol}")] HttpRequestData req,string symbol,OptionRuleParameters ruleParameters)
    {
        var stock = _optionTrader.GetAllStockInfo(symbol);
        var optionsToBuy = _optionTrader.FindOptionsToBuy(stock,ruleParameters);
        return await req.OkObjectResponse(stock);
    }

    [Function("options-toBuy")]
    public async Task<HttpResponseData> Option_GetOptionsToBuy(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "options/tobuy")] HttpRequestData req,
        List<string> symbols)
    {
        var optionsToBuy = new List<Stock>();

        foreach (var symbol in symbols)
        {
            var stock = _optionTrader.GetAllStockInfo(symbol);
            var optionToBuy = _optionTrader.FindOptionsToBuy(stock);
            optionsToBuy.Add(optionToBuy);
        }

        return await req.OkObjectResponse(optionsToBuy);
    }
    [Function("options-toBuy-withparameters")]
    public async Task<HttpResponseData> Option_GetOptionsToBuyWithParameters(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "options/tobuywithparameters")] HttpRequestData req,
        GetOptionsToBuyWithParametersRequest getOptionsToBuyWithParametersRequest)
    {
        var optionsToBuy = new List<Stock>();

        foreach (var symbol in getOptionsToBuyWithParametersRequest.Symbols)
        {
            var stock = _optionTrader.GetAllStockInfo(symbol);
            var optionToBuy = _optionTrader.FindOptionsToBuy(stock,getOptionsToBuyWithParametersRequest.OptionRuleParameters);
            optionsToBuy.Add(optionToBuy);
        }

        return await req.OkObjectResponse(optionsToBuy);
    }
    
}