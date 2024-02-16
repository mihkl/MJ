using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MJ.Pages.Controls;
public static class HtmlEditItem {
    public static IHtmlContent EditItem<TModel, TValue>( this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {

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
    //public static IHtmlContent ShowItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {
    //<dt class = "col-sm-2">
    //        @Html.DisplayNameFor(model => model.Title)
    //    </dt>
    //    <dd class = "col-sm-10">
    //        @Html.DisplayFor(model => model.Title)
    //    </dd>

    //}
}

