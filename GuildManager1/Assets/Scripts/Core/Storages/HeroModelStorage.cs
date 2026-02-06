using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Model;
using Assets.Scripts.Core.Model.GoldModel;
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
    public class HeroModelStorage : IStorage
    {
        public HeroSystemModel HeroSystemModel = new HeroSystemModel();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };

        public HeroModelStorage([Inject(Id = "CassarmConfigs")] List<HeroConfig> HeroConfigs, [Inject(Id = "ByeConfigs")] List<HeroConfig> HeroByeConfigs)
        {
            foreach (HeroConfig HeroCon in HeroConfigs)
            {

                HeroSystemModel.HeroModelsSystem.Add(HeroCon.GetHeroModel());

            }
            foreach (HeroConfig HeroCon in HeroByeConfigs)
            {

                HeroSystemModel.HeroByeModelsSystem.Add(HeroCon.GetHeroModel());

            }
        }
        public void Load(object load)
        {
            HeroSystemModel = load as HeroSystemModel;
        }

        public object Save()
        {
            return HeroSystemModel;
        }
    }
}
