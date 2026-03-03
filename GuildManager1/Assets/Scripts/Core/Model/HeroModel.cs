using Assets.Scripts.Core.Model.ItemsModel;
using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine;
[Serializable]
public class HeroModel
{
    
    public HeroModel(string heroImageID, string Name, float Hp, float Demage, float Speed, int Price, int level, int experiense)
    {
        _heroImageID = heroImageID;
        _speed = Speed;
        _name = Name;
        _hp = Hp;
        _demage = Demage;
        _price = Price;
        _level = level;
        _experiense = experiense;
    }
    public string _heroImageID;
    public float _demage;
    public float _hp;
    public float _speed; 
    public string _name; 

    public ItemModel itemBootsModel; 
    public ItemModel itemArmorModel; 

    public ItemModel itemPantsModel;
    public ItemModel itemHelmetModel; 

    public int _price;

    public int _level; 

    public int _experiense;



    public void AddExperienseAndlevelUp(int NewExperiense)
    {
        _experiense += NewExperiense;
        while (_experiense >= (float)(100 + 20 * (_level + 1)))
        {
            _level++;
            _experiense-= (100 + 20 * (_level + 1));
        }
    }

    public int GetRemainingExperiense()
    {
       return (100 + 20 * (_level + 1)) - _experiense;
    }

}
