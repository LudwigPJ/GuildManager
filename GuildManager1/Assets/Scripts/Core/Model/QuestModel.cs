using Assets.Scripts.Core.Model.ItemsModel;
using Newtonsoft.Json;
using System;
using UnityEngine;
namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class QuestModel
    {
        private float _remainingQuestTime;

        public QuestModel(Sprite _sprite, int _DangerQuest, int _ExperienseQuest, int _GoldQuest, string _questName, float _questAllTime)
        {
            Sprite = _sprite;
            DangerQuest = _DangerQuest;
            ExperienseQuest = _ExperienseQuest;
            GoldQuest = _GoldQuest;
            QuestName = _questName;
            _remainingQuestTime = _questAllTime;
        }

        [JsonIgnore] public Sprite Sprite; 
        public int DangerQuest; 
        public int ExperienseQuest; 
        public int GoldQuest; 
        public string QuestName;

        public bool QuestStart; 

        public bool QuestEnded;
        public HeroModel _HeroModel; 
        
        public float QuestAllTime
        {
            get
            {
                float heroParametersSum = GetHeroParametersSum();
                if (heroParametersSum <= 0f)
                {
                    return _remainingQuestTime;
                }

                return _remainingQuestTime / heroParametersSum;
            }
        }

        public void ReduceQuestTime(float deltaTime)
        {
            if (deltaTime <= 0f)
            {
                return;
            }

            float heroParametersSum = GetHeroParametersSum();
            float timeScale = heroParametersSum > 0f ? heroParametersSum : 1f;
            _remainingQuestTime = Mathf.Max(_remainingQuestTime - deltaTime * timeScale, 0f);
        }

        private float GetHeroParametersSum()
        {
            if (_HeroModel == null)
            {
                return 0f;
            }

            float baseParameters = _HeroModel._hp + _HeroModel._demage + _HeroModel._speed;

            baseParameters += GetItemParameters(_HeroModel.itemBootsModel);
            baseParameters += GetItemParameters(_HeroModel.itemArmorModel);
            baseParameters += GetItemParameters(_HeroModel.itemPantsModel);
            baseParameters += GetItemParameters(_HeroModel.itemHelmetModel);

            return baseParameters;
        }

        private float GetItemParameters(ItemModel itemModel)
        {
            if (itemModel == null)
            {
                return 0f;
            }

            return itemModel.TotalParameters;
        }
    }
}
