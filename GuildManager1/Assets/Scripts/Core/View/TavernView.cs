using System;
using UnityEngine;
using UnityEngine.UI;

public class TavernView : MonoBehaviour
{
    [SerializeField] private Button returnButtton;
    [SerializeField] private Button BookButton;
    [SerializeField] private Button SaveButton;

    public event Action OnOffReturnClicked;
    public event Action OnButtonBookClicked;
    public event Action OnSaveButtonCliced;

    private void Start()
    {
        returnButtton.onClick.AddListener(() => OnOffReturnClicked?.Invoke());
        BookButton.onClick.AddListener(() => OnButtonBookClicked?.Invoke());
        SaveButton.onClick.AddListener(() => OnSaveButtonCliced?.Invoke());

    }

    private void OnDestroy()
    {
        returnButtton.onClick.RemoveAllListeners();
        BookButton.onClick.RemoveAllListeners();
        SaveButton.onClick.RemoveAllListeners();
    }
}
