namespace EF.BulkOptimizations.Presentation.Core.Bundles
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Optimization;

    /// <summary>
    /// Transform relative URL in CSS files to its corresponding URL taking bundle optimization in account.
    /// </summary>
    public class StyleRelativePathTransform : IBundleTransform
    {
        /// <summary>
        /// Transforms the content in the <see cref="T:System.Web.Optimization.BundleResponse" /> object.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <param name="response">The bundle response.</param>
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = String.Empty;
            Regex pattern = new Regex(@"url\s*\(\s*([""']?)([^:)]+)\1\s*\)", RegexOptions.IgnoreCase);

            foreach (var cssFileInfo in response.Files)
            {
                string contents = string.Empty;
                using (var sr = new StreamReader(cssFileInfo.VirtualFile.Open()))
                {
                    contents = sr.ReadToEnd();
                }

                MatchCollection matches = pattern.Matches(contents);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        var uri = new Uri(new Uri("http://uri"), cssFileInfo.VirtualFile.VirtualPath);
                        var absoluteFilePath = uri.Segments.Take(uri.Segments.Count() - 1).Aggregate((a, b) => a + b) + match.Groups[2].Value;

                        contents = contents.Replace(match.Groups[0].Value, String.Format("url({0})", absoluteFilePath));
                    }
                }

                response.Content = String.Format("{0}\r\n{1}", response.Content, contents);
            }
        }
    }
}