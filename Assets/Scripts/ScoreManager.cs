using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float currentScore;
    private bool isCounting = true;

    void Update()
    {
        if (!isCounting) return;

        currentScore += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(currentScore).ToString();
    }

    public void StopScore()
    {
        isCounting = false;
    }

    public int GetFinalScore()
    {
        return Mathf.FloorToInt(currentScore);
    }
}
