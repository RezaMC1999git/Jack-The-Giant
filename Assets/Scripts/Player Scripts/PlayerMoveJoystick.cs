using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float moveSpeed = 8f, maxVelocity = 4f;
    private Rigidbody2D myRigidBody;
    private Animator animator;
    private bool moveRight, moveLeft;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (moveLeft)
            MoveLeft();
        if (moveRight)
            MoveRight();
    }
    public void SetMoveLeft(bool moveLeft) 
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }
    public void StopMoving() 
    {
        moveLeft = moveRight = false;
        animator.SetBool("Walk", false);
    }
    void MoveLeft() 
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(myRigidBody.velocity.x);
        if (vel < maxVelocity)
        {
            ForceX = -moveSpeed;
        }
        Vector3 temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;
        animator.SetBool("Walk", true);
        myRigidBody.AddForce(new Vector2(ForceX, 0));
    }
    void MoveRight() 
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(myRigidBody.velocity.x);
        if (vel < maxVelocity)
        {
            ForceX = moveSpeed;
        }
        Vector3 temp = transform.localScale;
        temp.x = 1f;
        transform.localScale = temp;
        animator.SetBool("Walk", true);
        myRigidBody.AddForce(new Vector2(ForceX, 0));
    }
}
