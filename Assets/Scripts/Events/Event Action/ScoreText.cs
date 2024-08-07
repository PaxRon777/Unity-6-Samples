using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _txtScore;

    void Start()
    {
        _txtScore = GetComponent<TextMeshProUGUI>();        
    }

    private void OnEnable()
    {
        Ball.OnScore += UpdateScore; //suscribe to the ball event to update the score text
    }

    private void OnDisable()
    {
        Ball.OnScore -= UpdateScore; //Cleanup event subscription
    }

    private void UpdateScore(int score)
    {
        _txtScore.text = score.ToString();
    }
}
