using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _txtScore;

    void Start()
    {
        _txtScore = GetComponent<TextMeshProUGUI>();
        Ball.OnScore += UpdateScore; //suscribe to the balls event action to update the score text
    }

    private void UpdateScore(int score)
    {
        _txtScore.text = score.ToString();
    }
}
