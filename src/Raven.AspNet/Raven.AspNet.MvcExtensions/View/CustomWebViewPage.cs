using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Raven.AspNet.MvcExtensions.View
{
    /// <summary>
    /// 自定义web页面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CustomWebViewPage<T> : WebViewPage<T>
    {
        private static HashSet<string> _scriptsHs = new HashSet<string>();
        private static HashSet<string> _stylesHs = new HashSet<string>();

        /// <summary>
        /// 资源是否压缩
        /// </summary>
        protected abstract bool IsAssetsCompress { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomWebViewPage()
        {
        }
        

        /// <summary>
        /// RenderScript
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual IHtmlString RenderScript(string path)
        {
            var bundlesPath = path.ToLower().Replace(".js", "").Replace(".", "_");//.Replace("assets", "bundles");
            var bundles = System.Web.Optimization.BundleTable.Bundles;

            if (!_scriptsHs.Contains(path))
            {
                lock (_scriptsHs)
                {
                    if (!_scriptsHs.Contains(path) && !bundles.Any(m => m.Path == path))
                    {
                        bundles.Add(new System.Web.Optimization.ScriptBundle(bundlesPath).Include(path));
                        _scriptsHs.Add(path);
                    }
                }
            }


            //是否启用资源压缩
            if (IsAssetsCompress)
            {
                return System.Web.Optimization.Scripts.Render(bundlesPath);
            }
            else
            {
                return System.Web.Optimization.Scripts.Render(path);
            }

        }


        /// <summary>
        /// ScriptUrl
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string ScriptUrl(string path)
        {
            var bundlesPath = path.ToLower().Replace(".js", "").Replace(".", "_");//.Replace("assets", "bundles");
            var bundles = System.Web.Optimization.BundleTable.Bundles;

            if (!_scriptsHs.Contains(path))
            {
                lock (_scriptsHs)
                {
                    if (!_scriptsHs.Contains(path) && !bundles.Any(m => m.Path == path))
                    {
                        bundles.Add(new System.Web.Optimization.ScriptBundle(bundlesPath).Include(path));
                        _scriptsHs.Add(path);
                    }
                }
            }


            //是否启用资源压缩
            if (IsAssetsCompress)
            {
                return System.Web.Optimization.Scripts.Url(bundlesPath).ToString();
            }
            else
            {
                return System.Web.Optimization.Scripts.Url(path).ToString();
            }

        }

        /// <summary>
        /// RenderStyle
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual IHtmlString RenderStyle(string path)
        {
            var bundlesPath = path.ToLower().Replace(".css", "").Replace(".", "_");//.Replace("assets", "bundles");
            var bundles = System.Web.Optimization.BundleTable.Bundles;

            if (!_stylesHs.Contains(path))
            {
                lock (_stylesHs)
                {
                    if (!_stylesHs.Contains(path) && !bundles.Any(m => m.Path == path))
                    {
                        bundles.Add(new System.Web.Optimization.StyleBundle(bundlesPath).Include(path));
                        _stylesHs.Add(path);
                    }
                }
            }

            //是否启用资源压缩
            if (IsAssetsCompress)
            {
                return System.Web.Optimization.Styles.Render(bundlesPath);
            }
            else
            {
                return System.Web.Optimization.Styles.Render(path);
            }

        }

        /// <summary>
        /// StyleUrl
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string StyleUrl(string path)
        {
            var bundlesPath = path.ToLower().Replace(".css", "").Replace(".", "_");//.Replace("assets", "bundles");
            var bundles = System.Web.Optimization.BundleTable.Bundles;

            if (!_stylesHs.Contains(path))
            {
                lock (_stylesHs)
                {
                    if (!_stylesHs.Contains(path) && !bundles.Any(m => m.Path == path))
                    {
                        bundles.Add(new System.Web.Optimization.StyleBundle(bundlesPath).Include(path));
                        _stylesHs.Add(path);
                    }
                }
            }

            //是否启用资源压缩
            if (IsAssetsCompress)
            {
                return System.Web.Optimization.Styles.Url(bundlesPath).ToString();
            }
            else
            {
                return System.Web.Optimization.Styles.Url(path).ToString();
            }

        }
    }
}
