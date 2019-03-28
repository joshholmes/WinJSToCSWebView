using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace FileAccessPolyFill
{
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
}
