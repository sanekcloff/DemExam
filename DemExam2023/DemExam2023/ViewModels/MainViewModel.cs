using DemExam2023.Data;
using DemExam2023.Entities;
using DemExam2023.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemExam2023.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(User user, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _user = user;

            Products = new List<Product>(GetProducts());
            Order = new Order
            {
                User = user,
                IsNew = true,
                Date = DateTime.Now,
                Code = GenerateCode()
            };
            ProductsInOrder = new();
            Points = new List<string> { "Не выбран" };
            Points.AddRange(ctx.Points.Select(p => p.Address).ToList());
            SelectedPoint = Points[0];
        }

        private ApplicationDbContext _ctx;
        private User _user;

        private Product _selectedProduct;
        private List<Product> _products;

        private Order _order;
        private List<Product> _productsInOrder;
        private string _selectedPoint;
        

        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value, nameof(SelectedProduct)); }
        public List<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public Order Order { get => _order; set => Set(ref _order, value, nameof(Order)); }
        public List<Product> ProductsInOrder { get => _productsInOrder; set => Set(ref _productsInOrder, value, nameof(ProductsInOrder)); }
        public List<string> Points { get; set; }
        public string SelectedPoint { get => _selectedPoint; set => Set(ref _selectedPoint, value, nameof(SelectedPoint)); }

        private ICollection<Product> GetProducts() => _ctx.Products.ToList();
        private bool IsSelectedProductNull() => SelectedProduct == null;
        private bool IsOrderEmpty() => ProductsInOrder.Count == 0;
        private bool IsOrderExist() => _ctx.Orders.Any(o => o.Equals(Order));
        private string GenerateCode()
        {
            string code = string.Empty;
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                code += rnd.Next(0, 10);
            }
            return code;
        }

        public void AddProductToOrder()
        {
            if (IsSelectedProductNull())
                MessageBox.Show("Выберите продукт!");
            else
            {
                ProductsInOrder.Add(SelectedProduct);
                MessageBox.Show("Продукт добавлен к заказу");
            } 
        }
        public void OpenOrderWindow()
        {
            if (IsOrderEmpty())
                MessageBox.Show("Заказ пуст!");
            else
                new OrderWindow(ProductsInOrder).ShowDialog();
        }
        public void BuyProducts()
        {
            if (IsOrderEmpty())
                MessageBox.Show("Заказ пуст!");
            else if (SelectedPoint == Points[0])
                MessageBox.Show("Выберите пункт выдачи!");
            else
            {
                Order.Products = ProductsInOrder;
                Order.Point = _ctx.Points.Single(p => p.Address == SelectedPoint);
                _ctx.Orders.Add(Order);
                _ctx.SaveChanges();
                MessageBox.Show("Заказ сформирован");
            }
        }
        public void GetPDF()
        {
            if (!IsOrderExist())
                MessageBox.Show("Заказ не оформлен!");
            else
                new PDFWindow(Order).ShowDialog();
        }
        public void AddProduct()
        {

        }
        public void EditProduct()
        {

        }
        
    }
}
