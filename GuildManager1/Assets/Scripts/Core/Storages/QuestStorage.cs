using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Core.Storages
{
    public class QuestStorage : IStorage
    {
        public QuestSystemModel QuestModel = new QuestSystemModel();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };


        public QuestStorage(List<QuestConfig> questConfigs)
        {
            foreach (QuestConfig QuestCon in questConfigs)
            {

                QuestModel.QuestModels1.Add(QuestCon.GetQuestModel());

            }
        }

        object IStorage.Save()
        {
            return QuestModel;
        }
        

        void IStorage.Load(object load)
        {
            QuestModel = load as QuestSystemModel;
        }
    }
}
