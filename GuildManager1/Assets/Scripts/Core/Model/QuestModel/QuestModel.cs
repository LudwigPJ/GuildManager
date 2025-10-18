using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Model.QuestModel
{
    public class QuestModel
    {
        public QuestModel(Sprite _sprite, int _DangerQuest, int _ExperienseQuest, int _GoldQuest, string _questName, float _questAllTime)
        {
            Sprite = _sprite;
            DangerQuest = _DangerQuest;
            ExperienseQuest = _ExperienseQuest;
            GoldQuest = _GoldQuest;
            QuestName = _questName;
            QuestAllTime = _questAllTime;
        }

        public Sprite Sprite { get; set; }
        public int DangerQuest {  get; set; }
        public int ExperienseQuest { get; set; }
        public int GoldQuest { get; set; }
        public string QuestName { get; set; }

        public bool QuestStart { get; set; }

        public bool QuestEnded {  get; set; }
        public HeroModel _HeroModel { get; set; }

        public float QuestAllTime {  get; set; }

    }
}
