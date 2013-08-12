using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Torrentson.Exceptions
{
    public class ScrapeException : TorrentsonException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeException" /> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public ScrapeException(string url)
        {
            base.Url = url;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeException"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="msg">The MSG.</param>
        public ScrapeException(string url, string msg)
            : base(msg)
        {
            base.Url = url;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrapeException"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public ScrapeException(string url, string msg, Exception innerException)
            : base(msg, innerException)
        {
            base.Url = url;
        }
    }
}
