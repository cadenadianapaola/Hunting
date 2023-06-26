using STGenetics.Data.Repositories;
using STGenetics.Models;

namespace STGenetics.Services
{
    public interface IAnimalService
    {
        Task<Animal> GetAllAnimalsById(int animalId);
        Task<List<AnimalDTO>> GetAllAnimals();
        Task<List<AnimalDTO>> GetFilterAnimal(string name, string breed,
            string birthdate, string sex, decimal price);
        Task<IEnumerable<Animal>> GetByIdsAnimals(string ids);
        Task<List<Sex>> GetAllSex();
        Task<List<Breed>> GetAllBreed();
        Task SaveAnimal(Animal animal);
        Task DeleteAnimal(int idAnimal);
        Task<List<DetailSale>> GetSalesAnimals(string animals);


    }
}
