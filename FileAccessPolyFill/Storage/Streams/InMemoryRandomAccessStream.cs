using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill.Storage
{
    [AllowForWeb]
    public sealed class InMemoryRandomAccessStream
    {
        public InMemoryRandomAccessStream() {
            _stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
        }
        public InMemoryRandomAccessStream(Windows.Storage.Streams.InMemoryRandomAccessStream stream)
        {
            _stream = stream;
        }
        internal Windows.Storage.Streams.InMemoryRandomAccessStream _stream;
    }
}
