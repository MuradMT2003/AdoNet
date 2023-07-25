using AdoNet.Models;

namespace AdoNet.Services.Interfaces
{
    public interface IFilialService
    {
        public Task<int> AddAsync(Filial Filial);
        public Task<int> AddAsync(List<Filial> Filial);
        public Task<List<Filial>> GetAllAsync();
        public Task<Filial> GetByIdAsync(int id);
        public Task<int> Delete(int id);
        public Task<int> Update(int id, Filial Filial);
    }
}
