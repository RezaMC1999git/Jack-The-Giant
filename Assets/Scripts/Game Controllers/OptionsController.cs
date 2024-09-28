using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject easySign, mediumSign, hardSign;
    private void Start()
    {
        SetTheDifficulty();
    }
    public void BackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    void SetInitialDifficulty(string difficulty) 
    {
        switch (difficulty) 
        {
            case "easy":
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
    }
    void SetTheDifficulty() 
    {
        if (GamePrefrences.GetEasyDifficultyState() == 1)
            SetInitialDifficulty("easy");
        if (GamePrefrences.GetMediumDifficultyState() == 1)
            SetInitialDifficulty("medium");
        if (GamePrefrences.GetHardDifficultyState() == 1)
            SetInitialDifficulty("hard");
    }
    public void EasyDifficulty() 
    {
        GamePrefrences.SetEasyDifficultyState(1);
        GamePrefrences.SetMediumDifficultyState(0);
        GamePrefrences.SetHardDifficultyState(0);
        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }
    public void MediumDifficulty()
    {
        GamePrefrences.SetEasyDifficultyState(0);
        GamePrefrences.SetMediumDifficultyState(1);
        GamePrefrences.SetHardDifficultyState(0);
        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }
    public void HardDifficulty()
    {
        GamePrefrences.SetEasyDifficultyState(0);
        GamePrefrences.SetMediumDifficultyState(0);
        GamePrefrences.SetHardDifficultyState(1);
        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }
}
