using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopVIew : MonoBehaviour
{
    [SerializeField] private Button returnToCityShopButtton;

    public event Action OnReturnShopClicked;

    private void Start()
    {
        returnToCityShopButtton.onClick.AddListener(() => OnReturnShopClicked?.Invoke());
    }

    private void OnDestroy()
    {
        returnToCityShopButtton.onClick.RemoveAllListeners();
    }
}
