using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    [HideInInspector]
    public bool canJump;
    PlayerAnimator playerAnimator;
    void Awake()
    {
        canJump = true;
        playerAnimator = transform.parent.GetComponent<PlayerAnimator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Land"))
        {
            canJump = true;
            playerAnimator.ChangeAnim("Jumping", false);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Land"))
        {
            canJump = false;
            
        }
    }
}
