﻿using Newtonsoft.Json;
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
<<<<<<< HEAD
                    new HotDog()
                    {
                        Id = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese danish fontina. Hard cheese cow goat red leicester pecorino macaroni cheese cheesecake gouda. Ricotta fromage cheese and biscuits stinking bishop halloumi monterey jack cheese strings goat. Pecorino babybel pecorino jarlsberg cow say cheese cottage cheese.",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Regular bun", "Sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        Id = 2,
                        Name = "Haute Dog",
                        ShortDescription = "The classy one",
                        Description = "Bacon ipsum dolor amet turducken ham t-bone shankle boudin kevin. Hamburger salami pork shoulder pork chop. Flank doner turducken venison rump swine sausage salami sirloin kielbasa pork belly tail cow. Pork chop bacon ground round cupim tongue, venison frankfurter bresaola tri-tip andouille sirloin turducken spare ribs biltong. Drumstick ham hock pork tail, capicola shank frankfurter beef ribs jowl meatball turkey hamburger. Tenderloin swine ham pork belly beef ribeye.",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() { "Baked bun", "Gourmet sausage", "Fancy mustard from Germany" },
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        Id = 3,
                        Name = "Extra Long",
                        ShortDescription = "For when a regular one isn't enough.",
                        Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone.",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Extra long bun", "Extra long sausage", "More ketchup" },
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new HotDogGroup()
            {
                Id = 2,
                Title = "Veggie Lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        Id = 4,
                        Name = "Veggie Hot Dog",
                        ShortDescription = "American for non-meat lovers.",
                        Description = "Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic.\n\nGumbo beet greens corn soko endive gumbo gourd. Parsley shallot courgette tatsoi pea sprouts fava bean collard greens dandelion okra wakame tomato. Dandelion cucumber earthnut pea peanut soko zucchini.",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Bun", "Vegetarian sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        Id = 5,
                        Name = "Haute Dog Veggie",
                        ShortDescription = "Classy and veggie",
                        Description = "Turnip greens yarrow ricebean rutabaga endive cauliflower sea lettuce kohlrabi amaranth water spinach avocado daikon napa cabbage asparagus winter purslane kale. Celery potato scallion desert raisin horseradish spinach carrot soko. Lotus root water spinach fennel kombu maize bamboo shoot green bean swiss chard seakale pumpkin onion chickpea gram corn pea. Brussels sprout coriander water chestnut gourd swiss chard wakame kohlrabi beetroot carrot watercress. Corn amaranth salsify bunya nuts nori azuki bean chickweed potato bell pepper artichoke.",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() { "Baked bun", "Gourmet vegetarian sausage", "Fancy mustard" },
                        Price = 10,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        Id = 6,
                        Name = "Extra Long Veggie",
                        ShortDescription = "For when a regular one isn't enough.",
                        Description = "Beetroot water spinach okra water chestnut ricebean pea catsear courgette summer purslane. Water spinach arugula pea tatsoi aubergine spring onion bush tomato kale radicchio turnip chicory salsify pea sprouts fava bean. Dandelion zucchini burdock yarrow chickpea dandelion sorrel courgette turnip greens tigernut soybean radish artichoke wattle seed endive groundnut broccoli arugula.",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Extra long bun", "Extra long vegetarian sausage", "More ketchup" },
                        Price = 8,
                        IsFavorite = false
=======
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
>>>>>>> bb5b8abc15d0875fe2964e4149b16b7cb204bd01
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
