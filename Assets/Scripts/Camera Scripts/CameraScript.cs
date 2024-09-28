using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 1f;
    private float accelaration = 0.2f;
    private float maxSpeed = 3.2f;
    private float easySpeed = 3.4f;
    private float mediumSpeed = 3.8f;
    private float hardSpeed = 4.2f;
    [HideInInspector]
    public bool moveCamera;

    void Start()
    {
        if (GamePrefrences.GetEasyDifficultyState() == 1)
            maxSpeed = easySpeed;
        if (GamePrefrences.GetMediumDifficultyState() == 1)
            maxSpeed = mediumSpeed;
        if (GamePrefrences.GetHardDifficultyState() == 1)
            maxSpeed = hardSpeed;
        moveCamera = true;
    }

    void Update()
    {
        if (moveCamera) 
        {
            MoveCamera();
        }
    }
    void MoveCamera() 
    {
        Vector3 Temp = transform.position;
        float OldY = Temp.y;
        float newY = Temp.y - (speed * Time.deltaTime);
        Temp.y = Mathf.Clamp(Temp.y, OldY, newY);
        transform.position = Temp;
        speed += accelaration * Time.deltaTime;
        if (speed > maxSpeed)
            speed = maxSpeed;
    }
}
