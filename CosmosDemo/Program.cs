using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace CosmosDemo
{
    class Program
    {
        private const string EndpointUrl = "https://capricorncosmos.documents.azure.com:443/";
        private const string PrimaryKey = "AXDBxMcJArtTrV1sGfrLEcW5udtjzMcAVPlR4jzrwm9zHtRTuJtbw4Gp8dETFJFvex381VVn6EsY03zNMJTG9g==";
        
        static void Main(string[] args)
        {
            DocumentClient client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<dynamic> query = client.CreateDocumentQuery<dynamic>(
                UriFactory.CreateDocumentCollectionUri("OCGExtension", "OrgUnits"), "SELECT * FROM OrgUnits", queryOptions);

            foreach (dynamic ou in query)
            {
                Console.WriteLine(ou.name);
            }
        }
    }
}
