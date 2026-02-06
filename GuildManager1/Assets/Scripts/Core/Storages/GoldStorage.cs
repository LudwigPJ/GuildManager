using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Model.GoldModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Storages
{
    public class GoldStorage :IStorage
    {
        private GoldModel _Goldmodel;
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };




        public GoldStorage() 
        {
            _Goldmodel = new GoldModel(0);
        }

        public GoldModel Goldmodel { get { return _Goldmodel; }}




        public object Save()
        {
            return _Goldmodel;
        }

        public void Load(object load)
        {
            _Goldmodel = load as GoldModel;
        }


    }
}
