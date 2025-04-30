using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace DocumentModule.Infrastructure
{
    public class FileStorageContext : IDisposable
    {
        private readonly IMinioClient client;
        private readonly string bucketName;

        public FileStorageContext(FileStorageSettings settings)
        {
            bucketName = settings.BucketName;
            client = new MinioClient()
                .WithEndpoint(settings.Endpoint, 9000)
                .WithCredentials(settings.AccessKey, settings.SecretKey)
            .Build();

            InitializeBucketAsync().Wait();
        }

        private async Task InitializeBucketAsync()
        {
            var exists = await client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            if (!exists)
            {
                await client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }
        }

        public async Task<string> Put(Guid FileId, IFormFile file)
        {
            PutObjectArgs poa = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(FileId.ToString())
                .WithStreamData(file.OpenReadStream())
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType)
                .WithHeaders(new Dictionary<string, string>() { { "Name", Uri.EscapeDataString(file.FileName) } });

            var response = await client.PutObjectAsync(poa);

            return file.ContentType;
        }

        public async Task<FileContentResult> Get(Guid FileId)
        {
            using (var memoryStream = new MemoryStream())
            {
                GetObjectArgs goa = new GetObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(FileId.ToString())
                    .WithCallbackStream((stream) =>
                    {
                        stream.CopyTo(memoryStream);
                    });

                var metadata = await client.GetObjectAsync(goa);

                return new FileContentResult(memoryStream.ToArray(), metadata.ContentType)
                {
                    FileDownloadName = Uri.UnescapeDataString(metadata.MetaData["Name"])
                };
            }
        }

        public async Task Delete(Guid fileId)
        {
            RemoveObjectArgs roa = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileId.ToString());

            await client.RemoveObjectAsync(roa);
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }

    public class FileStorageSettings
    {
        public string Endpoint { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
    }
}
