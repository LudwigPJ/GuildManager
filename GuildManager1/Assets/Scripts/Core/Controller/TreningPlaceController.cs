using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Model;
using Assets.Scripts.Core.Model.ItemsModel;
using Assets.Scripts.Core.View.ResourseView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Core.Controller
{
    public class TreningPlaceController : IDisposable
    {
        public CompositeDisposable disposables = new CompositeDisposable();
        public List<HeroView> HeroViews = new List<HeroView>();
        public ControllerHero ContollerHero;
        public TreninngPlaceView TreningPlaceView;
        public HeroView HeroViewPref;
        public TreningPlaceStorage treningPlaceStorage;
        public GoldCountView GoldCountView;
        private bool isSysteActive;

        public TreningPlaceController(ControllerHero _controllerHero, TreninngPlaceView _treninngPlaceView, [Inject(Id = "Book")] HeroView _heroViewPref, GoldCountView _goldCountView, TreningPlaceStorage _TreningPlaceStorage)
        {

            treningPlaceStorage = _TreningPlaceStorage;
            ContollerHero = _controllerHero;
            TreningPlaceView = _treninngPlaceView;
            HeroViewPref = _heroViewPref;
            GoldCountView = _goldCountView;
            UpdateTriningTime();




            RefreshHeroesInTreningPlace();




            TreningPlaceView.OnTimerTreningPlace += StartTreningTimer;
        }
        
        public void RefreshHeroesInTreningPlace()
        {
            HeroViews.ForEach(h => GameObject.Destroy(h.gameObject));

            HeroViews.Clear();

            if (treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace == null)
            {
                TreningPlaceView.SetTimerButtoninteractable(false);

            }
            else
            {
                TreningPlaceView.SetTimerButtoninteractable(true);
            }
            foreach (HeroModel heroesMOdel in ContollerHero.HeroModels)
            {
                HeroViews.Add(GameObject.Instantiate(HeroViewPref, TreningPlaceView._RootTreningPLace.transform));
                HeroViews.Last().RefreshHero(heroesMOdel);
                if(isSysteActive)
                {
                    HeroViews.Last().HeroClickBUttonInteractable(false);
                }

            }

            foreach (HeroView heroView1 in HeroViews)
            {
                heroView1.OnHeroClick += () =>
                {
                    TreningPlaceView._SelectedHeroInTreningPlace.RefreshHero(ContollerHero.HeroModels[HeroViews.IndexOf(heroView1)]);
                    treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace = ContollerHero.HeroModels[HeroViews.IndexOf(heroView1)];
                    TreningPlaceView._TimeToNewLevel.text = (treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.GetRemainingExperiense()*0.3f).ToString()+"секунд";
                    RefreshHeroesInTreningPlace();
                };
            }
            if (treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace != null)
            {
                TreningPlaceView._SelectedHeroInTreningPlace.RefreshHero(treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace);
                TreningPlaceView._TimeToNewLevel.text = (treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.GetRemainingExperiense() * 0.3f).ToString() + "секунд";
            }
        }

        public void StartTreningTimer()
        {
            if(treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace != null)
            {

                GoldCountView.StartCoroutine(TimerTreningPlaceCorutine());
                
            }
            
        }




        private void UpdateTriningTime()
        {
            if (treningPlaceStorage.TreningPlaceModel.Duration != string.Empty && treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace != null && treningPlaceStorage.TreningPlaceModel.DateStartTime != string.Empty) 
            {
                if (DateTime.UtcNow < DateTime.Parse(treningPlaceStorage.TreningPlaceModel.DateStartTime) + TimeSpan.Parse(treningPlaceStorage.TreningPlaceModel.Duration))
                { 
                
                    
                    treningPlaceStorage.TreningPlaceModel.Duration = (DateTime.Parse(treningPlaceStorage.TreningPlaceModel.DateStartTime) + TimeSpan.Parse(treningPlaceStorage.TreningPlaceModel.Duration) - DateTime.UtcNow).ToString();
                    StartTreningTimer();

                }
                else
                {
                    treningPlaceStorage.TreningPlaceModel.DateStartTime = string.Empty;
                    treningPlaceStorage.TreningPlaceModel.Duration = string.Empty;
                    treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.AddExperienseAndlevelUp(treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.GetRemainingExperiense());

                }
            }
        }




        private IEnumerator TimerTreningPlaceCorutine()
        {
            treningPlaceStorage.TreningPlaceModel.DateStartTime = DateTime.UtcNow.ToString();
            isSysteActive = true;
            foreach (HeroView heroview in HeroViews)
            {
                
                heroview.HeroClickBUttonInteractable(false);
            }
            TreningPlaceView.SetTimerButtonSetActive(false);
            double time = 0;

            if (treningPlaceStorage.TreningPlaceModel.Duration == string.Empty)
            {
                time = treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.GetRemainingExperiense() * 0.3f;
            }
            else
            {
                time = TimeSpan.Parse(treningPlaceStorage.TreningPlaceModel.Duration).TotalSeconds;
            }

            while (time > 0f)
            {
                time -= Time.deltaTime;
                TreningPlaceView.SetTimerTmpText(time.ToString());
                treningPlaceStorage.TreningPlaceModel.Duration = TimeSpan.FromSeconds(time).ToString();
                yield return null;

            }

            treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.AddExperienseAndlevelUp(treningPlaceStorage.TreningPlaceModel.SelectedHeroInTreningPlace.GetRemainingExperiense());
            TreningPlaceView.SetTimerButtonSetActive(true);            
            foreach (HeroView heroview in HeroViews)
            {

                heroview.HeroClickBUttonInteractable(true);
            }
            isSysteActive = false;
            RefreshHeroesInTreningPlace();
            
        }

        public void Dispose()
        {
            disposables.Clear();
        }
    }
}
