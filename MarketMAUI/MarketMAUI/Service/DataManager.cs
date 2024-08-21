  
using MarketMAUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Service
{
    public static class DataManager
    {
        public static string userCashePath
        {
            get
            {
                return Path.Combine(FileSystem.Current.AppDataDirectory, "casheUser.json");
            }
        }
        private static User contextUser;

        public static User ContextUser
        {
            get
            {
                if (contextUser == null)
                {
                    contextUser = GetData<User>(userCashePath);
                }
                return contextUser;
            }
            set
            {
                contextUser = value;
                SetData(userCashePath, contextUser);
            }
        }

        private static void SetData(string userCashePath, User contextUser)
        {
            var jsonData = JsonConvert.SerializeObject(contextUser);
            File.WriteAllText(userCashePath, jsonData);
        }

        private static T GetData<T>(string userCashePath)
        {
            var data = JsonConvert.DeserializeObject<T>(File.ReadAllText(userCashePath));
            return data;
        }




        public static List<HistorySkan> historySkans;
        public static List<ImageProduct> imageProducts;
        public static List<Product> products;
        public static List<Role> roles;
        public static List<User> users;

        public static async Task Init()
        {
            historySkans = await NetManager.Get<List<HistorySkan>>("api/HistorySkans");

            products = await NetManager.Get<List<Product>>("api/Products");
            imageProducts = await NetManager.Get<List<ImageProduct>>("api/ImageProducts");
            roles = await NetManager.Get<List<Role>>("api/Roles");
            users = await NetManager.Get<List<User>>("api/Users");
        }

        public static async void InitDataFile(string output, string sourcer)
        {
            if(!File.Exists(output))
            {
                var file = File.Create(output);
                file.Close();
                File.WriteAllText(output, sourcer);
            }
        }

        
    }
}
