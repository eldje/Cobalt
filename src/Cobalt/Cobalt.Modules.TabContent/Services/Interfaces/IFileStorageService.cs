using System.Collections.Generic;

namespace Cobalt.Modules.TabContent.Services.Interfaces
{
    public interface IFileStorageService
    {
        bool CreateNewContainer(string containerName);
        bool UploadNewBlob(string containerName, string saveAs, string path);
        IEnumerable<string> GetBlobs(string containerName);
        bool DownloadBlob(string containerName, string blobReference, string saveTo);
    }
}