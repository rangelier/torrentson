using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Torrentson.Contracts;
using Torrentson.Processor.Exceptions;

namespace Torrentson.Processor
{
    /// <summary>
    /// The torrentson processor that processes the remote rss feeds concurrently.
    /// </summary>
    public sealed class TorrentsonProcessor
    {
        #region Fields
        private int? concurrentRequestCount;
        private readonly HttpClient httpClient; 
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentsonProcessor" /> class.
        /// </summary>
        public TorrentsonProcessor()
        {
            this.httpClient = new HttpClient();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TorrentsonProcessor" /> class.
        /// </summary>
        /// <param name="concurrentRequestCount">The concurrent request count.</param>
        public TorrentsonProcessor(int concurrentRequestCount)
            :this()
        {
            this.concurrentRequestCount = concurrentRequestCount;
        }
        /// <summary>
        /// Starts the async.
        /// </summary>
        /// <param name="feeds">The feeds.</param>
        /// <param name="keywords">The keywords.</param>
        /// <returns>The list of torrents.</returns>
        public async Task<IEnumerable<Torrent>> StartAsync(IDictionary<string, IRssParser> feeds, params string[] keywords)
        {
            List<Task> tasks = new List<Task>();
            List<Torrent> torrents = new List<Torrent>();
            List<ProcessingException> errors = new List<ProcessingException>();

            //set the number of concurrent requests to the number of rss feeds.
            int initialCount = concurrentRequestCount ?? feeds.Keys.Count;
            SemaphoreSlim throttler = new SemaphoreSlim(initialCount: initialCount);

            foreach (KeyValuePair<string, IRssParser> kvp in feeds)
            {
                await throttler.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        string xml = await this.httpClient.GetStringAsync(kvp.Key);

                        var result = kvp.Value.Parse(xml, keywords);
                        torrents.AddRange(result);
                    }
                    catch (Exception innerException)
                    {
                        errors.Add(new ProcessingException(kvp.Key, "An error occured while processing the URL. Please check the inner exception for more details", innerException));
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);

            return torrents;
        }
        /// <summary>
        /// Starts the async.
        /// </summary>
        /// <param name="feeds">The feeds.</param>
        /// <param name="keywords">The keywords.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Torrent>> StartAsync(IEnumerable<RssInfo> feeds, params string[] keywords)
        {
            List<Task> tasks = new List<Task>();
            List<Torrent> torrents = new List<Torrent>();
            List<ProcessingException> errors = new List<ProcessingException>();

            //set the number of concurrent requests to the number of rss feeds.
            int initialCount = concurrentRequestCount ?? feeds.Count();
            SemaphoreSlim throttler = new SemaphoreSlim(initialCount: initialCount);

            foreach (RssInfo rssInfo in feeds)
            {
                await throttler.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        string xml = await this.httpClient.GetStringAsync(rssInfo.Url);

                        var result = rssInfo.Parser.Parse(xml, keywords);
                        torrents.AddRange(result);
                    }
                    catch (Exception innerException)
                    {
                        errors.Add(new ProcessingException(rssInfo.Url, "An error occured while processing the URL. Please check the inner exception for more details", innerException));
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);

            return torrents;
        }
    }
}
