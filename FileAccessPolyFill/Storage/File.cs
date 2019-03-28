using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
    [AllowForWeb]
    public sealed class StorageFile
    {
        public StorageFile() { }
        public StorageFile(Windows.Storage.StorageFile file)
        {
            _file = file;
        }
        internal Windows.Storage.StorageFile _file;

        public string Name { get { return _file.Name; } }
        public string Path { get { return _file.Path; } }

        #region public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFile> CreateFileAsync(string desiredName, Windows.Storage.CreationCollisionOption options)
        //public IAsyncOperation<StorageFile> CreateFileAsync(string desiredName, CreationCollisionOption options)
        public Windows.Foundation.IAsyncOperation<FileAccessPolyFill.StorageFolder> GetParentAsync()
        {
            return this.GetParentAsyncHelper().AsAsyncOperation();
        }

        private async Task<FileAccessPolyFill.StorageFolder> GetParentAsyncHelper()
        {
            var content = await _file.GetParentAsync();

            return new FileAccessPolyFill.StorageFolder(content);
        }
        #endregion

    }
}
