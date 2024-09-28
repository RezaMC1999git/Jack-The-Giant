using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button MusicBTN;
    [SerializeField] Sprite[] MusicIcons;

    private void Start()
    {
        CheckToPlayTheMusic();
    }
    void CheckToPlayTheMusic() 
    {
        if (GamePrefrences.GetMusicState() == 1) 
        {
            MusicCotroller.instance.PlayMusic(true);
            MusicBTN.image.sprite = MusicIcons[1];
        }
        else 
        {
            MusicCotroller.instance.PlayMusic(false);
            MusicBTN.image.sprite = MusicIcons[0];
        }
    }
    public void LoadTheGame() 
    {
        //Application.LoadLevel("GamePlay");
        SceneFader.instance.LoadLevel("GamePlay");
        gameManager1.instance.gameStartedFromMainMenu = true;
    }
    public void LoadHighScore() 
    {
        Application.LoadLevel("HighScore");
    }
    public void LoadOptions() 
    {
        Application.LoadLevel("Options");
    }
    public void QuitTheGame() 
    {
        Application.Quit();
    }
    public void MusicButton() 
    {
        if(GamePrefrences.GetMusicState() == 0) 
        {
            GamePrefrences.SetMusicState(1);
            MusicCotroller.instance.PlayMusic(true);
            MusicBTN.image.sprite = MusicIcons[1];
        }
        else 
        {
            GamePrefrences.SetMusicState(0);
            MusicCotroller.instance.PlayMusic(false);
            MusicBTN.image.sprite = MusicIcons[0];
        }
    }
}
