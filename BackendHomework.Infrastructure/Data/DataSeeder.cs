using BackendHomework.Core.Entities;
using System;

namespace BackendHomework.Infrastructure.Data
{
    public class DataSeeder
    {
        private readonly BackendHomeworkDbContext _context;

        public DataSeeder(BackendHomeworkDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Plates.AddRange(
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Baked Feta With Sumac & Grapes",
                    Description = "It is a great starter choice if you are on a budget.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Beetroot & Blackberry Cured Salmon",
                    Description = "You can serve this on crackers as a canape, and the beetroot and berries make it a great version as a starter.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Carpaccio Scallops",
                    Description = "This dish requires a little more effort than average.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chargrilled Mackerel With Sweet And Sour Beetroot",
                    Description = "Grilled mackerel gives a different kind of charred taste, and the beetroots add a perfect compromise to the sweet and sour starter.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Charred Leeks With Anchovy Dressing",
                    Description = "This simple starter is the star of the elegant dish, and the anchovy adds a depth of flavor.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Charred Spring Onions & Romesco",
                    Description = "It is a vegetarian dish appropriate for a dinner party.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheesy Sprout Fondue",
                    Description = "Transform your leftover cheese into a versatile starter recipe, served perfect with crusty bread.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chicken Liver & Pineau Pâté",
                    Description = "This is a sweet pâté recipe that is rich in taste using pineau. It goes well as a dinner party starter.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Faux Gras With Toast And Pickles",
                    Description = "The easiest parfait ever, with only two ingredients you’ll have this served in no time.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Gravadlax With Celeriac & Fennel Salad",
                    Description = "A Nordic salmon starter, cured with dill and served with a nice dressing of mustard, honey and dill with a crisp salad.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Grilled Lobster Tails With Lemon & Herb Butter",
                    Description = "This is an impressive party dinner dish but takes a little more effort to put together. The lobster tails are complimented with parsley, lemon, and garlic butter.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham Hock & Pistachio Roll",
                    Description = "It can be made into a starter, and is a Chrismas special.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Minted Melon, Tomato & Prosciutto Salad",
                    Description = "It is deal as a sharing plater to start off your dinner or summer event.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Onions And Goat’s Cheese Tarte Tatins",
                    Description = "The caramelized onions with thyme, and goat's cheese on the puff Tarte Tatins makes a great vegetarian dish as a party starter.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Potted Crab",
                    Description = "A hint of smoked paprika with your potted crab adds a new mix to party starters.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Runner Bean Samosas",
                    Description = "It is a great starter to nibble on for a few people. Runner beans go well with spices creating the perfect balance.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Scallops With Chorizo & Hazelnut Picada",
                    Description = "Adda touch of Spanish elegance with this meal. This is a vibrant starter for any occasion.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomatoes, Burrata And Broad Bean Salad",
                    Description = "It is a simple yet tasty dish that requires a few ingredients.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Tripple Cheese & Tarragon-Stuffed Mushroom",
                    Description = "This is a super fast and easy dish to make for a light starter. With just 5 ingredients you can have it ready to eat in 15 mins.",
                    Price = 0
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Watercress & Celeriac Soup With Goat’s Cheese Crouton",
                    Description = "This is a simple starter you can freeze ahead for your friends and family, and for an extra richness add the goat’s cheese",
                    Price = 0
                }
             );

            _context.SaveChanges();
        }
    }
}
