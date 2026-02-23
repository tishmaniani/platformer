using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private bool isGrounded;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        sprite.flipX = horizontal < 0 ? true : false;

        rb.linearVelocity = new Vector2(horizontal * _moveSpeed, rb.linearVelocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("На Земле");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Не на земле");
            isGrounded = false;
        }
    }



}
