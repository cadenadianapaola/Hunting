using STGenetics.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGenetics.Data.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<AnimalDTO>> GetAllAnimals();
        Task<IEnumerable<AnimalDTO>> GetFilterAnimal(string name, string breed,
            DateTime birthdate, string sex, decimal price, Boolean status);


        Task<Animal> GetAllAnimalsById(int id);
        Task<Animal> GetByIdsAnimals(List<int> ids);
        Task<List<Sex>> GetAllSex();
        Task<List<Breed>> GetAllBreed();
        Task<bool> InsertAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
        Task<bool> DeleteAnimal(int animalId);
        Task<IEnumerable<DetailSale>> GetSalesAnimals(string animals);
    }
}