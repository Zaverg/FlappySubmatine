using TMPro;
using UnityEngine;

public class SecondLiveView : MonoBehaviour
{
    [SerializeField] private SecondsLive _secondsLive;
    [SerializeField] private TextMeshProUGUI _textSeconds;

    private void OnEnable()
    {
        _secondsLive.Changed += Change;
    }

    private void OnDisable()
    {
        _secondsLive.Changed -= Change;
    }

    private void Change(float seconds)
    {
        _textSeconds.text = string.Format("{0:F2}", seconds);
    }
}
