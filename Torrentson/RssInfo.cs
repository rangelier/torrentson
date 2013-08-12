using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torrentson.Contracts;

namespace Torrentson
{
    /// <summary>
    /// The rss feed information.
    /// </summary>
    public class RssInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssInfo" /> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parser">The parser.</param>
        /// <param name="category">The category.</param>
        public RssInfo(string url, IRssParser parser, string category)
        {
            Url = url;
            Parser = parser;
            Category = category;
        }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the parser.
        /// </summary>
        /// <value>
        /// The parser.
        /// </value>
        public IRssParser Parser { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }
    }
}
