using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class StorageClass
    {
        public StorageClass ()
        {
            this.KnownFolders = new KnownFoldersClass();
            KnownFolderId = Enum.GetNames(typeof(Windows.Storage.KnownFolderId));
            CreationCollisionOption = Enum.GetNames(typeof(Windows.Storage.CreationCollisionOption));
            FileIO = new FileIO();
            Streams = new Streams();
        }
        public KnownFoldersClass KnownFolders { get; set; }
        public string[] KnownFolderId { get; set; }
        public string[] CreationCollisionOption { get; set; }
        public FileIO FileIO { get; set; }

        public FileAccessPolyFill.Streams Streams { get; set; }
    }
}

