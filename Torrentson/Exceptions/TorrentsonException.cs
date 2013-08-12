using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Torrentson.Exceptions
{
    public class TorrentsonException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentsonException" /> class.
        /// </summary>
        public TorrentsonException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentsonException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public TorrentsonException(string msg)
            : base(msg) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentsonException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public TorrentsonException(string msg, Exception innerException)
            : base(msg, innerException) { }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; protected set; }
    }
}
