﻿using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public string ContainerName { get; set; }

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Uri> UploadFileBlobAsync(Stream content, string contentType, string fileName)
        {
            var containerClient = await GetMovieShopContainerAsync();
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, new BlobHttpHeaders {ContentType = contentType});
            return blobClient.Uri;
        }

        public async Task<bool> CheckIfBlobExistsAsync(string blobName)
        {
            var containerClient = await GetMovieShopContainerAsync();
            var cloudBlockBlob = containerClient.GetBlobClient(blobName);
            return await cloudBlockBlob.ExistsAsync();
        }


        private async Task<BlobContainerClient> GetContainerAsync(string containerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
            return containerClient;
        }

        private async Task<BlobContainerClient> GetMovieShopContainerAsync()
        {
            return await GetContainerAsync(ContainerName);
        }
    }
}