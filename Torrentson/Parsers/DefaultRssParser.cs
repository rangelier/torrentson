﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Torrentson.Contracts;

namespace Torrentson.Parsers
{
    /// <summary>
    /// The default RSS parser for RSS 2.0 feeds.
    /// </summary>
    public class DefaultRssParser : IRssParser
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
                       Magnet = item.Element("enclosure") != null && item.Element("enclosure").Attribute("url") != null
                       ? item.Element("enclosure").Attribute("url").Value
                       : string.Empty,
                       DatePublished = item.Element("pubDate") != null
                       ? (DateTime?)Convert.ToDateTime(item.Element("pubDate").Value)
                       : null,
                   };
        }
    }
}
