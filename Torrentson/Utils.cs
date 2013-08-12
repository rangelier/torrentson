using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Torrentson
{
    /// <summary>
    /// Torrent utilities.
    /// </summary>
    public static class Utils
    {
        private const string MagnetFormat = "magnet:?xt=urn:btih:";

        /// <summary>
        /// Creates the magnet from info hash.
        /// </summary>
        /// <param name="infoHash">The info hash.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns></returns>
        public static string CreateMagnetFromInfoHash(string infoHash, string displayName)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}&dn={2}", MagnetFormat, infoHash, displayName.Replace(" ", "."));
        }
        /// <summary>
        /// Gets the info hash from a URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string GetInfoHashFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("url");

            string infoHash = string.Empty;

            //does the string contain a reference to a .torrent file
            if (url.Contains(".torrent"))
            {
                string[] splitted = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                infoHash = splitted[4].Substring(0, splitted[4].IndexOf("."));
            }

            return infoHash;
        }
    }
}
