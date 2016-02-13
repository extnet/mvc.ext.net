using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic.Controllers
{
    public class Punch_ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChart()
        {
            List<string> axisx = new List<string>
            {
                "12am",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12pm",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11"
            };

            List<Pair> data = new List<Pair>
            {
                new Pair("Mon", new List<int?>{
                  null, null, null, null, 23, null, null, null, null, 40, null, 15, 10, null, 17, null, 14, 12, 20, 16, null, null, 5, 28
                }),
                new Pair("Tue", new List<int?>{
                  35, 11, null, 2, 35, null, 22, null, null, 4, 3, null, 29, 5, 34, null, null, 26, null, null, null, null, 29, 8
                }),
                new Pair("Wed", new List<int?>{
                  null, 31, null, 19, 35, null, null, null, null, 1, 20, null, null, 21, 7, 5, 17, 23, 9, null, 6, null, 38, 27
                }),
                new Pair("Thu", new List<int?>{
                  12, null, null, null, 37, 23, 17, null, 32, null, null, 7, null, null, 27, null, null, 18, null, 1, null, 39, 3, null
                }),
                new Pair("Fri", new List<int?>{
                  null, null, null, null, 17, 30, null, 2, 27, 22, null, null, null, null, 40, 38, 8, null, null, 8, null, 9, null, 38
                }),
                new Pair("Sat", new List<int?>{
                  null, null, 18, 15, 38, null, null, null, 24, null, 30, null, 10, null, null, null, 20, 30, null, null, 34, null, null, 30
                }),
                new Pair("Sun", new List<int?>{
                  null, 11, 30, null, null, 20, 3, null, null, null, 26, 3, 28, 23, null, null, null, 21, null, null, null, 20, null, null
                })
            };

            return this.ComponentConfig(Draw(axisx, data));
        }

        private DrawContainer Draw(List<string> axisx, List<Pair> data)
        {
            DrawContainer draw = new DrawContainer { Border = false };

            int width = 800;
            int height = 300;
            int leftgutter = 30;
            int bottomgutter = 20;
            int x = Convert.ToInt32((width - leftgutter) * 1.0 / axisx.Count);
            int y = Convert.ToInt32((height - bottomgutter) * 1.0 / data.Count);
            int max = Convert.ToInt32(Math.Round(x / 2.0) - 1);

            for (int i = 0; i < axisx.Count; i++)
            {
                draw.Items.Add(new TextSprite
                {
                    X = Convert.ToInt32(leftgutter + x * (i + 0.5)),
                    Y = 294,
                    Text = axisx[i],
                    Font = "10px Fontin-Sans, Arial",
                    StrokeStyle = "none",
                    FillStyle = "#000"
                });
            }

            for (int i = 0; i < data.Count; i++)
            {
                draw.Items.Add(new TextSprite
                {
                    X = 10,
                    Y = Convert.ToInt32(y * (i + 0.5)),
                    Text = data[i].First.ToString(),
                    Font = "10px Fontin-Sans, Arial",
                    StrokeStyle = "none",
                    FillStyle = "#000"
                });
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < axisx.Count; j++)
                {
                    List<int?> row = (List<int?>)data[i].Second;
                    int? value = row[j];

                    if (value != null)
                    {
                        int r = Convert.ToInt32(Math.Min(Math.Round(Math.Sqrt(value.Value / Math.PI) * 4), max));
                        int dx = Convert.ToInt32(leftgutter + x * (j + 0.5) - 60 - r);
                        int dy = Convert.ToInt32(y * (i + 0.5) - 10);
                        string color = System.Drawing.ColorTranslator.ToHtml(ColorFromAhsb((1 - r * 1.0f / max) * 0.5, 1, 0.5));

                        draw.Items.Add(new CircleSprite
                        {
                            SpriteID = "dt_" + i + "_" + j,
                            CX = dx + 60 + r,
                            CY = dy + 10,
                            Radius = r,
                            StrokeStyle = "none",
                            FillStyle = color
                        });

                        if (r < 6)
                        {
                            draw.Items.Add(new CircleSprite
                            {
                                SpriteID = "bg_" + i + "_" + j,
                                CX = dx + 60 + r,
                                CY = dy + 10,
                                Radius = 6,
                                StrokeStyle = "2",
                                FillStyle = "#777",
                                GlobalAlpha = 0.5,
                                Hidden = true
                            });
                        }

                        draw.Items.Add(new TextSprite
                        {
                            SpriteID = "lbl_" + i + "_" + j,
                            X = dx + 60 + r,
                            Y = dy + 10,
                            TextAlign = TextSpriteAlign.Center,
                            Text = value.Value.ToString(),
                            Font = "10px Fontin-Sans, Arial",
                            StrokeStyle = "none",
                            FillStyle = "#fff",
                            Hidden = true
                        });

                        draw.Items.Add(new CircleSprite
                        {
                            CX = dx + 60 + r,
                            CY = dy + 10,
                            Radius = max,
                            StrokeStyle = "none",
                            FillStyle = "#000",
                            GlobalAlpha = 0/*,
                            Listeners =
                            {
                                MouseOver = {
                                    Handler = string.Format("onMouseOver(this.surface, {0});", JSON.Serialize("_"+i+"_"+j))
                                },

                                MouseOut = {
                                    Handler = string.Format("onMouseOut(this.surface, {0});", JSON.Serialize("_"+i+"_"+j))
                                }
                            }*/
                        });
                    }
                }
            }

            draw.Width = width;
            draw.Height = height;

            return draw;
        }

        public System.Drawing.Color ColorFromAhsb(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            return System.Drawing.Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
        }
    }
}
