using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName ="ConfigHero",menuName = "config/configHero")]
public class HeroConfig : ScriptableObject
{
    [SerializeField] float Demage;
    [SerializeField] float Hp;
    [SerializeField] float Speed;
    [SerializeField] string Name;
    [SerializeField] Sprite Hero;
    [SerializeField] int Price;
    


    public HeroModel GetHeroModel()
    {
        int level = 1;
        int experiense = 0;
        HeroModel hero1 = new HeroModel(Hero, Name, Hp, Demage, Speed, Price, level, experiense);
        return hero1;
    }



}
