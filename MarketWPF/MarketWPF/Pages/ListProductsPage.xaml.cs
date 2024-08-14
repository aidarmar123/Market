using MarketWPF.Models;
using MarketWPF.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListProductsPage.xaml
    /// </summary>
    public partial class ListProductsPage : Page
    {
        public ListProductsPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            LVProduct.ItemsSource = App.DB.Product.ToList();
        }

        private void BAddProduct_Click(object sender, RoutedEventArgs e)
        {
            new AddProductWindow(new Product()).ShowDialog();
            Refresh();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LVProduct.SelectedItem is Product product)
            {
                App.DB.Product.Remove(product);
                App.DB.SaveChanges();
                Refresh();
                BEdit.IsEnabled = false;
            }
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if(LVProduct.SelectedItem is Product product)
            {
                new AddProductWindow (product).ShowDialog();
                Refresh();
                BEdit.IsEnabled = false;
            }
        }

        private void LVProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDelete.IsEnabled = true;
            BEdit.IsEnabled = true;
        }
    }
}
