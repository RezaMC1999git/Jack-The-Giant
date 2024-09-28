using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;
    void Start()
    {
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < minX) 
        {
            Vector3 Temp = transform.position;
            Temp.x = minX;
            transform.position = Temp;
        }
        if(transform.position.x > maxX) 
        {
            Vector3 Temp = transform.position;
            Temp.x = maxX;
            transform.position = Temp;
        }
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        maxX = bounds.x - 0.3f;
        minX = -bounds.x + 0.3f;
    }
}
