using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace UrlShorteningService.Service.IntegrationTests.Steps
{
    [Binding]
    [Scope(Feature = "Lengthen")]
    [Scope(Feature = "Shorten")]
    public sealed class CommonSteps
    {
        [BeforeScenario(Order = 0)]
        public void CleanDatabase()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Database contains the following UrlMapping record for the Url")]
        public void GivenDatabaseContainsTheFollowingUrlMappingRecordForTheUrl(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call endpoint (.*) with (.*)")]
        public void WhenICallEndpoint(string endpoint, string argument)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
