using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f, maxVelocity = 4f;
    private Rigidbody2D myRigidBody;
    private Animator animator;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(myRigidBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                ForceX = moveSpeed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            animator.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                ForceX = -moveSpeed;
            }
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            animator.SetBool("Walk", true);
        }
        else
            animator.SetBool("Walk", false);
        myRigidBody.AddForce(new Vector2(ForceX, 0));
    }
}
