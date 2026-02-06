using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Storages
{
    public class TavernStorage :IStorage
    {
        public TavernModel QuestStorage = new TavernModel();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };

        public void Load(object load)
        {
            QuestStorage =  load as TavernModel;
        }

        public object Save()
        {
            return QuestStorage;
        }
    }
}
