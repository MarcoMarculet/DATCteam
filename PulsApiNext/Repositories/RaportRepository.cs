using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PulsApiNext.Models;
using System.Threading.Tasks;

namespace PulsApiNext.Repositories
{
    public class RaportRepository : IRaportRepository
    {
        public CloudTable RapoarteTable;
        public RaportRepository()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=pulsproiect;AccountKey=wRditxVJFRkgBGMM5ta1gWNI857KwSz72v3GS+nTDqv1lsqtXJmKjvkKULE+kl5JLJAazLLUHwaBi9ASh5ZNcg==;EndpointSuffix=core.windows.net";

            var account = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = account.CreateCloudTableClient();
            RapoarteTable = tableClient.GetTableReference("Rapoarte");
        }

        public async Task<TableResult> CreateRaport(Raport raport)
        {
            if (RapoarteTable == null)
            {
                Console.WriteLine("Table doesn't exist!");
                throw new Exception();
            }
            var insertOperation = TableOperation.InsertOrMerge(raport);
            return await RapoarteTable.ExecuteAsync(insertOperation);
        }

        public async Task<IEnumerable<Raport>> GetAllRaports()
        {
            if (RapoarteTable == null)
            {
                throw new Exception();
            }

            var rapoarte = new List<Raport>();
            TableQuery<Raport> query = new TableQuery<Raport>();//.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"));

            TableContinuationToken token = null;

            do
            {
                TableQuerySegment<Raport> resultSegment = await RapoarteTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                rapoarte.AddRange(resultSegment.Results);
            } while (token != null);

            return rapoarte;
        }

        public async Task<Raport> GetRaportById(int id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Raport>(RaportType.Atlet.ToString(), id.ToString());

            // Execute the retrieve operation.
            TableResult retrievedResult = await RapoarteTable.ExecuteAsync(retrieveOperation);

            // Print the phone number of the result.
            if (retrievedResult.Result != null)
            {
                Console.WriteLine("Result was not null");
                var retrievedAnimal = (Raport)retrievedResult.Result;
                return retrievedAnimal;
            }
            else
            {
                Console.WriteLine("The Name could not be retrieved.");
                throw new Exception();
            }
        }
    }
}