using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLHelpers.Helpers
{
    public static class TestHelper
    {
        public static MvcHtmlString ShowProducts(this HtmlHelper html, IEnumerable<Models.Product> products)
        {
            TagBuilder table = new TagBuilder("table");
            foreach (Models.Product product in products)
            {
                TagBuilder tr = new TagBuilder("tr");

                TagBuilder tdId = new TagBuilder("td");
                tdId.SetInnerText(product.Id.ToString());

                TagBuilder tdName = new TagBuilder("td");
                tdName.SetInnerText(product.Name);

                TagBuilder tdPrice = new TagBuilder("td");
                tdPrice.SetInnerText(product.Price.ToString());

                TagBuilder tdWeight = new TagBuilder("td");
                tdWeight.SetInnerText(product.Weight.ToString());

                tr.InnerHtml += tdId;
                tr.InnerHtml += tdName;
                tr.InnerHtml += tdPrice;
                tr.InnerHtml += tdWeight;
                table.InnerHtml += tr;
            }
            return new MvcHtmlString(table.ToString());
        }
    }

}