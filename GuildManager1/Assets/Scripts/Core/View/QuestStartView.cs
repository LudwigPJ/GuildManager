using Assets.Scripts.Core.Config;
using Assets.Scripts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.QuestVIew
{
    public class QuestStartView : MonoBehaviour
    {
        [SerializeField] TMP_Text NameQuest;
        [SerializeField] TMP_Text NameHero;
        [SerializeField] TMP_Text GoldForQuest;
        [SerializeField] TMP_Text ExperienseForQuest;
        [SerializeField] TMP_Text Timer;
        [SerializeField] Image Quest;
        [SerializeField] Image Hero;
        [SerializeField] Button StartQuestButton;
        [SerializeField] Button CloseQuestButton;
        [SerializeField] ImageConfig ImageConfig;


        public event Action OnQuestStart;



        private void Start()
        {
            CloseQuestButton.onClick.AddListener(Close);
            StartQuestButton.onClick.AddListener(()=> OnQuestStart?.Invoke());
        }

        public void Show(QuestModel _questmodel)
        {
            NameHero.text = null;
            Hero.sprite = null;
            Hero.color =new Color(1, 1, 1, 0f);
            
            gameObject.SetActive(true);
            NameQuest.text = _questmodel.QuestName;
            GoldForQuest.text = _questmodel.GoldQuest.ToString();
            ExperienseForQuest.text = _questmodel.ExperienseQuest.ToString();
            Quest.sprite = ImageConfig.GetSpriteByID(_questmodel.QuestImageID);
            
            
            if(_questmodel.QuestStart == true)
            {
                StartTimer();
            }
            else
            {
                Timer.gameObject.SetActive(false);
                StartQuestButton.gameObject.SetActive(true);

                StartQuestButton.interactable = false;
            }
            
            

            if (_questmodel._HeroModel != null)
            {
                Hero.color = new Color(1, 1, 1, 1f);
                NameHero.text = _questmodel._HeroModel._name;
                Hero.sprite = ImageConfig.GetSpriteByID(_questmodel._HeroModel._heroImageID);
                StartQuestButton.interactable = true;
            }

        }

        public void QuestViewTime(float _questAllTime)
        {
            Timer.text = _questAllTime.ToString();
        }

        public void StartTimer()
        {
            
            Timer.gameObject.SetActive(true);
            StartQuestButton.gameObject.SetActive(false);
            
            
        }

        public void HeroConnect(HeroModel _heroModel)
        {
            
            StartQuestButton.gameObject.SetActive(true);
            StartQuestButton.interactable = true;
            Hero.color = new Color(1, 1, 1, 1f);
            NameHero.text = _heroModel._name;
            Hero.sprite = ImageConfig.GetSpriteByID(_heroModel._heroImageID); 
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        private void OnDestroy()
        {
            CloseQuestButton.onClick.RemoveAllListeners();
            
        }
    }
}
