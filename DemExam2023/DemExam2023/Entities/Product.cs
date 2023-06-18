using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExam2023.Entities
{
    public class Product
    {
        public Product()
        {
            Orders= new List<Order>();
        }

        public int Id { get; set; }

        public string? Picture { get; set; } = null;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }= null!;
        public string Manufacturer { get; set; }= null!;
        public decimal Cost { get; set; }
        public int CountInStock { get; set; }
        public int Discount { get; set; }

        public ICollection<Order> Orders { get; set; }

        [NotMapped]
        public string PicturePath { get => Picture==null || Picture==string.Empty ? @"\Pictures\non-image.png" : @$"\Pictures\{Picture}"; }
        public bool IsDiscount { get => Discount!=0; }
        public decimal CorrectCost { get => Cost - (Cost * ((decimal)Discount / 100)); }
    }
}
