using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _score.Changed += UpdateScoreText;
    }

    private void OnDisable()
    {
        _score.Changed -= UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }
}
