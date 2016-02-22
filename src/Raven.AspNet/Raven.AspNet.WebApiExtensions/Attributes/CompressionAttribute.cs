using Raven.AspNet.WebApiExtensions.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Threading;

namespace Raven.AspNet.WebApiExtensions.Attributes
{
    /// <summary>
    /// 压缩
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CompressionAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<string, CompressionType> dict = new Dictionary<string, CompressionType>
        {
            {  nameof(CompressionType.Deflate).ToLower(), CompressionType.Deflate },
            {  nameof(CompressionType.GZip).ToLower(), CompressionType.GZip },
            {  nameof(CompressionType.Zlib).ToLower(), CompressionType.Zlib }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actContext)
        {
            var content = actContext.Response.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            //byte[] zlibbedContent = bytes == null ? new byte[0] : CompressionHelper.DeflateByte(bytes, CompressionType);

            if (bytes != null)
            {
                byte[] zlibbedContent = null;
                string encoding = null;
                CompressionType compressionType = GetCompressionType(actContext.Request, out encoding);
                if (compressionType != CompressionType.None)
                {
                    zlibbedContent = CompressionHelper.DeflateByte(bytes, compressionType);
                    var newContent = new ByteArrayContent(zlibbedContent);
                    newContent.Headers.Add("Content-encoding", encoding);
                    newContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content.Headers.ContentType.MediaType);

                    actContext.Response.Content = newContent;
                    //actContext.Response.Content.Headers.Add("Content-encoding", encoding);
                }
            }

            base.OnActionExecuted(actContext);
        }

        //public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    var content = actionExecutedContext.Response.Content;
        //    var bytes = content == null ? null : await content.ReadAsByteArrayAsync();
        //    //byte[] zlibbedContent = bytes == null ? new byte[0] : CompressionHelper.DeflateByte(bytes, CompressionType);

        //    if (bytes != null)
        //    {
        //        byte[] zlibbedContent = null;
        //        string encoding = null;
        //        CompressionType compressionType = GetCompressionType(actionExecutedContext.Request, out encoding);
        //        if (compressionType != CompressionType.None)
        //        {
        //            zlibbedContent = CompressionHelper.DeflateByte(bytes, compressionType);
        //            actionExecutedContext.Response.Content.Headers.Add("Content-encoding", encoding);
        //            actionExecutedContext.Response.Content = new ByteArrayContent(zlibbedContent);
        //        }
        //    }
        //    await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private CompressionType GetCompressionType(HttpRequestMessage request, out string encoding)
        {
            CompressionType compressionType = CompressionType.None;
            encoding = "deflate";
            var endodings = request.Headers.AcceptEncoding;
            foreach (var e in endodings)
            {
                var value = e.Value.ToLower();
                if (dict.TryGetValue(value, out compressionType))
                {
                    encoding = value;
                    break;
                }
            }

            return compressionType;
        }
    }
}
