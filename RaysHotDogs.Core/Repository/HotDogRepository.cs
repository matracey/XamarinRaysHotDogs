using Newtonsoft.Json;
using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

        string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogRepository()
        {
            Task.Run(() => LoadDataAsync(url)).Wait();
        }

        private async Task LoadDataAsync(string uri)
        {
            if(hotDogGroups != null)
            {
                string response = null;
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage r = await getResponse;
                        response = await r.Content.ReadAsStringAsync();

                        hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(response);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                };
            }
        }

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from @group in hotDogGroups
                from hotDog in @group.HotDogs
                select hotDog;
            return hotDogs.ToList();
        }

        public HotDog GetHotDog(int hotDogId)
        {
            IEnumerable<HotDog> dogs =
                from @group in hotDogGroups
                from hotDog in @group.HotDogs
                where hotDog.Id == hotDogId
                select hotDog;
            return dogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.Id == hotDogGroupId).FirstOrDefault();
            return group != null ? group.HotDogs : null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> dogs =
                from @group in hotDogGroups
                from hotDog in @group.HotDogs
                where hotDog.IsFavorite
                select hotDog;
            return dogs.ToList();
        }
    }
}
