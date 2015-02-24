namespace EF.BulkOptimizations.Business.Domain
{
    using LINQtoCSV;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ExcelVarietyDetail
    {
        public Guid ImportTaskId { get; set; }

        public string Geographic_Area_Code { get; set; }

        public string Variety_Name { get; set; }

        public string Local_Seller { get; set; }

        public string Value { get; set; }
    }
}
