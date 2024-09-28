using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField] private TextMeshProUGUI scoreText, coinText, lifeText,gameOverScoreText,gameOverCoinText;
    [SerializeField] private GameObject pausePanel,gameOverPanel;
    [SerializeField] GameObject readyButton;
    private GameObject leftScreen, rightScreen;

    private void Awake()
    {
        MakeInstance();
        leftScreen = GameObject.Find("Left");
        rightScreen = GameObject.Find("Right");
    }
    void Start()
    {
        Time.timeScale = 0f;
    }
    void MakeInstance() 
    {
        if (instance == null)
            instance = this;
    }
    public void GameOverShowPanel(int finalScore, int finalCoinScore) 
    {
        gameOverPanel.SetActive(true);
        gameOverCoinText.text = finalCoinScore.ToString();
        gameOverScoreText.text = finalScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }
    IEnumerator GameOverLoadMainMenu() 
    {
        yield return new WaitForSeconds(3f);
        SceneFader.instance.LoadLevel("MainMenu");
    }
    public void PlayerDiedRestartTheGame() 
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart() 
    {
        yield return new WaitForSeconds(1f);
        SceneFader.instance.LoadLevel("GamePlay");
    }
    public void SetScroe(int score) 
    {
        scoreText.text = "x" + score.ToString();
    }
    public void SetCoinScore(int coinScore) 
    {
        coinText.text = "x" + coinScore.ToString();
    }
    public void SetLifeScore(int lifeScore) 
    {
        lifeText.text = "x" + lifeScore.ToString();
    }
    public void PauseTheGame() 
    {
        Time.timeScale = 0f;
        leftScreen.SetActive(false);
        rightScreen.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void ResumeGame() 
    {
        Time.timeScale = 1f;
        leftScreen.SetActive(true);
        rightScreen.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void QuitGame() 
    {
        Time.timeScale = 1f;
        //  leftScreen.SetActive(true);
        //  rightScreen.SetActive(true);
        //  SceneFader.instance.LoadLevel("MainMenu");
        Application.LoadLevel("MainMenu");
    }
    public void StartTheGame() 
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
