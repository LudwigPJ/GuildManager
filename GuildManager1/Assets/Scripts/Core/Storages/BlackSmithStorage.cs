using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Model;
using Assets.Scripts.Core.Model.GoldModel;
using Assets.Scripts.Core.Model.ItemsModel;
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
    public class BlackSmithStorage : IStorage
    {
        private BlackSmithModel blackSmithModel = new BlackSmithModel();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };

        public BlackSmithStorage([Inject(Id = "ItemsConfigs")] List<ItemsConfig> itemsConfig)
        {
            foreach (ItemsConfig ItemCon in itemsConfig)
            {

                blackSmithModel.ItemModels.Add(ItemCon.GetItemModel());

            }
        }
        public BlackSmithModel BlackSmithModel {  get { return blackSmithModel; } }

        public object Save()
        {
            return blackSmithModel;
        }

        public void Load(object load)
        {
            blackSmithModel = load as BlackSmithModel;
        }
    }
}
