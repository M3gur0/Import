using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Business.Entities
{
    public enum Status
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
