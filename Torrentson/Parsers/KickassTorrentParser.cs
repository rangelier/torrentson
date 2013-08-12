using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Torrentson.Contracts;

namespace Torrentson.Parsers
{
    /// <summary>
    /// The parser for kickass torrent feeds.
    /// </summary>
    public class KickassTorrentParser : IRssParser
    {
        /// <summary>
        /// Parses the specified document.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="keywords">The keywords.</param>
        /// <returns>
        /// The list of torrents
        /// </returns>
        public IEnumerable<Torrent> Parse(string xml, params string[] keywords)
        {
            XDocument document = XDocument.Parse(xml);
            XNamespace ns = "http://xmlns.ezrss.it/0.1/"; //to find elements under this namespace.

            return from item in document.Descendants("item")
                   where item.Element("title") != null && keywords.Any(x => item.Value.ToLowerInvariant().Contains(x.ToLowerInvariant()))
                   let origin = document.Descendants("channel").First()
                   select new Torrent
                   {
                       Origin = origin.Element("title") != null
                       ? origin.Element("title").Value
                       : string.Empty,
                       Title = item.Element("title") != null
                       ? item.Element("title").Value
                       : string.Empty,
                       Magnet = item.Element(ns + "magnetURI") != null
                       ? item.Element(ns + "magnetURI").Value
                       : string.Empty,
                       DatePublished = item.Element("pubDate") != null
                       ? (DateTime?)Convert.ToDateTime(item.Element("pubDate").Value)
                       : null,
                   };
        }
    }
}
