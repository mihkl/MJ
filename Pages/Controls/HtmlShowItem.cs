using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MJ.Pages.Controls;

public static class HtmlShowItem {
    public static IHtmlContent ShowItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {

        var tagDt = new TagBuilder("dt");
        tagDt.AddCssClass("col-sm-2");
        tagDt.InnerHtml.AppendHtml(h.DisplayNameFor(e));

        var tagDd = new TagBuilder("dd");
        tagDd.AddCssClass("col-sm-10");
        tagDd.InnerHtml.AppendHtml(h.DisplayFor(e));

        var writer = new StringWriter();
        tagDt.WriteTo(writer, HtmlEncoder.Default);
        tagDd.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());


    }

}



