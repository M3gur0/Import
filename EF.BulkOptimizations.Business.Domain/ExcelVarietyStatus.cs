namespace EF.BulkOptimizations.Business.Domain
{
    using LINQtoCSV;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ExcelVarietyStatus
    {
        public string Name { get; set; }

        public string Application { get; set; }

        public string Network { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }

        public int? Year { get; set; }
    }
}
