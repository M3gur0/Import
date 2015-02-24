namespace EF.BulkOptimizations.Business.Domain
{
    using System;
    using System.IO;

    public class ImportTest
    {
        public Guid Id { get; set; }

        public int SpeciesId { get; set; }

        public int YearId { get; set; }

        public int CampaignId { get; set; }

        public DateTime PublicationDate { get; set; }

        public int SourceId { get; set; }

        public int VariableId { get; set; }

        public int UnitId { get; set; }

        public string Comment { get; set; }

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
