using System;
using UnityEngine;
using UnityEngine.UI;

public class TreninngPlaceView : MonoBehaviour
{
    [SerializeField] private Button returnToCityButttonTreningPlace;
    [SerializeField] private GameObject RootTreningPLace;

    public event Action OnTrenningPlaceReturnToCity;

    private void Start()
    {
        returnToCityButttonTreningPlace.onClick.AddListener(() => OnTrenningPlaceReturnToCity?.Invoke());
    }

    private void OnDestroy()
    {
        returnToCityButttonTreningPlace.onClick.RemoveAllListeners();
    }
}
