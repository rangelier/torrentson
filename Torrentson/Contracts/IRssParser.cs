using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Torrentson.Contracts
{
    public interface IRssParser
    {
        /// <summary>
        /// Parses the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="keywords">The keywords.</param>
        /// <returns>The list of torrents</returns>
        IEnumerable<Torrent> Parse(string xml, params string[] keywords);
    }
}
