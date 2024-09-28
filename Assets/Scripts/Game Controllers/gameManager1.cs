using UnityEngine;

public class gameManager1 : MonoBehaviour
{
    public static gameManager1 instance;
    [HideInInspector] public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector] public int score, coinScore, lifeScore;
    private void Awake()
    {
        MakeSingletone();
    }
    private void Start()
    {
        InitializeVariables();
    }
    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetCoinScore(coinScore);
                GamePlayController.instance.SetLifeScore(lifeScore);
                GamePlayController.instance.SetScroe(score);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                GamePlayController.instance.SetCoinScore(0);
                GamePlayController.instance.SetLifeScore(2);
                GamePlayController.instance.SetScroe(0);

                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;
            }
        }
    }
    void InitializeVariables() 
    {
        if(!PlayerPrefs.HasKey("Game Initialized")) 
        {
            GamePrefrences.SetEasyDifficultyState(0);
            GamePrefrences.SetEasyDifficultyCoinScore(0);
            GamePrefrences.SetEasyDifficultyHighscore(0);

            GamePrefrences.SetMediumDifficultyState(1);
            GamePrefrences.SetMediumDifficultyHighscore(0);
            GamePrefrences.SetMediumDifficultyCoinScore(0);
            
            GamePrefrences.SetHardDifficultyState(0);
            GamePrefrences.SetHardDifficultyHighscore(0);
            GamePrefrences.SetHardDifficultyCoinScore(0);

            GamePrefrences.SetMusicState(0);
            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }
    void MakeSingletone()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void CheckGameStatus(int score, int lifeScore, int coinScore)
    {
        if (lifeScore <= 0)
        {
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            GamePlayController.instance.SetLifeScore(0);
            GamePlayController.instance.GameOverShowPanel(score, coinScore);

            if (GamePrefrences.GetEasyDifficultyState() == 1) 
            {
                int highScore = GamePrefrences.GetEasyDifficultyHighscore();
                int coinHighScore = GamePrefrences.GetEasyDifficultyCoinScore();
                if(highScore < score) 
                    GamePrefrences.SetEasyDifficultyHighscore(score);
                if (coinHighScore < score)
                    GamePrefrences.SetEasyDifficultyCoinScore(coinScore);
            }
            if (GamePrefrences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePrefrences.GetMediumDifficultyHighscore();
                int coinHighScore = GamePrefrences.GetMediumDifficultyCoinScore();
                if (highScore < score)
                    GamePrefrences.SetMediumDifficultyHighscore(score);
                if (coinHighScore < score)
                    GamePrefrences.SetMediumDifficultyCoinScore(coinScore);
            }
            if (GamePrefrences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePrefrences.GetHardDifficultyHighscore();
                int coinHighScore = GamePrefrences.GetHardDifficultyCoinScore();
                if (highScore < score)
                    GamePrefrences.SetHardDifficultyHighscore(score);
                if (coinHighScore < score)
                    GamePrefrences.SetHardDifficultyCoinScore(coinScore);
            }
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GamePlayController.instance.PlayerDiedRestartTheGame();
        }
    }
}
