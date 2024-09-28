using UnityEngine;

public static class GamePrefrences 
{
    public static string easyDifficulty = "easyDifficulty";
    public static string mediumDifficulty = "mediumDifficulty";
    public static string hardDifficulty = "hardDifficulty";

    public static string easyDifficultyHighScore = "easyDifficultyHighScore";
    public static string mediumDifficultyHighScore = "mediumDifficultyHighScore";
    public static string hardDifficultyHighScore = "hardDifficultyHighScore";

    public static string easyDifficultyCoinScore = "easyDifficultyCoinScore";
    public static string mediumDifficultyCoinScore = "mediumDifficultyCoinScore";
    public static string hardDifficultyCoinScore = "hardDifficultyCoinScore";

    public static string isMusicOn = "isMusicOn";

	// 0-false  1-true
	public static int GetMusicState()
	{
		return PlayerPrefs.GetInt(GamePrefrences.isMusicOn);
	}

	// a method for setting the music state - On or Off
	public static void SetMusicState(int state)
	{
		PlayerPrefs.SetInt(GamePrefrences.isMusicOn, state);
	}

	// method for getting easy difficulty state
	public static int GetEasyDifficultyState()
	{
		return PlayerPrefs.GetInt(GamePrefrences.easyDifficulty);
	}

	// method for setting easy difficulty state
	public static void SetEasyDifficultyState(int state)
	{
		PlayerPrefs.SetInt(GamePrefrences.easyDifficulty, state);
	}

	// method for getting medium difficulty state
	public static int GetMediumDifficultyState()
	{
		return PlayerPrefs.GetInt(GamePrefrences.mediumDifficulty);
	}

	// method for setting medium difficulty state
	public static void SetMediumDifficultyState(int state)
	{
		PlayerPrefs.SetInt(GamePrefrences.mediumDifficulty, state);
	}

	// method for getting hard difficulty state
	public static int GetHardDifficultyState()
	{
		return PlayerPrefs.GetInt(GamePrefrences.hardDifficulty);
	}

	// method for setting hard difficulty state
	public static void SetHardDifficultyState(int state)
	{
		PlayerPrefs.SetInt(GamePrefrences.hardDifficulty, state);
	}

	// method for getting easy difficulty highscore
	public static int GetEasyDifficultyHighscore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.easyDifficultyHighScore);
	}

	// method for setting easy difficulty highscore
	public static void SetEasyDifficultyHighscore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.easyDifficultyHighScore, score);
	}

	// method for getting medium difficulty highscore
	public static int GetMediumDifficultyHighscore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.mediumDifficultyHighScore);
	}

	// method for setting medium difficulty highscore
	public static void SetMediumDifficultyHighscore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.mediumDifficultyHighScore, score);
	}

	// method for getting hard difficulty highscore
	public static int GetHardDifficultyHighscore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.hardDifficultyHighScore);
	}

	// method for setting hard difficulty highscore
	public static void SetHardDifficultyHighscore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.hardDifficultyHighScore, score);
	}

	// method for getting easy difficulty coin score
	public static int GetEasyDifficultyCoinScore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.easyDifficultyCoinScore);
	}

	// method for setting easy difficulty coin score
	public static void SetEasyDifficultyCoinScore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.easyDifficultyCoinScore, score);
	}

	// method for getting medium difficulty coin score
	public static int GetMediumDifficultyCoinScore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.mediumDifficultyCoinScore);
	}

	// method for setting medium difficulty coin score
	public static void SetMediumDifficultyCoinScore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.mediumDifficultyCoinScore, score);
	}

	// method for getting hard difficulty coin score
	public static int GetHardDifficultyCoinScore()
	{
		return PlayerPrefs.GetInt(GamePrefrences.hardDifficultyCoinScore);
	}

	// method for setting hard difficulty coin score
	public static void SetHardDifficultyCoinScore(int score)
	{
		PlayerPrefs.SetInt(GamePrefrences.hardDifficultyCoinScore, score);
	}
}
