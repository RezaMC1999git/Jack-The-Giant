using UnityEngine;

public class BGScaler : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float width = spriteRenderer.sprite.bounds.size.x;
        float WorldHeight = Camera.main.orthographicSize * 2f;
        float WorldWight = WorldHeight / Screen.height * Screen.width;

        tempScale.x = WorldWight / width;
        transform.localScale = tempScale;
    }
}
