using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class StorageFolder
    {
        public StorageFolder() { }
        public StorageFolder(Windows.Storage.StorageFolder folder)
        {
            _folder = folder;
        }
        private Windows.Storage.StorageFolder _folder;
        public string Name { get { return _folder.Name; } }
        public string Path { get { return _folder.Path; } }


        #region public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFile> CreateFileAsync(string desiredName, Windows.Storage.CreationCollisionOption options)
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
        #endregion

        #region Public async Task<FileAccessPolyFill.StorageFile> TryGetItemAsyncHelper(string name)
        //public IAsyncOperation<StorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFile> TryGetItemAsync(string name)
        {
            return this.TryGetItemAsyncHelper(name).AsAsyncOperation();
        }

        private async Task<FileAccessPolyFill.StorageFile> TryGetItemAsyncHelper(string name)
        {
            var content = await _folder.TryGetItemAsync(name);

            return new FileAccessPolyFill.StorageFile((Windows.Storage.StorageFile)content);
        }
        #endregion
    }
}
