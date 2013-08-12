using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Torrentson.Contracts
{
    /// <summary>
    /// The scraper.
    /// </summary>
    public interface IScraper
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string Url { get; }

        /// <summary>
        /// Starts the scraping process.
        /// </summary>
        void StartScraping();
    }
}
