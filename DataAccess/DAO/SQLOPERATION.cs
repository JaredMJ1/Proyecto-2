using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.DAO
{
    public class SQLOPERATION
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SQLOPERATION()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddStringParam(string paramName, string paramValue)
        {
            var param = new SqlParameter(paramName, SqlDbType.NVarChar); // Usa NVarChar para coincidir con SQL
            param.Value = (object)paramValue ?? DBNull.Value;
            Parameters.Add(param);
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, SqlDbType.Int)
            {
                Value = paramValue
            });
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            });
        }

        public void AddDoubleParam(string paramName, double paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, SqlDbType.Float)
            {
                Value = paramValue
            });
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, SqlDbType.DateTime)
            {
                Value = paramValue
            });
        }
    }
}