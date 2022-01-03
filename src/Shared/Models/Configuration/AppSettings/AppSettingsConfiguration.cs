using Shared.Models.Rules;

namespace Shared.Models.Configuration;

public class AppSettingsConfiguration
{
    public AllyAppSettings Ally { get; set; }
    public OptionRuleParameters OptionRuleParameters { get; set; }
}