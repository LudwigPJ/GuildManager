using Assets.Scripts.Core.Config;
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
    [SerializeField] TMP_Text level;
    [SerializeField] Slider experiense;
    [SerializeField] ImageConfig ImageConfig;


    [SerializeField] Sprite BootsBaseSprite;
    [SerializeField] Sprite ArmorBaseSprite;
    [SerializeField] Sprite PantsBaseSprite;
    [SerializeField] Sprite HelmetBaseSprite;


    public void RefreshHero(HeroModel hero1)
    {
        Hero.sprite = ImageConfig.GetSpriteByID(hero1._heroImageID);
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
            BootsView.sprite = hero1.itemBootsModel!=null ? ImageConfig.GetSpriteByID(hero1.itemBootsModel.ItemId) : BootsBaseSprite;

        }
        if (HelmetView != null)
        {
            HelmetView.sprite = hero1.itemHelmetModel !=null ? ImageConfig.GetSpriteByID(hero1.itemHelmetModel.ItemId) : HelmetBaseSprite;

        }
        if (ArmorView != null)
        {
            ArmorView.sprite = hero1.itemArmorModel != null  ? ImageConfig.GetSpriteByID(hero1.itemArmorModel.ItemId) : ArmorBaseSprite;

        }
        if (PantsView != null)
        {
            PantsView.sprite = hero1.itemPantsModel != null ? ImageConfig.GetSpriteByID(hero1.itemPantsModel.ItemId) : PantsBaseSprite;

        }
        if (level != null)
        {
            level.text = hero1._level.ToString();
        }
        if(experiense != null)
        {
            experiense.value =(float) hero1._experiense / (float)(100 + 20 * (hero1._level + 1));
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

    public void HeroClickBUttonInteractable(bool status)
    {
        HeroClickButton.interactable = status;
    }


    private void OnDestroy()
    {
        OnHeroClick = null;
    }
}
