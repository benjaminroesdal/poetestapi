using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingapicall
{
    public class ItemFactory
    {
        public List<Item> GetCurrentItems()
        {
            var cookies = new Dictionary<string, string> { { "POESESSID", "daf1563d04a5c008572693cf1e808178" } };
            var zzz = POEApi.DownloadString("https://www.pathofexile.com/character-window/get-items?accountName=Keymat20&character=SSF_BanjoBalls", Encoding.UTF8, cookies);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(zzz);
            var invitems = myDeserializedClass.items.Where(j => j.inventoryId == "MainInventory");
            return invitems.ToList();
        }
    }
}
