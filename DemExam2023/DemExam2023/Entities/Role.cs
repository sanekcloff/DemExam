using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExam2023.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<User> Users { get; set; }
    }
}
