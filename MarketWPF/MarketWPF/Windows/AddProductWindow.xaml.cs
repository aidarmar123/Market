using MarketWPF.Models;
using MarketWPF.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MarketWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        Product contextProduct;
        List<ImageProduct> imageProducts = new List<ImageProduct>();
        public AddProductWindow(Product product )
        {
            InitializeComponent();
            contextProduct = product;
            DataContext = contextProduct;
        }

        private void BAddIamge_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter=".png, .jpg, .jpeg | *.png; *.jpg; *.jpeg", Multiselect= true};
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                foreach(var file in dialog.FileNames)
                {
                    imageProducts.Add(new ImageProduct
                    {
                        Image = File.ReadAllBytes(file)
                    });
                }
                contextProduct.ImageProduct = imageProducts;
                DataContext = null;
                DataContext = contextProduct;
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var error = ValidationLine.ValidationProduct(contextProduct);
            if (error.Length == 0)
            {
                if (contextProduct.Id == 0)
                {
                    App.DB.Product.Add(contextProduct);
                }
                foreach (var image in imageProducts)
                {
                    if(image.Id== 0)
                    {
                        image.ProductId = contextProduct.Id;
                        App.DB.ImageProduct.Add(image);
                    }  
                }
                App.DB.SaveChanges();
                this.DialogResult = false;
            }
            else
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
