using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroView : MonoBehaviour
{
    [SerializeField] Image Hero;
    [SerializeField] TMP_Text demage;
    [SerializeField] TMP_Text Hp;
    [SerializeField] TMP_Text Speed;
    [SerializeField] TMP_Text Name;
    [SerializeField] Button HeroClickButton;


    public void RefreshHero(HeroModel hero1)
    {
        Hero.sprite = hero1._hero;
        Name.text = hero1._name;
        demage.text = hero1._demage.ToString();
        Hp.text= hero1._hp.ToString();
        Speed.text = hero1._speed.ToString();
    }

    public event Action OnHeroClick;

    private void Start()
    {
        if (HeroClickButton != null) 
        {
            HeroClickButton.onClick.AddListener(() => OnHeroClick?.Invoke());
        }
       
        
    }

    private void OnDestroy()
    {
        OnHeroClick = null;
    }
}
