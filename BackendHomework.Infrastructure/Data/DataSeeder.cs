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
                    Price = 1000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Beetroot & Blackberry Cured Salmon",
                    Description = "You can serve this on crackers as a canape, and the beetroot and berries make it a great version as a starter.",
                    Price = 2500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Carpaccio Scallops",
                    Description = "This dish requires a little more effort than average.",
                    Price = 5000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chargrilled Mackerel With Sweet And Sour Beetroot",
                    Description = "Grilled mackerel gives a different kind of charred taste, and the beetroots add a perfect compromise to the sweet and sour starter.",
                    Price = 1250
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Charred Leeks With Anchovy Dressing",
                    Description = "This simple starter is the star of the elegant dish, and the anchovy adds a depth of flavor.",
                    Price = 3000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Charred Spring Onions & Romesco",
                    Description = "It is a vegetarian dish appropriate for a dinner party.",
                    Price = 4300
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheesy Sprout Fondue",
                    Description = "Transform your leftover cheese into a versatile starter recipe, served perfect with crusty bread.",
                    Price = 1350
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chicken Liver & Pineau Pâté",
                    Description = "This is a sweet pâté recipe that is rich in taste using pineau. It goes well as a dinner party starter.",
                    Price = 1900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Faux Gras With Toast And Pickles",
                    Description = "The easiest parfait ever, with only two ingredients you’ll have this served in no time.",
                    Price = 1890
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Gravadlax With Celeriac & Fennel Salad",
                    Description = "A Nordic salmon starter, cured with dill and served with a nice dressing of mustard, honey and dill with a crisp salad.",
                    Price = 2500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Grilled Lobster Tails With Lemon & Herb Butter",
                    Description = "This is an impressive party dinner dish but takes a little more effort to put together. The lobster tails are complimented with parsley, lemon, and garlic butter.",
                    Price = 3500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham Hock & Pistachio Roll",
                    Description = "It can be made into a starter, and is a Chrismas special.",
                    Price = 7000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Minted Melon, Tomato & Prosciutto Salad",
                    Description = "It is deal as a sharing plater to start off your dinner or summer event.",
                    Price = 800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Onions And Goat’s Cheese Tarte Tatins",
                    Description = "The caramelized onions with thyme, and goat's cheese on the puff Tarte Tatins makes a great vegetarian dish as a party starter.",
                    Price = 900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Potted Crab",
                    Description = "A hint of smoked paprika with your potted crab adds a new mix to party starters.",
                    Price = 1800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Runner Bean Samosas",
                    Description = "It is a great starter to nibble on for a few people. Runner beans go well with spices creating the perfect balance.",
                    Price = 1100
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Scallops With Chorizo & Hazelnut Picada",
                    Description = "Adda touch of Spanish elegance with this meal. This is a vibrant starter for any occasion.",
                    Price = 3000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomatoes, Burrata And Broad Bean Salad",
                    Description = "It is a simple yet tasty dish that requires a few ingredients.",
                    Price = 500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Tripple Cheese & Tarragon-Stuffed Mushroom",
                    Description = "This is a super fast and easy dish to make for a light starter. With just 5 ingredients you can have it ready to eat in 15 mins.",
                    Price = 1200
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Watercress & Celeriac Soup With Goat’s Cheese Crouton",
                    Description = "This is a simple starter you can freeze ahead for your friends and family, and for an extra richness add the goat’s cheese.",
                    Price = 4500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer-Brined Beer Can Chicken",
                    Description = "This is a great meal that provides more fun while cooking.",
                    Price = 3800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Steamed Mussels And Chorizo",
                    Description = "Make this Mediterranean surf and turf dish for your fancy looking dinner. Add some spice and a splash of wine for bursting flavor.",
                    Price = 2500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Cauliflower Bolognese",
                    Description = "This is a great alternative to the meaty original, and it is suitable for both vegans and non-vegans.",
                    Price = 1950
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chicken Stew With Potatoes And Radish",
                    Description = "This is a great alternative to the meaty original, and it is suitable for both vegans and non-vegansIt makes an excellent choice for comfort food, " +
                    "taking in the flavour of chicken paprikash.",
                    Price = 3000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Creamy Squash Risotto With Toasted Pepitas",
                    Description = "A paprika packed squash puree makes this meal hearty and satisfying.",
                    Price = 1790
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chilled-Marinated Pork With Vietnamese Brussels Sprouts",
                    Description = "It is a great sauce for an easy dinner with plenty of flavor.",
                    Price = 1320
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Clam Toast With Pancetta",
                    Description = "The backbone of this toast is the pancetta, providing a great duo between pork and shellfish.",
                    Price = 1270
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Filipino-Style Meatloaf",
                    Description = "Meatloaf can be equally beautiful and tasty for your dinner party. You can soak up the juice with rice.",
                    Price = 2800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Filipino-Style Roast Pork Belly With Chile Vinegar",
                    Description = "This is a simple method for cooking pork belly and provides a succulent meaty taste.",
                    Price = 1850
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Grand Aioli",
                    Description = "It is a summer French classic that requires no cutlery. It can be served with any seafood or vegetable of your choice.",
                    Price = 2300
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Grilled Garlic And Black Pepper Shrimp",
                    Description = "It is a simple yet impressive meal and is easy to prepare.",
                    Price = 900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Grilled Scallops With Creamed Corn",
                    Description = "This is a multipurpose dry dish recipe that will have your guests coming back for seconds.",
                    Price = 1500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Olive Oil-Confit Chicken With Cipollini Onions",
                    Description = "The chicken thighs come out moist and soaked with the juicy flavour of the oils.",
                    Price = 2150
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Pork Chops With Celery And Almond Salad",
                    Description = "Two giant pork chops seasoned with garlic and thyme make this dish easy to serve as a family-style meal, and is also elegant.",
                    Price = 4000
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Pork Chops With Fig And Grape Agrodolce",
                    Description = "Cooking pork chops in balsamic vinegar and honey makes a sweet and sour sauce that perfectly complements the chops.",
                    Price = 3800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Roast Chicken With Harissa And Schmaltz",
                    Description = "This tenderized chicken packs a lot of heat, making it a great recipe for your main.",
                    Price = 2950
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Roasted Pumpkin, Marjoram, And Blue Cheese Frittata",
                    Description = "This makes for a great vegetarian main course at your elegant dinner partyThis tenderized chicken packs a lot of heat, making it a great recipe for your main.",
                    Price = 2780
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Slow-Roasted Salmon In Parchment Paper",
                    Description = "The flavor of this dish comes from olives and capers, some rum, a squeeze of lime juice, and sweet raisins.",
                    Price = 2150
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Spring Risotto",
                    Description = "This is ideal for a vegan dinner party.",
                    Price = 1900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomato Tart With Chickpea Crumbles",
                    Description = "Get a filling of protein and flavor with this classic tomato sauce dish.",
                    Price = 1550
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Avocado Chocolate Mousse",
                    Description = "This is super light yet delicious.",
                    Price = 900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Banoffee Pie",
                    Description = "Visit your childhood and treat your guest with this classic dinner dessert recipe.",
                    Price = 1250
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Bourbon Glazed Donut",
                    Description = "The extra effort put into this dessert is well worth the result.",
                    Price = 1400
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chilled Lemon Soufflé",
                    Description = "An iced lemon soufflé makes for a great dinner dessert recipe and is a great substitute for the famous French food, the chocolate souffle.",
                    Price = 1500
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate Almond Torte",
                    Description = "This is a winner for any dinner party you are throwing.",
                    Price = 1550
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate Cheesecake",
                    Description = "A sweet ending to a lovely dinner with family and friends is what this cheesecake represents.",
                    Price = 1100
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Classic Lemon Tart",
                    Description = "You can’t go wrong with this simple yet classic lemon tart.",
                    Price = 800
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Clementine And Coconut Cream Sorbet",
                    Description = "It is very simple to make but still lovely and refreshing.",
                    Price = 650
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "Coconut Custard Tart With Roasted Pineapple",
                    Description = "Add a tropical twist to your dinner with this custard tart.",
                    Price = 900
                },
                new Plate
                {
                    Id = Guid.NewGuid(),
                    Name = "DIY Raspberry Eton Mess",
                    Description = "Try something different by allowing your guest to put together their own dessert.",
                    Price = 1100
                }
             );

            _context.SaveChanges();
        }
    }
}
