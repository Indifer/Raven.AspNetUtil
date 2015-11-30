using Raven.AspNet.WebApiExtensions.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Raven.AspNet.WebApiExtensions.Attributes
{
    public class DeflateCompressionAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext actContext)
        {
            var content = actContext.Response.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            var zlibbedContent = bytes == null ? new byte[0] :
            CompressionHelper.DeflateByte(bytes);
            actContext.Response.Content = new ByteArrayContent(zlibbedContent);
            actContext.Response.Content.Headers.Add("Content-encoding", "deflate");
            base.OnActionExecuted(actContext);
        }
    }
}
