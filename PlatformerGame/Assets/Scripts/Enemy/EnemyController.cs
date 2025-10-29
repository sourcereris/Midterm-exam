using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private int moveDirection = -1;
    private Rigidbody2D rb;

    [Header("Collision Checks")]
    public Transform CheckWall;
    public Transform CheckCliff;
    public LayerMask whatIsGround;

    private bool isTouchingWall;
    private bool isAtCliffEdge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        isTouchingWall = Physics2D.OverlapCircle(CheckWall.position, .1f, whatIsGround);

        isAtCliffEdge = !Physics2D.OverlapCircle(CheckCliff.position, .1f, whatIsGround);

        if (isTouchingWall || isAtCliffEdge)
        {
            Flip();
        }

        rb.linearVelocity = new Vector2(moveSpeed * moveDirection, rb.linearVelocity.y);
    }

    void Flip()
    {
        moveDirection *= -1;

        transform.Rotate(0f, 180f, 0f);
    }

    void OnDrawGizmos()
    {
        if (CheckWall != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(CheckWall.position, .1f);
        }

        if (CheckCliff != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(CheckCliff.position, .1f);
        }
    }
}