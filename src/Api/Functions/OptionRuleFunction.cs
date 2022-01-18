using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Shared.Models;
using Shared.Models.Data;
using Shared.Repositories;

namespace api.Functions;

public class OptionRuleFunction
{
    private readonly IOptionRuleRepository _optionRuleRepository;

    public OptionRuleFunction(IOptionRuleRepository optionRuleRepository)
    {
        _optionRuleRepository = optionRuleRepository;
    }

    [OpenApiOperation(operationId: "OptionRuleByUserId", tags: new[] { "option rules","database" }, Summary = "Option Rules by User Id", Description = "Return list off all the Option Rules by User Id", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(OptionRule), Summary = "Option Rule", Description = "Object of all the Option Rules")]
    [Function("OptionRuleByUserId")]
    public async Task<HttpResponseData> GetRulesByUserId(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "option/rules/{userid:string}")]
        HttpRequestData req, string userId)
    {
        var optionRules = await _optionRuleRepository.GetOptionRulesByUserId(userId);

        return await req.OkObjectResponse(optionRules);
    }
}