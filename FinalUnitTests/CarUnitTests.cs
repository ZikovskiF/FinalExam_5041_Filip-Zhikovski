using FinalExam_5041.Controllers;
using FinalExam_5041.DTOs.CreateDTOs;
using FinalExam_5041.DTOs;
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
    public class CarControllerTests
    {
        [Fact]
        public async Task GetAllCars_ReturnsOkResult()
        {
            var mockRepo = new Mock<ICarRepo>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestCars());
            var controller = new CarController(mockRepo.Object);
            var result = await controller.GetAllCars();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var cars = Assert.IsAssignableFrom<IEnumerable<Car>>(okResult.Value);
            Assert.NotEmpty(cars);
        }

        [Fact]
        public async Task AddCar_ReturnsCreatedAtActionResult()
        {
            var mockRepo = new Mock<ICarRepo>();
            var controller = new CarController(mockRepo.Object);
            var newCar = new CreateCarDTO { LicencePlate = "ABC123", Model = "Toyota", Manufacturer = "Toyota", Year = 2022 };

            var result = await controller.AddCar(newCar);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var car = Assert.IsType<CarDTO>(createdAtActionResult.Value);
            Assert.Equal(newCar.LicencePlate, car.LicencePlate);
        }

        [Fact]
        public async Task DeleteCar_ReturnsNoContentResult()
        {
            var mockRepo = new Mock<ICarRepo>();
            var existingCar = new Car { Id = 1, LicencePlate = "XYZ789", Model = "Honda", Manufacturer = "Honda", Year = 2020 };
            mockRepo.Setup(repo => repo.GetByIdAsync(existingCar.Id))
                .ReturnsAsync(existingCar);
            var controller = new CarController(mockRepo.Object);

            var result = await controller.DeleteCar(existingCar.Id);

            Assert.IsType<NoContentResult>(result);
        }

        private List<Car> GetTestCars()
        {
            return new List<Car>
            {
                new Car { Id = 1, LicencePlate = "ABC123", Model = "Toyota", Manufacturer = "Toyota", Year = 2022 },
                new Car { Id = 2, LicencePlate = "DEF456", Model = "Ford", Manufacturer = "Ford", Year = 2021 }
            };
        }
    }
}
