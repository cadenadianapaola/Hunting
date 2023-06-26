using STGenetics.Data.Repositories;
using STGenetics.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace STGenetics.Services
{
    
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly string _rutaBase = "api/animal/";

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task DeleteAnimal(int animalId)
        {
           await _httpClient.DeleteAsync($"{_rutaBase}{animalId}");
        }

        public async Task<List<AnimalDTO>> GetAllAnimals()
        {
            return await _httpClient.GetFromJsonAsync<List<AnimalDTO>>($"{_rutaBase}");
        }


        public async Task<List<AnimalDTO>> GetFilterAnimal(string name, string breed,
            string birthdate, string sex, decimal price)
        {

            if(name == null)
            {
                name = "name";
            }
           

            if (breed == "0")
            {
                breed = "breed";
            }
            if (sex == "0")
            {
                sex = "sex";
            }



            var URL = $"GetFilterAnimal/?name={name}&breed={breed}&sex={sex}&Price={price}&status={false}&birthdate={birthdate}";



            return await _httpClient.GetFromJsonAsync<List<AnimalDTO>>($"{_rutaBase}{URL}");
        }



        public async Task<List<Sex>> GetAllSex()
        {
            return await _httpClient.GetFromJsonAsync<List<Sex>>($"{_rutaBase}GetAllSex");

        }
        public async Task<List<Breed>> GetAllBreed()
        {
            return await _httpClient.GetFromJsonAsync<List<Breed>>($"{_rutaBase}GetAllBreed");
        }

        public Task<IEnumerable<Animal>> GetByIdsAnimals(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAnimal(Animal animal)
        {
            if(animal.AnimalId == 0)
            {
                await _httpClient.PostAsJsonAsync<Animal>(_rutaBase, animal);
            }
            else
            {
                await _httpClient.PutAsJsonAsync<Animal>(_rutaBase, animal);
            }
        }

        public async Task<Animal> GetAllAnimalsById(int animalId)
        {
            return await _httpClient.GetFromJsonAsync<Animal>($"{_rutaBase}GetAllAnimalsById/{animalId}");
        }

        
        public async Task<List<DetailSale>> GetSalesAnimals(string animals)
        {
            return await _httpClient.GetFromJsonAsync<List<DetailSale>>($"{_rutaBase}GetSalesAnimals/{animals}");
        }
    }
}
