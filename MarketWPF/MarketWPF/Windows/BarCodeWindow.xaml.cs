﻿
using IronBarCode;
using MarketWPF.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для BarCodeWindow.xaml
    /// </summary>
    public partial class BarCodeWindow : Window
    {
        public byte[] Image { get; set; }
        public BarCodeWindow(Product product)
        {
            InitializeComponent();
            CreateBarCode(product);
           
        }

        private void CreateBarCode(Product product)
        {
            var barCode = BarcodeWriter.CreateBarcode(product.Id.ToString(), BarcodeWriterEncoding.Code128);
            barCode.ResizeTo(400, 100);

            Image = barCode.ToBitmap().GetBytes();
            DataContext = null;
            DataContext = this;

        }
    }
}
