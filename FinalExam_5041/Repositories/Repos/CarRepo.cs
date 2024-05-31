using FinalExam_5041.Data;
using FinalExam_5041.Models;
using FinalExam_5041.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalExam_5041.Repositories.Repos
{
    public class CarRepo : ICarRepo
    {
        private readonly CarClientDbContext _context;
        public CarRepo(CarClientDbContext context)
        {
            _context = context;
        }
        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }
        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task DeleteAsync(int id)
        {
            var room = await _context.Cars.FindAsync(id);
            if (room != null)
            {
                _context.Cars.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }
}
