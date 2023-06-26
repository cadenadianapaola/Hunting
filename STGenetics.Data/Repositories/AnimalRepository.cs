using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using STGenetics.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGenetics.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly STGeneticsDbContext _context;
        private readonly IMapper mapper;

        public AnimalRepository(STGeneticsDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteAnimal(int animalId)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(g => g.AnimalId == animalId);

            if (animal is null)
            {
                return false;
            }

            _context.Remove(animal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AnimalDTO>> GetAllAnimals()
        {
              return  await _context.Animals.ProjectTo<AnimalDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<AnimalDTO>> GetFilterAnimal(string name, string breed, 
            DateTime birthdate, string sex, decimal price, Boolean status)
        {
                //var result = await _context.Animals.
                //ProjectTo<AnimalDTO>(mapper.ConfigurationProvider).
                //Where(x => x.Name == name || x.Breed == breed ||x.BirthDate >= birthdate || x.Sex == sex || x.Price == price || x.Status == status  ).ToListAsync();


            var result = await _context.Animals.
                ProjectTo<AnimalDTO>(mapper.ConfigurationProvider).
                Where(x => x.Name == name || x.Breed == breed || x.Sex == sex || x.Status == status).ToListAsync();

            return result;
        }




        public async Task<IEnumerable<DetailSale>> GetSalesAnimals(string animalIds)
        {

            int[] idsFiltrados = animalIds.Split(',')
                                                .Select(int.Parse)
                                                .ToArray();

            var resultados = (from a in _context.Animals
                             where idsFiltrados.Contains(a.AnimalId)
                             group a by a.Breed into grupo
                             select new DetailSale
                             {
                                 Breed = grupo.Key,
                                 Price = grupo.Sum(a => a.Price),
                                 Row = grupo.Count(),
                                 Percent = grupo.Count()>5?5:0,
                                 Discunt = grupo.Count() > 5 ? grupo.Sum(a => a.Price) * 5 / 100 : grupo.Sum(a => a.Price),
                                 FullSale = grupo.Count() > 5 ? grupo.Sum(a => a.Price) * 95 / 100 : grupo.Sum(a => a.Price)
                             }).ToList();

                return resultados;
        }




        public async Task<Animal> GetAllAnimalsById(int id)
        {
            var result = await _context.Animals.FirstOrDefaultAsync(opcion => opcion.AnimalId == id);
            return result;
        }

        public async Task<List<Sex>> GetAllSex()
        {
            

            List<Sex> listSex = Enum.GetValues(typeof(Sex))
                            .Cast<Sex>()
                            .ToList();
            return listSex;
        }

        public async Task<List<Breed>> GetAllBreed()
        {
            List<Breed> listBreed = Enum.GetValues(typeof(Breed))
                            .Cast<Breed>()
                            .ToList();
            return listBreed;
        }

        public async Task<Animal> GetByIdsAnimals(List<int> ids)
        {
            var result = await _context.Animals.ToListAsync();

            Animal animal = new Animal();

            return animal;
        }

        public async Task<bool> InsertAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
             await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
