using System.Collections.Generic;
using RecipePal.Core.Models;

namespace RecipePal.Core.Mock
{
    public static class MockStaticData
    {
        public static class Quantities
        {
            public static IList<QuantityType> QuantityTypes { get; } =
                new List<QuantityType>
                {
                    new QuantityType {Tag = 1, QuantityName = "kg"},
                    new QuantityType {Tag = 2, QuantityName = "ml"},
                    new QuantityType {Tag = 3, QuantityName = "pounds"},
                    new QuantityType {Tag = 4, QuantityName = "ounce"},
                    new QuantityType {Tag = 5, QuantityName = "piece"},
                    new QuantityType {Tag = 6, QuantityName = "cup"},
                    new QuantityType {Tag = 7, QuantityName = "tbsp"},
                    new QuantityType {Tag = 8, QuantityName = "tsp"},
                    new QuantityType {Tag = 9, QuantityName = "sheets"},
                    new QuantityType {Tag = 10, QuantityName = "package"},
                    new QuantityType {Tag = 11, QuantityName = "lb"},
                    new QuantityType {Tag = 12, QuantityName = "oz"},
                    new QuantityType {Tag = 13, QuantityName = "can"},
                    new QuantityType {Tag = 14, QuantityName = "bunch"},
                };
        }


        public static class Ingredients
        {
            public static IList<Ingredient> IngredientsList { get; } =
                new List<Ingredient>
                {
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Artichokes", Quantity = 4},
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Lemon", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Salt ", Quantity = -1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Pepper", Quantity = -1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 1, Name = "Plum tomato", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 1, Name = "Red onion ", Quantity = 0.5},
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Scallion", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 1, Name = "Cilantro", Quantity = 2},
                    new Ingredient {QuantityTag = 8, RecipeTag = 1, Name = "Garlic", Quantity = 2},
                    new Ingredient {QuantityTag = 8, RecipeTag = 1, Name = "Jalapeño", Quantity = 0.5},
                    new Ingredient {QuantityTag = 7, RecipeTag = 1, Name = "Extra-virgin olive oil", Quantity = 2},
                    new Ingredient {QuantityTag = 7, RecipeTag = 1, Name = "Lime juice", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 1, Name = "Belgian endive spears", Quantity = 12},

                    new Ingredient {QuantityTag = 6, RecipeTag = 2, Name = "All-purpose flour ", Quantity = 1},
                    new Ingredient {QuantityTag = 9, RecipeTag = 2, Name = "Frozen puff pastry ", Quantity = 2},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Egg yolk ", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Water ", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Ripe Hass Avocados", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Ripe red pears", Quantity = 2},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Lemon ", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Gorgonzola cheese ", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 2, Name = "Honey", Quantity = -1},

