using EF.BulkOptimizations.Business.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.BulkOptimizations.Business.Services
{
    public class ImportServices
    {
        private static bool running = false;

        private static ConcurrentQueue<ImportTest> Tasks { get; set; }

        public static int Count { get { return ImportServices.Tasks.Count(); } }

        static ImportServices()
        {
            ImportServices.Tasks = new ConcurrentQueue<ImportTest>();
        }

        public static void Add(ImportTest task)
        {
            ImportServices.Tasks.Enqueue(task);
        }

        public static void Process()
        {
            if (!running)
            {
                Task.Run(() =>
                {
                    while (ImportServices.Tasks.Count() > 0)
                    {
                        running = true;
                        ImportTest task = null;
                        if (ImportServices.Tasks.TryDequeue(out task))
                        {
                            task.CurrentStatus = ImportTestStatus.Starting;
                            new VarietyServices().Parse(task.File.FullName);
                            task.CurrentStatus = ImportTestStatus.Success;
                        }
                    }
                }).ContinueWith((t) => running = false);
            }

            return;
        }

        public static IEnumerable<ImportTest> Get(params ImportTestStatus[] status)
        {
            return ImportServices.Tasks
                .Where(t => status.Any(s => s == t.CurrentStatus))
                .ToList();
        }
    }
}
