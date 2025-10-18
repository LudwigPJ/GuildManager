using TMPro;
using UnityEngine;

public class HeroModel
{
    public HeroModel(Sprite Hero, string Name, float Hp, float Demage, float Speed)
    {
        _hero = Hero;
        _speed = Speed;
        _name = Name;
        _hp = Hp;
        _demage = Demage;
    }
    public Sprite _hero { get; private set; }
    public float _demage { get; private set; }
    public float _hp { get; private set; }
    public float _speed { get; private set; }
    public string _name { get; private set; }

}
