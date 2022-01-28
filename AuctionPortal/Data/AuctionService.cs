using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuctionPortal.Data
{
    public class AuctionService
    {
        async Task<List<Item>> ReadItemsFromFile()
        {
            const string fileName = "auctions.json";
            var a = await FileWriteRead.ReadTextAsync(fileName);
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(a);
            return items;
        }
        public async Task<Item[]> GetAuctionsAsync()
        {
            var b = await ReadItemsFromFile();
            return b.ToArray();
        }

        public async Task<bool> PurchaseItem(int itemId, string cardNumber)
        {
            var items=await ReadItemsFromFile();
            foreach (var item in items.Where(item => item.Id == itemId))
            {
                await CardManager.ChargeCard(cardNumber, item.Price);
                items.Remove(item);
                await FileWriteRead.WriteTextAsync("auctions.json", JsonConvert.SerializeObject(items));
                
                return true;
            }

            return false;
        }

        public async Task AddItem(Item item)
        {
            var items=await ReadItemsFromFile();
            var max = items.Select(existingItem => existingItem.Id).Prepend(0).Max();
            item.Id = max + 1;
            items.Add(item);
            await FileWriteRead.WriteTextAsync("auctions.json", JsonConvert.SerializeObject(items));
            return;
            
        }
    }
}
