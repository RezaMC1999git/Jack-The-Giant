using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] BackGrounds;
    private float lastY;

    private void Start()
    {
        GetBackGroundAndSetLastY();
    }
    void GetBackGroundAndSetLastY() 
    {
        BackGrounds = GameObject.FindGameObjectsWithTag("BackGround");
        lastY = BackGrounds[0].transform.position.y;
        for (int i = 1 ; i< BackGrounds.Length; i++) 
        {
            if(lastY > BackGrounds[i].transform.position.y) 
            {
                lastY = BackGrounds[i].transform.position.y;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BackGround")) 
        {
            if(other.transform.position.y == lastY) 
            {
                Vector3 Temp = other.transform.position;
                float height = ((BoxCollider2D)other).size.y;
                for(int i = 0; i < BackGrounds.Length; i++) 
                {
                    if (!BackGrounds[i].activeInHierarchy) 
                    {
                        Temp.y -= height;
                        lastY = Temp.y;
                        BackGrounds[i].transform.position = Temp;
                        BackGrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
