using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Repository;
using System.Collections.Generic;

namespace RaysHotDogs.Core.Service
{
    public class HotDogDataService
    {
        private static readonly HotDogRepository HotDogRepository = new HotDogRepository();
        
        public List<HotDog> GetAllHotDogs()
        {
            return HotDogRepository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return HotDogRepository.GetGroupedHotDogs();
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            return HotDogRepository.GetHotDogsForGroup(hotDogGroupId);
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            return HotDogRepository.GetFavoriteHotDogs();
        }
        
        public HotDog GetHotDog(int hotDogId)
        {
            return HotDogRepository.GetHotDog(hotDogId);
        }
    }
}
