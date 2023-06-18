using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExam2023.Entities
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Code { get; set; } = null!;
        public bool IsNew { get; set; }

        public int PointId { get; set; }
        public int UserId { get; set; }

        public Point Point { get; set; } = null!;
        public User User { get; set; } = null!;

        public ICollection<Product> Products { get; set; }

        [NotMapped]
        public string? Status { get => IsNew ? "Новый" : null; }
    }
}
