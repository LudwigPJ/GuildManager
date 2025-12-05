using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Model.ItemsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Controller
{
    public class TreningPlaceController 
    {
        public List<HeroView> HeroViews = new List<HeroView>();
        public ControllerHero ContollerHero;
        public TreninngPlaceView TreningPlaceView;
        public HeroView HeroViewPref;

        TreningPlaceController(ControllerHero _controllerHero, TreninngPlaceView _treninngPlaceView, HeroView _heroViewPref )
        {
            ContollerHero = _controllerHero;
            TreningPlaceView = _treninngPlaceView;
            HeroViewPref = _heroViewPref;
        }

        public void RefreshHeroesInTreningPlace()
        {
            foreach (ItemModel heroesMOdel in ContollerHero.HeroModels)
            {
                ItemSellView.Add(GameObject.Instantiate(ItemByeViewPref, ShopView.RootInventory1.transform));
                ItemSellView.Last().RefreshItem(sellmodels);

            }
        }











    }
}
