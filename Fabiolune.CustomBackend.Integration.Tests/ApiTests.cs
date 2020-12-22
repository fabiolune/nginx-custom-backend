using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Fabiolune.CustomBackend.Integration.Tests
{
    public class ApiTests
    {
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Test]
        public void HomeRoute_ShouldReturn_404()
        {
            var result = _client.GetAsync("/").Result;

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void GenericEndpoint_ShouldReturn_404()
        {
            var result = _client.GetAsync($"/{Guid.NewGuid()}").Result;

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void Healthz_ShouldReturn_200()
        {
            var result = _client.GetAsync("/healthz").Result;

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}