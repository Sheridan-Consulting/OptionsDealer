
using System.Text.Json;
using System.Text.Json.Nodes;
using api;
using Shared.Models.Rules;

public class Functions
{
    private readonly IOptionTrader _optionTrader;

    public Functions(IOptionTrader optionTrader)
    {
        _optionTrader = optionTrader;
    }
    [Function("options-toBuy")]
    public async Task<HttpResponseData> Option_GetOptionToBuy([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "options/tobuy/{symbol}")] HttpRequestData req,string symbol)
    {
        var stock = _optionTrader.GetAllStockInfo(symbol);
        //var logger = req.FunctionContext.GetLogger("HttpFunction");
        //logger.LogInformation(JsonSerializer.Serialize(stock));
       
       // var optionsToBuy = _optionTrader.FindOptionsToBuy(stock);
        return await req.OkObjectResponse(stock);
    }
    
}