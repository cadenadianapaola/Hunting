using Microsoft.AspNetCore.Mvc;
using STGenetics.Data.Repositories;
using STGenetics.Models;

namespace STGenetics.API.Controllers
{
    [Route("api/animal")]
    [ApiController]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }



        [HttpGet]
        public async Task<IEnumerable<AnimalDTO>> getAllAnimal()
        {
             
            var resultado =     await animalRepository.GetAllAnimals();
            return resultado;

        }

        [HttpGet("GetFilterAnimal")]
        public async Task<IEnumerable<AnimalDTO>> GetFilterAnimal(string name = "name", 
            string breed = "breed", string sex = "sex", decimal price = 0, bool? status = false, string birthdate = "birthdate")
        {

            var resultado = await animalRepository.GetAllAnimals();

            if (name !=  "name")
                resultado = resultado.Where(a => a.Name == name);

            if (breed != "breed")
                resultado = resultado.Where(a => a.Breed == breed);

            
                resultado = resultado.Where(a => a.BirthDate == Convert.ToDateTime(birthdate));
            
                

            if (sex != "sex")
                resultado = resultado.Where(a => a.Sex == sex);

            if (price !=0)
                resultado = resultado.Where(a => a.Price == price);

            

            return resultado.ToList();

        }


        [HttpGet("GetAllSex")]
        public async Task<List<Sex>> GetAllSex()
        {
            return await animalRepository.GetAllSex();

        }

        [HttpGet("GetAllBreed")]
        public async Task<List<Sex>> GetAllBreed()
        {
            return await animalRepository.GetAllSex();

        }


        [HttpGet("GetAllAnimalsById/{animalId:int}")]
        public async Task<Animal> GetAllAnimalsById(int animalId)
        {
            return await animalRepository.GetAllAnimalsById(animalId);
        }


        [HttpGet("GetSalesAnimals/{Ids}")]
        public async Task<IEnumerable<DetailSale>> GetSalesAnimals(string Ids)
        {
            return await animalRepository.GetSalesAnimals(Ids);
        }



        [HttpDelete("{animalId:int}")]
        public async Task<Boolean> Delete(int animalId)
        {
            return await animalRepository.DeleteAnimal(animalId);
        }

        [HttpPut()]
        public async Task<IActionResult>  Put([FromBody] Animal animal)
        {

            if(animal == null)
            {
                return BadRequest();
            }

            var accion = await animalRepository.UpdateAnimal(animal);

            return Ok(accion);

        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }

            var accion =  await animalRepository.InsertAnimal(animal);

            return Ok(accion);

        }

    }
}
