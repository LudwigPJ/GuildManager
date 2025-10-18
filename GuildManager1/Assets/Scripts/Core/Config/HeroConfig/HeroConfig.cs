using UnityEngine;
[CreateAssetMenu(fileName ="ConfigHero",menuName = "config/configHero")]
public class HeroConfig : ScriptableObject
{
    [SerializeField] float Demage;
    [SerializeField] float Hp;
    [SerializeField] float Speed;
    [SerializeField] string Name;
    [SerializeField] Sprite Hero;


    public HeroModel GetHeroModel()
    {
        HeroModel hero1 = new HeroModel(Hero, Name, Hp, Demage, Speed);
        return hero1;
    }
}
