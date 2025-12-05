using Assets.Scripts.Core.View;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BlackSmithView : MonoBehaviour
{
    [SerializeField] private Button returnButtton;
    [SerializeField] private GameObject HeroRootBlacksmith;
    [SerializeField] private GameObject ItemsRootBLacksmith;
    [SerializeField] private HeroView ChoisenHero;
    [SerializeField] private Button ItemHelmetButton;
    [SerializeField] private Button ItemArmorButton;
    [SerializeField] private Button ItemBootsButton;
    [SerializeField] private Button ItemPantsButton;
    [SerializeField] private Button ItemSlotBootsButton;
    [SerializeField] private Button ItemSlotArmorButton;
    [SerializeField] private Button ItemSlotPantsButton;
    [SerializeField] private Button ItemSlotHelmetButton;


    public event Action OnBlacksmithReturnClicked;

    public event Action<EItemType> OnHelmetCliced;
    public event Action<EItemType> OnArmorCliced;
    public event Action<EItemType> OnBootsCliced;
    public event Action<EItemType> OnPantsCliced;

    public event Action OnSlotHelmetCliced;
    public event Action OnSlotArmorCliced;
    public event Action OnSlotPantsCliced;
    public event Action OnSlotBootsCliced;




    public GameObject _HeroRootBlackstmith => HeroRootBlacksmith;
    public GameObject _ItemsRootBlacksmith => ItemsRootBLacksmith;

    public HeroView _ChoisenHero => ChoisenHero;

    private void Start()
    {
        returnButtton.onClick.AddListener(() => OnBlacksmithReturnClicked?.Invoke());
        ItemHelmetButton.onClick.AddListener(() => OnHelmetCliced?.Invoke(EItemType.Helmet));
        ItemArmorButton.onClick.AddListener(() => OnArmorCliced?.Invoke(EItemType.Armor));
        ItemBootsButton.onClick.AddListener(() => OnBootsCliced?.Invoke(EItemType.Boots));
        ItemPantsButton.onClick.AddListener(() => OnPantsCliced?.Invoke(EItemType.Pants));

        ItemSlotBootsButton.onClick.AddListener(() => OnSlotBootsCliced?.Invoke());
        ItemSlotArmorButton.onClick.AddListener(() => OnSlotArmorCliced?.Invoke());
        ItemSlotPantsButton.onClick.AddListener(() => OnSlotPantsCliced?.Invoke());
        ItemSlotHelmetButton.onClick.AddListener(() => OnSlotHelmetCliced?.Invoke());
    }

    private void OnDestroy()
    {
        returnButtton.onClick.RemoveAllListeners();
        ItemHelmetButton.onClick.RemoveAllListeners();
        ItemArmorButton.onClick.RemoveAllListeners();
        ItemPantsButton.onClick.RemoveAllListeners();
        ItemBootsButton.onClick.RemoveAllListeners();
        OnHelmetCliced = null;
        OnArmorCliced = null;
        OnBootsCliced = null;
        OnPantsCliced = null;

        OnSlotHelmetCliced = null;
        OnSlotArmorCliced = null;
        OnSlotPantsCliced = null;
        OnSlotBootsCliced = null;
        ItemSlotBootsButton.onClick.RemoveAllListeners();
        ItemSlotArmorButton.onClick.RemoveAllListeners();
        ItemSlotPantsButton.onClick.RemoveAllListeners();
        ItemSlotHelmetButton.onClick.RemoveAllListeners();
    }
}
