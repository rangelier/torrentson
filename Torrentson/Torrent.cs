using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Torrentson
{
    public class Torrent
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public string Origin { get; set; }
        /// <summary>
        /// Gets or sets the magnet.
        /// </summary>
        /// <value>
        /// The magnet.
        /// </value>
        public string Magnet { get; set; }
        /// <summary>
        /// Gets or sets the date published.
        /// </summary>
        /// <value>
        /// The date published.
        /// </value>
        public DateTime? DatePublished { get; set; }
    }
}
