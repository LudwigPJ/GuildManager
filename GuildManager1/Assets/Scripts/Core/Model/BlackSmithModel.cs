using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Model.ItemsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Model
{
    [Serializable]
    public class BlackSmithModel
    {
        public List<ItemModel> _ItemModels = new List<ItemModel>();
        


        public List<ItemModel> ItemModels
        { 
            get 
            { 
                return _ItemModels; 
            }
            set 
            { 
                _ItemModels = value;
                SaveLoadSystemController._instance.Save();
            } 
        }


    }
}
