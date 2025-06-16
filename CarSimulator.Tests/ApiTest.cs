using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ApiService;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace CarSimulator.Tests
{
    [TestClass]
    public class ApiTest
    {
        private HttpClient _httpClient;
        private GetTheApi _getTheApi;

        [TestInitialize]
        public void Setup()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            _getTheApi = new GetTheApi(_httpClient);
        }

        [TestMethod]
        [TestCategory("IntegrationTest")]
        public async Task FetchApiData_Should_Return_Valid_User()
        {
            // ACT
            var result = await _getTheApi.FetchApiData();

            // ASSERT
            Assert.IsNotNull(result, "API returned null result.");
            Assert.IsNotNull(result.Name, "Name object is null.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Name.First), "First name is missing.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Name.Last), "Last name is missing.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Name.Title), "Title is missing.");

            // Optional checks if available
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Gender), "Gender is missing.");
            Assert.IsNotNull(result.Location, "Location is null.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Location.Country), "Country is missing.");
        }
    }
}
