using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApp1
{
    class Program
    {
        static String connectString = "DefaultEndpointsProtocol=https;AccountName=sqlvattwtwpybsdjcs;AccountKey=3633/nZVDS43fuhaNFVy7p9F23+OPuxbYSauDKxqvZaveg40hlwR83nnaKQgGiSxNd7jt7/UhXUkKmKfBTLW7w==;EndpointSuffix=core.windows.net";
        //static String connectString = "DefaultEndpointsProtocol=https;AccountName=sqlvattwtwpybsdjcs;AccountKey=3633/nZVDS43fuhaNFVy7p9F23+OPuxbYSauDKxqvZaveg40hlwR83nnaKQgGiSxNd7jt7/UhXUkKmKfBTLW7w==;EndpointSuffix=core.windows.net";
        //static String key = "nZVDS43fuhaNFVy7p9F23+OPuxbYSauDKxqvZaveg40hlwR83nnaKQgGiSxNd7jt7/UhXUkKmKfBTLW7w==;EndpointSuffix=core.windows.net";
        static string QueueName = "a1908g2";
        static String cloudTableName = "tablea1908g";
        static String containerName = "bloba1908g";
        static void Main(string[] args)
        {
            CloudStorageAccount cloudStorage = CloudStorageAccount.Parse(connectString);
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectString, containerName);
            if (cloudStorage != null)
            {
                GetTable_Entity_(cloudStorage);
                //DownloadBlobs(blobContainerClient);
            }
            Console.ReadLine();
        }
        static void readMessage(CloudStorageAccount cloudStorage)
        {
            CloudQueueClient cloudQueue = cloudStorage.CreateCloudQueueClient();
            CloudQueue queue = cloudQueue.GetQueueReference(QueueName);
            var message = queue.PeekMessageAsync();
            Console.WriteLine("Message : " + message.Result.AsString);
        }
        static void sendMessageToQueue(CloudStorageAccount cloudStorageAccount)
        {
            CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(QueueName);
            CloudQueueMessage cloudQueueMessage = new CloudQueueMessage("Rush B");
            cloudQueue.AddMessageAsync(cloudQueueMessage);
            Console.WriteLine("đã up lên");
        }
        static void Count(CloudStorageAccount cloudStorageAccount)
        {
            CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(QueueName);
            cloudQueue.FetchAttributesAsync();
            int? soLuongMessage = cloudQueue.ApproximateMessageCount;
            Console.WriteLine("so luong " + soLuongMessage);
        }
        static void Delete(CloudStorageAccount csa)
        {
            CloudQueueClient cqc = csa.CreateCloudQueueClient();
            CloudQueue cq = cqc.GetQueueReference(QueueName);
            var cqm = cq.GetMessageAsync();
            cq.DeleteMessageAsync(cqm.Result);
            Console.WriteLine("Da xoa");
        }
        static void GetTable_Entity_(CloudStorageAccount cloudStorageAccount)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable cloudTable = cloudTableClient.GetTableReference(cloudTableName);
            var query = new TableQuery<Student>();
            var students = cloudTable.ExecuteQuerySegmentedAsync(query, null).Result;
            Console.WriteLine("\n Data: |{0,19} | {1,15} | {2,15} | {3,10} | {4,10}",
                "Bí danh", "Tên đầu", "Tên đủ", "Điểm", "Nhận xét");
            foreach (var s in students)
            {
                Console.WriteLine(" Data: |{0,19} | {1,15} | {2,15} | {3,10} | {4,10}",
                    s.PartitionKey, s.RowKey, s.name, s.mark, s.comment);
            }
        }
        static bool AddTableEntityComponent(CloudTable table)
        {
            //dữ liệu mẫu:
            var newEntity = new Student()
            {
                PartitionKey = "poet",
                RowKey = "Nguyễn",
                name = "Nguyễn Du",
                mark = "100",
                comment = "Moonlight"
            };

            TableOperation insert = TableOperation.Insert(newEntity);
            try
            {
                Console.WriteLine("Begin Insert Data...");
                Console.WriteLine("Data: | {0,19} | {1,15} | {2,15} | {3,10} | {4,10} ", newEntity.PartitionKey, newEntity.RowKey, newEntity.name, newEntity.mark, newEntity.comment);
                table.ExecuteAsync(insert);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        static void DownloadBlobs(BlobContainerClient blobContainerClient)
        {
            
            blobContainerClient.CreateIfNotExists();
            Console.WriteLine("Data blob");

            var blobs = blobContainerClient.GetBlobs();
            foreach (BlobItem blobItem in blobs)
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
        }
    }
}
