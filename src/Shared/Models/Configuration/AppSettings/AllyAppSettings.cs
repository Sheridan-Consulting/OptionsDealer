namespace Shared.Models.Configuration;

public class AllyAppSettings
{
    public bool Active { get; set; }
    public string OAuth_ConsumerKey { get; set; }

    public string OAuth_ConsumerSecret { get; set; }

    public string OAuth_Token { get; set; }

    public string OAuth_TokenSecret { get; set; }
}