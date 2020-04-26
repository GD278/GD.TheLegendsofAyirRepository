using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Rigidbody2D playerRigidbody;
    private bool isJumping;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);
        if((isFacingRight && horizontalInput < 0) || 
            (!isFacingRight && horizontalInput > 0))
        {
            flip();
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
}
