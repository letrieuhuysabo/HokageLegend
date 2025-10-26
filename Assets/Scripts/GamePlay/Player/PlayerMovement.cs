using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    float xDirection;
    bool facingRight;
    Rigidbody2D rb;
    PlayerAttributes playerAttributes;
    PlayerAnimator playerAnimator;
    PlayerFoot playerFoot;

    public float XDirection { get => xDirection; set => xDirection = value; }

    void Awake()
    {
        xDirection = 0;
        facingRight = transform.localScale.x > 0;
        rb = GetComponent<Rigidbody2D>();
        playerAttributes = GetComponent<PlayerAttributes>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerFoot = transform.Find("Foot").GetComponent<PlayerFoot>();
    }
    void Update()
    {
        // di chuyển trái phải
        if (Input.GetKeyDown(InputConfigs.left) && !DontTakeInput.banInput)
        {
            xDirection = -1;
        }
        else if (Input.GetKeyDown(InputConfigs.right) && !DontTakeInput.banInput)
        {
            xDirection = 1;
        }
        if (Input.GetKeyUp(InputConfigs.left) && xDirection == -1)
        {
            if (Input.GetKey(InputConfigs.right))
            {
                xDirection = 1;
            }
            else
            {
                xDirection = 0;
            }
            
        }
        else if (Input.GetKeyUp(InputConfigs.right) && xDirection == 1)
        {
            if (Input.GetKey(InputConfigs.left))
            {
                xDirection = -1;
            }
            else
            {
                xDirection = 0;
            }
        }
        // flip
        if ((facingRight && xDirection < 0) || (!facingRight && xDirection > 0))
        {
            Flip();
        }
        // jump
        if (Input.GetKeyDown(InputConfigs.up) && !DontTakeInput.banInput)
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        if (xDirection != 0)
        {
            playerAnimator.ChangeAnim("Moving", true);
            rb.AddForce(new Vector2(xDirection, 0) * playerAttributes.characterAttributes.moveSpeed * 1000 * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        else
        {
            playerAnimator.ChangeAnim("Moving", false);
        }
    }
    public void ReCalculateFacingRight()
    {
        facingRight = transform.localScale.x > 0;
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        facingRight = !facingRight;
    }
    public void Jump()
    {
        if (playerFoot.canJump)
        {
            playerFoot.canJump = false;
            rb.AddForce(Vector2.up * playerAttributes.characterAttributes.jumpForce * 100, ForceMode2D.Impulse);
            playerAnimator.ChangeAnim("Jumping",true);
        }
        
    }
}
