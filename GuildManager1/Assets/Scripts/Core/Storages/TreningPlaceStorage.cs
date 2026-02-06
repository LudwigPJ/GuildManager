using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Storages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Core.Model
{
    public class TreningPlaceStorage : IStorage
    {
        private Subject<Unit> onLoad = new Subject<Unit>();
        public TreningPlaceModel TreningPlaceModel = new TreningPlaceModel();
        public IObservable<Unit> OnLoad => onLoad.AsObservable();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            
        };
        public void Load(object load)
        {
            TreningPlaceModel = load as TreningPlaceModel;
            onLoad.OnNext(Unit.Default);
        }

        public object Save()
        {
            return TreningPlaceModel;
        }
    }
}
