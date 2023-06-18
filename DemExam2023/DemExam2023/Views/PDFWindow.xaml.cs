using DemExam2023.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemExam2023.Views
{
    /// <summary>
    /// Логика взаимодействия для PDFWindow.xaml
    /// </summary>
    public partial class PDFWindow : Window
    {
        public PDFWindow()
        {
            InitializeComponent();
        }
        public PDFWindow(Order order)
        {
            InitializeComponent();
            IdTextBlock.Text = $"Номер заказа: {order.Id}";
            DateTextBlock.Text = $"Дата заказа: {order.Date.Date.ToString("d")}";
            CodeTextBlock.Text = $"{order.Code}";
            PointTextBlock.Text = $"Пункт выдачи: {order.Point.Address}";
            UserTextBlock.Text = $"Покупатель: {order.User.FullName}";
            PaymentAmountTextBlock.Text = $"Стоимость: {PaymentAmount(order.Products)}";
            ProductsList.ItemsSource = order.Products;
        }
        private decimal PaymentAmount(ICollection<Product> products)
        {
            decimal summ = 0;
            foreach (var product in products)
            {
                summ += product.CorrectCost;
            }
            return summ;
        }
    }
}
