using Assets.Scripts.Core.Model.ItemsModel;
using Assets.Scripts.Core.Model.QuestModel;
using Assets.Scripts.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;



namespace Assets.Scripts.Core.Config.ItemsConfig

{
    [CreateAssetMenu(fileName = "ConfigItem", menuName = "config/configItem")]
    public class ItemsConfig : ScriptableObject
    {
        [SerializeField] float Demage;
        [SerializeField] float Hp;
        [SerializeField] float Speed;
        [SerializeField] Sprite Item;
        [SerializeField] string Name;
        [SerializeField] EItemType type;
        [SerializeField] int price;


        public ItemModel GetItemModel()
        {
            ItemModel Item1 = new ItemModel(Item, Hp, Speed, Demage, Name, type, price);
            return Item1; 
        }


    }
}
