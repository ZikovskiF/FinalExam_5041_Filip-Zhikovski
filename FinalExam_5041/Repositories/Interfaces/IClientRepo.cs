using FinalExam_5041.Models;

namespace FinalExam_5041.Repositories.Interfaces
{
    public interface IClientRepo
    {
        Task<Client> GetByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task<List<Client>> GetByCarIdAsync(int CarId);
    }
}
