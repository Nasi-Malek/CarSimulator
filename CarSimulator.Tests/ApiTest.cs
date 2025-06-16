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
            _httpClient = new HttpClient();
            _getTheApi = new GetTheApi(_httpClient);
        }

        [TestMethod]
        public async Task FetchApidata_ShouldReturnRandomUser()
        {
            //ACT  
            var result = await _getTheApi.FetchApiData();

            //ASSERT  
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.Name.First));
            Assert.IsFalse(string.IsNullOrEmpty(result.Name.Last));
            Assert.IsFalse(string.IsNullOrEmpty(result.Name.Title));
        }
    }
}
