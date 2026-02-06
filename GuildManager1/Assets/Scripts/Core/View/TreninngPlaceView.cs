using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreninngPlaceView : MonoBehaviour
{
    [SerializeField] private Button returnToCityButttonTreningPlace;
    [SerializeField] private GameObject RootTreningPLace;
    [SerializeField] private HeroView SelectedHeroInTreningPlace;
    [SerializeField] private TMP_Text TimeToNewLevel;
    [SerializeField] private Button TimerTreningPlaceButton;
    [SerializeField] private TMP_Text TimerTreningPlaceForLevelUp;

    public event Action OnTrenningPlaceReturnToCity;
    public event Action OnTimerTreningPlace;


    public GameObject _RootTreningPLace => RootTreningPLace;
    public HeroView _SelectedHeroInTreningPlace => SelectedHeroInTreningPlace;

    public void SetTimerButtoninteractable(bool Status)
    {
        TimerTreningPlaceButton.interactable = Status;
    }

    public void SetTimerButtonSetActive(bool Status)
    {
        TimerTreningPlaceButton.gameObject.SetActive(Status);
        TimerTreningPlaceForLevelUp.gameObject.SetActive(!Status);

    }
    public void SetTimerTmpText(string Time)
    {
        TimerTreningPlaceForLevelUp.text = Time;
    }
    public TMP_Text _TimeToNewLevel => TimeToNewLevel;
    private void Start()
    {
        returnToCityButttonTreningPlace.onClick.AddListener(() => OnTrenningPlaceReturnToCity?.Invoke());
        TimerTreningPlaceButton.onClick.AddListener(() => OnTimerTreningPlace?.Invoke());
    }

    private void OnDestroy()
    {
        returnToCityButttonTreningPlace.onClick.RemoveAllListeners();
        TimerTreningPlaceButton.onClick.RemoveAllListeners();

        OnTimerTreningPlace = null;
        OnTrenningPlaceReturnToCity = null;
    }
}
