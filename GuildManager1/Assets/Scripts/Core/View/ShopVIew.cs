using Assets.Scripts.Core.View;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopVIew : MonoBehaviour
{
    [SerializeField] private Button returnToCityShopButtton;
    [SerializeField] private GameObject RootShop;
    [SerializeField] private GameObject RootInventory;
    [SerializeField] private Button SellItemButton;
    [SerializeField] private Button ByeItemButton;

    [SerializeField] private Button HelmetByeButton;
    [SerializeField] private Button ArmorByeButton;
    [SerializeField] private Button PantsByeButton;
    [SerializeField] private Button BootsByeButton;

    [SerializeField] private Button HelmetSellButton;
    [SerializeField] private Button ArmorSellButton;
    [SerializeField] private Button PantsSellButton;
    [SerializeField] private Button BootsSellButton;

    public event Action OnReturnShopClicked;

    public event Action<EItemType> OnHelmetByeCliced;
    public event Action<EItemType> OnArmorByeCliced;
    public event Action<EItemType> OnBootsByeCliced;
    public event Action<EItemType> OnPantsByeCliced;

    public event Action<EItemType> OnHelmetSellCliced;
    public event Action<EItemType> OnArmorSellCliced;
    public event Action<EItemType> OnBootsSellCliced;
    public event Action<EItemType> OnPantsSellCliced;

    public event Action OnSellItemCliced;
    public event Action OnByeItemCliced;

    private void Start()
    {
        returnToCityShopButtton.onClick.AddListener(() => OnReturnShopClicked?.Invoke());

        HelmetByeButton.onClick.AddListener(() => OnHelmetByeCliced?.Invoke(EItemType.Helmet));
        ArmorByeButton.onClick.AddListener(() => OnArmorByeCliced?.Invoke(EItemType.Armor));
        BootsByeButton.onClick.AddListener(() => OnBootsByeCliced?.Invoke(EItemType.Boots));
        PantsByeButton.onClick.AddListener(() => OnPantsByeCliced?.Invoke(EItemType.Pants));

        HelmetSellButton.onClick.AddListener(() => OnHelmetSellCliced?.Invoke(EItemType.Helmet));
        ArmorSellButton.onClick.AddListener(() => OnArmorSellCliced?.Invoke(EItemType.Armor));
        BootsSellButton.onClick.AddListener(() => OnBootsSellCliced?.Invoke(EItemType.Boots));
        PantsSellButton.onClick.AddListener(() => OnPantsSellCliced?.Invoke(EItemType.Pants));

        SellItemButton.onClick.AddListener(() => OnSellItemCliced?.Invoke());
        ByeItemButton.onClick.AddListener(() => OnByeItemCliced?.Invoke());

        SellItemButton.interactable = false;
        ByeItemButton.interactable = false;

    }

    private void OnDestroy()
    {
        returnToCityShopButtton.onClick.RemoveAllListeners();
        HelmetByeButton.onClick.RemoveAllListeners();
        ArmorByeButton.onClick.RemoveAllListeners();
        BootsByeButton.onClick.RemoveAllListeners();
        PantsByeButton.onClick.RemoveAllListeners();

        HelmetSellButton.onClick.RemoveAllListeners();
        ArmorSellButton.onClick.RemoveAllListeners();
        BootsSellButton.onClick.RemoveAllListeners();
        PantsSellButton.onClick.RemoveAllListeners();

        OnHelmetByeCliced = null;
        OnArmorByeCliced = null;
        OnBootsByeCliced = null;
        OnPantsByeCliced = null;

        OnHelmetSellCliced = null;
        OnArmorSellCliced = null;
        OnBootsSellCliced = null;
        OnPantsSellCliced = null;

        SellItemButton.onClick.RemoveAllListeners();
        ByeItemButton.onClick.RemoveAllListeners();

        OnSellItemCliced = null;
        OnByeItemCliced = null;
    }

    public void SelectButtonSell()
    {
        SellItemButton.interactable = true;
        ByeItemButton.interactable = false;
    }

    public void SelectButtonBye()
    {
        SellItemButton.interactable = false;
        ByeItemButton.interactable = true;
    }

    public GameObject RootShop1 => RootShop;
    public GameObject RootInventory1 => RootInventory;

}
