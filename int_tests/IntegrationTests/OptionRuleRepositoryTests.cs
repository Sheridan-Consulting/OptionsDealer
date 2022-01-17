using Data;
using Data.Repository;
using Shared.Models.Data;
using Shared.Models.Rules;
using Shouldly;
using Xunit;

namespace IntegrationTests;

public class OptionRuleRepositoryTests : IClassFixture<DbFixture>
{
    
    private readonly DbFixture _fixture;

    public OptionRuleRepositoryTests(DbFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task Create_ShouldInsertNewUser()
    {
        var sut = new OptionRuleRepository(_fixture.Database);

        var symbols = new OptionRule()
        {
            UserId = "1",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };

        var loadedSymbols = await sut.GetOptionRulesByUserId(symbols.UserId);
        loadedSymbols.ShouldBeNull();

        var id = await sut.CreateOptionRule(symbols);
        id.ShouldNotBeNull();
        
        var loadedSymbol = await sut.GetOptionRuleById(id);
        loadedSymbol.ShouldNotBeNull();
        loadedSymbol.Symbols.Count.ShouldBe(2);
        loadedSymbol.UserId.ShouldBe(symbols.UserId);
    }

    [Fact]
    public async Task Create_ShouldBeAbleToQueryByUserId()
    {
        var sut = new OptionRuleRepository(_fixture.Database);

        var symbols = new OptionRule()
        {
            UserId = "1",
            Symbols = new List<string>() {"AAPL", "MSFT"},
            OptionRuleParameters = new OptionRuleParameters()
        };
        var id = await sut.CreateOptionRule(symbols);
        id.ShouldNotBeNull();
        
        var loadedSymbols = await sut.GetOptionRulesByUserId(symbols.UserId);
        loadedSymbols.Count.ShouldBeGreaterThan(0);
    }
    
    /*
    [Fact]
    public async Task CreateAsync_ShouldThrowIfUserExist()
    {
        var sut = new OptionFilterSymbolsRepository(_fixture.DbContext);

        var symbols = new OptionFilterSymbol()
        {
            User = "2",
            Symbols = new List<string>() {"AAPL", "MSFT","F"}
        };
        await sut.CreateAsync(symbols);

        var symbols2 = new OptionFilterSymbol()
        {
            User = "2",
            Symbols = new List<string>() {"AAPL", "F"}
        };
       
        var ex = await Assert.ThrowsAsync<MongoDB.Driver.MongoWriteException>(async () => await sut.CreateAsync(symbols2));
        ex.Message.Contains(symbols.User);
    }
    */
}