using Assets.Scripts.Core.Model.ItemsModel;
using TMPro;
using UnityEngine;

public class HeroModel
{
    public HeroModel(Sprite Hero, string Name, float Hp, float Demage, float Speed, int Price)
    {
        _hero = Hero;
        _speed = Speed;
        _name = Name;
        _hp = Hp;
        _demage = Demage;
        _price = Price;
    }
    public Sprite _hero { get; private set; }
    public float _demage { get; private set; }
    public float _hp { get; private set; }
    public float _speed { get; private set; }
    public string _name { get; private set; }

    public ItemModel itemBootsModel { get; set; }
    public ItemModel itemArmorModel { get;  set; }

    public ItemModel itemPantsModel { get;  set; }
    public ItemModel itemHelmetModel { get; set; }

    public int _price { get; private set; }

}
