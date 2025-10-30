using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private int moveDirection = -1;
    private Rigidbody2D rb;

    [Header("Collision Checks")]
    public Transform CheckWall;
    public Transform CheckCliff;
    public LayerMask whatIsGround;
    public float PlayerDetectionDistance = 2f;

    private bool isTouchingWall;
    private bool isAtCliffEdge;
    private bool canSeePlayer;


    public StateMachine StateMachine { get; private set; }
    private void Awake()
    {
        StateMachine = new StateMachine(this);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(StateMachine.IdleState);
    }

    private void Update()
    {
        StateMachine.UpdateState();
    }

    void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();

        //Wall and Cliff Check positions
        isTouchingWall = Physics2D.OverlapCircle(CheckWall.position, .1f, whatIsGround);
        isAtCliffEdge = !Physics2D.OverlapCircle(CheckCliff.position, .1f, whatIsGround);

        //Direction depends on moveDirection value (Left, Right)
        canSeePlayer = false;
        Vector2 direction = new Vector2(moveDirection, 0);

        //Raycast can detect self object (enemy) collider. Proper wall checker position is required
        //Wall Checker is Child of Enemy
        RaycastHit2D playerHit = Physics2D.Raycast(CheckWall.position, direction, PlayerDetectionDistance);


        Debug.DrawRay(CheckWall.position, direction * PlayerDetectionDistance, Color.green);

        if (playerHit.collider != null && playerHit.collider.CompareTag("Player"))
        {
            canSeePlayer = true;
        }

        if (canSeePlayer)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            if (isTouchingWall || isAtCliffEdge)
            {
                Flip();
            }

            rb.linearVelocity = new Vector2(moveSpeed * moveDirection, rb.linearVelocity.y);
        }
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