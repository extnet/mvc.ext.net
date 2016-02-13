using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic.Controllers
{
    public class AnalyticsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDraw()
        {
            List<int> labels = new List<int>(31);
            for (int i = 1; i < 32; i++)
            {
                labels.Add(i);
            }

            List<int> data = new List<int> { 8, 25, 27, 25, 54, 59, 79, 47, 27, 44, 44, 51, 56, 83, 12, 91, 52, 12, 40, 8, 60, 29, 7, 33, 56, 25, 1, 78, 70, 68, 2 };


            return this.ComponentConfig(Draw(labels, data));
        }

        private DrawContainer Draw(List<int> labels, List<int> data)
        {
            DrawContainer draw = new DrawContainer
            {
                ID = "Draw1",
                Border = false
            };

            int width = 800;
            int height = 250;
            int leftgutter = 30;
            int bottomgutter = 20;
            int topgutter = 20;
            double colorhue = 0.6;
            string color = System.Drawing.ColorTranslator.ToHtml(this.ColorFromHSB(colorhue, 0.5, 0.5));

            double x = (width - leftgutter) / (labels.Count * 1.0);
            int max = data.Max();
            double y = (height - bottomgutter - topgutter) / (max * 1.0);

            draw.Items.Add(this.GridPath(leftgutter + y * 0.5 + 0.5, topgutter + 0.5, width - leftgutter - x, height - topgutter - bottomgutter, 10, 10, "#000"));

            PathSprite pathSprite = new PathSprite
            {
                StrokeStyle = color,
                LineWidth = 4,
                Linejoin = StrokeLinejoin.Round
            };
            draw.Items.Add(pathSprite);

            PathSprite bgpSprite = new PathSprite
            {
                StrokeStyle = "none",
                GlobalAlpha = 0.3,
                FillStyle = color
            };

            draw.Items.Add(bgpSprite);

            List<string> p = new List<string>();
            List<string> bgpp = new List<string>();

            for (int i = 0; i < labels.Count; i++)
            {
                int yc = Convert.ToInt32(Math.Round(height - bottomgutter - y * data[i]));
                int xc = Convert.ToInt32(Math.Round(leftgutter - 10 + x * (i + 0.5)));
                int heightCraph = height - bottomgutter;
                draw.Items.Add(new TextSprite
                {
                    X = Convert.ToInt32(xc),
                    Y = height - 6,
                    Text = labels[i].ToString(),
                    FillStyle = "#000",
                    Font = "12px Helvetica, Arial"
                });

                if (i == 0)
                {
                    p.AddRange(new string[]{"M", JSON.Serialize(xc), JSON.Serialize(yc),
                                            "C", JSON.Serialize(xc), JSON.Serialize(yc)});

                    bgpp.AddRange(new string[]{"M", JSON.Serialize(leftgutter - 10 + x * 0.5), JSON.Serialize(height - bottomgutter),
                                               "L", JSON.Serialize(xc), JSON.Serialize(yc),
                                               "C", JSON.Serialize(xc), JSON.Serialize(yc)});
                }

                if (i > 0 && i < (labels.Count - 1))
                {
                    double Y0 = Math.Round(height - bottomgutter - y * data[i - 1]);
                    double X0 = Math.Round(leftgutter + x * (i - 0.5));
                    double Y2 = Math.Round(height - bottomgutter - y * data[i + 1]);
                    double X2 = Math.Round(leftgutter + x * (i + 1.5));
                    double[] a = this.GetAnchors(X0, Y0, xc, yc, X2, Y2);

                    p.AddRange(new string[] { JSON.Serialize(a[0]), JSON.Serialize(a[1]), JSON.Serialize(xc), JSON.Serialize(yc), JSON.Serialize(a[2]), JSON.Serialize(a[3]) });
                    bgpp.AddRange(new string[] { JSON.Serialize(a[0]), JSON.Serialize(a[1]), JSON.Serialize(xc), JSON.Serialize(yc), JSON.Serialize(a[2]), JSON.Serialize(a[3]) });
                }

                draw.Items.Add(new CircleSprite
                {
                    SpriteID = "dot_" + i,
                    CX = Convert.ToInt32(xc),
                    CY = Convert.ToInt32(yc),
                    Radius = 4,
                    FillStyle = "#333",
                    StrokeStyle = color,
                    LineWidth = 2
                });

                AbstractSprite rect = new RectSprite
                {
                    X = Convert.ToInt32(leftgutter + x * i),
                    Y = 0,
                    Width = Convert.ToInt32(xc),
                    Height = heightCraph,
                    StrokeStyle = "none",
                    FillStyle = "#fff",
                    GlobalAlpha = 0
                };

                //rect.Listeners.MouseOver.Handler = string.Format("onMouseOver(this, {0}, {1}, {2});", data[i], labels[i], i);
                //rect.Listeners.MouseOut.Handler = string.Format("onMouseOut(this, {0});", i);

                draw.Items.Add(rect);

                if (i == (labels.Count - 1))
                {
                    p.AddRange(new string[] { JSON.Serialize(xc), JSON.Serialize(yc), JSON.Serialize(xc), JSON.Serialize(yc) });
                    bgpp.AddRange(new string[] { JSON.Serialize(xc), JSON.Serialize(yc), JSON.Serialize(xc), JSON.Serialize(yc), "L", JSON.Serialize(xc), JSON.Serialize(height - bottomgutter), "z" });
                    pathSprite.Path = string.Join(" ", p);
                    bgpSprite.Path = string.Join(" ", bgpp);
                }
            }

            draw.Width = width;
            draw.Height = height;

            return draw;
        }

        private double[] GetAnchors(double p1x, double p1y, double p2x, double p2y, double p3x, double p3y)
        {
            double l1 = (p2x - p1x) / 2;
            double l2 = (p3x - p2x) / 2;
            double a = Math.Atan((p2x - p1x) / Math.Abs(p2y - p1y));
            double b = Math.Atan((p3x - p2x) / Math.Abs(p2y - p3y));

            a = p1y < p2y ? Math.PI - a : a;
            b = p3y < p2y ? Math.PI - b : b;

            double alpha = Math.PI / 2 - ((a + b) % (Math.PI * 2)) / 2;
            double dx1 = l1 * Math.Sin(alpha + a);
            double dy1 = l1 * Math.Cos(alpha + a);
            double dx2 = l2 * Math.Sin(alpha + b);
            double dy2 = l2 * Math.Cos(alpha + b);

            return new double[]{
                p2x - dx1,
                p2y + dy1,
                p2x + dx2,
                p2y + dy2
            };
        }

        private AbstractSprite GridPath(double x, double y, double w, double h, int wv, int hv, string color)
        {
            List<string> path = new List<string>{"M", JSON.Serialize(Math.Round(x) + 0.5), JSON.Serialize(Math.Round(y) + 0.5),
                                        "L", JSON.Serialize(Math.Round(x + w) + 0.5), JSON.Serialize(Math.Round(y) + 0.5),
                                         JSON.Serialize(Math.Round(x + w) + 0.5), JSON.Serialize(Math.Round(y + h) + 0.5),
                                         JSON.Serialize(Math.Round(x) + 0.5), JSON.Serialize(Math.Round(y + h) + 0.5),
                                         JSON.Serialize(Math.Round(x) + 0.5), JSON.Serialize(Math.Round(y) + 0.5)};

            double rowHeight = h / hv;
            double columnWidth = w / wv;

            for (int i = 1; i < hv; i++)
            {
                path.AddRange(new string[]{"M", JSON.Serialize(Math.Round(x) + 0.5), JSON.Serialize(Math.Round(y + i * rowHeight) + 0.5),
                                                        "H", JSON.Serialize(Math.Round(x + w) + 0.5)});
            }

            for (int i = 1; i < wv; i++)
            {
                path.AddRange(new string[]{"M", JSON.Serialize(Math.Round(x + i * columnWidth) + 0.5), JSON.Serialize(Math.Round(y) + 0.5),
                                                        "V", JSON.Serialize(Math.Round(y + h) + 0.5)});
            }

            return new PathSprite
            {
                StrokeStyle = color,
                Path = String.Join<string>(" ", path)
            };
        }

        private System.Drawing.Color ColorFromHSB(double h, double sl, double l)
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
