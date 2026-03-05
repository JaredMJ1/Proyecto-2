using DataAccess.CRUD;
using Entities.DTO;

namespace Core.Managers
{
    public class UserManager : BaseManager
    {
        public void Create(UsuarioDTO u)
        {
            try
            {
                if (string.IsNullOrEmpty(u.Name))
                    throw new Exception("El nombre es requerido.");

                if (string.IsNullOrEmpty(u.Email))
                    throw new Exception("El email es requerido.");

                if (!IsOver18(u))
                    throw new Exception("El usuario debe ser mayor de 18 años.");

                var crud = new UserCrudFactory();
                crud.Create(u);

                var emailManager = new EmailManager();
                emailManager.SendWelcomeEmail(u);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Update(UsuarioDTO u)
        {
            try
            {
                if (!IsOver18(u))
                    throw new Exception("El usuario debe ser mayor de 18 años.");

                var crud = new UserCrudFactory();
                crud.Update(u);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var crud = new UserCrudFactory();
                crud.Delete(id);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<UsuarioDTO> RetrieveAll()
        {
            var list = new List<UsuarioDTO>();

            try
            {
                var crud = new UserCrudFactory();
                list = crud.RetrieveAll<UsuarioDTO>();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

            return list;
        }

        public UsuarioDTO RetrieveById(int id)
        {
            var user = new UsuarioDTO();

            try
            {
                var crud = new UserCrudFactory();
                user = crud.RetrieveById<UsuarioDTO>(id);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

            return user;
        }

        private bool IsOver18(UsuarioDTO u)
        {
            var age = DateTime.Now.Year - u.Birthday.Year;

            if (u.Birthday.Date > DateTime.Now.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}