using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class WindowsRT {
        public WindowsRT()
        {
            this.Storage = new StorageClass();
        }

        public StorageClass Storage { get; private set; }

    }

    [AllowForWeb]
    public sealed class StorageClass
    {
        public StorageClass ()
        {
            this.KnownFolders = new KnownFoldersClass();
            KnownFolderId = Enum.GetNames(typeof(Windows.Storage.KnownFolderId));
            CreationCollisionOption = Enum.GetNames(typeof(Windows.Storage.CreationCollisionOption));
        }
        public KnownFoldersClass KnownFolders { get; set; }
        public string[] KnownFolderId { get; set; }
        public string[] CreationCollisionOption { get; set; }
    }

    [AllowForWeb]
    public sealed class KnownFoldersClass
    {
        public KnownFoldersClass()
        {
        }

        public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFolder> GetFolderForUserAsync(FileAccessPolyFill.WindowsR.System.User user, Windows.Storage.KnownFolderId folderId)
        {
            return this.GetFolderForUserAsyncHelper(null, Windows.Storage.KnownFolderId.PicturesLibrary).AsAsyncOperation();
        }

        private async Task<FileAccessPolyFill.StorageFolder> GetFolderForUserAsyncHelper(FileAccessPolyFill.WindowsR.System.User user, Windows.Storage.KnownFolderId folderId)
        {
            var content = await Windows.Storage.KnownFolders.GetFolderForUserAsync(null, folderId);

            return new FileAccessPolyFill.StorageFolder(content);
        }
    }

    [AllowForWeb]
    public sealed class StorageFolder
    {
        public StorageFolder() { }
        public StorageFolder(Windows.Storage.StorageFolder folder)
        {
            _folder = folder;
        }
        private Windows.Storage.StorageFolder _folder;

        //public IAsyncOperation<StorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFile> CreateFileAsync(string desiredName, Windows.Storage.CreationCollisionOption options)
        {
            return this.CreateFileAsyncHelper(desiredName, options).AsAsyncOperation();
        }

        private async Task<FileAccessPolyFill.StorageFile> CreateFileAsyncHelper(string desiredName, Windows.Storage.CreationCollisionOption options)
        {
            var content = await _folder.CreateFileAsync(desiredName, options);

            return new FileAccessPolyFill.StorageFile(content);
        }
    }

    [AllowForWeb]
    public sealed class StorageFile
    {
        public StorageFile() { }
        public StorageFile(Windows.Storage.StorageFile file)
        {
            _file = file;
        }
        private Windows.Storage.StorageFile _file;
    }

    namespace WindowsR.System
    {
        [AllowForWeb]
        public sealed class User {
            public User() { }
            public User(Windows.System.User user)
            {
                _user = user;
            }
            private Windows.System.User _user;
        }
    }
}

