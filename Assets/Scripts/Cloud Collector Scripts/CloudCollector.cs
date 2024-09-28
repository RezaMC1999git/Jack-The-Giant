using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud" || other.tag == "Deadly")
            other.gameObject.SetActive(false);
    }
    
}
