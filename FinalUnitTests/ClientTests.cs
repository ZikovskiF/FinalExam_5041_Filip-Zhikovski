using FinalExam_5041.Controllers;
using FinalExam_5041.DTOs.CreateDTOs;
using FinalExam_5041.Models;
using FinalExam_5041.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FinalExam_5041.Tests.Controllers
{
    public class ClientControllerTests
    {
        [Fact]
        public async Task GetClients_ReturnsOkResult()
        {
            var mockRepo = new Mock<IClientRepo>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestClients());
            var controller = new ClientController(mockRepo.Object);

            var result = await controller.GetClients();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var clients = Assert.IsAssignableFrom<IEnumerable<Client>>(okResult.Value);
            Assert.NotEmpty(clients);
        }

        [Fact]
        public async Task CreateClient_ReturnsCreatedAtActionResult()
        {
            var mockRepo = new Mock<IClientRepo>();
            var controller = new ClientController(mockRepo.Object);
            var newClient = new CreateClientDTO { FirstName = "John", LastName = "Doe", DOB = DateTime.Now.AddYears(-30), Address = "123 Main St", Nationality = "US", RentStart = DateTime.Now, RentEnd = DateTime.Now.AddDays(7), CarId = 1 };

            var result = await controller.CreateClient(newClient);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var client = Assert.IsType<Client>(createdAtActionResult.Value);
            Assert.Equal(newClient.FirstName, client.FirstName);
        }

        [Fact]
        public async Task DeleteClient_ReturnsNoContentResult()
        {
            var mockRepo = new Mock<IClientRepo>();
            var existingClient = new Client { Id = 1, FirstName = "Jane", LastName = "Doe", DOB = DateTime.Now.AddYears(-25), Address = "456 Elm St", Nationality = "UK", RentStart = DateTime.Now, RentEnd = DateTime.Now.AddDays(7), CarId = 1 };
            mockRepo.Setup(repo => repo.GetByIdAsync(existingClient.Id))
                .ReturnsAsync(existingClient);
            var controller = new ClientController(mockRepo.Object);

            var result = await controller.DeleteClient(existingClient.Id);


            Assert.IsType<NoContentResult>(result);
        }

        private List<Client> GetTestClients()
        {
            return new List<Client>
            {
                new Client { Id = 1, FirstName = "John", LastName = "Doe", DOB = DateTime.Now.AddYears(-30), Address = "123 Main St", Nationality = "US", RentStart = DateTime.Now, RentEnd = DateTime.Now.AddDays(7), CarId = 1 },
                new Client { Id = 2, FirstName = "Jane", LastName = "Smith", DOB = DateTime.Now.AddYears(-28), Address = "456 Elm St", Nationality = "UK", RentStart = DateTime.Now, RentEnd = DateTime.Now.AddDays(7), CarId = 2 }
            };
        }
    }
}
