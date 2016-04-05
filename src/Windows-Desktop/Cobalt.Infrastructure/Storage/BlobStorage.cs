using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace Cobalt.Infrastructure.Storage
{
    public class BlobStorage
    {
        /// <summary>
        /// Creates a new blob storage container.
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public bool CreateNewContainer(string containerName)
        {
            try
            {
                var lowContainerName = containerName.ToLowerInvariant();
                
                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(lowContainerName);

                return container.CreateIfNotExists();
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Upload a new blob file.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="saveAs"></param>
        /// <param name="path"></param>
        public bool UploadNewBlob(string containerName, string saveAs, string path)
        {
            try
            {
                var lowContainerName = containerName.ToLowerInvariant();
                var extension = Path.GetExtension(path);
                var saveAsFull = saveAs + extension;

                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(lowContainerName);
                var blockBlob = container.GetBlockBlobReference(saveAsFull);

                using (var fileStream = File.OpenRead(path))
                {
                    blockBlob.UploadFromStream(fileStream);
                }

                return container.GetBlobReference(saveAsFull).Exists();
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a collection of blob URI's.
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public IEnumerable<string> GetBlobs(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            foreach (var item in container.ListBlobs())
            {
                var blockBlob = item as CloudBlockBlob;
                if (blockBlob != null)
                {
                    var blob = blockBlob;
                    yield return blob.Uri.ToString();
                }
                else if (item is CloudPageBlob)
                {
                    var pageBlob = (CloudPageBlob)item;
                    yield return pageBlob.Uri.ToString();
                }
                else if (item is CloudBlobDirectory)
                {
                    var directory = (CloudBlobDirectory)item;
                    yield return directory.Uri.ToString();
                }
            }
        }

        /// <summary>
        /// Download a blob file.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobReference"></param>
        /// <param name="saveTo"></param>
        public bool DownloadBlob(string containerName, string blobReference, string saveTo)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);
                var blockBlob = container.GetBlockBlobReference(blobReference);

                using (var fileStream = File.OpenWrite(saveTo + "\\" + blobReference))
                {
                    blockBlob.DownloadToStream(fileStream);
                }

                return File.Exists(saveTo + "\\" + blobReference);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
