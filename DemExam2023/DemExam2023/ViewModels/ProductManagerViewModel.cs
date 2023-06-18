using DemExam2023.Data;
using DemExam2023.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemExam2023.ViewModels
{
    public class ProductManagerViewModel : ViewModelBase
    {
        public ProductManagerViewModel(Product? product, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            if (product == null)
            {

            }
        }
        private Product? _product;
        private ApplicationDbContext _ctx;

        private string _title;
        private string _description;
        private string _manufacturer;
        private string _picture;
        private decimal _cost;
        private int _countInStock;
        private int _discount;

        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        public string Description { get => _description; set => Set(ref _description, value, nameof(Description)); }
        public string Manufacturer { get => _manufacturer; set => Set(ref _manufacturer, value, nameof(Manufacturer)); }
        public string Picture { get => _picture; set => Set(ref _picture, value, nameof(Picture)); }
        public decimal Cost { get => _cost; set => Set(ref _cost, value, nameof(Cost)); }
        public int CountInStock { get => _countInStock; set => Set(ref _countInStock, value, nameof(CountInStock)); }
        public int Discount { get => _discount; set => Set(ref _discount, value, nameof(Discount)); }

        private bool isNullFields() => string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Manufacturer);

        public void AddProduct()
        {
            if (isNullFields())
                MessageBox.Show("Поля должны быть заполнены!");
        }
    }
}
