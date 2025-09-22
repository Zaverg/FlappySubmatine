using TMPro;
using UnityEngine;

public class SurvivalTimeView : MonoBehaviour
{
    [SerializeField] private SurvivalTime _survivalTime;
    [SerializeField] private TextMeshProUGUI _textSeconds;

    private void OnEnable()
    {
        _survivalTime.Changed += UpdateTimeText;
    }

    private void OnDisable()
    {
        _survivalTime.Changed -= UpdateTimeText;
    }

    private void UpdateTimeText(float seconds)
    {
        _textSeconds.text = string.Format("{0:F2}", seconds);
    }
}
