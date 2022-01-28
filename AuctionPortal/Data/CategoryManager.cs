using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuctionPortal.Data
{
    public class CategoryManager
    {
        private static List<Category> _itemCategories;

        public static List<Category> GetCategories()
        {
            return _itemCategories;
        }

        public static async Task InitializeCategories()
        {
            var categories=await FileWriteRead.ReadTextAsync("categories.json");
            List<Category> itemsCategories = JsonConvert.DeserializeObject<List<Category>>(categories);
            _itemCategories = itemsCategories;
        }

        public static string GetCategoryDisplayName(string name)
        {
            foreach (var itemCategory in _itemCategories.Where(itemCategory => itemCategory.CategoryName == name))
            {
                return itemCategory.CategoryDisplayName;
            }

            return "nieznana kategoria";
        }
    }
}