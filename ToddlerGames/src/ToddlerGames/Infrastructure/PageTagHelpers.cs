using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ToddlerGames.Models.ViewModels;

namespace ToddlerGames.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.pages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.AddCssClass("footerNav");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = "Topic " + i });
                tag.InnerHtml.Append("Topic " + i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
