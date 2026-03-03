using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Model.ItemsModel;
using Assets.Scripts.Core.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Core.Controller
{
    public class ItemFabric
    {
        private List<ItemsConfig>  itemsConfigs;
        private LazyInject<ShopController> ItemByeModels;
        
        public ItemFabric([Inject(Id = "ItemsConfigs")] List<ItemsConfig> _itemsConfigs, LazyInject<ShopController> _ItemByeModels)
        {
            itemsConfigs = _itemsConfigs;
            ItemByeModels = _ItemByeModels;

        }

        public void CreateNewItem()
        {
            Random randomItem = new Random();
            ItemModel newItemModel = itemsConfigs[randomItem.Next(0,itemsConfigs.Count)].GetItemModel();
            ItemByeModels.Value.ItemByeModels.Add(newItemModel);

        }





    }
}
