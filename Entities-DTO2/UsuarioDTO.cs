using Entities.DTO2;

namespace Entities.DTO
{
    public class UsuarioDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthday { get; set; }
    }
}
