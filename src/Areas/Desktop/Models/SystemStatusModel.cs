using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Ext.Net.MVC.Examples.Areas.Desktop.Models
{
    public static class SystemStatusModel
    {
        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        private static int Pass
        {
            get
            {
                object obj = Session["pass"];
                return obj != null ? (int)obj : 99;
            }
            set
            {
                Session["pass"] = value;
            }
        }

        private static double LastCore1
        {
            get
            {
                object obj = Session["core1"];
                return obj != null ? (double)obj : 0d;
            }
            set
            {
                Session["core1"] = value;
            }
        }

        private static double LastCore2
        {
            get
            {
                object obj = Session["core2"];
                return obj != null ? (double)obj : 0d;
            }
            set
            {
                Session["core2"] = value;
            }
        }

        public static void UpdateCharts(SystemStatusData data)
        {
            if (data.Init)
            {
                SystemStatusModel.Init();
            }

            int pass = SystemStatusModel.Pass;

            var store = data.Memory;
            if (pass % 3 == 0 || data.Init)
            {
                data.MemoryData = SystemStatusModel.GenerateData(new string[] { "Wired", "Active", "Inactive", "Free" });
                if (store != null)
                {
                    if (data.Init)
                    {
                        store.Data = data.MemoryData;
                    }
                    else
                    {
                        store.LoadData(data.MemoryData);
                    }
                }
            }

            store = data.Process;
            if (pass % 2 == 0 || data.Init)
            {
                data.ProcessData = SystemStatusModel.GenerateData(new string[] { "Explorer", "Monitor", "Charts", "Desktop", "Ext3", "Ext4" });
                if (store != null)
                {
                    if (data.Init)
                    {
                        store.Data = data.ProcessData;
                    }
                    else
                    {
                        store.LoadData(data.ProcessData);
                    }
                }
            }

            SystemStatusModel.GenerateCPULoad(data);
            SystemStatusModel.Pass++;
        }

        private static void Init()
        {
            SystemStatusModel.LastCore1 = 0;
            SystemStatusModel.LastCore2 = 0;
            SystemStatusModel.Pass = 99;
        }

        private static double GenerateCPUValue(double factor, Random random)
        {
            double value = factor + ((Math.Floor(random.NextDouble() * 2) % 2) > 0 ? -1 : 1) * Math.Floor(random.NextDouble() * 9);

            if (value < 0 || value > 100)
            {
                value = 50;
            }

            return value;
        }

        private static List<object> GenerateData(string[] names)
        {
            List<object> data = new List<object>();
            double rest = names.Length;
            Random random = new Random();

            for (int i = 0; i < names.Length; i++)
            {
                double consume = Math.Floor(random.NextDouble() * rest * 100) / 100 + 2;
                rest = rest - (consume - 5);
                data.Add(new
                {
                    Name = names[i],
                    Memory = consume
                });
            }

            return data;
        }

        private static void GenerateCPULoad(SystemStatusData data)
        {
            double core1 = SystemStatusModel.LastCore1;
            double core2 = SystemStatusModel.LastCore2;
            int pass = 99;
            Random random = new Random();

            if (!data.Init)
            {
                data.CPULoad.RemoveAt(0);

                data.CPULoad.Each(new JFunction
                {
                    Args = new string[] { "item", "key" },
                    Handler = "item.data.Time = key;" // update time
                });

                core1 = SystemStatusModel.GenerateCPUValue(core1, random);
                core2 = SystemStatusModel.GenerateCPUValue(core2, random);

                data.CPULoad.LoadData(new[] { new { Core1 = core1, Core2 = core2, Time = pass } }, true);
            }
            else
            {
                List<object> d = new List<object>();
                d.Add(new { Core1 = 0, Core2 = 0, Time = 0 });

                for (int i = 1; i < 100; i++)
                {
                    core1 = SystemStatusModel.GenerateCPUValue(core1, random);
                    core2 = SystemStatusModel.GenerateCPUValue(core2, random);

                    d.Add(new
                    {
                        Core1 = core1,
                        Core2 = core2,
                        Time = i
                    });
                }

                data.CPULoadData = d;
                if (data.CPULoad != null)
                {
                    data.CPULoad.Data = d;
                }
                SystemStatusModel.Pass = 99;
            }

            SystemStatusModel.LastCore1 = core1;
            SystemStatusModel.LastCore2 = core2;
        }
    }

    public class SystemStatusData
    {
        public SystemStatusData(bool init)
        {
            this.Init = init;
        }

        public SystemStatusData(bool init, Store cpuLoad, Store memory, Store process)
        {
            this.Init = init;
            this.CPULoad = cpuLoad;
            this.Memory = memory;
            this.Process = process;
        }

        public bool Init
        {
            get;
            private set;
        }

        public Store CPULoad
        {
            get;
            private set;
        }

        public List<object> CPULoadData
        {
            get;
            set;
        }

        public Store Memory
        {
            get;
            private set;
        }

        public List<object> MemoryData
        {
            get;
            set;
        }

        public Store Process
        {
            get;
            private set;
        }

        public List<object> ProcessData
        {
            get;
            set;
        }
    }
}