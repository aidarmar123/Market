using MarketWPF.Models;
using MarketWPF.Models.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MarketWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MarketEntities DB = new MarketEntities();
        App()
        {
            RegistAllDescriptor();
        }

        private void RegistAllDescriptor()
        {
            RegistDescriptor<Product, MetaProduct>();
        }

        private void RegistDescriptor<T1, T2>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T1), typeof(T2));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T1));
        }
    }
}
