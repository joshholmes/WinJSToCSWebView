using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class Streams
    {
        public Streams()
        {
            //InMemoryRandomAccessStream = new Storage.InMemoryRandomAccessStream();
        }
        public FileAccessPolyFill.Storage.InMemoryRandomAccessStream InMemoryRandomAccessStream() {
            return new Storage.InMemoryRandomAccessStream();
        }
    }
}
