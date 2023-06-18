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
    /// Логика взаимодействия для ProductMangerWindow.xaml
    /// </summary>
    public partial class ProductMangerWindow : Window
    {
        private ProductManagerViewModel _viewModel;
        public ProductMangerWindow()
        {
            InitializeComponent();
        }
        public ProductMangerWindow(Product? product, ApplicationDbContext context)
        {
            InitializeComponent();
            DataContext = _viewModel = new ProductManagerViewModel(product, context);

        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
