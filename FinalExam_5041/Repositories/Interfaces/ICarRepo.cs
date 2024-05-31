using FinalExam_5041.Models;

namespace FinalExam_5041.Repositories.Interfaces
{
    public interface ICarRepo
    {
        Task<Car> GetByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
        Task<Car> AddAsync(Car car);
        Task<Car> UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}
