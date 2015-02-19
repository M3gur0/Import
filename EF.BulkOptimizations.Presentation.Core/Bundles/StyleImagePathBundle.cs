namespace EF.BulkOptimizations.Presentation.Core.Bundles
{
    using System.Web.Optimization;

    /// <summary>
    /// Bungle dedicated to image path references in css files.
    /// </summary>
    public class StyleImagePathBundle : Bundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleImagePathBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path used to reference the <see cref="T:System.Web.Optimization.Bundle" /> from within a view or Web page.</param>
        public StyleImagePathBundle(string virtualPath)
            : base(virtualPath)
        {
            base.Transforms.Add(new StyleRelativePathTransform());
            base.Transforms.Add(new CssMinify());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleImagePathBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path used to reference the <see cref="T:System.Web.Optimization.Bundle" /> from within a view or Web page.</param>
        /// <param name="cdnPath">An alternate url for the bundle when it is stored in a content delivery network.</param>
        public StyleImagePathBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
            base.Transforms.Add(new StyleRelativePathTransform());
            base.Transforms.Add(new CssMinify());
        }
    }
}