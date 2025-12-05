using System;
using UnityEngine;
using UnityEngine.UI;

public class CasarmView : MonoBehaviour
{
    [SerializeField] private Button returnToCityButttonCasarm;
    [SerializeField] private GameObject HeroObjectRoot;
    [SerializeField] private GameObject RootForByeHeroes;
    [SerializeField] private Button ByeHeroesButton;

    public event Action OnCasarmReturnToCity;
    public event Action OnCasarmByeHeroes;
    public GameObject _heroObjectRoot=>HeroObjectRoot;
    public GameObject _RootForByeHeroes => RootForByeHeroes;




    private void Start()
    {
        returnToCityButttonCasarm.onClick.AddListener(() => OnCasarmReturnToCity?.Invoke());
        ByeHeroesButton.onClick.AddListener(() => OnCasarmByeHeroes?.Invoke());
        ByeHeroesButton.interactable = false;


    }
    public void SelectByeHeroesButton(bool state)
    {
        
        ByeHeroesButton.interactable = state;
    }

    private void OnDestroy()
    {
        returnToCityButttonCasarm.onClick.RemoveAllListeners();
        ByeHeroesButton.onClick.RemoveAllListeners();

        OnCasarmReturnToCity = null;
        OnCasarmByeHeroes = null;
    }
}
