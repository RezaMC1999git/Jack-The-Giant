using UnityEngine;
using TMPro;

public class HighScoreControlle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, coinText;
    private void Start()
    {
        SetScoreBasedOnDifficulty();
    }
    public void BackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    public void SetScore(int score, int CoinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = CoinScore.ToString();
    }
    public void SetScoreBasedOnDifficulty() 
    {
        if(GamePrefrences.GetEasyDifficultyState() == 1) 
        {
            SetScore(GamePrefrences.GetEasyDifficultyHighscore(), GamePrefrences.GetEasyDifficultyCoinScore());
        }
        if (GamePrefrences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePrefrences.GetMediumDifficultyHighscore(), GamePrefrences.GetMediumDifficultyCoinScore());
        }
        if (GamePrefrences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePrefrences.GetHardDifficultyHighscore(), GamePrefrences.GetHardDifficultyCoinScore());
        }
    }
}
