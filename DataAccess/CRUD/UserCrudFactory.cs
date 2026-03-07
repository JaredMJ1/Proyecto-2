using DataAccess.DAO;
using Entities.DTO;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public override void Create(object dto)
        {
            var user = (UsuarioDTO)dto;

            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_InsertUsuario"
            };

            
            op.AddStringParam("@P_NAME", user.Name);
            op.AddStringParam("@P_LAST_NAME", user.Lastname);
            op.AddStringParam("@P_EMAIL", user.Email);
            op.AddStringParam("@P_PHONE", user.Phone);
            op.AddStringParam("@P_PASSWORD", user.PasswordHash);
            op.AddDateTimeParam("@P_BIRTH_DATE", user.Birthday);

            dao.ExecuteProcedure(op);
        }

        public override void Update(object dto)
        {
            var user = (UsuarioDTO)dto;

            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_UpdateUsuario"
            };

            op.AddIntParam("@Id", user.Id);
            op.AddStringParam("@Status", user.Status);
            op.AddStringParam("@Name", user.Name);
            op.AddStringParam("@LastName", user.Lastname);
            op.AddStringParam("@Email", user.Email);
            op.AddStringParam("@Phone", user.Phone);
            op.AddStringParam("@Password", user.PasswordHash);
            op.AddDateTimeParam("@BirthDate", user.Birthday);

            dao.ExecuteProcedure(op);
        }

        public override void Delete(int id)
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_DeleteUsuario"
            };

            op.AddIntParam("@Id", id);

            dao.ExecuteProcedure(op);
        }

        public override List<T> RetrieveAll<T>()
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_GetAllUsers"
            };

            var lstResults = dao.ExecuteQueryProcedure(op);
            var list = new List<T>();

            foreach (var item in lstResults)
            {
                var user = BuildUser(item);
                list.Add((T)(object)user);
            }

            return list;
        }

        public override T RetrieveById<T>(int id)
        {
            var op = new SQLOPERATION
            {
                ProcedureName = "dbo.usp_GetUserById"
            };

            op.AddIntParam("@P_ID", id);

            var lstResults = dao.ExecuteQueryProcedure(op);

            if (lstResults.Count == 0)
                return default(T);

            var user = BuildUser(lstResults[0]);

            return (T)(object)user;
        }

        private UsuarioDTO BuildUser(Dictionary<string, object> row)
        {
            return new UsuarioDTO
            {
                Id = row["Id"] != null ? (int)row["Id"] : 0,
                Name = row["Name"]?.ToString(),
                Lastname = row["LastName"]?.ToString(),
                Email = row["Email"]?.ToString(),
                Phone = row["Phone"]?.ToString(),
                PasswordHash = row["Password"]?.ToString(),
                Birthday = row["BirthDate"] != null
                           ? (DateTime)row["BirthDate"]
                           : DateTime.MinValue,
                Status = row.ContainsKey("Status") ? row["Status"]?.ToString() : null
            };
        }
    }
}
