using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class WindowsRT
    {
        public WindowsRT()
        {
            this.Storage = new StorageClass();
        }

        public StorageClass Storage { get; private set; }

    }
}
