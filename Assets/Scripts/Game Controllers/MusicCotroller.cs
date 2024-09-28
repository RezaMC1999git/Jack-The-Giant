using UnityEngine;

public class MusicCotroller : MonoBehaviour
{
    public static MusicCotroller instance;
    private AudioSource audioSource;
    private void Awake()
    {
        makeSingleton();
        audioSource = GetComponent<AudioSource>();
    }
    void makeSingleton() 
    {
        if(instance!= null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayMusic(bool play) 
    {
        if (play) 
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.Play();
            }
        }
        else 
        {
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
            }
        }
    } 
}
