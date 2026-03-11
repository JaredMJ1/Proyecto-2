using System.Collections.Generic;
using DataAccess.DAO;
using Entities.DTO;

namespace DataAccess.CRUD
{
    public class ProductCrudFactory : CrudFactory
    {
        public override void Create(object dto)
        {
            var product = (ProductDTO)dto;

            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_InsertProduct"
            };

            op.AddStringParam("@Name", product.Name);
            op.AddStringParam("@Description", product.Description);
            op.AddStringParam("@Category", product.Category);
            op.AddIntParam("@Quantity", product.Quantity);
            op.AddDecimalParam("@Price", product.Price);

            dao.ExecuteProcedure(op);
        }

        public override void Update(object dto)
        {
            var product = (ProductDTO)dto;

            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_UpdateProduct"
            };

            op.AddIntParam("@Id", product.Id);
            op.AddStringParam("@Name", product.Name);
            op.AddStringParam("@Description", product.Description);
            op.AddStringParam("@Category", product.Category);
            op.AddIntParam("@Quantity", product.Quantity);
            op.AddDecimalParam("@Price", product.Price);

            dao.ExecuteProcedure(op);
        }

        public override void Delete(int id)
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_DeleteProduct"
            };

            op.AddIntParam("@ProductId", id);

            dao.ExecuteProcedure(op);
        }

        public override List<T> RetrieveAll<T>()
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_GetAllProducts"
            };

            var results = dao.ExecuteQueryProcedure(op);
            var list = new List<T>();

            foreach (var row in results)
            {
                var product = BuildProduct(row);
                list.Add((T)(object)product);
            }

            return list;
        }

        public override T RetrieveById<T>(int id)
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_GetProductById"
            };

            op.AddIntParam("@Id", id);

            var results = dao.ExecuteQueryProcedure(op);

            if (results.Count == 0)
                return default(T);

            var product = BuildProduct(results[0]);

            return (T)(object)product;
        }

        private ProductDTO BuildProduct(Dictionary<string, object> row)
        {
            return new ProductDTO
            {
                Id = row["Id"] != null ? (int)row["Id"] : 0,
                Name = row["Name"]?.ToString(),
                Description = row["Description"]?.ToString(),
                Category = row["Category"]?.ToString(),
                Quantity = row["Quantity"] != null ? (int)row["Quantity"] : 0,
                Price = row["Price"] != null ? (decimal)row["Price"] : 0,
                Status = row["Status"]?.ToString()
            };
        }
    }
}