using Assets.Scripts.Core.Model.QuestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
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


        public event Action OnQuestStart;



        private void Start()
        {
            CloseQuestButton.onClick.AddListener(Close);
            StartQuestButton.onClick.AddListener(StartTimer);
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
            Quest.sprite = _questmodel.Sprite;
            
            
            if(_questmodel.QuestStart == true)
            {
                StartTimer();
            }
            else
            {
                Timer.gameObject.SetActive(false);
                StartQuestButton.gameObject.SetActive(true);

                StartQuestButton.interactable = true;
            }
            
            

            if (_questmodel._HeroModel != null)
            {
                Hero.color = new Color(1, 1, 1, 1f);
                NameHero.text = _questmodel._HeroModel._name;
                Hero.sprite = _questmodel._HeroModel._hero;

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
            
            OnQuestStart?.Invoke();
        }

        public void HeroConnect(HeroModel _heroModel)
        {
            
            StartQuestButton.gameObject.SetActive(true);
            StartQuestButton.interactable = true;
            Hero.color = new Color(1, 1, 1, 1f);
            NameHero.text = _heroModel._name;
            Hero.sprite = _heroModel._hero;
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        private void OnDestroy()
        {
            CloseQuestButton.onClick.RemoveAllListeners();
            StartQuestButton.onClick.RemoveAllListeners();
        }
    }
}
