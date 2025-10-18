using Assets.Scripts.Core.Controller.QuestController;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Model.QuestModel;
using Assets.Scripts.Core.View.QuestVIew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TavernController : IDisposable
{
    private QuestController QuestController;
    private QuestView QuestView;
    private BookView bookview;
    private TavernView tavernView;
    private ControllerHero ControllerHero;
    private HeroView heroViewBook;
    private List<HeroView> heroBookViews = new List<HeroView>();
    private List<QuestView> questViews = new List<QuestView>();
    private QuestStartView QuestStartView;
    private QuestModel CurrentQuestModel;
    private GoldController GoldController;

    public TavernController(BookView _bookview, TavernView _tavernView, ControllerHero _ControllerHero, HeroView _heroView, QuestView _qestView, QuestController _questController, QuestStartView _questStartView, GoldController goldController)
    {
        QuestController = _questController;
        QuestView = _qestView;
        heroViewBook = _heroView;
        ControllerHero = _ControllerHero;
        bookview = _bookview;
        tavernView = _tavernView;
        QuestStartView = _questStartView;
        GoldController = goldController;
        tavernView.OnButtonBookClicked += ShowBook;
        bookview.OnOffReturnClicked += CloseBook;


    }

    public IEnumerator QuestTimerCorutine(QuestModel _questModel)
    {

        while (_questModel.QuestAllTime >= 0)
        {

            if(CurrentQuestModel == _questModel)
            {
                QuestStartView.QuestViewTime(_questModel.QuestAllTime);
            }


            _questModel.QuestAllTime -= Time.deltaTime;
            yield return null;




        
        }
        if (_questModel == CurrentQuestModel)
        {
            QuestStartView.Close();
            
        }
        GoldController.GoldPlus(_questModel.GoldQuest);
        QuestView tmp = questViews[QuestController._QuestModels.IndexOf(_questModel)];        
        questViews.Remove(tmp);
        GameObject.Destroy(tmp.gameObject);
        QuestController._QuestModels.Remove(_questModel);
    }






    
    public void ShowBook()
    {
        bookview.gameObject.SetActive(true);
        QuestStartView.OnQuestStart += () =>
        {

            questViews[QuestController._QuestModels.IndexOf(CurrentQuestModel)].StartCoroutine(QuestTimerCorutine(CurrentQuestModel));
            CurrentQuestModel.QuestStart = true;

        };
        foreach (QuestModel _questModel in QuestController._QuestModels)
        {
            questViews.Add(GameObject.Instantiate(QuestView, bookview._questObjectBookRoot.transform));
        }
        for (int i = 0; i < QuestController._QuestModels.Count; i++)
        {
            questViews[i].RefreshQuest(QuestController._QuestModels[i]);
        }
        foreach (HeroModel _heroMod in ControllerHero.HeroModels)
        {
            heroBookViews.Add(GameObject.Instantiate(heroViewBook, bookview._heroObjectBookRoot.transform));
        }
        for (int i = 0; i < ControllerHero.HeroModels.Count; i++)
        {
            heroBookViews[i].RefreshHero(ControllerHero.HeroModels[i]);
        }
        foreach (QuestView view in questViews)
        {
            view.OnQuestOpen += () =>
            {
                QuestStartView.Show(QuestController._QuestModels[questViews.IndexOf(view)]);
                CurrentQuestModel = QuestController._QuestModels[questViews.IndexOf(view)];


            };
        }
        foreach (HeroView view in heroBookViews)
        {
            view.OnHeroClick += () =>
            {
                if (CurrentQuestModel.QuestStart == true )
                {
                    return;
                }
                bool poot = true;
                if (CurrentQuestModel._HeroModel == ControllerHero.HeroModels[heroBookViews.IndexOf(view)])
                {
                    CurrentQuestModel._HeroModel = null;
                    QuestStartView.Show(CurrentQuestModel);
                    return;
                }


                for (int i = 0; i < QuestController._QuestModels.Count; i++)
                {
                    if (ControllerHero.HeroModels[heroBookViews.IndexOf(view)] == QuestController._QuestModels[i]._HeroModel)
                    {
                        poot = false;

                    }
                }
                if (poot == true)
                {
                    CurrentQuestModel._HeroModel = ControllerHero.HeroModels[heroBookViews.IndexOf(view)];
                    QuestStartView.HeroConnect(ControllerHero.HeroModels[heroBookViews.IndexOf(view)]);
                }
                

            };
        }


    }

    public void CloseBook()
    {


        bookview.gameObject.SetActive(false);
        foreach (Transform heroView in bookview._heroObjectBookRoot.transform)
        {
            GameObject.Destroy(heroView.gameObject);
        }
        heroBookViews.Clear();
        foreach (Transform QuestView in bookview._questObjectBookRoot.transform)
        {
            GameObject.Destroy(QuestView.gameObject);
        }
        questViews.Clear();
    }


    public void Dispose()
    {
        tavernView.OnButtonBookClicked -= ShowBook;
        bookview.OnOffReturnClicked -= CloseBook;

    }


}
