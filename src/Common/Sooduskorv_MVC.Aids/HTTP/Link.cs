using System;

namespace Sooduskorv_MVC.Aids.HTTP
{
    public class Link
    {
        public Link(string displayName, string relativeLink) : this(displayName, new Uri(relativeLink, UriKind.Relative)) { }

        public Link(string displayName, Uri url, string propertyName = null)
        {
            DisplayName = displayName;
            Url = url;
            PropertyName = propertyName ?? displayName;
        }
        public string DisplayName { get; }
        public string Rel { get; set; }
        public Uri Url { get; }
        public string Method { get; set; }
        public string PropertyName { get; }
    }
}