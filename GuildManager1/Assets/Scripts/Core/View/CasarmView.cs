using System;
using UnityEngine;
using UnityEngine.UI;

public class CasarmView : MonoBehaviour
{
    [SerializeField] private Button returnToCityButttonCasarm;
    [SerializeField] private GameObject HeroObjectRoot;

    public event Action OnCasarmReturnToCity;
    public GameObject _heroObjectRoot=>HeroObjectRoot;




    private void Start()
    {
        returnToCityButttonCasarm.onClick.AddListener(() => OnCasarmReturnToCity?.Invoke());
        
    }

    private void OnDestroy()
    {
        returnToCityButttonCasarm.onClick.RemoveAllListeners();
    }
}
