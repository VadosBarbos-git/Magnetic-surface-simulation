using UnityEngine;

public class UpdateGrounded : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsGround;
    public bool isGrounded { get; private set; } = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_whatIsGround.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((_whatIsGround.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
        }
    }

}
