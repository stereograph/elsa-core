using System.Text.Encodings.Web;
using Elsa.Expressions.Liquid.Services;
using Fluid;

namespace Elsa.Expressions.Liquid.Options;

/// <summary>
/// Options for configuring the Liquid templating engine.
/// </summary>
public class FluidOptions
{
    /// <summary>
    /// A dictionary of filter registrations.
    /// </summary>
    public Dictionary<string, Type> FilterRegistrations { get; } = new();

    /// <summary>
    /// A list of parser configurations.
    /// </summary>
    public IList<Action<LiquidParser>> ParserConfiguration { get; } = new List<Action<LiquidParser>>();

    /// <summary>
    /// Gets or sets a value indicating whether to allow access to the configuration object.
    /// </summary>
    public bool AllowConfigurationAccess { get; set; }

    /// <summary>
    /// Gets or sets the default encoder to use when rendering a template.
    /// </summary>
    public TextEncoder Encoder { get; set; } = NullEncoder.Default;

    /// <summary>
    /// Get or set the fluid filters enabled in Elsa.
    /// </summary>
    public Action<TemplateContext> ConfigureFilters { get; set; } = _ => { };
}