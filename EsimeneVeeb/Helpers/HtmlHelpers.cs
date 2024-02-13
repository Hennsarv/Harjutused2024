using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace EsimeneVeeb.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString ActionButton(this HtmlHelper htmlHelper, string buttonText, string action, string controller, object routeValues = null, object htmlAttributes = null, object content = null, string icon = "")
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);

            var button = new TagBuilder("button");
            button.InnerHtml = buttonText + icon;
            button.Attributes["onclick"] = $"window.location.href='{url}'";

            if (htmlAttributes != null)
            {
                button.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            if (content != null)
            {
                button.InnerHtml += content.ToString();
            }

            return MvcHtmlString.Create(button.ToString());
        }




        public static string NameFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());
            return metadata.DisplayName ?? metadata.PropertyName;
        }

        public static string NameFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return metadata.DisplayName ?? metadata.PropertyName;
        }




    }

}
