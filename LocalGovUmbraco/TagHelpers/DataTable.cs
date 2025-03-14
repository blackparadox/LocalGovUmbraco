using LocalGovUmbraco.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace LocalGovUmbraco.TagHelpers
{
  /// <summary>
  /// Tag helper to dynamically render a html heading tag.
  /// </summary>
  [HtmlTargetElement("datatable", Attributes = "data", TagStructure = TagStructure.NormalOrSelfClosing)]
  public partial class DataTableTagHelper : TagHelper
  {
    /// <summary>
    /// Backing variable for the data.
    /// </summary>
    private IEnumerable<Dictionary<string, string?>>? _data;

    /// <summary>
    /// The level of the heading
    /// </summary>
    [HtmlAttributeName("ariaLabel")]
    public string? AriaLabel { get; set; }

    /// <summary>
    /// The data for the table.
    /// </summary>
    [HtmlAttributeName("data")]
    public IEnumerable<Dictionary<string, string?>>? Data
    {
      get => _data;
      set => _data = Normalise(value);
    }

    /// <summary>
    /// Callback function to generate class values for a given row.
    /// </summary>
    [HtmlAttributeName("rowClasses")]
    public Func<Dictionary<string, string?>, string[]>? RowClasses { get; set; }

    /// <summary>
    /// Normalise the <see cref="IEnumerable{Dictionary{string, string?}}"/> ensuring all <see cref="Dictionary<string, string?>"/> contain the same keys.
    /// </summary>
    /// 
    /// <param name="data"></param>
    /// <returns></returns>
    private static IEnumerable<Dictionary<string, string?>>? Normalise(IEnumerable<Dictionary<string, string?>>? data)
    {
      if (data is null)
      {
        return null;
      }

      IEnumerable<IEnumerable<string>> eKeys = data.Select(x => x.Keys);
      IEnumerable<string> keys = eKeys.Skip(1).Aggregate(new HashSet<string>(eKeys.First()), (h, e) => h.Union(e).ToHashSet());
      return data.Select((x, i) =>
      {
        Dictionary<string, string?> dict = [];
        foreach (string key in keys)
        {
          dict.Add(key, x.GetValue(key));
        }

        return dict;
      });
    }

    /// <summary>
    /// Check if a given string contains only a number.
    /// </summary>
    /// 
    /// <param name="input">The string to check.</param>
    /// 
    /// <returns>The result of the check.</returns>
    private static bool IsNumeric(string input) => decimal.TryParse(input.Trim().TrimEnd('%'), NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out _);

    /// <inheritdoc/>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      if (!(Data?.Any() ?? false) || Data.Max(x => x.Values.Count) == 0)
      {
        output.TagName = null;
        output.SuppressOutput();
        return;
      }

      output.TagName = "div";
      output.Attributes.Add("data-table", null);
      output.Attributes.Add("role", "table");
      if (!AriaLabel.IsNullOrWhiteSpace())
      {
        output.Attributes.Add("arial-label", AriaLabel);
      }

      int rowIndex = 1;
      foreach (Dictionary<string, string?> dict in Data)
      {
        string[] rowClasses = ["row"];
        if (RowClasses is not null)
        {
          rowClasses = [.. rowClasses.Concat(RowClasses(dict).Select(Extensions.StringExtensions.Slug).Distinct())];
        }
        output.Content.AppendHtml($"<dl class=\"{string.Join(" ", rowClasses)}\" role=\"row\" aria-rowindex=\"{rowIndex}\">");

        int cellIndex = 1;
        foreach (KeyValuePair<string, string?> item in dict)
        {
          output.Content.AppendHtml($"<dt data-key=\"{item.Key.Slug()}\" role=\"columnheader\" class=\"{(item.Value.IsNullOrWhiteSpace() ? "empty" : IsNumeric(item.Value) ? "number" : null)}\">");
          output.Content.Append(item.Key);
          output.Content.AppendHtml("</dt>");

          output.Content.AppendHtml($"<dd data-key=\"{item.Key.Slug()}\" role=\"cell\" aria-cellindex=\"{cellIndex++}\" class=\"{(item.Value.IsNullOrWhiteSpace() ? "empty" : IsNumeric(item.Value) ? "number" : null)}\">");
          output.Content.Append(item.Value);
          output.Content.AppendHtml("</dd>");
        }

        output.Content.AppendHtml("</dl>");
        rowIndex++;
      }
    }
  }
}
