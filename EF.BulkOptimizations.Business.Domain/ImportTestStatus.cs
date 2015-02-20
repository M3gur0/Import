using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.BulkOptimizations.Business.Domain
{
    public enum ImportTestStatus
    {
        Waiting,
        Starting,
        Controlling,
        Inserting,
        Finishing,
        Success,
        Error
    }
}
