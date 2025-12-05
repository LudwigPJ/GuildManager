using Assets.Scripts.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Model.ItemsModel
{
    public class ItemModel
    {
        public ItemModel(Sprite _Item, float _Hp, float _Speed, float _Demage, string _Name, EItemType _type, int _price)
        {
            Item = _Item;
            Hp = _Hp;
            Speed = _Speed;
            Demage = _Demage;
            Name = _Name;
            type = _type;
            Price = _price;
        }

        public string Name { get; set; }
        public float Demage { get; set; }
        public float Hp { get; set; }

        public float Speed { get; set; }

        public Sprite Item { get; set; }

        public EItemType type { get; set; }

        public bool ItemEquiped { get; set; }

        public float TotalParameters
        {
            get { return Hp + Demage + Speed; }
        }

        public int Price { get; set; }
        
    }
}
