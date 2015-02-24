using EF.BulkOptimizations.Business.Domain;
using EF.BulkOptimizations.Business.Entities;
using EF.BulkOptimizations.Data;
using LINQtoCSV;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.BulkOptimizations.Business.Services
{
    public class VarietyServices
    {
        private ExcelToSqlDataContext context { get; set; }

        public VarietyServices()
        {
            this.context = new ExcelToSqlDataContext();
        }

        public IEnumerable<Variety> GetAll()
        {
            return this.context.Set<Variety>().ToList();
        }

        public void Add(Variety item)
        {
            this.context.Insert(item);
            this.context.Save();
        }

        public void Parse(string filePath, Guid importTaskId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ExcelToSql"].ConnectionString;
            int batchSize = 1000000;
            int page = 0;
            bool end = false;

            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true
            };

            CsvContext cc = new CsvContext();

            var dataTable = new DataTable("Tmp_SQLBulkCopy");

            dataTable.Columns.Add(new DataColumn("ImportTaskId"));
            dataTable.Columns.Add(new DataColumn("Geographic_Area_Code"));
            dataTable.Columns.Add(new DataColumn("Variety_Name"));
            dataTable.Columns.Add(new DataColumn("Local_Seller"));
            dataTable.Columns.Add(new DataColumn("Value"));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlBulkCopy = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "Tmp_SQLBulkCopy"
                };

                sqlBulkCopy.ColumnMappings.Add("ImportTaskId", "ImportTaskId");
                sqlBulkCopy.ColumnMappings.Add("Geographic_Area_Code", "Geographic_Area_Code");
                sqlBulkCopy.ColumnMappings.Add("Variety_Name", "Variety_Name");
                sqlBulkCopy.ColumnMappings.Add("Local_Seller", "Local_Seller");
                sqlBulkCopy.ColumnMappings.Add("Value", "Value");

                while (!end)
                {
                    var batch = cc.Read<ExcelVarietyDetail>(filePath, inputFileDescription)
                        .Skip(page * batchSize)
                        .Take(batchSize)
                        .ToList();

                    if (batch.Any())
                    {
                        batch.ForEach(item =>
                        {
                            dataTable.Rows.Add(new Object[] { importTaskId, item.Geographic_Area_Code, item.Variety_Name, item.Local_Seller, item.Value });
                        });

                        sqlBulkCopy.WriteToServer(dataTable);

                        dataTable.Rows.Clear();
                    }
                    else
                    {
                        end = true;
                    }

                    page++;
                }
            }
        }
    }
}
