using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplicationWithIntegrationTests.Domain.Entities;
using WebApplicationWithIntegrationTests.IntegrationTests.Extensions;

namespace WebApplicationWithIntegrationTests.IntegrationTests
{
    [TestClass]
    public class PersonControllerTests : BaseTest
    {
        [TestMethod]
        public async Task GetAsync_ReturnsCollectionOfPersons()
        {
            // Arrange
            var expectedResult = new[]
            {
                new Person("John", "Doe", 40),
                new Person("John", "Smith", 22)
            };

            this.mockPersonRepository.Setup(r => r.GetAsync())
                .ReturnsAsync(expectedResult);

            // Act
            HttpResponseMessage response;

            using (var client = this.CreateClient())
            {
                response = await client.GetAsync("api/v1/person");
            }

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var actualResult = await response.GetContentAsAsync<IEnumerable<Person>>();
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public async Task GetAsync_ReturnInternalServerError()
        {
            // Arrange
            this.mockPersonRepository.Setup(r => r.GetAsync())
                .ThrowsAsync(new Exception());

            // Act
            HttpResponseMessage response;

            using (var client = this.CreateClient())
            {
                response = await client.GetAsync("api/v1/person");
            }

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}