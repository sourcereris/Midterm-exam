using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    private int moveDirection = -1;
    private Rigidbody2D rb;
    private bool isTouchingWall;
    private bool isAtCliffEdge;

    [Header("Collision Checks")]
    public Transform CheckWall;
    public Transform CheckCliff;
    public LayerMask whatIsGround;
    public LayerMask whatIsBox;
    public float PlayerDetectionDistance = 2f;

    public Transform PlayerTransform { get; set; }
    public Animator animator { get; set; }
    GameObject _player;

    public StateMachine StateMachine { get; private set; }
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null) PlayerTransform = _player.transform;
        else Debug.Log("No GameObjec With Tag(\"Player\")");
        
        animator = GetComponent<Animator>();
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
        PlayerTransform = _player.transform;
        StateMachine.PhysicsUpdate();

        //Wall and Cliff Check positions
        isTouchingWall = Physics2D.OverlapCircle(CheckWall.position, .1f, whatIsGround);
        isAtCliffEdge = !Physics2D.OverlapCircle(CheckCliff.position, .1f, whatIsGround);


        //isTouchingWall = Physics2D.OverlapCircle(CheckWall.position, .1f, whatIsBox);
        //isAtCliffEdge = !Physics2D.OverlapCircle(CheckCliff.position, .1f, whatIsBox);

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

        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}