using System.IO;
using System.Text.Json;
using External.Ameritrade.API.Models.Options;
using Shouldly;
using Xunit;

namespace Tests.TDAmeritrade
{
    public class OptionChainTests
    {
        private readonly OptionChain _optionChain;
        private readonly string _jsonString;
        public OptionChainTests()
        {
            _jsonString = File.ReadAllText(@"files/optionchain.json");                        
            _optionChain = JsonSerializer.Deserialize<OptionChain>(_jsonString);
        }

        [Fact]
        public void FileHadData() => _jsonString.ShouldNotBeNullOrEmpty();

        [Fact]
        public void ValidMaps_Symbol() => _optionChain.Symbol.ShouldBe("AAPL");

        [Fact]
        public void ValidMaps_Option_Puts_ShouldNotBeNull()
        {
            var puts = _optionChain.Puts["2021-07-09:5"]["138.0"];
            puts.ShouldNotBeEmpty();
        }

        [Fact]
        public void ValidMaps_Option_Puts_DaysToExpire_ShouldBe5()
        {
            var puts = _optionChain.Puts["2021-07-09:5"]["138.0"];
            puts[0].DaysToExpiration.ShouldBe(5);
        }


        [Fact]
        public void ValidMaps_Option_Calls_ShouldNotBeNull()
        {
            var calls = _optionChain.Calls["2021-07-09:5"]["138.0"] ;
            calls.ShouldNotBeNull();
        }

        [Fact]
        public void ValidMaps_Option_Calls_DaysToExpire_ShouldBe5()
        {
            var calls = _optionChain.Calls["2021-07-09:5"]["138.0"] ;
            calls[0].DaysToExpiration.ShouldBe(5);
        }
    }
}