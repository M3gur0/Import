using System;
using System.IO;
namespace Import.Business.Entities
{
    public class ImportTask
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Type { get; set; }

        public string OriginalFileName { get; set; }

        public FileInfo File { get; set; }

        public DateTime Received { get; set; }

        public Status CurrentStatus { get; set; }

        public ImportTask()
        {
            this.Id = Guid.NewGuid();
            this.Received = DateTime.Now;
            this.CurrentStatus = Status.Waiting;
        }
    }
}
