using Assets.Scripts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

namespace Assets.Scripts.Core.Controller
{
    
    public class SaveLoadSystemController :IDisposable
    
    {
        private string savedirectory = Path.Combine(Application.persistentDataPath,"Save");
        public static SaveLoadSystemController _instance;
        private List<IStorage> _storages;
        private SaveModel SaveModel = new SaveModel();
        private CompositeDisposable cDis = new CompositeDisposable();
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto,
        };
        public SaveLoadSystemController(List<IStorage> storages)
        {
            _instance = this;
            _storages = storages;
            Load();
            Observable.Interval(TimeSpan.FromSeconds(5)).Subscribe((save) => Save()).AddTo(cDis);

            
        }

        public void Save()
        {
            
            string save;
            SaveModel.savemodel.Clear();
            for (int i = 0; i < _storages.Count; i++)
            {
                SaveModel.savemodel.Add(_storages[i].Save());
            }

            save =  JsonConvert.SerializeObject(SaveModel, _settings);
            if (!File.Exists(savedirectory))
            {
                File.Delete(savedirectory);
            }
                File.WriteAllText(savedirectory, save);
            Debug.Log(save);
        }

        public void Load()
        {
            if (!File.Exists(savedirectory)) 
            {
                return;
            }
           

            string load = File.ReadAllText(savedirectory);
            SaveModel = JsonConvert.DeserializeObject<SaveModel>(load, _settings);
            for (int i = 0; i < SaveModel.savemodel.Count; i++)
            {
                _storages[i].Load(SaveModel.savemodel[i]);
            }
        }

        public void Dispose()
        {
            cDis.Clear();
        }
    }
}
