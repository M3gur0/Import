using EF.BulkOptimizations.Business.Entities;
using EF.BulkOptimizations.Business.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.BulkOptimizations.CAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new VarietyServices();

            var all = services.GetAll();
            all.ToString();

            Stopwatch sw = Stopwatch.StartNew();
            services.Parse(@"d:\temp\datasource.csv");
            Console.WriteLine(sw.Elapsed);

            Console.ReadLine();
        }
    }
}
