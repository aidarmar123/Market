﻿using System;
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
    /// Логика взаимодействия для HistroySkanPage.xaml
    /// </summary>
    public partial class HistroySkanPage : Page
    {
        public HistroySkanPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            DGHistory.ItemsSource = App.DB.HistorySkan
                .OrderBy(x=>x.DateTime)
                .ToList();
        }
    }
}
