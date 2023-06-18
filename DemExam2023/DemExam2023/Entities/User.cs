using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemExam2023.Entities
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {SurName}"; }
    }
}