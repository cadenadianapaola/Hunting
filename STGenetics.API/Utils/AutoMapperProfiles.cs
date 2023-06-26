using AutoMapper;
using STGenetics.Models;

namespace STGenetics.API.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Animal, AnimalDTO>();
        }
    }
}
