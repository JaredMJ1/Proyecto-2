using Entities.DTO;

namespace Core.Managers
{
    public class EmailManager : BaseManager
    {
        public void SendWelcomeEmail(UsuarioDTO u)
        {
            try
            {
               
                Console.WriteLine("=================================");
                Console.WriteLine("Enviando correo a: " + u.Email);
                Console.WriteLine("Hola " + u.Name + ", bienvenido al sistema.");
                Console.WriteLine("=================================");
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
    }
}