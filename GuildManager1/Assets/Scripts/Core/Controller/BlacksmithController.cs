using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Model.ItemsModel;
using Assets.Scripts.Core.Model.QuestModel;
using Assets.Scripts.Core.View;
using Assets.Scripts.Core.View.ItemView;
using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.Scripts.Core.Controller.Blacksmith
{
    public class BlacksmithController
    {
        private ControllerHero _ControllerHero;
        private HeroView _heroView;
        private List <HeroView> heroViews = new List<HeroView>();
        private BlackSmithView _smithView;
        private List <ItemModel> _ItemModels = new List<ItemModel>();
        private List <ItemView> _ItemView = new List<ItemView>();
        private HeroModel SelectedHero;
        private ItemView ItemViewPref;
        private Lazy<ShopController> ShopController;



       public BlacksmithController(ControllerHero controllerHero, HeroView heroView, BlackSmithView smithView, List<ItemsConfig> itemsConfig, ItemView _itemViewPref,Lazy <ShopController> _shopController )
        {
            ItemViewPref = _itemViewPref;
            _smithView = smithView;
            _ControllerHero = controllerHero;
            _heroView = heroView;
            ShopController = _shopController;


            foreach (ItemsConfig ItemCon in itemsConfig)
            {

                _ItemModels.Add(ItemCon.GetItemModel());

            }

            RefreshItemSmith();
            _smithView.OnArmorCliced += SortItems;
            _smithView.OnBootsCliced += SortItems;
            _smithView.OnPantsCliced += SortItems;
            _smithView.OnHelmetCliced += SortItems;

            

            _smithView.OnSlotHelmetCliced += () =>
            {
                if (SelectedHero.itemHelmetModel != null)
                {
                    SelectedHero.itemHelmetModel.ItemEquiped = false;
                }
                SelectedHero.itemHelmetModel = null;
                SortItems(EItemType.Helmet);
                _smithView._ChoisenHero.RefreshHero(SelectedHero);
                ShopController.Value.RefreshViews();

            };
            _smithView.OnSlotArmorCliced += () =>
            {
                if (SelectedHero.itemArmorModel != null)
                {
                    SelectedHero.itemArmorModel.ItemEquiped = false;
                }
                SelectedHero.itemArmorModel = null;
                SortItems(EItemType.Armor);
                _smithView._ChoisenHero.RefreshHero(SelectedHero);
                ShopController.Value.RefreshViews();

            };
            _smithView.OnSlotBootsCliced += () =>
            {
                if (SelectedHero.itemBootsModel != null)
                {
                    SelectedHero.itemBootsModel.ItemEquiped = false;
                }
                SelectedHero.itemBootsModel = null;
                SortItems(EItemType.Boots);
                _smithView._ChoisenHero.RefreshHero(SelectedHero);
                ShopController.Value.RefreshViews();

            };
            _smithView.OnSlotPantsCliced += () =>
            {
                if (SelectedHero.itemPantsModel != null)
                {
                    SelectedHero.itemPantsModel.ItemEquiped = false;
                }
                SelectedHero.itemPantsModel = null;
                SortItems(EItemType.Pants);
                _smithView._ChoisenHero.RefreshHero(SelectedHero);
                ShopController.Value.RefreshViews();

            };



        }


        private void SortItems(EItemType ItemType)
        {
            

            List<ItemModel> ItemSortModels = _ItemModels.Where(ItemModelSort => ItemModelSort.type == ItemType && ItemModelSort.ItemEquiped == false).ToList();
            _ItemView.Select(ItemOff =>
            {
                ItemOff.gameObject.SetActive(false);
                return ItemOff;
            }).Where(ItemViewSort => ItemSortModels.Any(ItemModelOn => _ItemModels.IndexOf(ItemModelOn) == _ItemView.IndexOf(ItemViewSort))).Select(ItemOn =>
            {
                ItemOn.gameObject.SetActive(true);
                return ItemOn;
            }).ToList();
        }

        public void RefreshItemSmith()
        {
            foreach(ItemView view in _ItemView)
            {
                GameObject.Destroy(view.gameObject);
            }

            foreach(HeroView view in heroViews)
            {
                GameObject.Destroy(view.gameObject);
            }

            _ItemView.Clear();
            heroViews.Clear();

            foreach (HeroModel _heroMod in _ControllerHero.HeroModels)
            {
                heroViews.Add(GameObject.Instantiate(_heroView, _smithView._HeroRootBlackstmith.transform));
                heroViews.Last().RefreshHero(_heroMod);
            }

            foreach (HeroView heroView1 in heroViews)
            {
                heroView1.OnHeroClick += () =>
                {
                    _smithView._ChoisenHero.RefreshHero(_ControllerHero.HeroModels[heroViews.IndexOf(heroView1)]);
                    SelectedHero = _ControllerHero.HeroModels[heroViews.IndexOf(heroView1)];
                };
            }

            foreach (ItemModel _itemMod in _ItemModels)
            {
                _ItemView.Add(GameObject.Instantiate(ItemViewPref, _smithView._ItemsRootBlacksmith.transform));
                _ItemView.Last().RefreshItem(_itemMod);
            }

            foreach (ItemView item in _ItemView)
            {
                item.OnSelectItem += () =>
                {
                    if (SelectedHero != null)
                    {
                        EItemType type = _ItemModels[_ItemView.IndexOf(item)].type;
                        if (type == EItemType.Helmet)
                        {
                            if (SelectedHero.itemHelmetModel != null)
                            {
                                SelectedHero.itemHelmetModel.ItemEquiped = false;
                            }
                            SelectedHero.itemHelmetModel = _ItemModels[_ItemView.IndexOf(item)];
                            SelectedHero.itemHelmetModel.ItemEquiped = true;
                            SortItems(EItemType.Helmet);
                        }
                        if (type == EItemType.Armor)
                        {
                            if (SelectedHero.itemArmorModel != null)
                            {
                                SelectedHero.itemArmorModel.ItemEquiped = false;
                            }
                            SelectedHero.itemArmorModel = _ItemModels[_ItemView.IndexOf(item)];
                            SelectedHero.itemArmorModel.ItemEquiped = true;
                            SortItems(EItemType.Armor);
                        }
                        if (type == EItemType.Boots)
                        {
                            if (SelectedHero.itemBootsModel != null)
                            {
                                SelectedHero.itemBootsModel.ItemEquiped = false;
                            }
                            SelectedHero.itemBootsModel = _ItemModels[_ItemView.IndexOf(item)];
                            SelectedHero.itemBootsModel.ItemEquiped = true;
                            SortItems(EItemType.Boots);
                        }
                        if (type == EItemType.Pants)
                        {
                            if (SelectedHero.itemPantsModel != null)
                            {
                                SelectedHero.itemPantsModel.ItemEquiped = false;
                            }
                            SelectedHero.itemPantsModel = _ItemModels[_ItemView.IndexOf(item)];
                            SelectedHero.itemPantsModel.ItemEquiped = true;
                            SortItems(EItemType.Pants);
                        }
                        _smithView._ChoisenHero.RefreshHero(SelectedHero);
                        ShopController.Value.RefreshViews();

                    }

                };
                SortItems(EItemType.Helmet);

            }
        }

        public List<ItemModel> itemModels { get { return _ItemModels;  } }
    }
}
