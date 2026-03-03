using Assets.Scripts.Core.Model;
using Assets.Scripts.Core.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Controller
{
    public class QuestFactory
    {
        private List<QuestConfig> questConfigs;
        private QuestStorage questStorage;
        public QuestFactory(List<QuestConfig> _questConfig, QuestStorage _questStorage)
        {
            questConfigs = _questConfig;
            questStorage = _questStorage;

        }

        public void CreateNewQuest()
        {
            Random random = new Random();
            QuestModel newquest = questConfigs[random.Next(0,questConfigs.Count())].GetQuestModel();
            questStorage.QuestModel.QuestModels.Add(newquest);
        }



    }
}
