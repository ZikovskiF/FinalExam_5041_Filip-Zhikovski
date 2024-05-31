using FinalExam_5041.Data;
using FinalExam_5041.Models;
using FinalExam_5041.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalExam_5041.Repositories.Repos
{
    public class ClientRepo : IClientRepo
    {
        private readonly CarClientDbContext _context;
        public ClientRepo(CarClientDbContext context)
        {
            _context = context;
        }
        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }
        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }
        public async Task<Client> AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Client>> GetByCarIdAsync(int CarId)
        {
            return await _context.Clients
                .Where(g => g.CarId == CarId)
                .ToListAsync();
        }
    }
}
