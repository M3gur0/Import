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

        public void Parse(string filePath)
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

            dataTable.Columns.Add(new DataColumn("Name"));
            dataTable.Columns.Add(new DataColumn("Application"));
            dataTable.Columns.Add(new DataColumn("Network"));
            dataTable.Columns.Add(new DataColumn("Comment"));
            dataTable.Columns.Add(new DataColumn("Status"));
            dataTable.Columns.Add(new DataColumn("Year"));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlBulkCopy = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "Tmp_SQLBulkCopy"
                };

                sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                sqlBulkCopy.ColumnMappings.Add("Application", "Application");
                sqlBulkCopy.ColumnMappings.Add("Network", "Network");
                sqlBulkCopy.ColumnMappings.Add("Comment", "Comment");
                sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                sqlBulkCopy.ColumnMappings.Add("Year", "Year");

                while (!end)
                {
                    var batch = cc.Read<ExcelVarietyStatus>(filePath, inputFileDescription).Skip(page * batchSize).Take(batchSize).ToList();
                    if (batch.Any())
                    {
                        batch.ForEach(item =>
                        {
                            dataTable.Rows.Add(new Object[] { item.Name, item.Application, item.Network, item.Comment, item.Status, item.Year });
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
