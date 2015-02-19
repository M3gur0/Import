using Import.Business.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Import.Business
{
    public static class ImportTaskServices
    {
        private static bool running = false;

        private static ConcurrentQueue<ImportTask> Tasks { get; set; }

        public static int Count { get { return ImportTaskServices.Tasks.Count(); } }

        static ImportTaskServices()
        {
            ImportTaskServices.Tasks = new ConcurrentQueue<ImportTask>();
        }

        public static void Add(ImportTask task)
        {
            ImportTaskServices.Tasks.Enqueue(task);
        }

        public static void Process()
        {
            if (!running)
            {
                Task.Run(() =>
                {
                    while (ImportTaskServices.Tasks.Count() > 0)
                    {
                        running = true;
                        ImportTask task = null;
                        if (ImportTaskServices.Tasks.TryDequeue(out task))
                        {
                            task.CurrentStatus = Status.Starting;
                            Thread.Sleep(10000);
                            task.CurrentStatus = Status.Success;
                        }
                    }
                }).ContinueWith((t) => running = false);
            }

            return;
        }

        public static IEnumerable<ImportTask> Get(params Status[] status)
        {
            return ImportTaskServices.Tasks
                .Where(t => status.Any(s => s == t.CurrentStatus))
                .ToList();
        }
    }
}
