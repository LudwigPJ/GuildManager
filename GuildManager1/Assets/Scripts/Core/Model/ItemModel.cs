using Assets.Scripts.Core.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Model.ItemsModel
{
    [Serializable]
    public class ItemModel
    {
        public ItemModel(string _ItemId, float _Hp, float _Speed, float _Demage, string _Name, EItemType _type, int _price)
        {
            ItemId = _ItemId;
            Hp = _Hp;
            Speed = _Speed;
            Demage = _Demage;
            Name = _Name;
            type = _type;
            Price = _price;
        }

        public string Name; 
        public float Demage; 
        public float Hp; 

        public float Speed;

        public string ItemId;

        public EItemType type;

        public bool ItemEquiped;

        public float TotalParameters
        {
            get { return Hp + Demage + Speed; }
        }

        public int Price;
        
    }
}
