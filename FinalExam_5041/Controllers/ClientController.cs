using FinalExam_5041.DTOs.CreateDTOs;
using FinalExam_5041.DTOs.UpdateDTOs;
using FinalExam_5041.Models;
using FinalExam_5041.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExam_5041.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;

        public ClientController(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientRepo.GetAllAsync();
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientRepo.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] CreateClientDTO clientDTO)
        {
            try
            {
                var client = new Client
                {
                    FirstName = clientDTO.FirstName,
                    LastName = clientDTO.LastName,
                    DOB = clientDTO.DOB,
                    Address = clientDTO.Address,
                    Nationality = clientDTO.Nationality,
                    RentStart = clientDTO.RentStart,
                    RentEnd = clientDTO.RentEnd,
                    CarId = clientDTO.CarId
                };

                await _clientRepo.AddAsync(client);
                return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDTO clientDTO)
        {
            try
            {
                var client = await _clientRepo.GetByIdAsync(id);
                if (client == null)
                {
                    return NotFound();
                }

                client.FirstName = clientDTO.FirstName;
                client.LastName = clientDTO.LastName;
                client.DOB = clientDTO.DOB;
                client.Address = clientDTO.Address;
                client.Nationality = clientDTO.Nationality;
                client.RentStart = clientDTO.RentStart;
                client.RentEnd = clientDTO.RentEnd;
                client.CarId = clientDTO.CarId;

                await _clientRepo.UpdateAsync(client);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                var client = await _clientRepo.GetByIdAsync(id);
                if (client == null)
                {
                    return NotFound();
                }

                await _clientRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}