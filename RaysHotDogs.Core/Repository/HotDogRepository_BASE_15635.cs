using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                Id = 1,
                Title = "Meat Lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        Id = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese danish fontina. Hard cheese",
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
                        Description = "Bacon ipsum dolor amet pig short ribs turducken chicken. Tongue meatloaf shankle beef biltong turkey bresaola. Corned beef frankfurter turkey rump beef ribs pork pork loin meatball ribeye pastrami venison shoulder chicken. Turkey ham rump chicken beef ribs salami spare ribs ham hock ball tip.",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() { "Baked bun", "Gourmet sausage" },
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        Id = 3,
                        Name = "Extra Long",
                        ShortDescription = "For when a regular one isn't enough.",
                        Description = "Pork chop andouille hamburger cupim, brisket fatback corned beef. Frankfurter fatback jowl cow. Swine alcatra boudin, turkey t-bone short loin ham chuck pork belly corned beef cow ham hock. Sirloin pancetta pork loin short loin, porchetta venison pork bacon tenderloin jowl andouille boudin ham. Ham hock prosciutto short loin swine jowl ball tip. Meatloaf porchetta tail, tongue spare ribs landjaeger filet mignon hamburger capicola. Tenderloin pork landjaeger turducken ball tip capicola kielbasa sirloin shoulder sausage.",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Extra long bun", "Extra long sausage" },
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
                        Description = "Ham t-bone pork loin beef ribs ground round doner bresaola chuck sirloin capicola cupim rump shoulder. Chicken turkey ribeye porchetta pork chop, short loin sausage doner fatback. Prosciutto ham bacon meatloaf. Ham ground round prosciutto short loin fatback tongue.",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Bun", "Vegetarian sausage" },
                        Price = 8,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        Id = 5,
                        Name = "Haute Dog Veggie",
                        ShortDescription = "Classy and veggie",
                        Description = "Bacon ipsum dolor amet pig short ribs turducken chicken. Tongue meatloaf shankle beef biltong turkey bresaola. Corned beef frankfurter turkey rump beef ribs pork pork loin meatball ribeye pastrami venison shoulder chicken. Turkey ham rump chicken beef ribs salami spare ribs ham hock ball tip.",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() { "Baked bun", "Gourmet vegetarian sausage" },
                        Price = 10,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        Id = 6,
                        Name = "Extra Long Veggie",
                        ShortDescription = "For when a regular one isn't enough.",
                        Description = "Pork chop andouille hamburger cupim, brisket fatback corned beef. Frankfurter fatback jowl cow. Swine alcatra boudin, turkey t-bone short loin ham chuck pork belly corned beef cow ham hock. Sirloin pancetta pork loin short loin, porchetta venison pork bacon tenderloin jowl andouille boudin ham. Ham hock prosciutto short loin swine jowl ball tip. Meatloaf porchetta tail, tongue spare ribs landjaeger filet mignon hamburger capicola. Tenderloin pork landjaeger turducken ball tip capicola kielbasa sirloin shoulder sausage.",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() { "Extra long bun", "Extra long vegetarian sausage" },
                        Price = 8,
                        IsFavorite = false
                    }
                }
            }
        };

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
