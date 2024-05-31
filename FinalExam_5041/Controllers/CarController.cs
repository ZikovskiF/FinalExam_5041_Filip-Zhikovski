using FinalExam_5041.DTOs;
using FinalExam_5041.DTOs.CreateDTOs;
using FinalExam_5041.DTOs.UpdateDTOs;
using FinalExam_5041.Models;
using FinalExam_5041.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExam_5041.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepo _carRepo;

        public CarController(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
        {
            var cars = await _carRepo.GetAllAsync();
            var carDTOs = MapCarsToDTOs(cars);
            return Ok(carDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(int id)
        {
            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDTO = MapCarToDTO(car);
            return Ok(carDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> AddCar(CreateCarDTO carDTO)
        {
            var car = MapDTOToCar(carDTO);
            var addedCar = await _carRepo.AddAsync(car);
            var addedCarDTO = MapCarToDTO(addedCar);
            return CreatedAtAction(nameof(GetCarById), new { id = addedCarDTO.Id }, addedCarDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, UpdateCarDTO carDTO)
        {
            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.Model = carDTO.Model;
            car.Manufacturer = carDTO.Manufacturer;
            car.Year = carDTO.Year;
            car.LicencePlate = carDTO.LicencePlate;

            await _carRepo.UpdateAsync(car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carRepo.DeleteAsync(id);

            return NoContent();
        }

        private static CarDTO MapCarToDTO(Car car) =>
            new CarDTO
            {
                Id = car.Id,
                LicencePlate = car.LicencePlate,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Year = car.Year
            };

        private static List<CarDTO> MapCarsToDTOs(IEnumerable<Car> cars)
        {
            var carDTOs = new List<CarDTO>();
            foreach (var car in cars)
            {
                carDTOs.Add(MapCarToDTO(car));
            }
            return carDTOs;
        }

        private static Car MapDTOToCar(CreateCarDTO carDTO) =>
            new Car
            {
                LicencePlate = carDTO.LicencePlate,
                Model = carDTO.Model,
                Manufacturer = carDTO.Manufacturer,
                Year = carDTO.Year
            };
    }
}
