namespace EF.BulkOptimizations.Business.Domain
{
    using System;
    using System.IO;

    public class ImportTest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string OriginalFileName { get; set; }

        public FileInfo File { get; set; }

        public DateTime Received { get; set; }

        public ImportTestStatus CurrentStatus { get; set; }

        public ImportTest()
        {
            this.Id = Guid.NewGuid();
            this.Received = DateTime.Now;
            this.CurrentStatus = ImportTestStatus.Waiting;
        }
    }
}
