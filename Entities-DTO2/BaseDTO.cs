using System;

namespace Entities.DTO2
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
