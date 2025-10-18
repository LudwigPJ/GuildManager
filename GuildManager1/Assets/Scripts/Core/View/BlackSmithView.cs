using System;
using UnityEngine;
using UnityEngine.UI;

public class BlackSmithView : MonoBehaviour
{
    [SerializeField] private Button returnButtton;

    public event Action OnBlacksmithReturnClicked;

    private void Start()
    {
        returnButtton.onClick.AddListener(() => OnBlacksmithReturnClicked?.Invoke());
    }

    private void OnDestroy()
    {
        returnButtton.onClick.RemoveAllListeners();
    }
}
