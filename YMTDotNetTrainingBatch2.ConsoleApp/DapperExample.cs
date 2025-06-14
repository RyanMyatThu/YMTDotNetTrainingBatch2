using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    internal class DapperExample
    {
        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            UserID = "sa",
            InitialCatalog = "DotNetTrainingBatch2",
            TrustServerCertificate = true,
            Password = "sasa@123"

        };
        void Read()
        {
            using (IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString))
            {

            }
            ;
        }
        void Edit()
        {

        }
        void Update()
        {

        }
        void Create()
        {

        }
        void Delete()
        {

        }
    }
}
