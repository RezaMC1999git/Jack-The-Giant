using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private AudioClip coinClip, lifeClip;
    private CameraScript cameraScript;
    private Vector3 previousPosition;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private bool countScore;
    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();     
    }
    void CountScore()
    {
        if (countScore) 
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }
            previousPosition = transform.position;
            GamePlayController.instance.SetScroe(scoreCount);
        }     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) 
        {
            coinCount++;
            scoreCount += 200;
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            GamePlayController.instance.SetCoinScore(coinCount);
            GamePlayController.instance.SetScroe(scoreCount);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Life"))
        {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            GamePlayController.instance.SetLifeScore(lifeCount);
            GamePlayController.instance.SetScroe(scoreCount);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Bounds") || other.CompareTag("Deadly")) 
        {
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            gameManager1.instance.CheckGameStatus(scoreCount, lifeCount, coinCount);
        }
    }
}
