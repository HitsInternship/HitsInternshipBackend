using Minio;
using Minio.DataModel.Args;

namespace DocumentModule.Infrastructure.FileStorage
{
    public class FileStorageContext : IDisposable
    {
        public readonly IMinioClient client;
        public readonly string bucketName;

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

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
