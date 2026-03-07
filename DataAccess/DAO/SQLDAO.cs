using Microsoft.Data.SqlClient;

using System.Collections.Generic;

using System.Data;
using System.Runtime.InteropServices.JavaScript;



namespace DataAccess.DAO

{

    public class SQLDAO

    {

        private static SQLDAO _instance;

        private readonly string _connectionString;



        private SQLDAO()

        {

            _connectionString = @"Data Source=JARED\SQLEXPRESS;Initial Catalog=2026C1-ecommerce;Integrated Security=True;Trust Server Certificate=True";

        }



        public static SQLDAO GetInstance()

        {

            if (_instance == null)

                _instance = new SQLDAO();



            return _instance;

        }



        public void ExecuteProcedure(SQLOPERATION operation)

        {

            using SqlConnection conn = new SqlConnection(_connectionString);

            using SqlCommand cmd = new SqlCommand(operation.ProcedureName, conn);



            cmd.CommandType = CommandType.StoredProcedure;



            foreach (var param in operation.Parameters)

            {

                cmd.Parameters.Add(param);

            }



            conn.Open();

            cmd.ExecuteNonQuery();

        }



        public List<Dictionary<string, object>> ExecuteQueryProcedure(SQLOPERATION operation)

        {

            var results = new List<Dictionary<string, object>>();



            using SqlConnection conn = new SqlConnection(_connectionString);

            using SqlCommand cmd = new SqlCommand(operation.ProcedureName, conn);



            cmd.CommandType = CommandType.StoredProcedure;



            foreach (var param in operation.Parameters)

            {

                cmd.Parameters.Add(param);

            }



            conn.Open();



            using SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())

            {

                var row = new Dictionary<string, object>();



                for (int i = 0; i < reader.FieldCount; i++)

                {

                    string columnName = reader.GetName(i);

                    object value = reader.IsDBNull(i) ? null : reader.GetValue(i);



                    row[columnName] = value;

                }



                results.Add(row);

            }



            return results;

        }

    }

}

