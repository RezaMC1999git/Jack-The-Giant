using System.Collections;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private Animator fadeAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        MakeSingleto();
    }
    void MakeSingleto() 
    {
        if (instance != null)
            Destroy(gameObject);
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel(string level) 
    {
        StartCoroutine(FadeInOut(level));
    }
    IEnumerator FadeInOut(string Level) 
    {
        fadePanel.SetActive(true);
        fadeAnimator.Play("FadeIn");
        yield return StartCoroutine(myCourotine.WaitForRealSeconds(1f));
        Application.LoadLevel(Level);
        fadeAnimator.Play("FadeOut");
        yield return StartCoroutine(myCourotine.WaitForRealSeconds(0.7f));
        fadePanel.SetActive(false);
    }
}
