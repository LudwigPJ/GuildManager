using Assets.Scripts.Core.Model.QuestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.QuestVIew
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] Image Quest;
        [SerializeField] TMP_Text ExperienseQuest;
        [SerializeField] TMP_Text GoldQuest;
        [SerializeField] TMP_Text DangerQuest;
        [SerializeField] TMP_Text Name;
        [SerializeField] Button QuestOpenButton;

        public event Action OnQuestOpen;



        public void RefreshQuest(QuestModel Quest1)
        {
            Quest.sprite = Quest1.Sprite;
            ExperienseQuest.text = Quest1.ExperienseQuest.ToString();
            GoldQuest.text = Quest1.GoldQuest.ToString();
            DangerQuest.text = Quest1.DangerQuest.ToString();
            Name.text =Quest1.QuestName.ToString();


        }

        private void Start()
        {
            QuestOpenButton.onClick.AddListener(() => OnQuestOpen?.Invoke());
        }

        private void OnDestroy()
        {
            OnQuestOpen = null;
            QuestOpenButton.onClick.RemoveAllListeners();
        }
    }
}
