using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Ground Movement")]
    [Tooltip("Movement Speed in Tiles Per Second (1 tile = 1 meter in unity world).")]
    [SerializeField]
    private float speed;
    [Header("Air Movement")]
    [Tooltip("The upward force applied to the player when they jump.")]
    [SerializeField]
    [Range(0, 10)]
    private float jumpForce;
    private Animator animator;
    [SerializeField]
    [Range(0, 10)]
    private float climbSpeed;
    Collider2D[] results = new Collider2D[1];
    Collider2D playerCollider;
    ContactFilter2D ladderFilter;

    private Rigidbody2D playerRigidbody;
    private bool isOnGround = false;
    private bool isFacingRight = true;
    
    public float distance;
    private bool climbing = false;
    public LayerMask ladder;
    // Start is called before the first frame update
    void Start()
    {
        ladderFilter = new ContactFilter2D();
        LayerMask mask = LayerMask.GetMask("LadderTrigger");
        ladderFilter.SetLayerMask(mask);
        ladderFilter.useTriggers = true;
        playerCollider = GetComponent<Collider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //TO DO: MOVE THIS INTO FIXED UPDATE
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);
        float horizontalInput = Input.GetAxis("Horizontal");
        
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);
        if((isFacingRight && horizontalInput < 0) || 
            (!isFacingRight && horizontalInput > 0))
        {
            flip();
        }
        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            
            Jump();
        }
       
        //update our animator system after updating players movement.
        animator.SetFloat("xSpeed", Mathf.Abs(playerRigidbody.velocity.x));
        animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
       animator.SetBool("isOnGround", isOnGround);
        animator.SetBool("isClimbing", climbing);


        //Ladder Climbing
        int numHit = playerCollider.OverlapCollider(ladderFilter, results);
        if(numHit >= 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                climbing = true;
                
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                climbing = false;
            }
        }

        else
        {
            climbing = false;
        }
        Debug.Log($"{climbing}");

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            climbing = false;

        }
        if (climbing == true)
        {
            float verticalInput = Input.GetAxis("Vertical");
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, verticalInput * climbSpeed);
            playerRigidbody.isKinematic = true;
        }
        
        else
        {

            playerRigidbody.isKinematic = false;
        }
        //Restart Level:
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }

    private void FixedUpdate()
    {
        //Physics code in here, not update. 
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        animator.SetTrigger("isJumping");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
