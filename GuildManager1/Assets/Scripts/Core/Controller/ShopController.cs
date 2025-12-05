using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Model.ItemsModel;
using Assets.Scripts.Core.View;
using Assets.Scripts.Core.View.ItemView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core.Controller
{
    public class ShopController
    {
        private List<ItemView> ItemSellView = new List<ItemView>();
        private List<ItemView> ItemByeView = new List<ItemView>();
        private BlacksmithController BlacksmithController;
        private List<ItemModel> itemByeModels = new List<ItemModel>();
        private ShopVIew ShopView;
        private ItemView ItemByeViewPref;
        private ItemView ItemSellViewPref;
        private ItemModel SelectItem;
        private GoldController goldController;
        



        public ShopController(List<ItemsConfig> _itemsConfigs, ItemView _itemByeView, ItemView _itemSellView, BlacksmithController _blacksmithController, ShopVIew _ShopView, GoldController _goldColntoller)
        {
            ItemSellViewPref = _itemSellView;
            ItemByeViewPref = _itemByeView;
            BlacksmithController = _blacksmithController;
            ShopView = _ShopView;
            goldController = _goldColntoller;
            






            foreach (ItemsConfig itemsConfig in _itemsConfigs)
            {
                itemByeModels.Add(itemsConfig.GetItemModel());
            }

            RefreshViews();

            ShopView.OnArmorByeCliced += SortByeItems;
            ShopView.OnHelmetByeCliced += SortByeItems;
            ShopView.OnPantsByeCliced += SortByeItems;
            ShopView.OnBootsByeCliced += SortByeItems;

            ShopView.OnBootsSellCliced += SortSellItems;
            ShopView.OnArmorSellCliced += SortSellItems;
            ShopView.OnPantsSellCliced += SortSellItems;
            ShopView.OnHelmetSellCliced += SortSellItems;

            ShopView.OnSellItemCliced += SellCurretItem;
            ShopView.OnByeItemCliced += ByeCurretItem;
        }

        private void SortSellItems(EItemType ItemType)
        {


            List<ItemModel> ItemSortModels = BlacksmithController.itemModels.Where(ItemModelSort => ItemModelSort.type == ItemType && ItemModelSort.ItemEquiped == false).ToList();
            ItemSellView.Select(ItemOff =>
            {
                ItemOff.gameObject.SetActive(false);
                return ItemOff;
            }).Where(ItemViewSort => ItemSortModels.Any(ItemModelOn => BlacksmithController.itemModels.IndexOf(ItemModelOn) == ItemSellView.IndexOf(ItemViewSort))).Select(ItemOn =>
            {
                ItemOn.gameObject.SetActive(true);
                return ItemOn;
            }).ToList();
        }

        private void SortByeItems(EItemType ItemType)
        {


            List<ItemModel> ItemSortModels = itemByeModels.Where(ItemModelSort => ItemModelSort.type == ItemType && ItemModelSort.ItemEquiped == false).ToList();
            ItemByeView.Select(ItemOff =>
            {
                ItemOff.gameObject.SetActive(false);
                return ItemOff;
            }).Where(ItemViewSort => ItemSortModels.Any(ItemModelOn => itemByeModels.IndexOf(ItemModelOn) == ItemByeView.IndexOf(ItemViewSort))).Select(ItemOn =>
            {
                ItemOn.gameObject.SetActive(true);
                return ItemOn;
            }).ToList();
        }

        public void RefreshViews()
        {
            foreach(ItemView view in ItemSellView)
            {
                GameObject.Destroy(view.gameObject);
            }

            foreach (ItemView view in ItemByeView)
            {
                GameObject.Destroy(view.gameObject);
            }

            ItemByeView.Clear();
            ItemSellView.Clear();

            foreach (ItemModel sellmodels in BlacksmithController.itemModels)
            {
                ItemSellView.Add(GameObject.Instantiate(ItemByeViewPref, ShopView.RootInventory1.transform));
                ItemSellView.Last().RefreshItem(sellmodels);

            }

            foreach (ItemModel itemModel in itemByeModels)
            {
                ItemByeView.Add(GameObject.Instantiate(ItemByeViewPref, ShopView.RootShop1.transform));
                ItemByeView.Last().RefreshItem(itemModel);
            }

            foreach (ItemView itemsellview in ItemSellView)
            {
                itemsellview.OnSelectItem += () =>
                {
                    foreach (ItemView item in ItemSellView)
                    {
                        item.SelectGalochka(false);

                    }
                    foreach (ItemView item in ItemByeView)
                    {
                        item.SelectGalochka(false);
                    }
                    itemsellview.SelectGalochka(true);
                    ShopView.SelectButtonSell();
                    int index = ItemSellView.IndexOf(itemsellview);
                    SelectItem = BlacksmithController.itemModels[index];
                };
            }

            foreach (ItemView itemByeview in ItemByeView)
            {
                itemByeview.OnSelectItem += () =>
                {
                    foreach (ItemView item in ItemSellView)
                    {
                        item.SelectGalochka(false);
                    }
                    foreach (ItemView item in ItemByeView)
                    {
                        item.SelectGalochka(false);
                    }
                    itemByeview.SelectGalochka(true);
                    ShopView.SelectButtonBye();
                    int index = ItemByeView.IndexOf(itemByeview);
                    SelectItem = itemByeModels[index];
                };
            }
            foreach(ItemModel itemModel1 in BlacksmithController.itemModels)
            {
                if(itemModel1.ItemEquiped)
                {
                    int index = BlacksmithController.itemModels.IndexOf(itemModel1);
                    ItemSellView[index].gameObject.SetActive(false);
                    
                }
            }
            
        }

        private void SellCurretItem()
        {
            if (SelectItem == null)
            {
                Debug.LogWarning("Attempted to sell item without selection.");
                return;
            }

            BlacksmithController.itemModels.Remove(SelectItem);
            itemByeModels.Add(SelectItem);
            RefreshViews();
            BlacksmithController.RefreshItemSmith();
            goldController.GoldPlus(SelectItem.Price);
            SelectItem = null;
        }

        private void ByeCurretItem()
        {
            if (SelectItem == null)
            {
                Debug.LogWarning("Attempted to buy item without selection.");
                return;
            }

            if (goldController.GoldMinus(SelectItem.Price))
            {
                itemByeModels.Remove(SelectItem);
                BlacksmithController.itemModels.Add(SelectItem);
                RefreshViews();
                BlacksmithController.RefreshItemSmith();

                
            }
        }
    }
}
