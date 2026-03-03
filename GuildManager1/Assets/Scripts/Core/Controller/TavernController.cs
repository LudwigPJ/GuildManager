using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Model;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View;
using Assets.Scripts.Core.View.QuestVIew;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class TavernController : IDisposable
{
    private QuestStorage questStorage;
    private QuestView QuestView;
    private BookView bookview;
    private TavernView tavernView;
    private ControllerHero ControllerHero;
    private HeroView heroViewBook;
    private List<HeroView> heroBookViews = new List<HeroView>();
    private List<QuestView> questViews = new List<QuestView>();
    private QuestStartView QuestStartView;
    private TavernStorage TavernStorage;
    private GoldController GoldController;
    private SaveLoadSystemController SaveLoadSystemController;
    private QuestFactory QuestFactory;

    public TavernController(BookView _bookview, TavernView _tavernView, ControllerHero _ControllerHero, [Inject(Id = "Book")] HeroView _heroView, QuestView _qestView, QuestStorage _questStorage , QuestStartView _questStartView, GoldController goldController, TavernStorage _TavernStorage, SaveLoadSystemController _saveLoadSystemController, QuestFactory _questFactory)
    {
        SaveLoadSystemController = _saveLoadSystemController;
        TavernStorage = _TavernStorage;
        questStorage = _questStorage;
        QuestView = _qestView;
        heroViewBook = _heroView;
        ControllerHero = _ControllerHero;
        bookview = _bookview;
        tavernView = _tavernView;
        QuestStartView = _questStartView;
        GoldController = goldController;
        QuestFactory = _questFactory;
        tavernView.OnButtonBookClicked += ShowBook;
        bookview.OnOffReturnClicked += CloseBook;
        tavernView.OnSaveButtonCliced += SaveLoadSystemController.Save;
        UpdateQuestsTime();

    }

    public IEnumerator QuestTimerCorutine(QuestModel _questModel, GameObject handler)
    {
        _questModel.StartTime = DateTime.UtcNow.ToString();
        QuestStartView.StartTimer();
        while (_questModel.QuestAllTime > 0f)
        {

            if(TavernStorage.QuestStorage.QuestModelSystem == _questModel)
            {
                QuestStartView.QuestViewTime(_questModel.QuestAllTime);
            }


            _questModel.ReduceQuestTime(Time.deltaTime);
            yield return null;




        
        }
        if (_questModel == TavernStorage.QuestStorage.QuestModelSystem)
        {
            QuestStartView.Close();
            
        }
        GoldController.GoldPlus(_questModel.GoldQuest);
        _questModel._HeroModel.AddExperienseAndlevelUp(_questModel.ExperienseQuest);
        int index = ControllerHero.HeroModels.IndexOf(_questModel._HeroModel);
        if (tavernView.isActiveAndEnabled)
        {
            heroBookViews[index].RefreshHero(_questModel._HeroModel);

            
            QuestView tmp = questViews[questStorage.QuestModel.QuestModels1.IndexOf(_questModel)];
            questViews.Remove(tmp);

            GameObject.Destroy(tmp.gameObject);
            
           
        }
        _questModel._HeroModel = null;
        questStorage.QuestModel.QuestModels1.Remove(_questModel);
        QuestFactory.CreateNewQuest();
        GameObject.Destroy(handler);
    }



    private void UpdateQuestsTime()
    {
        List<QuestModel> questdelete = new List<QuestModel>();
        foreach (QuestModel quests in questStorage.QuestModel.QuestModels)
        {
            if (quests.QuestStart && quests._HeroModel != null && quests.StartTime != string.Empty)
            {
                if (DateTime.UtcNow < DateTime.Parse(quests.StartTime) + TimeSpan.FromSeconds(quests.QuestAllTime))
                {


                    TimeSpan OutTime = DateTime.UtcNow - DateTime.Parse(quests.StartTime);
                    quests._remainingQuestTime -= (float)(OutTime * quests.GetHeroParametersSum()).TotalSeconds;
                    GameObject handler = new GameObject();
                    handler.AddComponent<CorutineHeandler>();
                    handler.GetComponent<CorutineHeandler>().StartCoroutine(QuestTimerCorutine(quests, handler));

                    

                }
                else
                {

                    GoldController.GoldPlus(quests.GoldQuest);
                    quests._HeroModel.AddExperienseAndlevelUp(quests.ExperienseQuest);
                    int index = ControllerHero.HeroModels.IndexOf(quests._HeroModel);
                   
                    quests._HeroModel = null;
                    questdelete.Add(quests);
                    



                }
            }
        }
        foreach(QuestModel _questsdelete in questdelete)
        {
            questStorage.QuestModel.QuestModels.Remove(_questsdelete);
            QuestFactory.CreateNewQuest();
        }
        questdelete.Clear();
    }



    public void ShowBook()

    {
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



        bookview.gameObject.SetActive(true);
        QuestStartView.OnQuestStart += QuestStart;
       
        foreach (QuestModel _questModel in questStorage.QuestModel.QuestModels1)
        {
            questViews.Add(GameObject.Instantiate(QuestView, bookview._questObjectBookRoot.transform));
        }
        for (int i = 0; i < questStorage.QuestModel.QuestModels1.Count; i++)
        {
            questViews[i].RefreshQuest(questStorage.QuestModel.QuestModels1[i]);
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
                QuestStartView.Show(questStorage.QuestModel.QuestModels1[questViews.IndexOf(view)]);
                TavernStorage.QuestStorage.QuestModelSystem = questStorage.QuestModel.QuestModels1[questViews.IndexOf(view)];


            };
        }
        foreach (HeroView view in heroBookViews)
        {
            view.OnHeroClick += () =>
            {

                if (TavernStorage.QuestStorage.QuestModelSystem == null || TavernStorage.QuestStorage.QuestModelSystem.QuestStart == true )
                {
                    return;
                }
                bool poot = true;
                if (TavernStorage.QuestStorage.QuestModelSystem._HeroModel == ControllerHero.HeroModels[heroBookViews.IndexOf(view)])
                {
                    TavernStorage.QuestStorage.QuestModelSystem._HeroModel = null;
                    QuestStartView.Show(TavernStorage.QuestStorage.QuestModelSystem);
                    return;
                }


                for (int i = 0; i < questStorage.QuestModel.QuestModels1.Count; i++)
                {
                    if (ControllerHero.HeroModels[heroBookViews.IndexOf(view)] == questStorage.QuestModel.QuestModels1[i]._HeroModel)
                    {
                        poot = false;

                    }
                }
                if (poot == true)
                {
                    TavernStorage.QuestStorage.QuestModelSystem._HeroModel = ControllerHero.HeroModels[heroBookViews.IndexOf(view)];
                    QuestStartView.HeroConnect(ControllerHero.HeroModels[heroBookViews.IndexOf(view)]);
                }
                

            };
        }


    }


    private void QuestStart()
    {
        GameObject handler = new GameObject();
        handler.AddComponent<CorutineHeandler>();
        handler.GetComponent<CorutineHeandler>().StartCoroutine(QuestTimerCorutine(TavernStorage.QuestStorage.QuestModelSystem, handler));

        TavernStorage.QuestStorage.QuestModelSystem.QuestStart = true;
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
        QuestStartView.OnQuestStart -= QuestStart;

    }


    public void Dispose()
    {
        tavernView.OnButtonBookClicked -= ShowBook;
        bookview.OnOffReturnClicked -= CloseBook;

    }


}
