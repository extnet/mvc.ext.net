using System;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column.Models
{
    public class RendererModel
    {
        private static double seed = 1.42;

        private static int Random()
        {
            // Controllable random.
            seed *= 7.3;
            seed -= Math.Floor(seed);
            return Convert.ToInt32(seed);
        }

        private static int mkRand(int mult, int shift)
        {
            return mult * Random() + shift;
        }

        private static int mkRecRand(int val, int mult, int shift)
        {
            return Math.Abs(val + mkRand(mult, shift));
        }

        public static object GenerateData(int count = 7)
        {
            var data = new List<Item>();
            int i;
            Item record = new Item
            {
                ID = 0,
                G0 = 200,
                G1 = mkRand(500, 100),
                G2 = mkRand(500, 100),
                G3 = mkRand(500, 100),
                G4 = mkRand(500, 100),
                G5 = mkRand(500, 100),
                G6 = mkRand(500, 100),
                Name = "Item-0"
            };

            data.Add(record);
            for (i = 1; i < count; i++)
            {
                record = new Item
                {
                    ID = i,
                    G0 = record.G0 + 30 * Random(),
                    G1 = mkRecRand(record.G1, 300, -140),
                    G2 = mkRecRand(record.G2, 300, -140),
                    G3 = mkRecRand(record.G3, 300, -140),
                    G4 = mkRecRand(record.G4, 300, -140),
                    G5 = mkRecRand(record.G5, 300, -140),
                    G6 = mkRecRand(record.G6, 300, -140),
                    Name = "Item-" + i
                };
                data.Add(record);
            }

            return data;
        }

        public class Item
        {
            public int ID { get; set; }
            public int G0 { get; set; }
            public int G1 { get; set; }
            public int G2 { get; set; }
            public int G3 { get; set; }
            public int G4 { get; set; }
            public int G5 { get; set; }
            public int G6 { get; set; }
            public string Name { get; set; }
        }
    }
}
