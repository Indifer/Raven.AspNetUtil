using Raven.AspNet.WebApiExtensions.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Threading;

namespace Raven.AspNet.WebApiExtensions.Filters
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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="actContext"></param>
        //public override void OnActionExecuted(HttpActionExecutedContext actContext)
        //{
        //    var content = actContext.Response.Content;
        //    if (content != null)
        //    {
        //        string encoding = null;
        //        CompressionType compressionType = GetCompressionType(actContext.Request, out encoding);
        //        if (compressionType != CompressionType.None)
        //        {
        //            var bytes = content.ReadAsByteArrayAsync().Result;
        //            if (bytes != null)
        //            {
        //                byte[] zlibbedContent = null;
        //                zlibbedContent = CompressionHelper.CompressionByte(bytes, compressionType);
        //                var newContent = new ByteArrayContent(zlibbedContent);
        //                newContent.Headers.Add("Content-encoding", encoding);
        //                newContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content.Headers.ContentType.MediaType);

        //                actContext.Response.Content = newContent;
        //            }
        //        }

        //    }

        //    base.OnActionExecuted(actContext);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var content = actionExecutedContext.Response.Content;
            if (content != null)
            {
                string encoding = null;
                CompressionType compressionType = GetCompressionType(actionExecutedContext.Request, out encoding);
                if (compressionType != CompressionType.None)
                {
                    var bytes = content.ReadAsByteArrayAsync().Result;
                    if (bytes != null)
                    {
                        byte[] zlibbedContent = null;
                        zlibbedContent = await CompressionHelper.CompressionByteAsync(bytes, compressionType);
                        var newContent = new ByteArrayContent(zlibbedContent);
                        newContent.Headers.Add("Content-encoding", encoding);
                        newContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content.Headers.ContentType.MediaType);

                        actionExecutedContext.Response.Content = newContent;
                    }
                }

            }
            await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

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
