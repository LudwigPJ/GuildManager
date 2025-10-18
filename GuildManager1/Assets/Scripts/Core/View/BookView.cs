using System;
using UnityEngine;
using UnityEngine.UI;

public class BookView : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject HeroObjectBookRoot;
    [SerializeField] private GameObject QuestObjectBookRoot;

    public event Action OnOffReturnClicked;
    public GameObject _heroObjectBookRoot => HeroObjectBookRoot;
    public GameObject _questObjectBookRoot => QuestObjectBookRoot;

    private void Start()
    {
        returnButton.onClick.AddListener(() => OnOffReturnClicked?.Invoke());
    }

    private void OnDestroy()
    {
        returnButton.onClick.RemoveAllListeners();
    }
}
