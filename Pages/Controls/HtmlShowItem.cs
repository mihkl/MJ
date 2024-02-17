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
    public static IHtmlContent EditItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {

        var lab = h.LabelFor(e, new { @class = "control-label" });
        var ed = h.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } });
        var val = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

        var div = new TagBuilder("div");
        div.AddCssClass("form-group");
        div.InnerHtml.AppendHtml(lab);
        div.InnerHtml.AppendHtml(ed);
        div.InnerHtml.AppendHtml(val);

        var writer = new StringWriter();
        div.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());
    }

    public static IHtmlContent IndexTable<TModel, TValue> (this IHtmlHelper<TModel> h,Expression<Func<TModel, TValue>> e,TValue val) {
        var td = new TagBuilder("td");
        td.InnerHtml.AppendHtml(h.DisplayFor(e, val));
        return td;
    }
    public static IHtmlContent IndexHeader (this IHtmlHelper h, string headerText) {
        
        var th = new TagBuilder("th");
        th.InnerHtml.Append(headerText);
        return th;
    }







}



