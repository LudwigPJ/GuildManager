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
    [SerializeField] Image BootsView;
    [SerializeField] Image ArmorView;
    [SerializeField] Image PantsView;
    [SerializeField] Image HelmetView;
    [SerializeField] TMP_Text Price;
    [SerializeField] Image Galochka;


    [SerializeField] Sprite BootsBaseSprite;
    [SerializeField] Sprite ArmorBaseSprite;
    [SerializeField] Sprite PantsBaseSprite;
    [SerializeField] Sprite HelmetBaseSprite;


    public void RefreshHero(HeroModel hero1)
    {
        Hero.sprite = hero1._hero;
        Name.text = hero1._name;
        demage.text = hero1._demage.ToString();
        Hp.text= hero1._hp.ToString();
        Speed.text = hero1._speed.ToString();
        if (Price != null)
        {
            Price.text = hero1._price.ToString();
        }
        if(BootsView != null)
        {
            BootsView.sprite = hero1.itemBootsModel!=null ? hero1.itemBootsModel.Item: BootsBaseSprite;

        }
        if (HelmetView != null)
        {
            HelmetView.sprite = hero1.itemHelmetModel !=null ? hero1.itemHelmetModel.Item: HelmetBaseSprite;

        }
        if (ArmorView != null)
        {
            ArmorView.sprite = hero1.itemArmorModel != null  ? hero1.itemArmorModel.Item: ArmorBaseSprite;

        }
        if (PantsView != null)
        {
            PantsView.sprite = hero1.itemPantsModel != null ? hero1.itemPantsModel.Item: PantsBaseSprite;

        }
    }

    public event Action OnHeroClick;

    private void Start()
    {
        if (HeroClickButton != null) 
        {
            HeroClickButton.onClick.AddListener(() => OnHeroClick?.Invoke());
        }
       
        
    }

    public void SelectGalochkaByeHeroes(bool State)
    {
        if (Galochka != null)
        {
            Galochka.gameObject.SetActive(State);
        }
    }
    
    


    private void OnDestroy()
    {
        OnHeroClick = null;
    }
}
