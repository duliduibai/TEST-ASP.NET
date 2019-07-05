using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace VM_MVC
{
    public static class HtmlUrlHelperExtensions
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, string> pageUrlAccessor)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < pagingInfo.PageCount; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrlAccessor(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.PageIndex)
                {
                    tag.AddCssClass("selected");
                }
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
        public static MvcHtmlString GenreLinks(this UrlHelper helper,
            IEnumerable<string> genres)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var genre in genres)
            {
                sb.Append(String.Format("<span><a href = '{0}'>{1}</a></span>",
                    helper.RouteUrl("GenreHome", new { Genre = genre }), genre));
            }
            return MvcHtmlString.Create(sb.ToString());
        }
        public static MvcHtmlString ActorLinks(this UrlHelper helper,
            IEnumerable<string> acotrs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var actor in acotrs)
            {
                sb.Append(String.Format("<span><a href = '{0}'>{1}</a></span>",
                    helper.RouteUrl("ActorHome", new { Actor = actor }), actor));
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }


    public class PagingInfo
    {
        public static int PageSize
        {
            //get { return int.Parse(ConfigurationManager.AppSettings["pageSize"]); }
            get { return 5; }
        }

        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get { return (int)Math.Ceiling((decimal)RecordCount / PageSize); } }
    }

}