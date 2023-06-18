using DemExam2023.Data;
using DemExam2023.Entities;
using DemExam2023.ViewModels;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(User user, ApplicationDbContext ctx)
        {
            InitializeComponent();
            DataContext = _viewModel = new MainViewModel(user, ctx); 

            if (user.RoleId==1)
            {
                ManagerContextMenu.IsEnabled = true;
                ManagerContextMenu.Visibility = Visibility.Visible;
            }

            Title = $"{user.Role.Name} : {user.FullName}";
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddProductToOrder();
        }

        private void OrderShowButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenOrderWindow();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddProduct();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.EditProduct();
        }

        private void BuyProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BuyProducts();
        }

        private void GetPDFButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetPDF();
        }
    }
}
