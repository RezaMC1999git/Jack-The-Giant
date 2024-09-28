using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Clouds;
    [SerializeField] private GameObject[] Collectables;
    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float contolX;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        PositionThePlayer();
    }
    private void Awake()
    {
        contolX = 0;
        SetMinAndMaxX();
        CreateClouds();
        Player = GameObject.Find("Jack");
        for(int i = 0; i < Collectables.Length; i++) 
        {
            Collectables[i].SetActive(false);
        }
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
    void Shufflle(GameObject[] ArrayToShuffle)
    {
        for (int i = 0; i < ArrayToShuffle.Length; i++)
        {
            GameObject temp = ArrayToShuffle[i];
            int random = Random.Range(i, ArrayToShuffle.Length);
            ArrayToShuffle[i] = ArrayToShuffle[random];
            ArrayToShuffle[random] = temp;
        }
    }
    void CreateClouds()
    {
        Shufflle(Clouds);
        float PositionY = 0;
        for (int i = 0; i < Clouds.Length; i++)
        {
            Vector3 temp = Clouds[i].transform.position;
            temp.y = PositionY;
            
            if (contolX == 0) 
            {
                temp.x = Random.Range(0.0f, maxX);
                contolX = 1;
            }
            else if(contolX == 1) 
            {
                temp.x = Random.Range(0.0f, minX);
                contolX = 2;
            }
            else if (contolX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                contolX = 3;
            }
            else if (contolX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                contolX = 0;
            }
            lastCloudPositionY = PositionY;
            Clouds[i].transform.position = temp;
            PositionY -= distanceBetweenClouds;
        }
    }
    void PositionThePlayer() 
    {
        GameObject[] DarkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] CloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");
        for(int i = 0; i < DarkClouds.Length; i++) 
        {
            if(DarkClouds[i].transform.position.y == 0) 
            {
                Vector3 t = DarkClouds[i].transform.position;
                DarkClouds[i].transform.position = new Vector3(CloudsInGame[0].transform.position.x,
                                                               CloudsInGame[0].transform.position.y,
                                                               CloudsInGame[0].transform.position.z);
                CloudsInGame[0].transform.position = t;
            }
        }
        Vector3 Temp = CloudsInGame[0].transform.position;
        for(int i = 1; i < CloudsInGame.Length; i++) 
        {
            if (Temp.y < CloudsInGame[i].transform.position.y)
                Temp = CloudsInGame[i].transform.position;
        }
        Temp.y += 0.8f;
        Player.transform.position = Temp;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Cloud") || other.CompareTag("Deadly")) 
        {
            if(other.transform.position.y == lastCloudPositionY) 
            {
                Shufflle(Clouds);
                Shufflle(Collectables);
                Vector3 temp = other.transform.position;
                for(int i = 0; i < Clouds.Length; i++) 
                {
                    if (!Clouds[i].activeInHierarchy) 
                    {
                        if (contolX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            contolX = 1;
                        }
                        else if (contolX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            contolX = 2;
                        }
                        else if (contolX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            contolX = 3;
                        }
                        else if (contolX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            contolX = 0;
                        }
                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        Clouds[i].transform.position = temp;
                        Clouds[i].SetActive(true);

                        int random = Random.Range(0,Collectables.Length);
                        if (Clouds[i].tag !="Deadly") 
                        {
                            if (!Collectables[i].activeInHierarchy) 
                            {
                                Vector3 temp2 = Clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if (Collectables[random].CompareTag("Coin")) 
                                {
                                     Collectables[random].transform.position = temp2;
                                     Collectables[random].SetActive(true);
                                }
                                else 
                                {
                                    Collectables[random].transform.position = temp2;
                                    Collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
