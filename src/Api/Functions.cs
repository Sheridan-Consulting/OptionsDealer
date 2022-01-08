
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using api;
using api.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Shared.Models;
using Shared.Models.Rules;

public class Functions
{
    private readonly IOptionTrader _optionTrader;

    public Functions(IOptionTrader optionTrader)
    {
        _optionTrader = optionTrader;
    }
    
    [OpenApiOperation(operationId: "option-tobuy", tags: new[] { "options" }, Summary = "Option To Buy", Description = "Takes in Single Stock Symbol and Default Option Rule Parameters", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiParameter("Symbol", Type = typeof(string), In = ParameterLocation.Query, Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Stock), Summary = "Stock response", Description = "This returns Stock and Options info that meet the rules")]
    [Function("option-toBuy")]
    public async Task<HttpResponseData> Option_GetOptionToBuy([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "options/bysymbol/{symbol}")] HttpRequestData req,string symbol)
    {
        var stock = _optionTrader.GetAllStockInfo(symbol);
        var optionsToBuy = _optionTrader.FindOptionsToBuy(stock);
        return await req.OkObjectResponse(stock);
    }
    
    [Function("options-toBuy")]
    public async Task<HttpResponseData> Option_GetOptionsToBuy(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "options/tobuy")] HttpRequestData req)
    {
        var getOptionsToBuy = await req.DeserializeRequest<GetOptionsToBuy>();
        var optionsToBuy = new List<Stock>();
        
        foreach (var symbol in getOptionsToBuy.Symbols)
        {
            var stock = _optionTrader.GetAllStockInfo(symbol);
            var optionToBuy = _optionTrader.FindOptionsToBuy(stock);
            optionsToBuy.Add(optionToBuy);
        }

        return await req.OkObjectResponse(optionsToBuy);
    }
    [Function("options-toBuy-withparameters")]
    public async Task<HttpResponseData> Option_GetOptionsToBuyWithParameters(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "options/tobuywithparameters")] HttpRequestData req)
    {

        var getOptionsToBuyWithParametersRequest = await req.DeserializeRequest<GetOptionsToBuyWithParametersRequest>();
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