using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torrentson.Exceptions;

namespace Torrentson.Processor.Exceptions
{
    public class ProcessingException : TorrentsonException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingException" /> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public ProcessingException(string url, string msg, Exception innerException)
            : base(msg, innerException)
        {
            base.Url = url;
        }
    }
}
