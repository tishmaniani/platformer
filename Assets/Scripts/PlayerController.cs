using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Характеристики персонажа
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    //Проверка касаняния земли игроком
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    //Следование камеры
    


    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, checkRadius, groundLayer);

        if (horizontal != 0)
        {
            sprite.flipX = horizontal < 0;
        }

        rb.linearVelocity = new Vector2(horizontal * _moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, checkRadius);
        }
    }

}
