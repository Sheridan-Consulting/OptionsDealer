using System.IO;
using System.Text.Json;
using Ally.Models;
using Shouldly;
using TDAmeritrade.Models.Options;
using Xunit;

namespace Tests.ally;

public class AllyFileMappingTest
{
    private readonly AllyOptionChain _optionChain;
    private readonly string _jsonString;
    private readonly Strike _singleStrike;
    public AllyFileMappingTest()
    {
        _jsonString = File.ReadAllText(@"ally/files/option.json");                        
        _optionChain = JsonSerializer.Deserialize<AllyOptionChain>(_jsonString);
        _singleStrike = _optionChain.Response.Quotes.Strikes[0];
    }
    
    [Fact]
    public void FileHadData() => _jsonString.ShouldNotBeNullOrEmpty();

    [Fact]
    public void ValidMaps_Symbol() => _singleStrike.Symbol.ShouldBe("AAPL");
}