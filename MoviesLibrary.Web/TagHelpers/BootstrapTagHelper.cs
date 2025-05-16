using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MoviesLibrary.Web.TagHelpers;
[HtmlTargetElement("bootstrap")]
public class BootstrapTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "link";
        output.TagMode = TagMode.SelfClosing;
        output.Attributes.Add("rel", "stylesheet");
        output.Attributes.Add("type", "text/css");
        output.Attributes.Add("href", "https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css");
    }
}
