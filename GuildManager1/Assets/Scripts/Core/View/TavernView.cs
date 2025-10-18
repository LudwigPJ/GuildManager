using System;
using UnityEngine;
using UnityEngine.UI;

public class TavernView : MonoBehaviour
{
    [SerializeField] private Button returnButtton;
    [SerializeField] private Button BookButton;

    public event Action OnOffReturnClicked;
    public event Action OnButtonBookClicked;

    private void Start()
    {
        returnButtton.onClick.AddListener(() => OnOffReturnClicked?.Invoke());
        BookButton.onClick.AddListener(() => OnButtonBookClicked?.Invoke());

    }

    private void OnDestroy()
    {
        returnButtton.onClick.RemoveAllListeners();
        BookButton.onClick.RemoveAllListeners();
    }
}
