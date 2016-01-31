using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Ext.Net.MVC;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Models
{    
    public class Plant
    {
        public string Common 
        { 
            get; 
            set; 
        }

        public string Botanical
        {
            get;
            set;
        }

        public string Zone
        {
            get;
            set;
        }

        public string ColorCode
        {
            get;
            set;
        }

        public string Light
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public DateTime Availability
        {
            get;
            set;
        }

        public bool Indoor
        {
            get;
            set;
        }

        public static Paging<Plant> PlantsPaging(StoreRequestParameters parameters)
        {
            return Plant.PlantsPaging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null);
        }

        public static Paging<Plant> PlantsPaging(int start, int limit, string sort, SortDirection dir, string filter)
        {
            List<Plant> plants = Plant.GetPlants();

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                plants.RemoveAll(plant => !plant.Common.ToLower().StartsWith(filter.ToLower()));
            }

            if (!string.IsNullOrEmpty(sort))
            {
                plants.Sort(delegate(Plant x, Plant y)
                {
                    object a;
                    object b;

                    int direction = dir == SortDirection.DESC ? -1 : 1;

                    a = x.GetType().GetProperty(sort).GetValue(x, null);
                    b = y.GetType().GetProperty(sort).GetValue(y, null);

                    return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
                });
            }

            if ((start + limit) > plants.Count)
            {
                limit = plants.Count - start;
            }

            List<Plant> rangePlants = (start < 0 || limit < 0) ? plants : plants.GetRange(start, limit);

            return new Paging<Plant>(rangePlants, plants.Count);
        }

        public static List<Plant> GetPlants()
        {
            return new List<Plant> { 
                new Plant 
                {
                    Common = "Bloodroot",
                    Botanical = "Sanguinaria canadensis",
                    Zone = "4",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 2.44,
                    Availability = new DateTime(2006, 03, 15),
                    Indoor = true
                }, 

                new Plant 
                {
                    Common = "Columbine",
                    Botanical = "Aquilegia canadensis",
                    Zone = "3",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 9.37,
                    Availability = new DateTime(2006, 03, 06),
                    Indoor = true
                }, 

                new Plant
                {
                    Common = "Marsh Marigold",
                    Botanical = "Caltha palustris",
                    Zone = "4",
                    ColorCode = "F5F5F5",
                    Light = "Mostly Sunny",
                    Price = 6.81,
                    Availability = new DateTime(2006, 05, 17),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Cowslip",
                    Botanical = "Caltha palustris",
                    Zone = "4",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 9.90,
                    Availability = new DateTime(2006, 03, 06),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Dutchman's-Breeches",
                    Botanical = "Dicentra cucullaria",
                    Zone = "3",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 6.44,
                    Availability = new DateTime(2006, 01, 20),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Ginger, Wild",
                    Botanical = "Asarum canadense",
                    Zone = "3",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 9.03,
                    Availability = new DateTime(2006, 04, 18),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Hepatica",
                    Botanical = "Hepatica americana",
                    Zone = "4",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 4.45,
                    Availability = new DateTime(2006, 01, 26),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Liverleaf",
                    Botanical = "Hepatica americana",
                    Zone = "4",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 3.99,
                    Availability = new DateTime(2006, 01, 02),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Jack-In-The-Pulpit",
                    Botanical = "Arisaema triphyllum",
                    Zone = "4",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 3.23,
                    Availability = new DateTime(2006, 02, 01),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Mayapple",
                    Botanical = "Podophyllum peltatum",
                    Zone = "3",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 2.98,
                    Availability = new DateTime(2006, 06, 05),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Phlox, Woodland",
                    Botanical = "Phlox divaricata",
                    Zone = "3",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 2.80,
                    Availability = new DateTime(2006, 01, 22),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Phlox, Blue",
                    Botanical = "Phlox divaricata",
                    Zone = "3",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 5.59,
                    Availability = new DateTime(2006, 02, 16),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Spring-Beauty",
                    Botanical = "Claytonia Virginica",
                    Zone = "7",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 6.59,
                    Availability = new DateTime(2006, 02, 01),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Trillium",
                    Botanical = "Trillium grandiflorum",
                    Zone = "5",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 3.90,
                    Availability = new DateTime(2006, 04, 29),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Wake Robin",
                    Botanical = "Trillium grandiflorum",
                    Zone = "5",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 3.20,
                    Availability = new DateTime(2006, 02, 21),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Violet, Dog-Tooth",
                    Botanical = "Erythronium americanum",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 9.04,
                    Availability = new DateTime(2006, 02, 01),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Trout Lily",
                    Botanical = "Erythronium americanum",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 6.94,
                    Availability = new DateTime(2006, 03, 24),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Adder's-Tongue",
                    Botanical = "Erythronium americanum",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 9.58,
                    Availability = new DateTime(2006, 04, 13),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Anemone",
                    Botanical = "Anemone blanda",
                    Zone = "6",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 8.86,
                    Availability = new DateTime(2006, 12, 26),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Grecian Windflower",
                    Botanical = "Anemone blanda",
                    Zone = "6",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 9.16,
                    Availability = new DateTime(2006, 07, 10),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Bee Balm",
                    Botanical = "Monarda didyma",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 4.59,
                    Availability = new DateTime(2006, 05, 03),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Bergamot",
                    Botanical = "Monarda didyma",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 7.16,
                    Availability = new DateTime(2006, 04, 27),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Black-Eyed Susan",
                    Botanical = "Rudbeckia hirta",
                    Zone = "Annual",
                    ColorCode = "FFFFFF",
                    Light = "Sunny",
                    Price = 9.80,
                    Availability = new DateTime(2006, 06, 18),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Buttercup",
                    Botanical = "Ranunculus",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 2.57,
                    Availability = new DateTime(2006, 06, 10),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Crowfoot",
                    Botanical = "Ranunculus",
                    Zone = "4",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 9.34,
                    Availability = new DateTime(2006, 04, 03),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Butterfly Weed",
                    Botanical = "Asclepias tuberosa",
                    Zone = "Annual",
                    ColorCode = "FFFFFF",
                    Light = "Sunny",
                    Price = 2.78,
                    Availability = new DateTime(2006, 06, 30),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Cinquefoil",
                    Botanical = "Potentilla",
                    Zone = "Annual",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 7.06,
                    Availability = new DateTime(2006, 05, 25),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Primrose",
                    Botanical = "Oenothera",
                    Zone = "3 - 5",
                    ColorCode = "FFFFFF",
                    Light = "Sunny",
                    Price = 6.56,
                    Availability = new DateTime(2006, 01, 30),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Gentian",
                    Botanical = "Gentiana",
                    Zone = "4",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 7.81,
                    Availability = new DateTime(2006, 05, 18),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Blue Gentian",
                    Botanical = "Gentiana",
                    Zone = "4",
                    ColorCode = "EEEEEE",
                    Light = "Sun or Shade",
                    Price = 8.56,
                    Availability = new DateTime(2006, 05, 02),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Jacob's Ladder",
                    Botanical = "Polemonium caeruleum",
                    Zone = "Annual",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 9.26,
                    Availability = new DateTime(2006, 02, 21),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Greek Valerian",
                    Botanical = "Polemonium caeruleum",
                    Zone = "Annual",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 4.36,
                    Availability = new DateTime(2006, 07, 14),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "California Poppy",
                    Botanical = "Eschscholzia californica",
                    Zone = "Annual",
                    ColorCode = "FFFFFF",
                    Light = "Sunny",
                    Price = 7.89,
                    Availability = new DateTime(2006, 03, 27),
                    Indoor = false
                }, 
                
                new Plant
                {
                    Common = "Shooting Star",
                    Botanical = "Dodecatheon",
                    Zone = "Annual",
                    ColorCode = "E7E7E7",
                    Light = "Mostly Shady",
                    Price = 8.60,
                    Availability = new DateTime(2006, 05, 13),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Snakeroot",
                    Botanical = "Cimicifuga",
                    Zone = "Annual",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 5.63,
                    Availability = new DateTime(2006, 07, 11),
                    Indoor = true
                }, 
                
                new Plant
                {
                    Common = "Cardinal Flower",
                    Botanical = "Lobelia cardinalis",
                    Zone = "2",
                    ColorCode = "E1E1E1",
                    Light = "Shade",
                    Price = 3.02,
                    Availability = new DateTime(2006, 02, 22),
                    Indoor = true
                }
            };
        }
    }
}