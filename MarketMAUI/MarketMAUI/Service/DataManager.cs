using MarketMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Service
{
    public static class DataManager
    {
        public static List<HistorySkan> historySkans;
        public static List<ImageProduct> imageProducts;
        public static List<Product> products;
        public static List<Role> roles;
        public static List<User> users;

        public static async Task Init()
        {
            historySkans = await NetManager.Get<List<HistorySkan>>("api/HistorySkans");
            imageProducts = await NetManager.Get<List<ImageProduct>>("api/ImageProducts");
            products = await NetManager.Get<List<Product>>("api/Products");
            roles = await NetManager.Get<List<Role>>("api/Roles");
            users = await NetManager.Get<List<User>>("api/Users");
        }
    }
}
