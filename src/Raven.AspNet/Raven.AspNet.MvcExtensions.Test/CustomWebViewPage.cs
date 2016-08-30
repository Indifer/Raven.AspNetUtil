using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNet.MvcExtensions.Test
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomWebViewPage<T> : Raven.AspNet.MvcExtensions.View.CustomWebViewPage<T>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override bool IsAssetsCompress
        {
            get
            {
                if (Request["_debug"] == "1")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override string StyleUrl(string path)
        {
            return base.StyleUrl(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override string ScriptUrl(string path)
        {
            return base.ScriptUrl(path);
        }

        /// <summary>
        /// 协议名称
        /// </summary>
        public string Scheme
        {
            get
            {
                return Request.Url.Scheme;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
        }
    }
}
