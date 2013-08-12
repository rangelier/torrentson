using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torrentson.Contracts;
using Torrentson.Parsers;

namespace Torrentson
{
    /// <summary>
    /// The container for torrent feeds.
    /// </summary>
    public sealed class Torrentson
    {
        private static readonly Lazy<Torrentson> instance = new Lazy<Torrentson>(() => new Torrentson());

        /// <summary>
        /// The build-in collection of rss feeds.
        /// </summary>
        private IList<RssInfo> rssFeeds = new List<RssInfo>
        {
            new RssInfo("http://isohunt.com/js/rss/?iht=1&noSL", new IsohuntParser(), RssCategory.Movies),
            new RssInfo("http://isohunt.com/js/rss/?iht=2&noSL", new IsohuntParser(), RssCategory.Music),
            new RssInfo("http://isohunt.com/js/rss/?iht=3&noSL", new IsohuntParser(), RssCategory.Tv),
            new RssInfo("http://isohunt.com/js/rss/?iht=4&noSL", new IsohuntParser(), RssCategory.Games),
            new RssInfo("http://isohunt.com/js/rss/?iht=5&noSL", new IsohuntParser(), RssCategory.Apps),
            new RssInfo("http://isohunt.com/js/rss/?iht=6&noSL", new IsohuntParser(), RssCategory.Pictures),
            new RssInfo("http://isohunt.com/js/rss/?iht=7&noSL", new IsohuntParser(), RssCategory.Anime),
            new RssInfo("http://isohunt.com/js/rss/?iht=8&noSL", new IsohuntParser(), RssCategory.Comics),
            new RssInfo("http://isohunt.com/js/rss/?iht=9&noSL", new IsohuntParser(), RssCategory.Books),
            new RssInfo("http://isohunt.com/js/rss/?iht=10&noSL", new IsohuntParser(), RssCategory.Videos),
            new RssInfo("http://www.ezrss.it/feed/", new EzTvRssParser(), RssCategory.Videos),
            new RssInfo("http://kat.ph/tv/?rss=1", new KickassTorrentParser(), RssCategory.Tv),
            new RssInfo("http://kat.ph//movies/?rss=1", new KickassTorrentParser(), RssCategory.Movies),
            new RssInfo("http://kat.ph/music/?rss=1", new KickassTorrentParser(), RssCategory.Music),
            new RssInfo("http://kat.ph/games/?rss=1", new KickassTorrentParser(), RssCategory.Games),
            new RssInfo("http://kat.ph/applications/?rss=1", new KickassTorrentParser(), RssCategory.Applications),
            new RssInfo("http://kat.ph/anime/?rss=1", new KickassTorrentParser(), RssCategory.Anime),
            new RssInfo("http://kat.ph/books/?rss=1", new KickassTorrentParser(), RssCategory.Books),
            new RssInfo("http://pirateproxy.net/feeds/100",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/101",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/102",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/103",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/104",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/199",new PiratebayRssParser(), RssCategory.Music),
            new RssInfo("http://pirateproxy.net/feeds/200",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/201",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/202",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/203",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/204",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/205",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/206",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/207",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/208",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/209",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/299",new PiratebayRssParser(), RssCategory.Movies),
            new RssInfo("http://pirateproxy.net/feeds/300",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/301",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/302",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/303",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/304",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/305",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/306",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/399",new PiratebayRssParser(), RssCategory.Applications),
            new RssInfo("http://pirateproxy.net/feeds/400",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/401",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/402",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/403",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/404",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/405",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/406",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/407",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/408",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/499",new PiratebayRssParser(), RssCategory.Games),
            new RssInfo("http://pirateproxy.net/feeds/600",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/601",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/602",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/603",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/604",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/605",new PiratebayRssParser(), RssCategory.Other),
            new RssInfo("http://pirateproxy.net/feeds/699",new PiratebayRssParser(), RssCategory.Other)
        };
        /// <summary>
        /// Initializes a new instance of the <see cref="Torrentson" /> class.
        /// </summary>
        private Torrentson() { }
        /// <summary>
        /// Gets the current torrentson instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Torrentson Instance
        {
            get { return instance.Value; }
        }
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public string[] Categories
        {
            get { return this.rssFeeds.Select(x => x.Category).Distinct().ToArray(); }
        }
        /// <summary>
        /// Gets the RSS feeds.
        /// </summary>
        /// <value>
        /// The RSS feeds.
        /// </value>
        public IList<RssInfo> RssFeeds
        {
            get { return this.rssFeeds; }
        }
        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        public Torrentson Register()
        {
            return Torrentson.Instance;
        }
    }
}
