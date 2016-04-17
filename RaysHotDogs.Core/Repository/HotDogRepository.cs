using Newtonsoft.Json;
using RaysHotDogs.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> _hotDogGroups = new List<HotDogGroup>();

        private const string Url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogRepository()
        {
            Task.Run(() => LoadDataAsync(Url)).Wait();
        }

        private static async Task LoadDataAsync(string uri)
        {
            if(_hotDogGroups != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var getResponse = httpClient.GetAsync(uri);
                    var r = await getResponse;
                    var response = await r.Content.ReadAsStringAsync();

                    _hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(response);
                };
            }
        }

        public List<HotDog> GetAllHotDogs()
        {
            var hotDogs =
                from @group in _hotDogGroups
                from hotDog in @group.HotDogs
                select hotDog;
            return hotDogs.ToList();
        }

        public HotDog GetHotDog(int hotDogId)
        {
            var dogs =
                from @group in _hotDogGroups
                from hotDog in @group.HotDogs
                where hotDog.Id == hotDogId
                select hotDog;
            return dogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return _hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = _hotDogGroups.FirstOrDefault(h => h.Id == hotDogGroupId);
            return @group?.HotDogs;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            var dogs =
                from @group in _hotDogGroups
                from hotDog in @group.HotDogs
                where hotDog.IsFavorite
                select hotDog;
            return dogs.ToList();
        }
    }
}
