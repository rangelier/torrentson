using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Torrentson.Contracts;

namespace Torrentson.Parsers
{
    /// <summary>
    /// The isohunt rss parser.
    /// </summary>
    public class IsohuntParser : IRssParser
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
            string origin = document.Descendants("channel").First().Element("title").Value;

            return from item in document.Descendants("item")
                   where item.Element("title") != null && keywords.Any(x => item.Value.ToLowerInvariant().Contains(x.ToLowerInvariant()))
                   select new Torrent
                                      {
                                          Origin = origin,
                                          Title = item.Element("title") != null
                                          ? item.Element("title").Value
                                          : string.Empty,
                                          Magnet = CreateMagnet(item),
                                          DatePublished = item.Element("pubDate") != null
                                          ? (DateTime?)Convert.ToDateTime(item.Element("pubDate").Value)
                                          : null,
                                      };
        }
        /// <summary>
        /// Creates the magnet.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string CreateMagnet(XElement item)
        {
            string magnet = string.Empty;

            string title = item.Element("title").Value;
            string url = item.Element("enclosure") != null && item.Element("enclosure").Attribute("url") != null 
                ?item.Element("enclosure").Attribute("url").Value
                : string.Empty;

            string infoHash = Utils.GetInfoHashFromUrl(url);
            magnet = Utils.CreateMagnetFromInfoHash(infoHash, title);

            return magnet;
        }
    }
}
