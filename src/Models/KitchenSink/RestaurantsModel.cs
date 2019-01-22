using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Models.KitchenSink
{
    public class RestaurantsModel
    {
        public static IEnumerable GetAllRestaurants()
        {
            const string DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed egestas gravida nibh, quis porttitor felis venenatis id. Nam sodales mollis quam eget venenatis. Aliquam metus lorem, tincidunt ut egestas imperdiet, convallis lacinia tortor.";
            Random random = new Random();

            return new object[]
            {
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cheesecake Factory", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "University Cafe", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Slider Bar", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Shokolaat", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Gordon Biersch", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Crepevine", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Creamery", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Old Pro", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Nola\'s", cuisine = "Cajun" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "House of Bagels", cuisine = "Bagels" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "The Prolific Oven", cuisine = "Sandwiches" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "La Strada", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Buca di Beppo", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Pasta?", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Madame Tam", cuisine = "Asian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Sprout Cafe", cuisine = "Salad" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Pluto\'s", cuisine = "Salad" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Junoon", cuisine = "Indian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Bistro Maxine", cuisine = "French" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Three Seasons", cuisine = "Vietnamese" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Sancho\'s Taquira", cuisine = "Mexican" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Reposado", cuisine = "Mexican" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Siam Royal", cuisine = "Thai" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Krung Siam", cuisine = "Thai" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Thaiphoon", cuisine = "Thai" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Tamarine", cuisine = "Vietnamese" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Joya", cuisine = "Tapas" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Jing Jing", cuisine = "Chinese" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Patxi\'s Pizza", cuisine = "Pizza" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Evvia Estiatorio", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cafe 220", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cafe Renaissance", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Kan Zeman", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Gyros-Gyros", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Mango Caribbean Cafe", cuisine = "Caribbean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Coconuts Caribbean Restaurant & Bar", cuisine = "Caribbean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Rose & Crown", cuisine = "English" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Baklava", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Mandarin Gourmet", cuisine = "Chinese" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Bangkok Cuisine", cuisine = "Thai" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Darbar Indian Cuisine", cuisine = "Indian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Mantra", cuisine = "Indian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Janta", cuisine = "Indian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Hyderabad House", cuisine = "Indian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Starbucks", cuisine = "Coffee" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Peet\'s Coffee", cuisine = "Coffee" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Coupa Cafe", cuisine = "Coffee" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Lytton Coffee Company", cuisine = "Coffee" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Il Fornaio", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Lavanda", cuisine = "Mediterranean" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "MacArthur Park", cuisine = "American" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "St Michael\'s Alley", cuisine = "Californian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cafe Renzo", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Osteria", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Vero", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cafe Renzo", cuisine = "Italian" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Miyake", cuisine = "Sushi" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Sushi Tomo", cuisine = "Sushi" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Kanpai", cuisine = "Sushi" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Pizza My Heart", cuisine = "Pizza" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "New York Pizza", cuisine = "Pizza" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "California Pizza Kitchen", cuisine = "Pizza" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Round Table", cuisine = "Pizza" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Loving Hut", cuisine = "Vegan" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Garden Fresh", cuisine = "Vegan" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Cafe Epi", cuisine = "French" },
                new { description = DESCRIPTION, rating = random.Next(0, 6), name = "Tai Pan", cuisine = "Chinese" }
            };
        }
    }
}