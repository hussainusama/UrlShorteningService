using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using UrlShorteningService.Encoders;

namespace UrlShorteningService.IntegrationTests
{
    [Binding]
    public class ShortenTheUrlThenGetBackOriginalUrlSteps
    {
        private string _shortenedUrl;
        private string _originalUrl;

        private readonly IConfiguration _config;

        public ShortenTheUrlThenGetBackOriginalUrlSteps()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
        }

        [BeforeScenario]
        public void CleanupDataBase()
        {
            using (SqlConnection connection =
                new SqlConnection(_config["ConnectionStrings:DbConnectionString"]))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM [dbo].[UrlMap]", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        [Given(@"Database contains the following UrlMap records")]
        public void GivenDatabaseContainsTheFollowingUrlMapRecords(Table table)
        {
            using (SqlConnection connection =
                new SqlConnection(_config["ConnectionStrings:DbConnectionString"]))
            {
                connection.Open();

                StringBuilder insertCommand = new StringBuilder();
                insertCommand.Append("SET IDENTITY_INSERT [dbo].[UrlMap] ON ");

                foreach (var row in table.Rows)
                {
                    insertCommand.Append($"INSERT INTO [dbo].[UrlMap] (Id, Url) VALUES ({row["Id"]}, '{row["Url"]}') ");
                }
              
                insertCommand.Append("SET IDENTITY_INSERT [dbo].[UrlMap] OFF ");

                insertCommand.Append($"DBCC CHECKIDENT ('[dbo].[UrlMap]', RESEED, {table.Rows[table.RowCount - 1]["Id"]});");
                
                using (SqlCommand command = new SqlCommand(insertCommand.ToString(), connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }
        
        [When(@"I call shorten endpoint (.*) with (.*)")]
        public void WhenICallShortenEndpoint(string uri, string url)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_config["WebService:UrlShorteningServiceHost"])
            };

            var response = client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(new { LongUrl = url }), Encoding.UTF8, "application/json")).Result;
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            _shortenedUrl = response.Content.ReadAsStringAsync().Result;
        }

        [When(@"I call lengthen endpoint (.*) with the received encoded string")]
        public void WhenICallLengthenEndpoint(string uri)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_config["WebService:UrlShorteningServiceHost"])
            };

            var response = client.GetAsync($"{uri}?encodedUrl={_shortenedUrl}").Result;
            response.StatusCode.Should().Be(HttpStatusCode.OK);
           
            _originalUrl = response.Content.ReadAsStringAsync().Result;
        }

        
        [Then(@"I get an encoded string representing next database record id which is (.*)")]
        public void ThenIGetAnEncodedStringRepresentingNextDatabaseRecordIdWhichIs(int nextDbId)
        {
            Base62Encoder encoder = new Base62Encoder();
            encoder.Encode(nextDbId).Should().Be(_shortenedUrl);
        }
        
        [Then(@"I get the original url back (.*)")]
        public void ThenIGetTheOriginalUrlBack(string url)
        {
            _originalUrl.Should().Be(url);
        }
    }
}