                    new Ingredient {QuantityTag = -1, RecipeTag = 3, Name = "Boneless beef pot", Quantity = 1},
                    new Ingredient {QuantityTag = 10, RecipeTag = 3, Name = "Wonton wrappers", Quantity = 0.5},
                    new Ingredient
                    {
                        QuantityTag = 7,
                        RecipeTag = 3,
                        Name = "Southeast Asian peanut sauce",
                        Quantity = 0.25
                    },
                    new Ingredient {QuantityTag = 6, RecipeTag = 3, Name = "Hoisin sauce", Quantity = 2},
                    new Ingredient {QuantityTag = -1, RecipeTag = 3, Name = "Yellow bell pepper", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 3, Name = "Vegetable oil", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 3, Name = "Monterey Jack cheese", Quantity = 2},
                    new Ingredient {QuantityTag = 6, RecipeTag = 3, Name = "Tomato", Quantity = 0.5},
                    new Ingredient {QuantityTag = 6, RecipeTag = 3, Name = "Green onion", Quantity = 0.25},
                    new Ingredient {QuantityTag = 7, RecipeTag = 3, Name = "Fresh cilantro", Quantity = 1},

                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "Maraschino cherries", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "All-purpose flour", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 4, Name = "Baking powder", Quantity = 2},
                    new Ingredient {QuantityTag = 7, RecipeTag = 4, Name = "Salt", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "Butter", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "Brown sugar", Quantity = 2},
                    new Ingredient {QuantityTag = -1, RecipeTag = 4, Name = "Eggs", Quantity = 2},
                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "Bananas", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 4, Name = "Macadamia nuts", Quantity = 0.5},

                    new Ingredient {QuantityTag = 11, RecipeTag = 5, Name = "Beef", Quantity = 0.75},
                    new Ingredient {QuantityTag = 11, RecipeTag = 5, Name = "Pork", Quantity = 0.75},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Garlic", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Eggs", Quantity = 2},
                    new Ingredient {QuantityTag = 6, RecipeTag = 5, Name = "White wine", Quantity = 0.25},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Salt", Quantity = -1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Black pepper", Quantity = -1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Parsley sprigs", Quantity = 5},
                    new Ingredient {QuantityTag = 12, RecipeTag = 5, Name = "Gorgonzola cheese", Quantity = 3.5},
                    new Ingredient {QuantityTag = 6, RecipeTag = 5, Name = "Flour", Quantity = 0.5},
                    new Ingredient {QuantityTag = -1, RecipeTag = 5, Name = "Extra virgin olive oil", Quantity = -1},

                    new Ingredient {QuantityTag = 7, RecipeTag = 6, Name = "Chili powder", Quantity = 4},
                    new Ingredient {QuantityTag = 7, RecipeTag = 6, Name = "Cumin", Quantity = 2},
                    new Ingredient {QuantityTag = 7, RecipeTag = 6, Name = "Chipotle powder", Quantity = 2},
                    new Ingredient {QuantityTag = 8, RecipeTag = 6, Name = "Dried oregano", Quantity = 2},
                    new Ingredient {QuantityTag = 8, RecipeTag = 6, Name = "Dried parsley", Quantity = 2},
                    new Ingredient {QuantityTag = 8, RecipeTag = 6, Name = "Salt", Quantity = 2},
                    new Ingredient {QuantityTag = 3, RecipeTag = 6, Name = "Flank steak", Quantity = 2},
                    new Ingredient {QuantityTag = 7, RecipeTag = 6, Name = "Extra-virgin olive oil", Quantity = 3},

                    new Ingredient {QuantityTag = 3, RecipeTag = 7, Name = "Boneless lamb", Quantity = 1},
                    new Ingredient {QuantityTag = 8, RecipeTag = 7, Name = "Salt", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 7, Name = "Vegetable oil", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 7, Name = "Red pepper", Quantity = 1},
                    new Ingredient {QuantityTag = 8, RecipeTag = 7, Name = "Curry powder", Quantity = 2},
                    new Ingredient {QuantityTag = 13, RecipeTag = 7, Name = "Pineapple tidbits", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 7, Name = "Cooked rice", Quantity = 3},
                    new Ingredient {QuantityTag = 6, RecipeTag = 7, Name = "Raisins ", Quantity = 0.3},

                    new Ingredient {QuantityTag = 11, RecipeTag = 8, Name = "Pork spare ribs", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 8, Name = "Dried lotus leaves", Quantity = 2},
                    new Ingredient {QuantityTag = -1, RecipeTag = 8, Name = "Rice powder", Quantity = -1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Chopped scallion", Quantity = 2},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Chopped ginger", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Soy sauce", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Oil", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Sugar", Quantity = 1},
                    new Ingredient {QuantityTag = 7, RecipeTag = 8, Name = "Sesame oil", Quantity = 0.5},

                    new Ingredient {QuantityTag = 3, RecipeTag = 9, Name = "Catfish", Quantity = 2.5},
                    new Ingredient {QuantityTag = 14, RecipeTag = 9, Name = "Mixed fresh herbs", Quantity = 1},
                    new Ingredient {QuantityTag = 3, RecipeTag = 9, Name = "Sea salt", Quantity = 9},
                    new Ingredient {QuantityTag = -1, RecipeTag = 9, Name = "Garlic", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 9, Name = "Parsley sprig", Quantity = 1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 9, Name = "Olive oil", Quantity = 0.5},
                    new Ingredient {QuantityTag = -1, RecipeTag = 9, Name = "Lemon", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 9, Name = "Salt", Quantity = -1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 9, Name = "Pepper", Quantity = -1},

                    new Ingredient {QuantityTag = -1, RecipeTag = 10, Name = "Nonstick cooking spray", Quantity = -1},
                    new Ingredient {QuantityTag = 6, RecipeTag = 10, Name = "Cornstarch", Quantity = 0.3},
                    new Ingredient {QuantityTag = 8, RecipeTag = 10, Name = "Salt", Quantity = 0.75},
                    new Ingredient {QuantityTag = 8, RecipeTag = 10, Name = "Cayenne pepper", Quantity = 0.25},
                    new Ingredient {QuantityTag = -1, RecipeTag = 10, Name = "Egg whites", Quantity = 2},
                    new Ingredient {QuantityTag = 6, RecipeTag = 10, Name = "Flaked coconut", Quantity = 1.5},
                    new Ingredient {QuantityTag = 3, RecipeTag = 10, Name = "Salmon fillet", Quantity = 1},
                    new Ingredient {QuantityTag = -1, RecipeTag = 10, Name = "Pineapple Salsa", Quantity = -1},
                };
        }

        public static class Categories
        {
            public static List<Category> CategoriesList { get; } =
                new List<Category>
                {
                    new Category
                    {
                        Tag = 1,
                        Name = "Appetizer Recipes",
                        ImageUrl = "https://image.ibb.co/mdavQk/ARTICHOKE_CEVICHE.jpg"
                    },
                    new Category
                    {
                        Tag = 2,
                        Name = "Beverage Recipes",
                    },
                    new Category
                    {
                        Tag = 3,
                        Name = "Breads, Muffins, etc",
                    },
                    new Category
                    {
                        Tag = 4,
                        Name = "Breakfast Recipes",
                    },
                    new Category
                    {
                        Tag = 5,
                        Name = "Dessert Recipes",
                    },
                    new Category
                    {
                        Tag = 6,
                        Name = "Holiday Recipes",
                    },
                    new Category
                    {
                        Tag = 7,
                        Name = "Meat Recipes",
                        ImageUrl = "https://image.ibb.co/jbkC5k/stewed_lamb.jpg"
                    },
                    new Category
                    {
                        Tag = 8,
                        Name = "Ham Main Dish Recipes",
                    },
                    new Category
                    {
                        Tag = 9,
                        Name = "Lamb Main Dish Recipes",
                    },
                    new Category
                    {
                        Tag = 10,
                        Name = "Alligator Recipes",
                    },
                    new Category
                    {
                        Tag = 11,
                        Name = "Ostrich & Emu Recipes",
                    },
                    new Category
                    {
                        Tag = 12,
                        Name = "Venison Recipes",
                    },
                    new Category
                    {
                        Tag = 13,
                        Name = "Rabbit, Hare & Squirrel",
                    },
                    new Category
                    {
                        Tag = 14,
                        Name = "Other Meats Recipes",
                    },
                    new Category
                    {
                        Tag = 15,
                        Name = "Poultry Recipes",
                    },
                    new Category
                    {
                        Tag = 16,
                        Name = "Chicken Recipes",
                    },
                    new Category
                    {
                        Tag = 17,
                        Name = "Cornish Hen Recipes",
                    },
                    new Category
                    {
                        Tag = 18,
                        Name = "Turkey Recipes",
                    },
                    new Category
                    {
                        Tag = 19,
                        Name = "Duck, Duckling Recipes",
                    },
                    new Category
                    {
                        Tag = 20,
                        Name = "Goose & Game Birds",
                    },
                    new Category
                    {
                        Tag = 21,
                        Name = "Seafood Recipes",
                        ImageUrl = "https://image.ibb.co/iE4GWQ/grilled_salmon_pineapple_salsa.jpg"
                    },
                    new Category
                    {
                        Tag = 22,
                        Name = "Meatless & Vegetarian",
                    },
                    new Category
                    {
                        Tag = 23,
                        Name = "Pasta & Noodles",
                    },
                    new Category
                    {
                        Tag = 24,
                        Name = "Potato Recipes",
                    },
                    new Category
                    {
                        Tag = 25,
                        Name = "Rice Recipes",
                    },
                    new Category
                    {
                        Tag = 26,
                        Name = "Stuffing Recipes",
                    },
                    new Category
                    {
                        Tag = 27,
                        Name = "Salad Recipes",
                    },
                    new Category
                    {
                        Tag = 28,
                        Name = "Salad Dressing Recipes",
                    },
                    new Category
                    {
                        Tag = 29,
                        Name = "Sandwiches & Wraps",
                    },
                    new Category
                    {
                        Tag = 30,
                        Name = "Sauces, Salsas, Relishes",
                    },
                    new Category
                    {
                        Tag = 31,
                        Name = "Seasonings, Marinades",
                    },
                    new Category
                    {
                        Tag = 32,
                        Name = "Soups & Stews Recipes",
                    },
                    new Category
                    {
                        Tag = 33,
                        Name = "Vegetable Recipes",
                    }
                };
        }

        public static class Recipies
        {
            public static List<Recipe> RecipiesList { get; } =
                new List<Recipe>
                {
                    new Recipe
                    {
                        Tag = 1,
                        CategoryTag = 1,
                        PhotoUrl = "https://image.ibb.co/mdavQk/ARTICHOKE_CEVICHE.jpg",
                        IngredientsNumber = 12,
                        Name = "Artichoke ceviche in belgian endive",
                        CookTime = 145,
                        Difficulty = 0,
                        Serves = 4,
                        Description =
                            " 1. Trim the stems, leaves, and choke from the artichokes. Place the hearts in a small pot with enough water to generously cover. Add the lemon slices and salt to taste. Bring the water to a simmer over high heat.. Reduce the heat to medium and simmer until the artichoke hearts are very tender, about 12 to 15 minutes. Cool the hearts and slice thinly or quarter. \n 2. Toss together the artichokes, tomato, red onion, scallion, cilantro, garlic, and jalapeño. Drizzle the olive oil and lime juice over the ceviche and season generously with salt and pepper. Toss until the ingredients are evenly coated. Cover the bowl and marinate the ceviche in the refrigerator for at least 2, and up to 12, hours. \n 3. Taste the ceviche just before serving and season with additional cilantro, lime juice, coarsely ground black pepper, and salt to taste. Spoon the ceviche into the endive spears and serve on a chilled platter or plates. \n"
                    },
                    new Recipe
                    {
                        Tag = 2,
                        CategoryTag = 1,
                        PhotoUrl = "https://image.ibb.co/gG56WQ/avocado_puff_pastry_shells.jpg",
                        IngredientsNumber = 9,
                        Name = "Avocado pears honey pastry",
                        CookTime = 60,
                        Difficulty = 2,
                        Serves = 40,
                        Description =
                            "Preheat oven to 400 degrees. \nLightly coat baking sheet with cooking spray. \nLightly flour cutting surface and cut 1-1/2 inch round circles from pastry sheets (about 24 from each sheet). \nPlace on prepared baking sheet one inch apart. \nWhisk egg yolk and water in small bowl to create an egg wash; brush wash over each pastry round. \nBake for 15 minutes until tops are puffed and golden brown.\nTransfer rounds to wire rack to cool. \nTo serve, gently split each puffed round with sharp knife to create a small pocket. \nStack an avocado slice atop a pear slice and sprinkle lightly with lemon juice. \nPlace slices in the pastry puff pockets and top with ½ tsp of crumbled cheese each. \nLoosely close the pockets and place on serving tray. \nDrizzle a bit of honey from about 12 inches height on each pastry and serve immediately. "
                    },
                    new Recipe
                    {
                        Tag = 3,
                        CategoryTag = 1,
                        PhotoUrl = "https://image.ibb.co/cfr25k/Style_Beef_Nachos.png",
                        IngredientsNumber = 10,
                        Name = "Asian beef nachos",
                        CookTime = 30,
                        Difficulty = 1,
                        Serves = 8,
                        Description =
                            "Evenly space oven racks and preheat to 400°F. \r\n\r\nSpray two large baking sheets with cooking spray. Place wonton wrappers on baking sheets in single layer. Spray wrappers with cooking spray.\r\n \r\nBake in 400°F oven 6 to 9 minutes, or until crisp and edges are lightly browned; switching baking sheet position in oven midway through the baking. Remove sheets to wire racks.\r\n\r\nMeanwhile, heat beef pot roast according to package directions. \r\n\r\nRemove pot roast from gravy; shred pot roast using 2 forks. (Gravy may be reserved for another use if desired.) Combine peanut and hoisin sauces in large bowl. Add beef, toss to coat.\r\n\r\nToss bell pepper with oil in small bowl. Place in shallow baking pan. Roast in 400°F oven 10 to 12 minutes or until tender and lightly browned.\r\n\r\nPlace wonton chips on two microwave-safe dinner plates. Sprinkle evenly with cheese; top with beef. \r\n\r\nMicrowave each plate on HIGH 1/2 to 2 minutes, or until beef is hot and cheese is melted. Sprinkle with bell pepper, tomato, green onions and cilantro. Serve immediately."
                    },

                    new Recipe
                    {
                        Tag = 4,
                        CategoryTag = 3,
                        PhotoUrl = "https://image.ibb.co/hfw8d5/aloha_bread.jpg",
                        IngredientsNumber = 9,
                        Name = "Aloha bread",
                        CookTime = 70,
                        Difficulty = 1,
                        Serves = 1,
                        Description =
                            "Drain maraschino cherries, reserving 2 tablespoons juice. Cut cherries into quarters; set aside. \r\n\r\nCombine flour, baking powder and salt; set aside.\r\n\r\nCombine butter, brown sugar, eggs and reserved cherry juice in a large mixing bowl. \r\nMix on medium speed with an electric mixer until ingredients are thoroughly combined. \r\n\r\nAdd flour mixture and mashed bananas alternately, beginning and ending with flour mixture. \r\n\r\nStir in drained cherries and nuts. \r\n\r\nLightly spray a 9x5x3-inch baking pan with non-stick cooking spray. Spread batter evenly in pan.\r\n\r\nBake in a preheated 350-degree oven 1 hour, or until golden brown and wooden pick inserted near center comes out clean. \r\nRemove from pan; let cool on wire rack. \r\nStore in a tightly covered container."
                    },

                    new Recipe
                    {
                        Tag = 5,
                        CategoryTag = 7,
                        PhotoUrl = "https://image.ibb.co/jYmVrQ/meatballs.jpg",
                        IngredientsNumber = 11,
                        Name = "Meatballs",
                        CookTime = 35,
                        Difficulty = 0,
                        Serves = 4,
                        Description =
                            "Mix together the meats, garlic, eggs, wine, salt and pepper, and parsley. The easiest way to do this is with your hands—really squish everything together thoroughly. Set the mixture aside in the fridge for a couple of hours to allow the flavors to develop. Make golf ball size pieces of the mixture—about 1 oz—and roll them into a neat ball: you should make about 24.\r\n\r\nBreak the cheese up into small nuggets. Take a meatball in one hand, and with your other hand use your thumb to make a hole in the meatball. Add a piece of cheese and close up the hole by pinching the meat mixture together. Roll the meatball again and make sure the cheese is fully covered in the meat. Repeat until all the meatballs have a piece of cheese in the middle. Next, roll the meatballs in the flour.\r\n\r\nPour enough olive oil into a medium-sized frying pan or wok to come halfway up the meatballs once they are added. Heat the oil over medium heat and once it is hot, cook the meatballs in batches, about 5 or 6 at a time. Allow 1 minute on each side. Drain them on paper towels and keep warm.\r\n\r\nTo make the onion sauce, saute the onion in the olive oil until soft but not colored. This will take about 5 minutes. Add the flour, stir, and cook for another minute, before adding the warm stock. Season with salt and pepper, stir well, and simmer for about 10 minutes. Remove any froth that comes to the surface. Blend the sauce with a hand blender to give it a smooth consistency. Bring the sauce back to a simmer, add the meatballs, and cook for another minute.\r\n\r\nDivide the meatballs and sauce between four warmed bowls, scatter the almonds and parsley over the top, and eat immediately."
                    },

                    new Recipe
                    {
                        Tag = 6,
                        CategoryTag = 7,
                        PhotoUrl = "https://image.ibb.co/eKVC5k/steak.jpg",
                        IngredientsNumber = 8,
                        Name = "Chilli rubbed flank steak",
                        CookTime = 18,
                        Difficulty = 1,
                        Serves = 4,
                        Description =
                            "Preheat the oven to 400°F.\r\n\r\nIn a small bowl, combine the chili powder, cumin, chipotle, oregano, parsley, and salt. Rub the spice mixture over the steak to coat completely.\r\n\r\nIn a large, heavy, ovenproof skillet, heat the oil until almost smoking. Sear the steaks until the meat begins to caramelize, 2 to 3 minutes per side; don\'t touch or poke at the meat so that caramelization can occur. Transfer the pan to the oven and roast for 5 to 6 minutes for medium-rare (when a meat thermometer registers 130° to 140°F).\r\n\r\nRemove the steaks to a plate and allow them to rest, loosely tented under a piece of aluminum foil, 5 to 10 minutes. Slice thin across the grain and dig in."
                    },

                    new Recipe
                    {
                        Tag = 7,
                        CategoryTag = 7,
                        PhotoUrl = "https://image.ibb.co/jbkC5k/stewed_lamb.jpg",
                        IngredientsNumber = 8,
                        Name = "Carribean lamb",
                        CookTime = 38,
                        Difficulty = 2,
                        Serves = 4,
                        Description =
                            "Season lamb with salt. \r\n\r\nCook in hot oil in large skillet over medium-high heat until browned, about 2 to 3 minutes.  \r\n  \r\nAdd red pepper and curry and cook until peppers are tender crisp. \r\n\r\nAdd pineapple and liquid, rice and raisins. \r\n\r\nSimmer uncovered about 5 minutes or until lamb is cooked. "
                    },

                    new Recipe
                    {
                        Tag = 8,
                        CategoryTag = 7,
                        PhotoUrl = "https://image.ibb.co/hFRkQk/pork_with_leaf.jpg",
                        IngredientsNumber = 9,
                        Name = "Pork ribs in lotus leaf",
                        CookTime = 120,
                        Difficulty = 2,
                        Serves = 4,
                        Description =
                            "Cut spare ribs into pieces 1½ inch wide, 2 inches long, then marinate in seasonings 1/2 hour. \r\nCut lotus leaves into eight pieces and soak in hot water 20 min. \r\nRemove marinated ribs and discard scallion and ginger. Add rice powder and thoroughly mix with rib pieces. Divide ribs into eight small portions. Place each on a soaked lotus leaf, fold and roll to make a package. Place with the smooth side down in a bowl or deep plate. Steam over high heat for two hours until tender. Put a serving plate face down over the bowl and turn over."
                    },

                    new Recipe
                    {
                        Tag = 9,
                        CategoryTag = 21,
                        PhotoUrl = "https://image.ibb.co/dkWKkk/Tortilla_Crusted_Catfish.jpg",
                        IngredientsNumber = 9,
                        Name = "Catfish in salt crust",
                        CookTime = 45,
                        Difficulty = 1,
                        Serves = 4,
                        Description =
                            "Preheat the oven to 475°F, Fill the cavity of the fish with the mixed herbs. \r\n\r\nLine a roasting pan with foil and cover with a 3/4-inch thick layer of the coarse salt. \r\n\r\nPlace the catfish on top and cover with the remaining coarse salt. \r\n\r\nBake for about 35 minutes, then remove from the oven and let stand for 10 minutes. \r\n\r\nMeanwhile, combine the garlic, parsley, olive oil and lemon juice in a bowl and season with salt and pepper. \r\n\r\nTo serve, break the salt crust and carefully extract the fish. \r\n\r\nRemove and discard the skin, cut the fish in half and slice into fillets. \r\n\r\nServe with the sauce."
                    },

                    new Recipe
                    {
                        Tag = 10,
                        CategoryTag = 21,
                        PhotoUrl = "https://image.ibb.co/iE4GWQ/grilled_salmon_pineapple_salsa.jpg",
                        IngredientsNumber = 9,
                        Name = "Coconut salmon",
                        CookTime = 25,
                        Difficulty = 2,
                        Serves = 2,
                        Description =
                            "Preheat the oven to 375 degrees F. Spray a baking sheet with cooking spray. Combine the cornstarch, salt, and cayenne in a shallow dish. In a medium bowl with an electric mixer, beat the egg whites on medium-high speed until white and frothy, about 2 minutes. Put the coconut in a separate shallow dish. Cut the salmon into 2 pieces. Wash and dry with a paper towel. Coat each piece of salmon with the cornstarch mixture, then with the egg whites, and then with the coconut. Place on the baking sheet.\r\n\r\nCover with aluminum foil and bake for 15 minutes. Uncover and bake for 10 to 12 minutes more, depending on the thickness of the fish, until the flesh is no longer red but pink and flaky and the coconut is browned. Do not overcook."
                    },
                };
        }

        public static class Fav
        {
            public static IList<Favorites> FavoritesList { get; } = new List<Favorites>
            {
                new Favorites {RecipeTag = 1},
                new Favorites {RecipeTag = 4},
                new Favorites {RecipeTag = 5}
            };
        }
    }
}