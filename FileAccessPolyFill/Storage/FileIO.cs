using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class FileIO
    {
        #region Public async Task WriteTextAsyncHelper(Windows.Storage.IStorageFile file, string contents)
        //public IAsyncOperation<StorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        public Windows.Foundation.IAsyncAction WriteTextAsync(FileAccessPolyFill.StorageFile file, string contents)
        {
            return this.WriteTextAsyncHelper(file._file, contents).AsAsyncAction();
        }

        //public static IAsyncAction WriteTextAsync(IStorageFile file, string contents);
        private async Task WriteTextAsyncHelper(Windows.Storage.IStorageFile file, string contents)
        {
            await Windows.Storage.FileIO.WriteTextAsync(file, contents).AsTask();
        }
        #endregion
        #region Public async Task WriteTextAsyncHelper(Windows.Storage.IStorageFile file, string contents)
        //public IAsyncOperation<StorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        public Windows.Foundation.IAsyncOperation<string> ReadTextAsync(FileAccessPolyFill.StorageFile file)
        {
            return this.WriteTextAsyncHelper(file._file).AsAsyncOperation();
        }

        //public static IAsyncAction WriteTextAsync(IStorageFile file, string contents);
        private async Task<string> WriteTextAsyncHelper(Windows.Storage.IStorageFile file)
        {
            var content = await Windows.Storage.FileIO.ReadTextAsync(file);

            return content;
        }
        #endregion

    }
}
