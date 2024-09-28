using UnityEngine;

public class BGCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BackGround")
            other.gameObject.SetActive(false);
    }
}
