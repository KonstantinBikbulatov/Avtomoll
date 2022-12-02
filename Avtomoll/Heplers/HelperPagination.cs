using Avtomoll.Abstract;
using Avtomoll.Model;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace Avtomoll.Heplers
{
    public static class HelperPagination
    {
        public static HtmlString PaginationBootstrap(
    this IHtmlHelper helper,
    IPagination model)
        {
            var tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination");

            /*string partRoute = model.NameModel == null
                ? "Products"
                : model.NameModel;*/

            for (int i = 0; i < model.PagesQuantity; i++)
            {
                var tagLi = new TagBuilder("li"); // <li></li>
                tagLi.AddCssClass("page-item");

                if (model.ActivePage == i + 1)
                    tagLi.AddCssClass("active");

                var tagA = new TagBuilder("a"); // <a> </a>
                tagA.AddCssClass("page-link");
                tagA.MergeAttribute("href", $"/manager/{model.NameModel}/{i + 1}");
                tagA.InnerHtml.SetContent((i + 1).ToString());
                tagLi.InnerHtml.AppendHtml(tagA);
                tagUl.InnerHtml.AppendHtml(tagLi);
            }
            var writer = new System.IO.StringWriter();
            tagUl.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}